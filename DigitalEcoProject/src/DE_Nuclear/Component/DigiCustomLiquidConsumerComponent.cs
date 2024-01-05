using System;
using System.Collections.Generic;
using System.Threading;
using Eco.Core.Controller;
using Eco.Core.Utils;
using Eco.Core.Items;
using Eco.Gameplay.Components;
using Eco.Gameplay.Items;
using Eco.Gameplay.Objects;
using Eco.Gameplay.Systems.TextLinks;
using Eco.Gameplay.Wires;
using Eco.Shared.IoC;
using Eco.Shared.Localization;
using Eco.Shared.Utils;
using Eco.Shared.Math;
using Eco.Shared.Serialization;
using Eco.Core.Systems;
using Eco.Gameplay.Occupancy;
using Eco.Gameplay.Pipes.LiquidComponents;
using Eco.Gameplay.Pipes;

namespace Digits.Nuclear
{
    // Consumes what's in the tank
    [Serialized, AutogenClass, LocDisplayName("Pipes"), NoIcon]
    [Ecopedia(null, "Pipe Component")]
    public class DigiCustomLiquidConsumerComponent : WorldObjectComponent, IController, IWireContainer
    {
        private const float MaxAllowedNotConverted = 0.001f;                    // maximum amount which allows consumer to function without being converted

        private readonly object syncRoot = new object();

        private float amountWanted = -1f;
        private float amountToReceive = -1f;
        private float maxCanReceive = -1f;
        private float thisTickNotConverted;
        private float pendingNotConverted;

        public override WorldObjectComponentClientAvailability Availability => WorldObjectComponentClientAvailability.UI;

        [SyncToView] public override string IconName => nameof(PipeComponent);

        [Serialized] public Ray InputPosDir { get; set; }
        [SyncToView, Autogen, UITypeName("PipeInput")] public WireInput InputPipe { get; private set; }
        public override bool Enabled => this.enabled;

        [Serialized] float toConsume; // Amount we will consume, reducing this till zero.
        public float constantConsumptionRate; // We will consumer up to this much by default per request.
        float percentRequiredFlow; // The percent of max consumption that must be maintained to be enabled.
        private float thisTickConsumed; // Consumed this tick, will be saved in LateTick as LastTickReceived
        private DigiCustomLiquidConverterComponent converter; // optional converter which may be used to convert consumed liquid

        public float BufferSize { get; set; } // if object isn't operating we still can accumulate some amount up to bufferSize
        public float BufferAmount { get; private set; } // current amount in buffer
        public float LastTickConsumed { get; private set; } // consumed last tick

        public Type AcceptedType { get; private set; }
        public ThreadSafeAction<Type, float> OnConsumed = new ThreadSafeAction<Type, float>();
        public event Func<Type, float> OnCanReceive;
        public Func<bool> ShouldConsumeLiquid;

        bool enabled;
        StatusElement status;
        OnOffComponent onOffComp;

        BlockOccupancyType cacheBlockType;

        public IEnumerable<WireConnection> Wires { get { yield return this.InputPipe; } }

        public void Setup(Type acceptedType, float consumptionRate, BlockOccupancyType blockOccupancyType, float percentRequiredFlow, DigiCustomLiquidConverterComponent converter = null)
        {
            this.percentRequiredFlow = percentRequiredFlow;
            this.AcceptedType = acceptedType;
            this.constantConsumptionRate = consumptionRate;
            this.InputPosDir = this.Parent.GetOccupancyType(blockOccupancyType);

            this.status = this.Parent.GetComponent<StatusComponent>().CreateStatusElement();
            this.LiquidName = Item.Get(this.AcceptedType).UILink();
            this.InputPipe = WireInput.CreatePipeInput(this.Parent, Localizer.Do($"{this.LiquidName} Input"), this.InputPosDir, this.MaxCanReceive, payload => this.Consume(payload, true));
            this.InputPipe.TrackFlow(new PipePayload(acceptedType, 0f, 1f));
            this.onOffComp = this.Parent.GetComponent<OnOffComponent>();
            this.converter = converter;
            //this.ForceActiveTab = true; // We don't need to hide the tab since it has useful info for the player even when status disabled.
            this.cacheBlockType = blockOccupancyType;
        }

        public override void OnAfterObjectMoved()
        {
            this.InputPosDir = this.Parent.GetOccupancyType(this.cacheBlockType); // Update ray pos.
            this.InputPipe.UpdateRayPosition(this.InputPosDir);
        }

        public void QueueConsume(float amount) => this.toConsume += amount;

