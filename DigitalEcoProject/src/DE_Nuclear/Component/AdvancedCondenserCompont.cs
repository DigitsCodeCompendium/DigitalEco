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
    [Serialized, LocDisplayName("Condenser")]
    [RequireComponent(typeof(DigiCustomLiquidConverterComponent))]
    [RequireComponent(typeof(StatusComponent))]
    public class AdvancedCondenserComponent : WorldObjectComponent, IController
    {
        private DigiCustomLiquidConverterComponent converter;
        private StatusElement status;

        // Rankine cycle variables
        public float inletPressure;
        public float inletTemperature;
        public float inletEnthalpy;
        public float inletEntropy;

        float outletPressure => 10f; // isobaric procces
        float outletTemperature => 180f; // => s_from_p_h(outletPressure, outletEnthalpy)
        float outletEnthalpy => 763.3682f;    // => inletEnthalpy + added_heat
        float outletEntropy => 2.1417f;     // => s_from_p_h(outletPressure, outletEnthalpy)

        public void Initialize()
        {
            this.converter = this.Parent.GetComponent<DigiCustomLiquidConverterComponent>();
            this.status = this.Parent.GetComponent<StatusComponent>().CreateStatusElement();

            this.converter.Setup(typeof(LowPressureSteamItem), typeof(WaterItem), BlockOccupancyType.WaterInputPort, BlockOccupancyType.OutputPort, 10f, 0f);
        }

        public override void Tick()
        {   
            this.status.SetStatusMessage(false, Localizer.Format("InletTemp {0}, InletPressure {1}, OutletTemp {2}, OutletPressure {3}", 
                                        Text.Info(this.inletTemperature), Text.Info(this.inletPressure), Text.Info(this.outletTemperature), Text.Info(this.outletPressure)));
        }
    }
}
