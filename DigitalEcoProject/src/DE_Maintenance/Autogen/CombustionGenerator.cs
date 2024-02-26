using System;
using System.Collections.Generic;
using System.ComponentModel;
using Digits.Maintenance;
using Eco.Gameplay.Objects;

namespace Eco.Mods.TechTree
{
    [RequireComponent(typeof(MaintenanceComponent2))]
    public partial class CombustionGeneratorObject
    {
        partial void ModsPreInitialize()
        {
            MaintenanceComponent2 mComp = this.GetComponent<MaintenanceComponent2>();
            mComp.Initialize();

            mComp.CreatePartSlot("Frame");
            mComp.AddPartSlotRestriction("Frame",
                new MaintenanceTypesRestriction("Frame", new string[] { "MTier 4", "MTier 3" }));
            mComp.AddPartSlotDegradation("Frame",
                new Dictionary<string, float>() { { "onPowerGridTick", 100f/(4f*60f*60f) } });

            mComp.CreatePartSlot("Bearing Kit");
            mComp.AddPartSlotRestriction("Bearing Kit", 
                new MaintenanceTypesRestriction("Bearing Kit", new string[] { "MTier 3", "MTier 4" }));
            mComp.AddPartSlotDegradation("Bearing Kit",
                new Dictionary<string, float>() { { "onPowerGridTick", 100f/(4f*60f*60f) } });
        }
    }
}