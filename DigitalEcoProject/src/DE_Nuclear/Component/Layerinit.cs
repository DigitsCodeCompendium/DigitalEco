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
using Eco.Core.Plugins.Interfaces;
using Eco.Core.Utils;

namespace Digits.Nuclear
{

    [Serialized]
    [LocDisplayName("Radiation Emitter Component")]
    public class LayerInit : IModKitPlugin, IInitializablePlugin
    {
        public string GetCategory() => "Utility";

        public string GetStatus() => "REEEEEEEEEEEE";

        public void Initialize(TimedTask timer)
        {
            CreateLayer();
        }

        public void CreateLayer()
        {
            InitialLayerSet.TryAddLayer("Radfield", new WorldLayerSettings
            {
                MaxColor = Color.Black,
                SyncToClient = true
            });
        }

        public class WorldLayerSettingsRadfield : WorldLayerSettings
        {
            public WorldLayerSettingsRadfield() : base()
            {
                this.Name = "Radfield";
                this.MinimapName = Localizer.DoStr("Radfield");
                this.InitMultiplier = 1f;
                this.SyncToClient = true;
                this.Range = new Eco.Shared.Math.Range(0f, 1f);
                this.OverrideRenderRange = null;
                this.MinColor = new Color(1f, 1f, 1f);
                this.MaxColor = new Color(0f, 0f, 0f);
                this.SumRelevant = false;
                this.Unit = string.Empty;
                this.VoxelsPerEntry = 5;
                this.Category = WorldLayerCategory.World;
                this.ValueType = WorldLayerValueType.Percent;
                this.AreaDescription = string.Empty;

            }
        }
    }
}
