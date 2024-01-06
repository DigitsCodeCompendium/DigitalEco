using Digits.Maintenance;
using Digits.PartSlotting;
using Eco.Core.Controller;
using Eco.Core.Utils;
using Eco.Gameplay.Components;
using Eco.Gameplay.Items;
using Eco.Gameplay.Objects;
using Eco.Gameplay.Players;
using Eco.Shared.Localization;
using Eco.Shared.Networking;
using Eco.Shared.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digits.Nuclear
{
    [Serialized]
    [LocDescription("Provides information about the reactor"), CreateComponentTabLoc("Reactor Fuel", true)]
    [RequireComponent(typeof(PartSlotComponent))]
    [AutogenClass]
    public class ReactorFuelComponent : WorldObjectComponent, IController
    {
        PartSlotComponent partSlotComponent;
        PartSlot partSlot;

        float lastConvertAmount = 1;

        public ReactorFuelComponent()
        {
            this.PartsListUIElements ??= new ControllerList<PartListElement>(this, nameof(PartsListUIElements));
        }

        public override void Initialize()
        {
            this.partSlotComponent = this.Parent.GetComponent<PartSlotComponent>();

            this.partSlotComponent.CreatePartSlot("Fuel Cell", new TagCollection("Fuel Cell", new string[] { }));
            this.partSlotComponent.Setup();
            this.partSlot = this.partSlotComponent.GetPartSlot("Fuel Cell");

            //Only have 1 fuel cell for now
            this.partsListUIElements.Clear();
            PartListElement partListElement = new PartListElement();
            partListElement.PartName = partSlot.name;
            partListElement.status = "No Fuel Cell inserted";
            this.partsListUIElements.Add(partListElement);
            
        }

        public bool HasFuel()
        {
            RepairableItem? item = this.partSlotComponent.GetPartFromSlot(this.partSlot)?.Item as RepairableItem;
            if (item != null)
            {
                if (!item.Broken)
                {
                    return true;
                }
            }
            return false;
        }

        public void UseFuel(float amount)
        {
            RepairableItem? item = this.partSlotComponent.GetPartFromSlot(this.partSlot)?.Item as RepairableItem;
            if (item != null)
            {
                if (!item.Broken)
                {
                    if (item.Durability - amount > 0)
                        item.Durability -= amount;
                    else item.Durability = 0;
                }
            }
            this.lastConvertAmount = amount;
            this.UpdateFuelStatus();
        }

        public void UpdateFuelStatus()
        {
            if (this.partSlotComponent.IsSlotOccupied(this.partSlot))
            {
                RepairableItem repairableItem = (RepairableItem) this.partSlotComponent.GetPartFromSlot(this.partSlot).Item;
                this.partsListUIElements[0].Status = repairableItem.Durability.ToString("0.0") + "% -> " + SecondsToTime(repairableItem.Durability/this.lastConvertAmount) + "s remianing";
            }
            else this.partsListUIElements[0].Status = "No Fuel Cell inserted";
        }

        private string SecondsToTime(float seconds)
        {
            int hours;
            hours = (int) Math.Floor(seconds / (60 * 60));
            seconds -= hours * 60 * 60;

            int minutes;
            minutes = (int) Math.Floor(seconds / 60);
            seconds -= minutes * 60;

            return Localizer.Format("{0}:{1}:{2}", hours.ToString(), minutes.ToString("00"), seconds.ToString("00.0"));

        }

        //-----------------------------------------------------
        //!           UI STUFF BEYOND THIS POINT
        //-----------------------------------------------------

        ControllerList<PartListElement> partsListUIElements { get; set; }
        [Eco, ClientInterfaceProperty, GuestHidden, PropReadOnly, LocDisplayName("Parts Overview")]
        public ControllerList<PartListElement> PartsListUIElements
        {
            get => partsListUIElements;
            set
            {
                if (value == partsListUIElements) return;
                partsListUIElements = value;
                this.Changed(nameof(PartsListUIElements));
            }
        }

        // Take-out button
        [RPC, Autogen]
        public virtual void InsertOrRemoveFuelCell(Player player)
        {
            if (this.partSlotComponent.IsSlotOccupied(this.partSlot))
            {
                ItemStack? itemStack = this.partSlotComponent.GetPartFromSlot(this.partSlot);
                this.partSlotComponent.TakePartFromSlot(player, itemStack);
            }
            else
            {
                this.partSlotComponent.PutPlayerSelectedItemIntoPartSlot(player);
            }
            this.UpdateFuelStatus();
        }
    }
}
