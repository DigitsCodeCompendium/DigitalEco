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
using Eco.Shared.Utils;

namespace Digits.Nuclear
{
    // Converts one liquid type to another when triggered
    [Serialized]
    [RequireComponent(typeof(FluidTankConsumerComponent), "ConvertorIn")]
    [RequireComponent(typeof(FluidTankProducerComponent), "ConvertorOut")]
    [RequireComponent(typeof(StatusComponent))]
    [Ecopedia(null, "Pipe Component"), NoIcon]
    public class FluidTankComponent : WorldObjectComponent, IController
    {
        public event Action<float> OnConvert; // Called when the component performs a conversion

        public float fluidAmount;

        private bool enabled = true;
        private float maxCanReceive;
        Type fluidType;
        public FluidTankProducerComponent producer;
        public FluidTankConsumerComponent consumer;
        StatusElement status;

        public override bool Enabled => this.enabled;

        public event Func<bool> ShouldConvertLiquid;
        public FluidTankConsumerComponent In => this.consumer;
        public FluidTankProducerComponent Out => this.producer;



        public void Setup(Type fluidType, BlockOccupancyType inputBlockType, BlockOccupancyType outputBlockType, float consumptionRate = 1f, float requiredFlow = .9f)
        {
            // Setup the input and output.
            this.fluidType = fluidType;
            this.producer = this.Parent.GetComponent<FluidTankProducerComponent>("ConvertorOut");
            this.consumer = this.Parent.GetComponent<FluidTankConsumerComponent>("ConvertorIn");

            this.producer.Setup(fluidType, consumptionRate, outputBlockType);
            this.producer.OnProduced += OnProduced;
            this.producer.CanProduce += CanProduce;

            this.consumer.Setup(fluidType, consumptionRate, inputBlockType, requiredFlow, this);
            this.consumer.ShouldConsumeLiquid = () => this.ShouldConvertLiquid?.Invoke() ?? true;
            this.status = this.Parent.GetComponent<StatusComponent>().CreateStatusElement();
        }

        private bool CanProduce(float amount)
        {
            return this.fluidAmount > amount;
        }

        private void OnProduced(float amount)
        {
            if (this.fluidAmount - amount > 0)
                this.fluidAmount -= amount;
            else
                this.fluidAmount = 0;
        }

        public void AdjustConsumptionRate(float rate)
        {
            this.consumer.constantConsumptionRate = rate;
        }
        public void AdjustProductionRate(float rate)
        {
            this.producer.constantProductionRate = rate;
        }

        internal float Convert(PipePayload input)
        {
            if (this.ShouldConvertLiquid?.Invoke() ?? true)
            {
                
                var convertedAmount = input.Amount;//this.producer.Produce(input.Amount, input.Time);
                if (convertedAmount > 0)
                    this.OnConvert?.Invoke(convertedAmount);
                this.fluidAmount += convertedAmount;
                return convertedAmount;
            }
            return 0;
        }

        public override void LateTick()
        {
            this.maxCanReceive = -1f;
            this.status.SetStatusMessage(true, Localizer.Format("Fluid in tank: {0}", Text.Info(this.fluidAmount)));
            this.enabled = true;
        }

        #region IController
        private int controllerID;
        ref int IHasUniversalID.ControllerID => ref this.controllerID;
        #endregion
    }
}

