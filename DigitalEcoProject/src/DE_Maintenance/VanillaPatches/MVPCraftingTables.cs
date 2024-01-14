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
    internal static class MaintenanceRates
    {
        //time constants
        const float day = (60f * 60f * 24f);
        const float hour = (60f * 60f);

        //Tier constants
        const float Tier1Durability = 100f;
        const float Tier2Durability = 300f;
        const float Tier3Durability = 500f;
        const float Tier4Durability = 1000f;

        //Machine frames
        public const float Tier1MachineFrameTickRate = Tier1Durability / day;
        public const float Tier2MachineFrameTickRate = Tier2Durability / day;
        public const float Tier3MachineFrameTickRate = Tier3Durability / day;
        public const float Tier4MachineFrameTickRate = Tier4Durability / day;

        //Tools
        public const float Tier1ToolTickRate    = Tier1Durability / (2f * day);
        public const float Tier1ToolCraftRate   = Tier1Durability / 100f;

        public const float Tier2ToolTickRate    = Tier2Durability / (2f * day);
        public const float Tier2ToolCraftRate   = Tier2Durability / 100f;

        public const float Tier3ToolTickRate    = Tier3Durability / (2f * day);
        public const float Tier3ToolCraftRate   = Tier3Durability / 100f;

        public const float Tier4ToolTickRate    = Tier4Durability / (2f * day);
        public const float Tier4ToolCraftRate   = Tier4Durability / 100f;


    }

    //--------------------------------------------------------
    //!                       Tier 1
    //--------------------------------------------------------

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
                new Dictionary<string, float>() { { "degOnTick", MaintenanceRates.Tier1MachineFrameTickRate } });

            mComp.CreatePartSlot("Chisel");
            mComp.AddPartSlotRestriction("Chisel", 
                new MaintenanceTypesRestriction("Maintenance Tool Chisel", new string[] { "Maintenance Tier 1", "Maintenance Tier 2", "Maintenance Tier 3", "Maintenance Tier 4" }));
            mComp.AddPartSlotDegradation("Chisel",
                new Dictionary<string, float>() { { "degOnTick", 100f / (60f * 60f * 48f) }, { "degOnCraftTick", MaintenanceRates.Tier1ToolCraftRate } });
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
                new Dictionary<string, float>() { { "degOnTick", MaintenanceRates.Tier1MachineFrameTickRate } });

            mComp.CreatePartSlot("Chisel");
            mComp.AddPartSlotRestriction("Chisel",
                new MaintenanceTypesRestriction("Maintenance Tool Chisel", new string[] { "Maintenance Tier 1", "Maintenance Tier 2", "Maintenance Tier 3", "Maintenance Tier 4" }));
            mComp.AddPartSlotDegradation("Chisel",
                new Dictionary<string, float>() { { "degOnTick", 100f / (60f * 60f * 48f) }, { "degOnCraftTick", MaintenanceRates.Tier1ToolCraftRate } });
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
                new Dictionary<string, float>() { { "degOnTick", MaintenanceRates.Tier1MachineFrameTickRate } });

            mComp.CreatePartSlot("Crushing Wheels");
            mComp.AddPartSlotRestriction("Crushing Wheels",
                new MaintenanceTypesRestriction("Maintenance Tool Crushing Wheel", new string[] { "Maintenance Tier 1", "Maintenance Tier 2", "Maintenance Tier 3", "Maintenance Tier 4" }));
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
                new Dictionary<string, float>() { { "degOnTick", MaintenanceRates.Tier1MachineFrameTickRate } });

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
                new Dictionary<string, float>() { { "degOnTick", MaintenanceRates.Tier1MachineFrameTickRate } });

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
                new Dictionary<string, float>() { { "degOnTick", MaintenanceRates.Tier1MachineFrameTickRate } });

            mComp.CreatePartSlot("Knife Set");
            mComp.AddPartSlotRestriction("Knife Set",
                new MaintenanceTypesRestriction("Maintenance Tool Knife", new string[] { "Maintenance Tier 1", "Maintenance Tier 2", "Maintenance Tier 3", "Maintenance Tier 4" }));
            mComp.AddPartSlotDegradation("Knife Set",
                new Dictionary<string, float>() { { "degOnTick", 100f / (60f * 60f * 48f) }, { "degOnCraftTick", 100f / (100f) } });
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
                new Dictionary<string, float>() { { "degOnTick", MaintenanceRates.Tier1MachineFrameTickRate } });

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
                new Dictionary<string, float>() { { "degOnTick", MaintenanceRates.Tier1MachineFrameTickRate } });

            mComp.CreatePartSlot("Smith's Tools");
            mComp.AddPartSlotRestriction("Smith's Tools",
                new MaintenanceTypesRestriction("Maintenance Tool Smith", new string[] { "Maintenance Tier 1", "Maintenance Tier 2", "Maintenance Tier 3", "Maintenance Tier 4" }));
            mComp.AddPartSlotDegradation("Smith's Tools",
                new Dictionary<string, float>() { { "degOnTick", 100f / (60f * 60f * 48f) }, { "degOnCraftTick", 100f / (100f) } });
        }
    }

    [RequireComponent(typeof(MaintenanceComponent2))]
    public partial class BloomeryObject
    {
        partial void ModsPreInitialize()
        {
            MaintenanceComponent2 mComp = this.GetComponent<MaintenanceComponent2>();
            mComp.Initialize();

            mComp.CreatePartSlot("Machine Frame");
            mComp.AddPartSlotRestriction("Machine Frame",
                new MaintenanceTypesRestriction("Maintenance Machine Frame", new string[] { "Maintenance Tier 1", "Maintenance Tier 2", "Maintenance Tier 3", "Maintenance Tier 4" }));
            mComp.AddPartSlotDegradation("Machine Frame",
                new Dictionary<string, float>() { { "degOnTick", MaintenanceRates.Tier1MachineFrameTickRate } });

            mComp.CreatePartSlot("Bellows");
            mComp.AddPartSlotRestriction("Bellows",
                new MaintenanceTypesRestriction("Maintenance Tool Bellows", new string[] { "Maintenance Tier 1", "Maintenance Tier 2", "Maintenance Tier 3", "Maintenance Tier 4" }));
            mComp.AddPartSlotDegradation("Bellows",
                new Dictionary<string, float>() { { "degOnTick", 100f / (60f * 60f * 48f) }, { "degOnCraftTick", 100f / (100f) } });

            mComp.CreatePartSlot("Refractory");
            mComp.AddPartSlotRestriction("Refractory",
                new MaintenanceTypesRestriction("Maintenance Tool Refractory", new string[] { "Maintenance Tier 1", "Maintenance Tier 2", "Maintenance Tier 3", "Maintenance Tier 4" }));
            mComp.AddPartSlotDegradation("Refractory",
                new Dictionary<string, float>() { { "degOnTick", 100f / (60f * 60f * 48f) }, { "degOnCraftTick", 100f / (100f) } });
        }
    }

    //--------------------------------------------------------
    //!                       Tier 2
    //--------------------------------------------------------

    [RequireComponent(typeof(MaintenanceComponent2))]
    public partial class KilnObject
    {
        partial void ModsPreInitialize()
        {
            MaintenanceComponent2 mComp = this.GetComponent<MaintenanceComponent2>();
            mComp.Initialize();

            mComp.CreatePartSlot("Machine Frame");
            mComp.AddPartSlotRestriction("Machine Frame",
                new MaintenanceTypesRestriction("Maintenance Machine Frame", new string[] { "Maintenance Tier 2", "Maintenance Tier 3", "Maintenance Tier 4" }));
            mComp.AddPartSlotDegradation("Machine Frame",
                new Dictionary<string, float>() { { "degOnTick", MaintenanceRates.Tier2MachineFrameTickRate } });

            mComp.CreatePartSlot("Bellows");
            mComp.AddPartSlotRestriction("Bellows",
                new MaintenanceTypesRestriction("Maintenance Tool Bellows", new string[] { "Maintenance Tier 2", "Maintenance Tier 3", "Maintenance Tier 4" }));
            mComp.AddPartSlotDegradation("Bellows",
                new Dictionary<string, float>() { { "degOnTick", 100f / (60f * 60f * 48f) }, { "degOnCraftTick", 100f / (100f) } });

            mComp.CreatePartSlot("Refractory");
            mComp.AddPartSlotRestriction("Refractory",
                new MaintenanceTypesRestriction("Maintenance Tool Refractory", new string[] { "Maintenance Tier 2", "Maintenance Tier 3", "Maintenance Tier 4" }));
            mComp.AddPartSlotDegradation("Refractory",
                new Dictionary<string, float>() { { "degOnTick", 100f / (60f * 60f * 48f) }, { "degOnCraftTick", 100f / (100f) } });
        }
    }

    [RequireComponent(typeof(MaintenanceComponent2))]
    public partial class GlassworksObject
    {
        partial void ModsPreInitialize()
        {
            MaintenanceComponent2 mComp = this.GetComponent<MaintenanceComponent2>();
            mComp.Initialize();

            mComp.CreatePartSlot("Machine Frame");
            mComp.AddPartSlotRestriction("Machine Frame",
                new MaintenanceTypesRestriction("Maintenance Machine Frame", new string[] { "Maintenance Tier 2", "Maintenance Tier 3", "Maintenance Tier 4" }));
            mComp.AddPartSlotDegradation("Machine Frame",
                new Dictionary<string, float>() { { "degOnTick", MaintenanceRates.Tier2MachineFrameTickRate } });

            mComp.CreatePartSlot("Smith's Tools");
            mComp.AddPartSlotRestriction("Smith's Tools",
                new MaintenanceTypesRestriction("Maintenance Tool Smith", new string[] { "Maintenance Tier 2", "Maintenance Tier 3", "Maintenance Tier 4" }));
            mComp.AddPartSlotDegradation("Smith's Tools",
                new Dictionary<string, float>() { { "degOnTick", 100f / (60f * 60f * 48f) }, { "degOnCraftTick", 100f / (100f) } });

            mComp.CreatePartSlot("Refractory");
            mComp.AddPartSlotRestriction("Refractory",
                new MaintenanceTypesRestriction("Maintenance Tool Refractory", new string[] { "Maintenance Tier 2", "Maintenance Tier 3", "Maintenance Tier 4" }));
            mComp.AddPartSlotDegradation("Refractory",
                new Dictionary<string, float>() { { "degOnTick", 100f / (60f * 60f * 48f) }, { "degOnCraftTick", 100f / (100f) } });
        }
    }

    [RequireComponent(typeof(MaintenanceComponent2))]
    public partial class SawmillObject
    {
        partial void ModsPreInitialize()
        {
            MaintenanceComponent2 mComp = this.GetComponent<MaintenanceComponent2>();
            mComp.Initialize();

            mComp.CreatePartSlot("Machine Frame");
            mComp.AddPartSlotRestriction("Machine Frame",
                new MaintenanceTypesRestriction("Maintenance Machine Frame", new string[] { "Maintenance Tier 2", "Maintenance Tier 3", "Maintenance Tier 4" }));
            mComp.AddPartSlotDegradation("Machine Frame",
                new Dictionary<string, float>() { { "degOnTick", MaintenanceRates.Tier2MachineFrameTickRate } });

            mComp.CreatePartSlot("Sawblade");
            mComp.AddPartSlotRestriction("Sawblade",
                new MaintenanceTypesRestriction("Maintenance Tool Sawblade", new string[] { "Maintenance Tier 2", "Maintenance Tier 3" }));
            mComp.AddPartSlotDegradation("Sawblade",
                new Dictionary<string, float>() { { "degOnTick", 100f / (60f * 60f * 48f) }, { "degOnCraftTick", 100f / (100f) } });
        }
    }

    [RequireComponent(typeof(MaintenanceComponent2))]
    public partial class BlastFurnaceObject
    {
        partial void ModsPreInitialize()
        {
            MaintenanceComponent2 mComp = this.GetComponent<MaintenanceComponent2>();
            mComp.Initialize();

            mComp.CreatePartSlot("Machine Frame");
            mComp.AddPartSlotRestriction("Machine Frame",
                new MaintenanceTypesRestriction("Maintenance Machine Frame", new string[] { "Maintenance Tier 2", "Maintenance Tier 3", "Maintenance Tier 4" }));
            mComp.AddPartSlotDegradation("Machine Frame",
                new Dictionary<string, float>() { { "degOnTick", MaintenanceRates.Tier2MachineFrameTickRate } });

            mComp.CreatePartSlot("Bellows");
            mComp.AddPartSlotRestriction("Bellows",
                new MaintenanceTypesRestriction("Maintenance Tool Bellows", new string[] { "Maintenance Tier 2", "Maintenance Tier 3", "Maintenance Tier 4" }));
            mComp.AddPartSlotDegradation("Bellows",
                new Dictionary<string, float>() { { "degOnTick", 100f / (60f * 60f * 48f) }, { "degOnCraftTick", 100f / (100f) } });

            mComp.CreatePartSlot("Refractory");
            mComp.AddPartSlotRestriction("Refractory",
                new MaintenanceTypesRestriction("Maintenance Tool Refractory", new string[] { "Maintenance Tier 2", "Maintenance Tier 3", "Maintenance Tier 4" }));
            mComp.AddPartSlotDegradation("Refractory",
                new Dictionary<string, float>() { { "degOnTick", 100f / (60f * 60f * 48f) }, { "degOnCraftTick", 100f / (100f) } });
        }
    }


}