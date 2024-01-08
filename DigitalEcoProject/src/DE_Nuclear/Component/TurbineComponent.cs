using System;
using System.Collections.Generic;
using System.ComponentModel;
using Eco.Gameplay.Components;
using Eco.Gameplay.Objects;
using Eco.Gameplay.Occupancy;
using Eco.Gameplay.Pipes.LiquidComponents;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;
using Eco.Shared.Utils;
using Eco.Core.Controller;
using Eco.Mods.TechTree;

namespace Digits.Nuclear
{
    [Serialized, LocDisplayName("Turbine")]
    [RequireComponent(typeof(LiquidConverterComponent))]
    [RequireComponent(typeof(PowerGridComponent))] 
    [RequireComponent(typeof(StatusComponent))]
    public class TurbineComponent : WorldObjectComponent, IController
    {
        
        private LiquidConverterComponent converter;
        private PowerGridComponent grid;
        private StatusElement status;

        private float powerPerFlow;
        private float maximumFlow;
        private float minimumFlow;
        
        public double buffer;
        public float temperature;

        public void Initialize(float powerPerFlow, float maximumFlow, float minimumFlow)
        {
            this.powerPerFlow = powerPerFlow;
            this.maximumFlow = maximumFlow;
            this.minimumFlow = minimumFlow;
            this.buffer = 0;

            this.converter = this.Parent.GetComponent<LiquidConverterComponent>();
            this.grid = this.Parent.GetComponent<PowerGridComponent>();
            this.status = this.Parent.GetComponent<StatusComponent>().CreateStatusElement();

            this.converter.Setup(typeof(SteamItem), typeof(WaterItem), BlockOccupancyType.WaterInputPort, BlockOccupancyType.OutputPort, this.maximumFlow, 0f);
            this.converter.In.BufferSize = maximumFlow;
            this.converter.OnConvert += this.Converted;

            this.grid.Initialize(10, new ElectricPower()); 
        }

        void Converted(float amount)
        {
            // float producing = this.powerPerFlow * amount;

            // if(amount <= this.maximumFlow && amount >= this.minimumFlow)
            // {
            //     this.grid.EnergySupply = producing; 
            //     //this.status.SetStatusMessage(true, Localizer.Format("Currently producing {0}w with a flow of {1} steam. Buffer is {2}", Text.Info(producing), Text.Info(amount), Text.Info(this.buffer)));
            // }
            // else if(amount < this.minimumFlow)
            // {
            //     this.grid.EnergySupply = 0;
            //     //this.status.SetStatusMessage(false, Localizer.Format("Currently producing {0}w with a flow of {1} steam. Too little steam is being passed into the turbine! Buffer is {2}", Text.Info(0), Text.Info(amount), Text.Info(this.buffer)));
            // }

            this.buffer += amount;
        }

        public override void Tick()
        {   
            if(this.buffer > 0){
                this.buffer -= 0.01 * Math.Pow(buffer,2);
            } else if(this.buffer - 0.1 < 0){
                this.buffer = 0;
            }
        
            double output = (double)this.powerPerFlow * this.buffer;
            this.grid.EnergySupply = (float)output;

            this.status.SetStatusMessage(false, Localizer.Format("Buffer {0}, Power Output {1}, Temperature {2}", Text.Info(this.buffer), Text.Info(output), Text.Info(temperature)));
        }


    }
}
