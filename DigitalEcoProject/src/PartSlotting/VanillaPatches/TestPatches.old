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
            var mComp = this.GetComponent<MaintenanceComponent>();
            partSlotComponent.Initialize();
            mComp.Initialize();
            //partSlotComponent.Initialize();

            mComp.CreatePartSlot(                   "Machine Frame",
                                                    new TagCollection("Maintenance Machine Frame", new string[] { "Maintenance Tier 1", "Maintenance Tier 2", "Maintenance Tier 3" }),
                                                    new Dictionary<string, float>() { { "degOnTick", 100f / 10f } },
                                                    true);

            mComp.CreatePartSlot(                   "Chisels",
                                                    new TagCollection("Maintenance Tool Chisels", new string[] { "Maintenance Tier 1", "Maintenance Tier 2" }),
                                                    new Dictionary<string, float>() { { "degOnCraftTick", 100f / (100f) } });

            //partSlotCollection.CreatePartSlot("Chisels", (nuclearprops, maintprops, etcprops) =>
            //{
            //    nuclearproperties.append({ "degOnTick", 100f / (60f) });
            //    if(maint)
            //    properties.append({ "degOnTick", 100f / (60f) });
            //}

            // 


            //partSlotComponent.FinalizePartSlots(partSlotCollection);

            //this.GetComponent<MaintenanceComponent>().Initialize();

        }

        partial void ModsPostInitialize()
        {
            var partSlotComponent = this.GetComponent<PartSlotComponent>();
            partSlotComponent.FinalizePartSlots();

            //this.GetComponent<MaintenanceComponent>().Initialize();

        }
    }

    [RequireComponent(typeof(PartSlotComponent))]
    public partial class SteamEngineObject
    {
        partial void ModsPreInitialize()
        {

            var partSlotComponent = this.GetComponent<PartSlotComponent>();
            partSlotComponent.Initialize();

            PartSlotCollection partSlotCollection = new PartSlotCollection();

            partSlotCollection.CreatePartSlot("Machine Frame",
                                 new TagCollection("Maintenance Machine Frame",
                                    new string[] { "Maintenance Tier 1", "Maintenance Tier 2", "Maintenance Tier 3" }));

            partSlotCollection.CreatePartSlot("Chisels",
                                 new TagCollection("Maintenance Tool Chisels",
                                    new string[] { "Maintenance Tier 1", "Maintenance Tier 2" }));

            partSlotComponent.FinalizePartSlots();

        }
    }
}