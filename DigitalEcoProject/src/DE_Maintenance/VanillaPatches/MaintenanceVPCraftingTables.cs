using System;
using System.Collections.Generic;
using Eco.Gameplay.Objects;
using Eco.Core.Utils;
using Digits.PartSlotting;
using Digits.Maintenance;
using System.Runtime.InteropServices;
using Eco.Core.Items;

//Possible degradation types
//onTick -> applies this damage per object tick adjusted
//onTickWhileOn -> applies this damage per object tick when onOff component is on. Stops onTick from applying when object is on
//onCraftTick -> applies this damage per object tick while the crafting component is operating (the object is crafting something)
//onVehicleTick -> applies this damager per object tick while the vehicle component is operating (someone is mounted on the vehicle. I dont think this counts for passengers, only the driver)
//onPowerGridTick

//CreatePartSlot(string name, Dictionary<string, float> degradationTypes, TagCollection tagCollection, bool disableMachineWhenBroken = false)

namespace Eco.Mods.TechTree
{
    [RequireComponent(typeof(MaintenanceComponent))]
    public partial class MasonryTableObject
    {
        partial void ModsPreInitialize()
        {
            var mComp = this.GetComponent<MaintenanceComponent>();
            mComp.Initialize();

            mComp.CreatePartSlot(   "Machine Frame",
                                    new TagCollection("Maintenance Machine Frame", new string[] { "Maintenance Tier 1", "Maintenance Tier 2", "Maintenance Tier 3", "Maintenance Tier 4" }),
                                    new Dictionary<string, float>() { { "degOnTick", 100f / (60f * 60f * 24f) } },
                                    true);

            mComp.CreatePartSlot(   "Chisels",
                                    new TagCollection("Maintenance Tool Chisels", new string[] { "Maintenance Tier 1", "Maintenance Tier 2", "Maintenance Tier 3", "Maintenance Tier 4" }),
                                    new Dictionary<string, float>() { { "degOnTick", 100f / (60f * 60f * 48f) }, { "degOnCraftTick", 100f / (100f) } },
                                    true);

            this.GetComponent<PartSlotComponent>().FinalizePartSlots();
        }
    }

    [RequireComponent(typeof(MaintenanceComponent))]
    public partial class CarpentryTableObject
    {
        partial void ModsPreInitialize()
        {
            var mComp = this.GetComponent<MaintenanceComponent>();
            mComp.Initialize();

            mComp.CreatePartSlot("Machine Frame",
                                    new TagCollection("Maintenance Machine Frame", new string[] { "Maintenance Tier 1", "Maintenance Tier 2", "Maintenance Tier 3", "Maintenance Tier 4" }),
                                    new Dictionary<string, float>() { { "degOnTick", 100f / (60f * 60f * 24f) } },
                                    true);

            mComp.CreatePartSlot("Chisels",
                                    new TagCollection("Maintenance Tool Chisels", new string[] { "Maintenance Tier 1", "Maintenance Tier 2", "Maintenance Tier 3", "Maintenance Tier 4" }),
                                    new Dictionary<string, float>() { { "degOnTick", 100f / (60f * 60f * 48f) }, { "degOnCraftTick", 100f / (100f) } },
                                    true);

            this.GetComponent<PartSlotComponent>().FinalizePartSlots();
        }
    }

    [RequireComponent(typeof(MaintenanceComponent))]
    public partial class ArrastraObject
    {
        partial void ModsPreInitialize()
        {
            var mComp = this.GetComponent<MaintenanceComponent>();
            mComp.Initialize();

            mComp.CreatePartSlot("Machine Frame",
                                    new TagCollection("Maintenance Machine Frame", new string[] { "Maintenance Tier 1", "Maintenance Tier 2", "Maintenance Tier 3", "Maintenance Tier 4" }),
                                    new Dictionary<string, float>() { { "degOnTick", 100f / (60f * 60f * 24f) } },
                                    true);

            mComp.CreatePartSlot("Crushing Wheels",
                                    new TagCollection("Maintenance Tool Crushing Wheels", new string[] { "Maintenance Tier 1", "Maintenance Tier 2", "Maintenance Tier 3", "Maintenance Tier 4" }),
                                    new Dictionary<string, float>() { { "degOnTick", 100f / (60f * 60f * 48f) }, { "degOnCraftTick", 100f / (100f) } },
                                    true);

            this.GetComponent<PartSlotComponent>().FinalizePartSlots();
        }
    }

