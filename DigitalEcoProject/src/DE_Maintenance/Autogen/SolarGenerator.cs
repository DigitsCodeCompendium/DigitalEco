using System;
using System.Collections.Generic;
using System.ComponentModel;
using Digits.Maintenance;
using Eco.Gameplay.Objects;

namespace Eco.Mods.TechTree
{
    [RequireComponent(typeof(MaintenanceComponent2))]
    public partial class SolarGeneratorObject
    {
        partial void ModsPreInitialize()
        {
            MaintenanceComponent2 mComp = this.GetComponent<MaintenanceComponent2>();
            mComp.Initialize();

            mComp.CreatePartSlot("Frame");
            mComp.AddPartSlotRestriction("Frame",
                new MaintenanceTypesRestriction("Frame", new string[] { "MTier 4" }));
            mComp.AddPartSlotDegradation("Frame",
                new Dictionary<string, float>() { { "degOnPowerGridTick", 100f/(4f*60f*60f) } });

            mComp.CreatePartSlot("Fuse Kit");
            mComp.AddPartSlotRestriction("Fuse Kit", 
                new MaintenanceTypesRestriction("Fuse Kit", new string[] { "MTier 4" }));
            mComp.AddPartSlotDegradation("Fuse Kit",
                new Dictionary<string, float>() { { "degOnPowerGridTick", 100f/(4f*60f*60f) } });
        }
    }
}