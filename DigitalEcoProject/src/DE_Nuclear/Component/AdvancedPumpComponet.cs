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
    [Serialized, LocDisplayName("Pump")]
    [RequireComponent(typeof(DigiCustomLiquidConverterComponent))]
    [RequireComponent(typeof(StatusComponent))]
    public class AdvancedPumpComponent : WorldObjectComponent, IController
    {
        private DigiCustomLiquidConverterComponent converter;
        private StatusElement status;
        private StatusElement status2;

        // Rankine cycle variables
        float inletPressure = 1;
        float inletTemperature => RankineData.sat_t_from_p(inletPressure);
        float inletEnthalpy => RankineData.sat_h_from_p(inletPressure).Item1;
        float inletEntropy => RankineData.sat_s_from_p(inletPressure).Item1;

        float outletPressure => 90; //set the pressure increase to constant for now until the component is more refined
        float outletTemperature => RankineData.t_from_p_h(outletPressure, outletEnthalpy).Item1;
        float outletEnthalpy => RankineData.h_from_p_s(outletPressure, outletEntropy).Item1;
        float outletEntropy => inletEntropy; //Isentropic procces


        public void Initialize()
        {
            this.converter = this.Parent.GetComponent<DigiCustomLiquidConverterComponent>();
            this.status = this.Parent.GetComponent<StatusComponent>().CreateStatusElement();
            this.status2 = this.Parent.GetComponent<StatusComponent>().CreateStatusElement();

            this.converter.Setup(typeof(WaterItem), typeof(HighPressureWaterItem), BlockOccupancyType.WaterInputPort, BlockOccupancyType.OutputPort, 10f, 0f);
        }

        public override void Tick()
        {
            this.status.SetStatusMessage (false, Localizer.Format("InletTemp {0}, InletPressure {1}, InletEnthalpy {2}, InletEntropy {3}", Text.Info(this.inletTemperature), Text.Info(this.inletPressure), Text.Info(this.inletEnthalpy), Text.Info(this.inletEntropy)));
            this.status2.SetStatusMessage(false, Localizer.Format("OutletTemp {0}, OutletPressure {1}, OutletEnthalpy {2}, OutletEntropy {3}", Text.Info(this.outletTemperature), Text.Info(this.outletPressure), Text.Info(this.outletEnthalpy), Text.Info(this.outletEntropy)));
            
            //doing weird shit
            Type type = typeof(WireConnection);
            FieldInfo fieldInfo = type.GetField("<WireRefs>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance);

            ThreadSafeList<WeakReference<WireConnection>> value = (ThreadSafeList<WeakReference<WireConnection>>)fieldInfo.GetValue(this.Parent.GetComponent<DigiCustomLiquidConverterComponent>().producer.OutputPipe);

            if (value is ThreadSafeList<WeakReference<WireConnection>> threadSafeList)
            {
                foreach (var thing in threadSafeList.Refs())
                {
                    if (thing.Owner is ReactorObject)
                    {
                        thing.Owner.GetComponent<AdvancedReactorComponent>().inletTemperature = this.outletTemperature;
                        thing.Owner.GetComponent<AdvancedReactorComponent>().inletPressure = this.outletPressure;
                        thing.Owner.GetComponent<AdvancedReactorComponent>().inletEnthalpy = this.outletEnthalpy;
                        thing.Owner.GetComponent<AdvancedReactorComponent>().inletEntropy = this.outletEntropy;
                        Log.Write(Localizer.Format(thing.Owner.ToString()));
                    }
                }
            }
        }
    }
}
