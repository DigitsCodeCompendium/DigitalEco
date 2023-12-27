namespace Eco.Mods.TechTree
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using Eco.Core.Items;
    using Eco.Gameplay.Blocks;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.Components.Auth;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Economy;
    using Eco.Gameplay.Housing;
    using Eco.Gameplay.Interactions;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Modules;
    using Eco.Gameplay.Minimap;
    using Eco.Gameplay.Objects;
    using Eco.Gameplay.Occupancy;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Property;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Gameplay.Pipes.LiquidComponents;
    using Eco.Gameplay.Pipes.Gases;
    using Eco.Shared;
    using Eco.Shared.Math;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    using Eco.Shared.View;
    using Eco.Shared.Items;
    using Eco.Shared.Networking;
    using Eco.Gameplay.Pipes;
    using Eco.World.Blocks;
    using Eco.Gameplay.Housing.PropertyValues;
    using Eco.Gameplay.Civics.Objects;
    using Eco.Gameplay.Settlements;
    using Eco.Gameplay.Systems.NewTooltip;
    using Eco.Core.Controller;
    using Eco.Core.Utils;
	using Eco.Gameplay.Components.Storage;
    using Eco.Gameplay.Items.Recipes; 

    [Serialized]
    [LocDisplayName("Reactor Component")]
    [RequireComponent(typeof(LiquidConverterComponent))]
    //[RequireComponent(typeof(PowerGridComponent))] 
    [RequireComponent(typeof(StatusComponent))]
    [RequireComponent(typeof(FuelSupplyComponent))]
    [RequireComponent(typeof(FuelConsumptionComponent))]

    public class ReactorComponent : WorldObjectComponent, IController
    {
        private LiquidConverterComponent converter;
        private StatusElement status;

        private float maxTemp;
        private float minTemp;
        private float nomTemp;
        private float currentTemp;
        private float maximumFlow;
        private int ticksSinceLastConvert;

        public void Initialize(float maxTemp, float nomTemp, float maximumFlow)
        {
            this.minTemp = 20;
            this.currentTemp = minTemp;

            this.maxTemp = maxTemp;
            this.maximumFlow = maximumFlow;
            
            this.converter = this.Parent.GetComponent<LiquidConverterComponent>();
            this.status = this.Parent.GetComponent<StatusComponent>().CreateStatusElement();

            this.converter.Setup(typeof(WaterItem), typeof(SteamItem),
                                BlockOccupancyType.InputPort,
                                BlockOccupancyType.OutputPort);
            this.converter.In.BufferSize = maximumFlow;
            this.converter.OnConvert += this.Converted;
        }

        void Converted(float amount)
        {

        }

        public override void Tick()
        {
            // if (currentTemp < nomTemp) 
            // { this.converter.In.ShouldConsumeLiquid = false; }
            // else if (currentTemp >= nomTemp) 
            // { this.converter.In.ShouldConsumeLiquid = true;}

            this.status.SetStatusMessage(false, Localizer.Format("Reactor is currently {0} degrees C", Text.Info(currentTemp)));

            if (this.Parent.GetComponent<OnOffComponent>().On && currentTemp <= maxTemp)
            {
                currentTemp += 10;
            }
            else if (!this.Parent.GetComponent<OnOffComponent>().On && currentTemp >= minTemp)
            {
                currentTemp -= 1;
            }
        }
    }
}
