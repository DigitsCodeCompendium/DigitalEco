using System;
using System.Threading;
using Eco.Core.Controller;
using Eco.Core.Items;
using Eco.Core.Systems;
using Eco.Gameplay.Components;
using Eco.Gameplay.Objects;
using Eco.Gameplay.Occupancy;
using Eco.Gameplay.Pipes;
using Eco.Gameplay.Pipes.LiquidComponents;
using Eco.Shared.Localization;
using Eco.Shared.Math;
using Eco.Shared.Serialization;

namespace Digits.Nuclear
{
    // Converts one liquid type to another when triggered
    [Serialized]
    [RequireComponent(typeof(DigiCustomLiquidConsumerComponent), "ConvertorIn")]
    [RequireComponent(typeof(LiquidProducerComponent), "ConvertorOut")]
    [Ecopedia(null, "Pipe Component"), NoIcon]
    public class DigiCustomLiquidConverterComponent : WorldObjectComponent, IController, IDisposable
    {
        private readonly ThreadLocal<bool> calculatingMaxCanReceive = new ThreadLocal<bool>(); // Prevent loops when checking pipe flow.

        public event Action<float> OnConvert; // Called when the component performs a conversion

        private bool enabled = true;
        private bool cyclicPipe;
        private float maxCanReceive;
        Type receivesType;
        Type outputsType;
        public LiquidProducerComponent producer;
        public DigiCustomLiquidConsumerComponent consumer;
        StatusElement status;

        public override bool Enabled => this.enabled;

        public event Func<bool> ShouldConvertLiquid;
        public DigiCustomLiquidConsumerComponent In => this.consumer;
        public LiquidProducerComponent Out => this.producer;

        public void Setup(Type inputType, Type outputsType, BlockOccupancyType inputBlockType, BlockOccupancyType outputBlockType, float consumptionRate = 1f, float requiredFlow = .9f)
        {
            // Setup the input and output.
            this.receivesType = inputType;
            this.outputsType = outputsType;
            this.producer = this.Parent.GetComponent<LiquidProducerComponent>("ConvertorOut");
            this.consumer = this.Parent.GetComponent<DigiCustomLiquidConsumerComponent>("ConvertorIn");

            this.producer.Setup(outputsType, 0, outputBlockType);

            this.consumer.Setup(inputType, consumptionRate, inputBlockType, requiredFlow, this);
            this.consumer.OnCanReceive += this.OnCanReceive;
            this.consumer.ShouldConsumeLiquid = () => true;
            this.status = this.Parent.GetComponent<StatusComponent>().CreateStatusElement();
        }

        public void adjustConsumptionRate(float rate)
        {
            this.consumer.constantConsumptionRate = rate;
        }

        internal float Convert(PipePayload input)
        {
            if (this.ShouldConvertLiquid.Invoke())
            {
                var convertedAmount = this.producer.Produce(input.Amount, input.Time);
                if (convertedAmount > 0)
                    this.OnConvert?.Invoke(convertedAmount);
                return convertedAmount;
            }
            return 0;
        }

        private float EnsureMaxCanReceive()
        {
            var currentValue = this.maxCanReceive;
            if (currentValue >= 0f) return currentValue;

            var amountWanted = this.CalculateMaxCanReceive();
            Interlocked.CompareExchange(ref this.maxCanReceive, amountWanted, currentValue);
            return this.maxCanReceive;
        }

        private float CalculateMaxCanReceive()
        {
            if (this.calculatingMaxCanReceive.Value)
            {
                this.cyclicPipe = true;
                return 0;
            }
            if (!this.ShouldConvertLiquid?.Invoke() ?? false) return 0;

            this.calculatingMaxCanReceive.Value = true;
            try
            {
                this.producer.OutputPipe.UpdateIfNeeded();
                return this.producer.OutputPipe.MaxCanReceive(this.outputsType);
            }
            finally
            {
                this.calculatingMaxCanReceive.Value = false;
            }
        }

        // Propagate it to the receiver
        public float OnCanReceive(Type itemType)
        {
            if (itemType != this.receivesType) return 0;
            return this.EnsureMaxCanReceive();
        }

        public override void LateTick()
        {
            this.maxCanReceive = -1f;
            if (this.cyclicPipe)
            {
                this.cyclicPipe = false;
                this.enabled = false;
                this.status.SetStatusMessage(false, Localizer.Do($"{this.consumer.LiquidName} can't flow, because the output {this.producer.LiquidName} flow back to the input pipe."));
                return;
            }

            this.status.Clear();
            this.enabled = true;
        }

        #region IController
        private int controllerID;
        ref int IHasUniversalID.ControllerID => ref this.controllerID;
        #endregion

        public void Dispose() => this.calculatingMaxCanReceive.Dispose();
    }
}
