namespace Eco.Mods.TechTree
{
    using System;
    using System.Collections.Generic;
    using Eco.Gameplay.Objects;
    using Eco.Core.Utils;
    using Digits.PartSlotting;
    using Digits.DE_Maintenance;
    using System.Runtime.InteropServices;

    //Possible degradation types
    //degOnTick -> applies this damage per object tick adjusted
    //degOnTickWhileOn -> applies this damage per object tick when onOff component is on. Stops onTick from applying when object is on
    //degOnCraftTick -> applies this damage per object tick while the crafting component is operating (the object is crafting something)
    //degOnVehicleTick -> applies this damager per object tick while the vehicle component is operating (someone is mounted on the vehicle. I dont think this counts for passengers, only the driver)
    //degOnPowerGridTick
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

            this.partSlotCollection.CreatePartSlot(  "Machine Frame",
                                                new TagCollection("Maintenance Machine Frame", 
                                                    new string[] { "Maintenance Tier 1", "Maintenance Tier 2", "Maintenance Tier 3" }));

            this.partSlotCollection.CreatePartSlot(  "Chisels",
                                                new TagCollection("Maintenance Tool Chisels", 
                                                    new string[] { "Maintenance Tier 1", "Maintenance Tier 2" }),
                                                new Dictionary<string, float>() { { "degOnTick", 100f/(60f) }, { "disableOnBroken", 1} });

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

    // [RequireComponent(typeof(MaintenanceComponent))]
    // public partial class SteamTruckObject
    // {
    // void ModsPreInitialize()
    //     {
    //         var mComp = this.GetComponent<MaintenanceComponent>();
    //         mComp.Initialize();

    //         mComp.CreatePartSlot("Vehicle Frame", 
    //                              new TagCollection("Maintenance Vehicle Frame", new string[] {"Maintenance Tier 1", "Maintenance Tier 2", "Maintenance Tier 3"}),
    //                              new Dictionary<string, float>(){{"onTick", 100f/(60f)}, {"onTickWhileOn", 100f/(60f)}, {"onCraft", 100f/(1000f)}});

    //         mComp.CreatePartSlot("Wheels", 
    //                              new TagCollection("Maintenance Tool Chisels", new string[] {"Maintenance Tier 1", "Maintenance Tier 2"}),
    //                              new Dictionary<string, float>(){{"onCraft", 100f/(100f)}});

    //     }
    // }
}