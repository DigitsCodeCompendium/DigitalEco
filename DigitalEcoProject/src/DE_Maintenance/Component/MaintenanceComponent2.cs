using Digits.PartSlotting;
using Eco.Core.Controller;
using Eco.Core.Utils;
using Eco.Gameplay.Components;
using Eco.Gameplay.Items;
using Eco.Gameplay.Objects;
using Eco.Gameplay.Utils;
using Eco.Shared.Localization;
using Eco.Shared.Networking;
using Eco.Shared.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digits.Maintenance
{
    [Serialized]
    [RequireComponent(typeof(StatusComponent))]
    [LocDescription("Provides information about object maintenance"), CreateComponentTabLoc("Maintenance", true)]
    [NoIcon]
    [AutogenClass]
    internal class MaintenanceComponent2 : WorldObjectComponent, IController, IHasClientControlledContainers
    {
        private bool enabled;
        public override bool Enabled => enabled;

        public override WorldObjectComponentClientAvailability Availability => WorldObjectComponentClientAvailability.UI;

        private OnOffComponent?         onOffComponent;
        private CraftingComponent?      craftingComponent;
        private VehicleComponent?       vehicleComponent;
        private PowerGridComponent      powerGridComponent;

        public Dictionary<string, Dictionary<string, float>> slotDegradation;

        public MaintenanceComponent2() 
        {
            this.enabled = true;
            this.PartSlots ??= new ControllerList<MPartSlot>(this, nameof(PartSlots));
        }

        public void Initialize()
        {
            //grab possible components to monitor for damaging parts
            this.onOffComponent         = this.Parent.GetComponent<OnOffComponent>();
            this.vehicleComponent       = this.Parent.GetComponent<VehicleComponent>();
            this.craftingComponent      = this.Parent.GetComponent<CraftingComponent>();
            this.powerGridComponent     = this.Parent.GetComponent<PowerGridComponent>();
        }

        public override void Tick()
        {
            base.Tick();
        }

        public void CreatePartSlot(string name)
        {
            if (IsPartSlotOccupied(name) == null)
            {
                PartSlots.Add(new MPartSlot(name));
                this.Changed(nameof(PartSlots));
            }
        }

        public void AddPartSlotRestriction(string partSlotName, InventoryRestriction inventoryRestriction)
        {
            MPartSlot? partSlot = GetPartSlot(partSlotName);
            if (partSlot == null) return;
            partSlot.Inventory.AddInvRestriction(inventoryRestriction);
        }

        public void AddPartSlotDegradation(string partSlotName, Dictionary<string, float> degradration)
        {
            MPartSlot? partSlot = GetPartSlot(partSlotName);
            if (partSlot == null) return;
            slotDegradation[partSlotName] = degradration;
        }

        public MPartSlot? GetPartSlot(string name)
        {
            foreach (MPartSlot partSlot in PartSlots)
            {
                if (partSlot.PartName == name)
                    return partSlot;
            }
            return null;
        }

        public bool? IsPartSlotOccupied(string name)
        {
            MPartSlot? partSlot = GetPartSlot(name);
            if (partSlot == null) return null;

            if (partSlot.Inventory.IsEmpty)
                return false;
            else
                return true;
        }

        //-------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------
        //! UI AUTOGEN STUFF, do not edit anything under this line unless it is UI stuff.

        ControllerList<MPartSlot> partSlots { get; set; }
        [Eco, ClientInterfaceProperty, GuestHidden, PropReadOnly, LocDisplayName("Parts Overview")]
        public ControllerList<MPartSlot> PartSlots
        {
            get => partSlots;
            set
            {
                if (value == partSlots) return;
                partSlots = value;
                this.Changed(nameof(PartSlots));
            }
        }
    }
}
