using System;
using System.Collections.Generic;
using System.ComponentModel;
using Digits.Maintenance;
using Eco.Gameplay.Objects;

namespace Eco.Mods.TechTree
{
    [RequireComponent(typeof(MaintenanceComponent2))]
    public partial class LaboratoryObject
    {
        partial void ModsPreInitialize()
        {
            MaintenanceComponent2 mComp = this.GetComponent<MaintenanceComponent2>();
            mComp.Initialize();

            mComp.CreatePartSlot("Frame");
            mComp.AddPartSlotRestriction("Frame",
                new MaintenanceTypesRestriction("Frame", new string[] { "MTier 4", "MTier 3", "MTier 2" }));
            mComp.AddPartSlotDegradation("Frame",
                new Dictionary<string, float>() { { "degOnCraftTick", 100f/(4f*60f*60f) } });

            mComp.CreatePartSlot("Glassware");
            mComp.AddPartSlotRestriction("Glassware", 
                new MaintenanceTypesRestriction("Glassware", new string[] { "MTier 2", "MTier 3" }));
            mComp.AddPartSlotDegradation("Glassware",
                new Dictionary<string, float>() { { "degOnCraftTick", 100f/(4f*60f*60f) } });
        }
    }
}