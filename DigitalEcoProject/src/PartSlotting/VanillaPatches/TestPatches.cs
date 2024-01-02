namespace Eco.Mods.TechTree
{
    using System;
    using System.Collections.Generic;
    using Eco.Gameplay.Objects;
    using Eco.Core.Utils;
    using Digits.PartSlotting;
    using Digits.Maintenance;
    using System.Runtime.InteropServices;
    using Eco.Core.Items;

    [RequireComponent(typeof(MaintenanceComponent))]
    [RequireComponent(typeof(PartSlotComponent))]
    public partial class MasonryTableObject
    {
        partial void ModsPreInitialize()
        {
            var partSlotComponent = this.GetComponent<PartSlotComponent>();
            partSlotComponent.Setup(20);  // Initialize with 20 part slots
            var mComp = this.GetComponent<MaintenanceComponent>();
            mComp.Initialize();

            mComp.CreatePartSlot(                   "Machine Frame",
                                                    new TagCollection("Maintenance Machine Frame", new string[] { "Maintenance Tier 1", "Maintenance Tier 2", "Maintenance Tier 3" }),
                                                    new Dictionary<string, float>() { });

            mComp.CreatePartSlot(                   "Chisels",
                                                    new TagCollection("Maintenance Tool Chisels", new string[] { "Maintenance Tier 1", "Maintenance Tier 2" }),
                                                    new Dictionary<string, float>() { });

            partSlotComponent.FinalizeUI();

            //partSlotCollection.CreatePartSlot("Chisels", (nuclearprops, maintprops, etcprops) =>
            //{
            //    nuclearproperties.append({ "degOnTick", 100f / (60f) });
            //    if(maint)
            //    properties.append({ "degOnTick", 100f / (60f) });
            //}

            // 



        }
    }

    [RequireComponent(typeof(PartSlotComponent))]
    public partial class SteamEngineObject
    {
        partial void ModsPreInitialize()
        {

            var partSlotComponent = this.GetComponent<PartSlotComponent>();
            partSlotComponent.Setup(20);  // Initialize with 20 part slots
            //partSlotComponent.Initialize();

            //PartSlotCollection partSlotCollection = new PartSlotCollection();

            partSlotComponent.CreatePartSlot("Machine Frame",
                                 new TagCollection("Maintenance Machine Frame",
                                    new string[] { "Maintenance Tier 1", "Maintenance Tier 2", "Maintenance Tier 3" }));

            partSlotComponent.CreatePartSlot("Chisels",
                                 new TagCollection("Maintenance Tool Chisels",
                                    new string[] { "Maintenance Tier 2" }));

            //? Example of how to define a part slot using already existing items
            //partSlotComponent.CreatePartSlot("Basic Upgrade",
            //                     new TagCollection("BasicUpgrade",
            //                        new string[] { "BasicUpgrade" }));

            partSlotComponent.FinalizeUI();


        }
    }

    //? Example of how to define a part slot using already existing items
    public partial class BasicUpgradeLvl1Item : ISlottableItem {  }
}