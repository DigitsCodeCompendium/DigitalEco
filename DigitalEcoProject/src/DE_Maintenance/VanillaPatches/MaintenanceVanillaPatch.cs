using System.Collections.Generic;
using Eco.Gameplay.Objects;
using Eco.Core.Utils;
using Digits.PartSlotting;
using Digits.Maintenance;

namespace Eco.Mods.TechTree
{
	//Possible degradation types
	//onTick -> applies this damage per object tick adjusted
	//onTickWhileOn -> applies this damage per object tick when onOff component is on. Stops onTick from applying when object is on
	//onCraftTick -> applies this damage per object tick while the crafting component is operating (the object is crafting something)
	//onVehicleTick -> applies this damager per object tick while the vehicle component is operating (someone is mounted on the vehicle. I dont think this counts for passengers, only the driver)
	//onPowerGridTick

	//CreatePartSlot(string name, Dictionary<string, float> degradationTypes, TagCollection tagCollection, bool disableMachineWhenBroken = false)

	[RequireComponent(typeof(MaintenanceComponent))]
    public partial class MasonryTableObject
    {
        partial void ModsPreInitialize()
        {
            var mComp = this.GetComponent<MaintenanceComponent>();
            mComp.Initialize();

            mComp.CreatePartSlot(   "Machine Frame",
                                    new Dictionary<string, float>() { { "onTick", 100f / (240f) }, { "onTickWhileOn", 100f / (60f) }, { "onCraftTick", 100f / (1000f) } },
                                    new TagCollection("Maintenance Machine Frame", new string[] { "Maintenance Tier 1", "Maintenance Tier 2", "Maintenance Tier 3" }),
                                    true);
            
            mComp.CreatePartSlot(   "Chisels",
                                    new Dictionary<string, float>() { { "onCraftTick", 100f / (100f) } },
                                    new TagCollection("Maintenance Tool Chisels", new string[] {"Maintenance Tier 1", "Maintenance Tier 2"}),
                                    true);
        }
    }

    /*
    [RequireComponent(typeof(MaintenanceComponent))]
    public partial class SteamEngineObject
    {
        partial void ModsPreInitialize()
        {
            var mComp = this.GetComponent<MaintenanceComponent>();
            mComp.Initialize();

            mComp.CreatePartSlot("Machine Frame", 
                                 new TagCollection("Maintenance Machine Frame", new string[] {"Maintenance Tier 1", "Maintenance Tier 2", "Maintenance Tier 3"}),
                                 new Dictionary<string, float>(){{"onTick", 100f/(240f)}, {"onTickWhileOn", 100f/(60f)}});
            
            mComp.CreatePartSlot("Chisels", 
                                 new TagCollection("Maintenance Tool Chisels", new string[] {"Maintenance Tier 1", "Maintenance Tier 2"}),
                                 new Dictionary<string, float>(){{"onPowerGridTick", 100f/(100f)}});

        }
    }
    */

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