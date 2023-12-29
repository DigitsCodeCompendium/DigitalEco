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
    using Digits.DE_Maintenance;

    [RequireComponent(typeof(MaintenanceComponent))]
    public partial class MasonryTableObject
    {
        partial void ModsPreInitialize()
        {
            var mComp = this.GetComponent<MaintenanceComponent>();
            mComp.Initialize();
            mComp.InitCraftingComponent();
            mComp.InitOnOffComponent();

            //mComp.CreatePartSlots(new string[] {"Tier 1 Machine Frame", "Chisels"});

            mComp.CreatePartSlot("Machine Frame", 
                                 new TagCollection("Maintenance Machine Frame", new string[] {"Maintenance Tier 1", "Maintenance Tier 2", "Maintenance Tier 3"}),
                                 new Dictionary<string, float>(){{"onTick", 100f/(60f)}, {"onTickWhileOn", 100f/(60f)}, {"onCraft", 100f/(1000f)}});
            
            mComp.CreatePartSlot("Chisels", 
                                 new TagCollection("Maintenance Tool Chisels", new string[] {"Maintenance Tier 1", "Maintenance Tier 2"}),
                                 new Dictionary<string, float>(){{"onCraft", 100f/(100f)}});

        }
    }

    // [RequireComponent(typeof(MaintenanceComponent))]
    // public partial class SteamTruckObject
    // {
    // void ModsPreInitialize()
    //     {
    //         var mComp = this.GetComponent<MaintenanceComponent>();
    //         mComp.Initialize();
    //         mComp.InitCraftingComponent();
    //         mComp.InitOnOffComponent();

    //         //mComp.CreatePartSlots(new string[] {"Tier 1 Machine Frame", "Chisels"});

    //         mComp.CreatePartSlot("Machine Frame", 
    //                              new TagCollection("Maintenance Machine Frame", new string[] {"Maintenance Tier 1", "Maintenance Tier 2", "Maintenance Tier 3"}),
    //                              new Dictionary<string, float>(){{"onTick", 100f/(60f)}, {"onTickWhileOn", 100f/(60f)}, {"onCraft", 100f/(1000f)}});
            
    //         mComp.CreatePartSlot("Chisels", 
    //                              new TagCollection("Maintenance Tool Chisels", new string[] {"Maintenance Tier 1", "Maintenance Tier 2"}),
    //                              new Dictionary<string, float>(){{"onCraft", 100f/(100f)}});

    //     }
    // }
}