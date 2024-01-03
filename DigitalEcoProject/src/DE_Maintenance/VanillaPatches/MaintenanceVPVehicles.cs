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
/*
namespace Eco.Mods.TechTree
{
    [RequireComponent(typeof(MaintenanceComponent))]
    public partial class SteamTruckObject
    {
        void ModsPreInitialize()
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

        protected override void Initialize()
        {
            base.Initialize();
            this.ModsPreInitialize();     
            this.GetComponent<CustomTextComponent>().Initialize(200);
            this.GetComponent<FuelSupplyComponent>().Initialize(2, fuelTagList);
            this.GetComponent<FuelConsumptionComponent>().Initialize(75);
            this.GetComponent<AirPollutionComponent>().Initialize(0.2f);
            this.GetComponent<VehicleComponent>().HumanPowered(1);
            this.GetComponent<StockpileComponent>().Initialize(new Vector3i(2, 2, 3));
            this.GetComponent<PublicStorageComponent>().Initialize(24, 5000000);
            this.GetComponent<MinimapComponent>().InitAsMovable();
            this.GetComponent<MinimapComponent>().SetCategory(Localizer.DoStr("Vehicles"));
            this.GetComponent<VehicleComponent>().Initialize(18, 3, 2);
            this.GetComponent<VehicleComponent>().FailDriveMsg = Localizer.Do($"You are too hungry to drive {this.DisplayName}!");
        }
    }
}
*/