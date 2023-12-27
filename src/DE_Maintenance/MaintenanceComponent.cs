namespace Digits.DE_Maintenance
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using Eco.Mods.TechTree;
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
    [RequireComponent(typeof(StatusComponent))]
    [LocDisplayName("Maintenance"), LocDescription("Provides information about object maintenance")]
    [AutogenClass]
    public class MaintenanceComponent : WorldObjectComponent, IController
    {
        private StatusElement status;

        public void Initialize()
        {
            this.status = this.Parent.GetComponent<StatusComponent>().CreateStatusElement();
        }

        public override void Tick()
        {
            this.status.SetStatusMessage(false, Localizer.Format("Machine Parts are currently at %"));
        }
    }
}
