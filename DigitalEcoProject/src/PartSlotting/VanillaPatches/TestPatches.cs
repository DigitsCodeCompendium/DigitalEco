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
        public PartSlotCollection partSlotCollection;
        partial void ModsPreInitialize()
        {
            var partSlotComponent = this.GetComponent<PartSlotComponent>();
            partSlotComponent.Initialize();
            if(partSlotCollection == null)
            {
                this.partSlotCollection = new PartSlotCollection();
            }
            //partSlotComponent.Initialize();

            this.partSlotCollection.CreatePartSlot( "Machine Frame",
                                                    new TagCollection("Maintenance Machine Frame", 
                                                        new string[] { "Maintenance Tier 1", "Maintenance Tier 2", "Maintenance Tier 3" }));

            this.partSlotCollection.CreatePartSlot( "Chisels",
                                                    new TagCollection("Maintenance Tool Chisels", 
                                                        new string[] { "Maintenance Tier 1", "Maintenance Tier 2" }));

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
            partSlotComponent.FinalizePartSlots(partSlotCollection);

            this.GetComponent<MaintenanceComponent>().Initialize();

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

            partSlotComponent.FinalizePartSlots(partSlotCollection);

        }
    }
}