    [RequireComponent(typeof(MaintenanceComponent))]
    public partial class RockerBoxObject
    {
        partial void ModsPreInitialize()
        {
            var mComp = this.GetComponent<MaintenanceComponent>();
            mComp.Initialize();

            mComp.CreatePartSlot("Machine Frame",
                                    new TagCollection("Maintenance Machine Frame", new string[] { "Maintenance Tier 1", "Maintenance Tier 2", "Maintenance Tier 3", "Maintenance Tier 4" }),
                                    new Dictionary<string, float>() { { "degOnTick", 100f / (60f * 60f * 24f) } },
                                    true);

            mComp.CreatePartSlot("Sieving Mesh",
                                    new TagCollection("Maintenance Tool Sieving Mesh", new string[] { "Maintenance Tier 1", "Maintenance Tier 2", "Maintenance Tier 3", "Maintenance Tier 4" }),
                                    new Dictionary<string, float>() { { "degOnTick", 100f / (60f * 60f * 48f) }, { "degOnCraftTick", 100f / (100f) } },
                                    true);

            this.GetComponent<PartSlotComponent>().FinalizePartSlots();
        }
    }

    [RequireComponent(typeof(MaintenanceComponent))]
    public partial class FarmersTableObject
    {
        partial void ModsPreInitialize()
        {
            var mComp = this.GetComponent<MaintenanceComponent>();
            mComp.Initialize();

            mComp.CreatePartSlot("Machine Frame",
                                    new TagCollection("Maintenance Machine Frame", new string[] { "Maintenance Tier 1", "Maintenance Tier 2", "Maintenance Tier 3", "Maintenance Tier 4" }),
                                    new Dictionary<string, float>() { { "degOnTick", 100f / (60f * 60f * 24f) } },
                                    true);

            mComp.CreatePartSlot("Sieving Mesh",
                                    new TagCollection("Maintenance Tool Sieving Mesh", new string[] { "Maintenance Tier 1", "Maintenance Tier 2", "Maintenance Tier 3", "Maintenance Tier 4" }),
                                    new Dictionary<string, float>() { { "degOnTick", 100f / (60f * 60f * 48f) }, { "degOnCraftTick", 100f / (100f) } },
                                    true);

            this.GetComponent<PartSlotComponent>().FinalizePartSlots();
        }
    }

    [RequireComponent(typeof(MaintenanceComponent))]
    public partial class ButcheryTableObject
    {
        partial void ModsPreInitialize()
        {
            var mComp = this.GetComponent<MaintenanceComponent>();
            mComp.Initialize();

            mComp.CreatePartSlot("Machine Frame",
                                    new TagCollection("Maintenance Machine Frame", new string[] { "Maintenance Tier 1", "Maintenance Tier 2", "Maintenance Tier 3", "Maintenance Tier 4" }),
                                    new Dictionary<string, float>() { { "degOnTick", 100f / (60f * 60f * 24f) } },
                                    true);

            mComp.CreatePartSlot("Butchery Tools",
                                    new TagCollection("Maintenance Tool Butchery", new string[] { "Maintenance Tier 1", "Maintenance Tier 2", "Maintenance Tier 3", "Maintenance Tier 4" }),
                                    new Dictionary<string, float>() { { "degOnTick", 100f / (60f * 60f * 48f) }, { "degOnCraftTick", 100f / (100f) } },
                                    true);

            this.GetComponent<PartSlotComponent>().FinalizePartSlots();
        }
    }


    [RequireComponent(typeof(MaintenanceComponent))]
    public partial class SteamEngineObject
    {
        partial void ModsPreInitialize()
        {
            var mComp = this.GetComponent<MaintenanceComponent>();
            mComp.Initialize();
            //partSlotComponent.Initialize();

            mComp.CreatePartSlot(   "Machine Frame",
                                    new TagCollection("Maintenance Machine Frame", new string[] { "Maintenance Tier 2", "Maintenance Tier 3", "Maintenance Tier 4" }),
                                    new Dictionary<string, float>() { { "degOnTick", 300f / (60f * 60f * 24f) } },
                                    true);

            mComp.CreatePartSlot(   "Steam Valves",
                                    new TagCollection("Maintenance Steam Valves", new string[] { "Maintenance Tier 2", "Maintenance Tier 3" }),
                                    new Dictionary<string, float>() { { "degOnTick", 100f / (60f * 60f * 48f) }, { "degOnCraftTick", 100f / (100f) } },
                                    true);

            this.GetComponent<PartSlotComponent>().FinalizePartSlots();
        }
    }
}