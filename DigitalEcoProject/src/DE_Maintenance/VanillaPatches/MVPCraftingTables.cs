using System;
using System.Collections.Generic;
using Eco.Gameplay.Objects;
using Eco.Core.Utils;
using Digits.PartSlotting;
using Digits.Maintenance;
using System.Runtime.InteropServices;
using Eco.Core.Items;
using Eco.Gameplay.Items;

//Possible degradation types
//onTick -> applies this damage per object tick adjusted
//onTickWhileOn -> applies this damage per object tick when onOff component is on. Stops onTick from applying when object is on
//onCraftTick -> applies this damage per object tick while the crafting component is operating (the object is crafting something)
//onVehicleTick -> applies this damager per object tick while the vehicle component is operating (someone is mounted on the vehicle. I dont think this counts for passengers, only the driver)
//onPowerGridTick

//CreatePartSlot(string name, Dictionary<string, float> degradationTypes, TagCollection tagCollection, bool disableMachineWhenBroken = false)

namespace Eco.Mods.TechTree
{
    [RequireComponent(typeof(MaintenanceComponent2))]
    public partial class MasonryTableObject
    {
        partial void ModsPreInitialize()
        {
            MaintenanceComponent2 mComp = this.GetComponent<MaintenanceComponent2>();
            mComp.Initialize();

            mComp.CreatePartSlot("Machine Frame");
            mComp.AddPartSlotRestriction("Machine Frame",
                new MaintenanceTypesRestriction("Maintenance Machine Frame", new string[] { "Maintenance Tier 1", "Maintenance Tier 2", "Maintenance Tier 3", "Maintenance Tier 4" }));
            mComp.AddPartSlotDegradation("Machine Frame",
                new Dictionary<string, float>() { { "degOnTick", 100f / (60f * 60f * 24f) } });

            mComp.CreatePartSlot("Chisel");
            mComp.AddPartSlotRestriction("Chisel", 
                new MaintenanceTypesRestriction("Maintenance Tool Chisel", new string[] { "Maintenance Tier 1", "Maintenance Tier 2", "Maintenance Tier 3", "Maintenance Tier 4" }));
            mComp.AddPartSlotDegradation("Chisel",
                new Dictionary<string, float>() { { "degOnTick", 100f / (60f * 60f * 48f) }, { "degOnCraftTick", 100f / (100f) } });
        }
    }

    [RequireComponent(typeof(MaintenanceComponent2))]
    public partial class CarpentryTableObject
    {
        partial void ModsPreInitialize()
        {
            MaintenanceComponent2 mComp = this.GetComponent<MaintenanceComponent2>();
            mComp.Initialize();

            mComp.CreatePartSlot("Machine Frame");
            mComp.AddPartSlotRestriction("Machine Frame",
                new MaintenanceTypesRestriction("Maintenance Machine Frame", new string[] { "Maintenance Tier 1", "Maintenance Tier 2", "Maintenance Tier 3", "Maintenance Tier 4" }));
            mComp.AddPartSlotDegradation("Machine Frame",
                new Dictionary<string, float>() { { "degOnTick", 100f / (60f * 60f * 24f) } });

            mComp.CreatePartSlot("Chisel");
            mComp.AddPartSlotRestriction("Chisel",
                new MaintenanceTypesRestriction("Maintenance Tool Chisel", new string[] { "Maintenance Tier 1", "Maintenance Tier 2", "Maintenance Tier 3", "Maintenance Tier 4" }));
            mComp.AddPartSlotDegradation("Chisel",
                new Dictionary<string, float>() { { "degOnTick", 100f / (60f * 60f * 48f) }, { "degOnCraftTick", 100f / (100f) } });
        }
    }

