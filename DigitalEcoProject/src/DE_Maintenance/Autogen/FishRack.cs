using System;
using System.Collections.Generic;
using System.ComponentModel;
using Digits.Maintenance;
using Eco.Gameplay.Objects;

namespace Eco.Mods.TechTree
{
    [RequireComponent(typeof(MaintenanceComponent2))]
    public partial class FishRackObject
    {
        partial void ModsPreInitialize()
        {
            MaintenanceComponent2 mComp = this.GetComponent<MaintenanceComponent2>();
            mComp.Initialize();

            mComp.CreatePartSlot("Frame");
            mComp.AddPartSlotRestriction("Frame",
                new MaintenanceTypesRestriction("Frame", new string[] { "MTier 4", "MTier 3", "MTier 2", "MTier 1" }));
            mComp.AddPartSlotDegradation("Frame",
                new Dictionary<string, float>() { { "degOnCraftTick", 100f/(4f*60f*60f) } });

            mComp.CreatePartSlot("Thread");
            mComp.AddPartSlotRestriction("Thread", 
                new MaintenanceTypesRestriction("Thread", new string[] { "MTier 1", "MTier 3" }));
            mComp.AddPartSlotDegradation("Thread",
                new Dictionary<string, float>() { { "degOnCraftTick", 100f/(4f*60f*60f) } });
        }
    }
}