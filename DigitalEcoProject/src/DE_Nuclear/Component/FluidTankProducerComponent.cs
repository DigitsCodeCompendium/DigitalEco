// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.

namespace Eco.Gameplay.Pipes.LiquidComponents
{
    using System;
    using System.Collections.Generic;
    using Eco.Core.Controller;
    using Eco.Core.Items;
    using Eco.Core.Systems;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Objects;
    using Eco.Gameplay.Occupancy;
    using Eco.Gameplay.Pipes.Gases;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Gameplay.Wires;
    using Eco.Shared.IoC;
    using Eco.Shared.Localization;
    using Eco.Shared.Math;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    using Eco.Simulation.Settings;

    // Consumes what's in the tank
    [Serialized, AutogenClass, LocDisplayName("Pipes"), NoIcon, LocDescription("View the input and output pipes to this object.")]
    [Ecopedia(null, "Pipe Component")]
    [RequireComponent(typeof(AttachmentComponent))]
    public class FluidTankProducerComponent : WorldObjectComponent, IController, IWireContainer, IPolluter
    {
        public override WorldObjectComponentClientAvailability Availability => WorldObjectComponentClientAvailability.UI;

        [SyncToView] public override string IconName => nameof(PipeComponent);
        public LocString LiquidName { get; private set; }

        [SyncToView, Autogen, UITypeName("PipeOutput")] public WireOutput OutputPipe { get; private set; }
        public float constantProductionRate;
        Type producesType;

        StatusElement status;

        BlockOccupancyType cacheBlockType;

        public event Func<float, bool> CanProduce;
        public event Action<float> OnProduced;

        public IEnumerable<WireConnection> Wires { get { yield return this.OutputPipe; } }

        public void Setup(Type producesType, float productionRate, BlockOccupancyType blockOccupancyType)
        {
            this.producesType = producesType;
            this.constantProductionRate = productionRate;
            this.status = this.Parent.GetComponent<StatusComponent>().CreateStatusElement();
            this.LiquidName = Item.Get(producesType).UILink();
            this.OutputPipe = new WireOutput(this.Parent, typeof(PipeBlock), this.Parent.GetOccupancyType(blockOccupancyType), Localizer.Do($"{this.LiquidName} Output"));
            this.OutputPipe.TrackFlow(new PipePayload(producesType, 0f, 1f));
            this.cacheBlockType = blockOccupancyType;

            this.Parent.OnOperatingChange.Add(() =>
            {
                if (!this.Parent.Operating)
                    this.OutputPipe.StopSendingItems();
            });
        }

        public override void OnAfterObjectMoved() => this.OutputPipe.UpdateRayPosition(this.Parent.GetOccupancyType(this.cacheBlockType)); // Update ray pos.

        public override void Destroy()
        {
            base.Destroy();
            this.OutputPipe?.Destroy();
        }

        public float Produce(float quantity, float time) => this.OutputPipe.SendItem(new PipePayload(this.producesType, quantity, time));

        public override void Tick()
        {
            float amount = this.constantProductionRate;
            float num = 0;
            if (this.Parent.Operating && this.Parent.Enabled && this.constantProductionRate != 0 && this.CanProduce.Invoke(amount))
            {
                num = this.OutputPipe.SendItem(new PipePayload(this.producesType, amount * ServiceHolder<IWorldObjectManager>.Obj.TickDeltaTime, ServiceHolder<IWorldObjectManager>.Obj.TickDeltaTime));
            }
            this.OnProduced?.Invoke(num);
        }

        public override void LateTick() => this.OutputPipe.UpdateStatus(ServiceHolder<IWorldObjectManager>.Obj.TickDeltaTime);

        public float GetPollutionTonsPerHour()
        {
            if (this.producesType == typeof(SmogItem))
                return this.constantProductionRate * SmogItem.PollutionTonsPerSmogItem * TimeUtil.SecondsPerHour * EcoDef.Obj.ClimateSettings.PollutionMultiplier;
            return 0f;
        }

        #region IController
        private int controllerID;
        ref int IHasUniversalID.ControllerID => ref this.controllerID;
        #endregion
    }
}