        /// <summary> Max (potential) amount of items with <paramref name="itemType"/> which can be received. </summary>
        private float MaxCanReceive(Type itemType) => this.AcceptedType == itemType ? Math.Min(this.EnsureMaxCanReceive(), this.EnsureAmountWanted()) : 0f;

        /// <summary> Consumes <paramref name="input"/> optionally using buffer if <paramref name="useBuffer"/> set. If buffer used then all non instantly consumed capacity will go to the buffer. </summary>
        private float Consume(PipePayload input, bool useBuffer)
        {
            if (input.Amount < WireConnection.MinFlow) return 0f; // ignore input with no amount

            if (!this.TryFlush(input.Time)) return 0f; // try to flush not converted amount to converter, if fails then stop consuming
            if (!this.Parent.Enabled) return 0f; // ignore input if parent not enabled
            return this.ConsumeUnchecked(input, useBuffer);
        }

        /// <summary> Flushed all non-converted amount to converter. Returns <c>false</c> if converter can't accept it. </summary>
        private bool TryFlush(float time)
        {
            if (this.pendingNotConverted >= WireConnection.MinFlow)
            {
                lock (this.syncRoot)
                {
                    // can't flush if already have non converted liquid (from previously failed flush attempt)
                    if (this.thisTickNotConverted >= WireConnection.MinFlow) return false;
                    // try to convert pending unconverted amount
                    this.pendingNotConverted -= this.converter.Convert(new PipePayload(this.AcceptedType, this.pendingNotConverted, time));
                    // and add everything not converted to this tick
                    InterlockedUtils.Add(ref this.thisTickNotConverted, this.pendingNotConverted);
                }
                // check if still has pending non converted amount
                return this.pendingNotConverted < MaxAllowedNotConverted;
            }

            return true;
        }

        /// <summary> Same as <see cref="Consume"/>, but without cycles check. </summary>
        private float ConsumeUnchecked(PipePayload input, bool useBuffer)
        {
            this.EnsureAmountWanted(); // ensure amount wanted calculated, because it may be called first time before LateTick
            var consumedQuantity = InterlockedUtils.SubMinNonNegative(ref this.amountToReceive, input.Amount);
            if (consumedQuantity < WireConnection.MinFlow)
                return 0;

            // apply consumed amount
            InterlockedUtils.SubMinNonNegative(ref this.toConsume, consumedQuantity);
            this.OnConsumed?.Invoke(input.ItemType, consumedQuantity);
            this.thisTickConsumed = consumedQuantity;

            // if converter is set then pass consumed amount to it and update non consumed amount
            if (this.converter != null)
            {
                var notConverted = consumedQuantity - this.converter.Convert(input.WithAmount(consumedQuantity));
                if (notConverted >= WireConnection.MinFlow)
                    InterlockedUtils.Add(ref this.thisTickNotConverted, notConverted);
            }

            // save non consumed amount to the buffer, buffer will be consumed in Tick as extra source of liquid when pipe input not available
            if (useBuffer && consumedQuantity < input.Amount)
            {
                var bufferAvailable = this.BufferSize - this.BufferAmount;
                if (bufferAvailable <= 0.0f) return consumedQuantity;
                var bufferedQuantity = Math.Min(bufferAvailable, input.Amount - consumedQuantity);
                this.BufferAmount += bufferedQuantity;
                consumedQuantity += bufferedQuantity;
            }

            return consumedQuantity;
        }

        public override void Tick()
        {
            this.EnsureAmountWanted(); // ensure amount wanted calculated for LateTick
            var tickTime = ServiceHolder<IWorldObjectManager>.Obj.TickDeltaTime;
            // try to flush pending non converted liquid
            if (!this.TryFlush(tickTime)) return;

            // supply consumer from buffer (if not empty)
            if (this.BufferAmount >= WireConnection.MinFlow && this.Parent.Operating)
                this.BufferAmount -= this.Consume(new PipePayload(this.AcceptedType, this.BufferAmount, tickTime), false);
        }

        public LocString LiquidName { get; private set; }

        public override void LateTick()
        {
            this.UpdateStatus();

            this.LastTickConsumed = this.thisTickConsumed;
            this.thisTickConsumed = 0f;
            this.pendingNotConverted = this.thisTickNotConverted;
            this.thisTickNotConverted = 0f;
            // reset amountWanted and amountToReceive so it will be recalculated for next tick
            this.amountToReceive = -1f;
            this.amountWanted = -1f;
            this.maxCanReceive = -1f;
        }

