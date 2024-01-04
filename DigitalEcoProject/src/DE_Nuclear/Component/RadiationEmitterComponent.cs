using System;
using System.Collections.Generic;
using System.ComponentModel;
using Eco.Gameplay.Objects;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;
using Eco.Core.Controller;
using Eco.Simulation;
using Eco.Shared.Math;
using Eco.Simulation.WorldLayers;
using Eco.Simulation.WorldLayers.Layers;
using Eco.Shared.Utils;

namespace Digits.Nuclear
{

    [Serialized]
    [LocDisplayName("Radiation Emitter Component")]
    public class RadiationEmitterComponent : WorldObjectComponent, IController
    {
        public override void Tick()
        {
            //EcoSim.PlantSim.NutrientLayers["Nitrogen"].AddAmount(this.Parent.Position.XYZi(), 1f);
            WorldLayerManager.Obj.ClimateSim.AddAirPollutionTons(this.Parent.Position.XYZi(), 10f);
            WorldLayerManager.Obj.GetLayer("Radfield").SetAtWorldPos(this.Parent.Position.XZi(), 10f);
        }
    }
}