    [RequireComponent(typeof(MaintenanceComponent2))]
    public partial class ArrastraObject
    {
        partial void ModsPreInitialize()
        {
            MaintenanceComponent2 mComp = this.GetComponent<MaintenanceComponent2>();
            mComp.Initialize();

            mComp.CreatePartSlot("Machine Frame");
            mComp.AddPartSlotRestriction("Machine Frame",
                new MaintenanceTypesRestriction("Maintenance Machine Frame", new string[] { "Maintenance Tier 1", "Maintenance Tier 2", "Maintenance Tier 3", "Maintenance Tier 4" }));
            mComp.AddPartSlotDegradation("Machine Frame",
                new Dictionary<string, float>() { { "degOnTick", 100f / (60f * 60f * 24f) } });

            mComp.CreatePartSlot("Crushing Wheels");
            mComp.AddPartSlotRestriction("Crushing Wheels",
                new MaintenanceTypesRestriction("Maintenance Tool Crushing Wheels", new string[] { "Maintenance Tier 1", "Maintenance Tier 2", "Maintenance Tier 3", "Maintenance Tier 4" }));
            mComp.AddPartSlotDegradation("Crushing Wheels",
                new Dictionary<string, float>() { { "degOnTick", 100f / (60f * 60f * 48f) }, { "degOnCraftTick", 100f / (100f) } });
        }
    }

    [RequireComponent(typeof(MaintenanceComponent2))]
    public partial class RockerBoxObject
    {
        partial void ModsPreInitialize()
        {
            MaintenanceComponent2 mComp = this.GetComponent<MaintenanceComponent2>();
            mComp.Initialize();

            mComp.CreatePartSlot("Machine Frame");
            mComp.AddPartSlotRestriction("Machine Frame",
                new MaintenanceTypesRestriction("Maintenance Machine Frame", new string[] { "Maintenance Tier 1", "Maintenance Tier 2", "Maintenance Tier 3", "Maintenance Tier 4" }));
            mComp.AddPartSlotDegradation("Machine Frame",
                new Dictionary<string, float>() { { "degOnTick", 100f / (60f * 60f * 24f) } });

            mComp.CreatePartSlot("Sieving Mesh");
            mComp.AddPartSlotRestriction("Sieving Mesh",
                new MaintenanceTypesRestriction("Maintenance Tool Sieving Mesh", new string[] { "Maintenance Tier 1", "Maintenance Tier 2", "Maintenance Tier 3", "Maintenance Tier 4" }));
            mComp.AddPartSlotDegradation("Sieving Mesh",
                new Dictionary<string, float>() { { "degOnTick", 100f / (60f * 60f * 48f) }, { "degOnCraftTick", 100f / (100f) } });
        }
    }

    [RequireComponent(typeof(MaintenanceComponent2))]
    public partial class FarmersTableObject
    {
        partial void ModsPreInitialize()
        {
            MaintenanceComponent2 mComp = this.GetComponent<MaintenanceComponent2>();
            mComp.Initialize();

            mComp.CreatePartSlot("Machine Frame");
            mComp.AddPartSlotRestriction("Machine Frame",
                new MaintenanceTypesRestriction("Maintenance Machine Frame", new string[] { "Maintenance Tier 1", "Maintenance Tier 2", "Maintenance Tier 3", "Maintenance Tier 4" }));
            mComp.AddPartSlotDegradation("Machine Frame",
                new Dictionary<string, float>() { { "degOnTick", 100f / (60f * 60f * 24f) } });

            mComp.CreatePartSlot("Sieving Mesh");
            mComp.AddPartSlotRestriction("Sieving Mesh",
                new MaintenanceTypesRestriction("Maintenance Tool Sieving Mesh", new string[] { "Maintenance Tier 1", "Maintenance Tier 2", "Maintenance Tier 3", "Maintenance Tier 4" }));
            mComp.AddPartSlotDegradation("Sieving Mesh",
                new Dictionary<string, float>() { { "degOnTick", 100f / (60f * 60f * 48f) }, { "degOnCraftTick", 100f / (100f) } });
        }
    }

    [RequireComponent(typeof(MaintenanceComponent2))]
    public partial class ButcheryTableObject
    {
        partial void ModsPreInitialize()
        {
            MaintenanceComponent2 mComp = this.GetComponent<MaintenanceComponent2>();
            mComp.Initialize();

            mComp.CreatePartSlot("Machine Frame");
            mComp.AddPartSlotRestriction("Machine Frame",
                new MaintenanceTypesRestriction("Maintenance Machine Frame", new string[] { "Maintenance Tier 1", "Maintenance Tier 2", "Maintenance Tier 3", "Maintenance Tier 4" }));
            mComp.AddPartSlotDegradation("Machine Frame",
                new Dictionary<string, float>() { { "degOnTick", 100f / (60f * 60f * 24f) } });

            mComp.CreatePartSlot("Knife Set");
            mComp.AddPartSlotRestriction("Knife Set",
                new MaintenanceTypesRestriction("Maintenance Tool Knife", new string[] { "Maintenance Tier 1", "Maintenance Tier 2", "Maintenance Tier 3", "Maintenance Tier 4" }));
            mComp.AddPartSlotDegradation("Knife Set",
                new Dictionary<string, float>() { { "degOnTick", 100f / (60f * 60f * 48f) }, { "degOnCraftTick", 100f / (100f) } });
        }
    }