        /// <summary> Enables/disables component and updates status. </summary>
        private void SetEnabled(bool enabled, LocString message)
        {
            this.status.SetStatusMessage(enabled, message);
            this.enabled = enabled;
        }

        private void UpdateStatus()
        {
            var tickTime = ServiceHolder<IWorldObjectManager>.Obj.TickDeltaTime;
            // Update status in LateTick when all liquid was consumed
            this.InputPipe.UpdateStatus(tickTime);

            if (this.pendingNotConverted >= MaxAllowedNotConverted)
            {
                this.SetEnabled(false, Localizer.Do($"The output pipe can't handle pending amount of {this.converter.Out.LiquidName} converted from {this.LiquidName}. It causes temporary or permanent issues."));
                return;
            }

            if (this.InputPipe.IsDisconnected)
            {
                var needLiquid = this.amountWanted > WireConnection.MinFlow;
                this.status.SetStatusMessage(!needLiquid, Localizer.Do($"{this.InputPipe.Name} pipe is disconnected, but not currently needed."), Localizer.Do($"{this.InputPipe.Name} pipe is disconnected."));
                this.enabled = !needLiquid;
                return;
            }

            if (this.amountWanted < WireConnection.MinFlow)
            {
                this.SetEnabled(true, Localizer.Do($"{this.InputPipe.Name} pipe connected, {this.LiquidName} not currently needed."));
                return;
            }

            // using available flow for checks instead of actual flow, otherwise consumer never enabled because disabled table can't receive liquid
            var averageFlow = Math.Min(this.InputPipe.AvailableFlow.Average, this.constantConsumptionRate);
            // check if has enough flow
            if (averageFlow < this.constantConsumptionRate * this.percentRequiredFlow)
            {
                var maxCanReceiveFlow = this.EnsureMaxCanReceive() / tickTime;
                LocString flowInfo;
                if (this.converter == null || Math.Abs(maxCanReceiveFlow - averageFlow) > 0.001f)
                    flowInfo = averageFlow >= 0.001f
                        ? Localizer.Do($"{this.LiquidName} flow available at {Text.Negative(averageFlow.ToString("0.###"))} liters per second")
                        : Localizer.Do($"No {this.LiquidName} flow available.");
                else
                    flowInfo = maxCanReceiveFlow >= 0.001f
                        ? Localizer.Do($"Output {this.converter.Out.LiquidName} flow available at {Text.Negative(averageFlow.ToString("0.###"))} liters per second")
                        : Localizer.Do($"Output {this.converter.Out.LiquidName} flow not available");

                this.SetEnabled(false, Localizer.Do($"{flowInfo}, must be at least {Text.StyledNum(this.constantConsumptionRate * this.percentRequiredFlow)} liters per second."));
                return;
            }

            this.enabled = true;
            if (averageFlow > 0)
                this.status.SetStatusMessage(true, Localizer.Do($"{this.LiquidName} flow available at {Text.Positive(averageFlow.ToString("0.###"))} (of max {Text.Positive(this.constantConsumptionRate.ToString("0.###"))}) liters per second."));
            else this.status.Clear();
        }

        /// <summary> Calculates max potentially possible amount to receive. Actual consumed amount may be lower depending on consumer state (disabled, output limited etc). </summary>
        private float CalculateMaxAmount(float time) => (this.constantConsumptionRate * time) + this.toConsume;

        private float EnsureMaxCanReceive()
        {
            var currentValue = this.maxCanReceive;
            if (currentValue >= 0f) return currentValue;
            var maxCanReceive = this.OnCanReceive?.Invoke(this.AcceptedType) ?? float.MaxValue;
            Interlocked.CompareExchange(ref this.maxCanReceive, maxCanReceive, currentValue);
            return this.maxCanReceive;
        }

        /// <summary> Ensures wanted amount calculated. </summary>
        private float EnsureAmountWanted()
        {
            var currentValue = this.amountWanted;
            if (currentValue >= 0f) return currentValue;

            float amountWanted;
            if ((this.onOffComp?.On ?? true) && (this.ShouldConsumeLiquid?.Invoke() ?? true))
                amountWanted = this.CalculateMaxAmount(ServiceHolder<IWorldObjectManager>.Obj.TickDeltaTime);
            else
                amountWanted = 0f;

            // ReSharper disable once CompareOfFloatsByEqualityOperator
            if (Interlocked.CompareExchange(ref this.amountToReceive, amountWanted, currentValue) == currentValue)
                this.amountWanted = amountWanted;
            return this.amountWanted;
        }

        #region IController
        private int controllerID;
        ref int IHasUniversalID.ControllerID => ref this.controllerID;
        #endregion
    }
}
