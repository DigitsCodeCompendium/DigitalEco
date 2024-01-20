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
using Eco.Core.Utils;
using Eco.Gameplay.Wires;
using System.Reflection;

namespace Digits.Nuclear
{
    [Serialized, LocDisplayName("Turbine")]
    [RequireComponent(typeof(DigiCustomLiquidConverterComponent))]
    [RequireComponent(typeof(StatusComponent))]
    public class AdvancedTurbineComponent : WorldObjectComponent, IController
    {
        private DigiCustomLiquidConverterComponent converter;
        private StatusElement status;
        private StatusElement status2;
        private StatusElement status3;

        // Rankine cycle variables
        public float inletPressure;
        public float inletTemperature;
        public float inletEnthalpy;
        public float inletEntropy;

        float outletPressure => 1f; // isobaric procces
        float outletTemperature => RankineData.t_from_p_h(outletPressure, outletEnthalpy).Item1;
        float outletEnthalpy => RankineData.h_from_p_s(outletPressure, outletEntropy).Item1;
        float outletEntropy => inletEntropy;

        float powerGenerated;

        public void OnConvert(float amount)
        {
            powerGenerated = (this.inletEnthalpy - this.outletEnthalpy)/amount;
            this.status3.SetStatusMessage(false, Localizer.Format("Power Generated {0} W", Text.Info(powerGenerated)));
        }

        public void Initialize(BlockOccupancyType inputBlockType, BlockOccupancyType outputBlockType)
        {
            this.converter = this.Parent.GetComponent<DigiCustomLiquidConverterComponent>();
            this.status = this.Parent.GetComponent<StatusComponent>().CreateStatusElement();
            this.status2 = this.Parent.GetComponent<StatusComponent>().CreateStatusElement();
            this.status3 = this.Parent.GetComponent<StatusComponent>().CreateStatusElement();

            this.converter.Setup(typeof(HighPressureSteamItem), typeof(LowPressureSteamItem), inputBlockType, outputBlockType, 10f, 0f);
            this.converter.OnConvert += OnConvert;
        }

        public override void Tick()
        {
            this.status.SetStatusMessage(false, Localizer.Format("InletTemp {0}, InletPressure {1}, InletEnthalpy {2}, InletEntropy {3}", Text.Info(this.inletTemperature), Text.Info(this.inletPressure), Text.Info(this.inletEnthalpy), Text.Info(this.inletEntropy)));
            this.status2.SetStatusMessage(false, Localizer.Format("OutletTemp {0}, OutletPressure {1}, OutletEnthalpy {2}, OutletEntropy {3}", Text.Info(this.outletTemperature), Text.Info(this.outletPressure), Text.Info(this.outletEnthalpy), Text.Info(this.outletEntropy)));
            

            //doing weird shit
            Type type = typeof(WireConnection);
            FieldInfo fieldInfo = type.GetField("<WireRefs>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance);

            ThreadSafeList<WeakReference<WireConnection>> value = (ThreadSafeList<WeakReference<WireConnection>>)fieldInfo.GetValue(this.Parent.GetComponent<DigiCustomLiquidConverterComponent>().producer.OutputPipe);

            if (value is ThreadSafeList<WeakReference<WireConnection>> threadSafeList)
            {
                foreach (var thing in threadSafeList.Refs())
                {
                    if (thing.Owner is CondenserObject)
                    {
                        thing.Owner.GetComponent<AdvancedCondenserComponent>().inletTemperature = this.outletTemperature;
                        thing.Owner.GetComponent<AdvancedCondenserComponent>().inletPressure = this.outletPressure;
                        thing.Owner.GetComponent<AdvancedCondenserComponent>().inletEnthalpy = this.outletEnthalpy;
                        thing.Owner.GetComponent<AdvancedCondenserComponent>().inletEntropy = this.outletEntropy;
                    }
                }
            }
        }
    }
}