    [RequireComponent(typeof(MaintenanceComponent2))]
    public partial class SteamEngineObject
    {
        partial void ModsPreInitialize()
        {
            MaintenanceComponent2 mComp = this.GetComponent<MaintenanceComponent2>();
            mComp.Initialize();

            mComp.CreatePartSlot("Machine Frame");
            mComp.AddPartSlotRestriction("Machine Frame",
                new MaintenanceTypesRestriction("Maintenance Machine Frame", new string[] { "Maintenance Tier 2", "Maintenance Tier 3", "Maintenance Tier 4" }));
            mComp.AddPartSlotDegradation("Machine Frame",
                new Dictionary<string, float>() { { "degOnTick", 100f / (60f * 60f * 24f) } });

            mComp.CreatePartSlot("Steam Valves");
            mComp.AddPartSlotRestriction("Steam Valves",
                new MaintenanceTypesRestriction("Maintenance Steam Valves", new string[] { "Maintenance Tier 2", "Maintenance Tier 3", "Maintenance Tier 4" }));
            mComp.AddPartSlotDegradation("Steam Valves",
                new Dictionary<string, float>() { { "degOnTick", 100f / (60f * 60f * 48f) } });
        }
    }

    [RequireComponent(typeof(MaintenanceComponent2))]
    public partial class WainwrightTableObject
    {
        partial void ModsPreInitialize()
        {
            MaintenanceComponent2 mComp = this.GetComponent<MaintenanceComponent2>();
            mComp.Initialize();

            mComp.CreatePartSlot("Machine Frame");
            mComp.AddPartSlotRestriction("Machine Frame",
                new MaintenanceTypesRestriction("Maintenance Machine Frame", new string[] { "Maintenance Tier 1", "Maintenance Tier 2", "Maintenance Tier 3", "Maintenance Tier 4" }));
            mComp.AddPartSlotDegradation("Machine Frame",
                new Dictionary<string, float>() { { "degOnTick", 100f / (60f * 60f * 24f) } });

            mComp.CreatePartSlot("Smith's Tools");
            mComp.AddPartSlotRestriction("Smith's Tools",
                new MaintenanceTypesRestriction("Maintenance Tool Smith", new string[] { "Maintenance Tier 1", "Maintenance Tier 2", "Maintenance Tier 3", "Maintenance Tier 4" }));
            mComp.AddPartSlotDegradation("Smith's Tools",
                new Dictionary<string, float>() { { "degOnTick", 100f / (60f * 60f * 48f) }, { "degOnCraftTick", 100f / (100f) } });
        }
    }

    [RequireComponent(typeof(MaintenanceComponent2))]
    public partial class AnvilObject
    {
        partial void ModsPreInitialize()
        {
            MaintenanceComponent2 mComp = this.GetComponent<MaintenanceComponent2>();
            mComp.Initialize();

            mComp.CreatePartSlot("Machine Frame");
            mComp.AddPartSlotRestriction("Machine Frame",
                new MaintenanceTypesRestriction("Maintenance Machine Frame", new string[] { "Maintenance Tier 1", "Maintenance Tier 2", "Maintenance Tier 3", "Maintenance Tier 4" }));
            mComp.AddPartSlotDegradation("Machine Frame",
                new Dictionary<string, float>() { { "degOnTick", 100f / (60f * 60f * 24f) } });

            mComp.CreatePartSlot("Smith's Tools");
            mComp.AddPartSlotRestriction("Smith's Tools",
                new MaintenanceTypesRestriction("Maintenance Tool Smith", new string[] { "Maintenance Tier 1", "Maintenance Tier 2", "Maintenance Tier 3", "Maintenance Tier 4" }));
            mComp.AddPartSlotDegradation("Smith's Tools",
                new Dictionary<string, float>() { { "degOnTick", 100f / (60f * 60f * 48f) }, { "degOnCraftTick", 100f / (100f) } });
        }
    }
}