using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Linq;
using Eco.Mods.TechTree;
using Eco.Core.Items;
using Eco.Gameplay.Blocks;
using Eco.Gameplay.Components;
using Eco.Gameplay.Components.Auth;
using Eco.Gameplay.DynamicValues;
using Eco.Gameplay.Economy;
using Eco.Gameplay.Housing;
using Eco.Gameplay.Interactions;
using Eco.Gameplay.Items;
using Eco.Gameplay.Modules;
using Eco.Gameplay.Minimap;
using Eco.Gameplay.Objects;
using Eco.Gameplay.Occupancy;
using Eco.Gameplay.Players;
using Eco.Gameplay.Property;
using Eco.Gameplay.Skills;
using Eco.Gameplay.Systems;
using Eco.Gameplay.Utils;
using Eco.Gameplay.Systems.TextLinks;
using Eco.Gameplay.Pipes.LiquidComponents;
using Eco.Gameplay.Pipes.Gases;
using Eco.Shared;
using Eco.Shared.Math;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;
using Eco.Shared.Utils;
using Eco.Shared.View;
using Eco.Shared.Items;
using Eco.Shared.Networking;
using Eco.Gameplay.Pipes;
using Eco.World.Blocks;
using Eco.Gameplay.Housing.PropertyValues;
using Eco.Gameplay.Civics.Objects;
using Eco.Gameplay.Settlements;
using Eco.Gameplay.Systems.NewTooltip;
using Eco.Core.Controller;
using Eco.Core.Utils;
using Eco.Gameplay.Components.Storage;
using Eco.Gameplay.Items.Recipes;
using System.Collections;
using System.Linq;
using System.Reflection;
using System.Text;
using Eco.Mods.TechTree;
using Eco.Shared.IoC;
using Digits.PartSlotting;

namespace Digits.DE_Maintenance
{
    [Serialized]
    [RequireComponent(typeof(StatusComponent))]
    [RequireComponent(typeof(PartSlotComponent))]
    [LocDescription("Provides information about object maintenance"), CreateComponentTabLoc("Maintenance", true)]
    [NoIcon]
    [AutogenClass]
    public class MaintenanceComponent : WorldObjectComponent, IController, IHasClientControlledContainers
    {
		public override WorldObjectComponentClientAvailability Availability => WorldObjectComponentClientAvailability.UI;
        //required components
        private StatusElement status;
        private PartSlotComponent partSlotComponent;

        //optional components
        private OnOffComponent?         onOffComponent;
        private CraftingComponent?      craftingComponent;
        private VehicleComponent?       vehicleComponent;
        private PowerGridComponent?     powerGridComponent;

        public MaintenanceComponent()
        {
            this.PartsListUIElements ??= new ControllerList<PartListElement>(this, nameof(PartsListUIElements));
        }

        public void Initialize()
        {
            base.Initialize();

            //grab possible components to monitor for damaging parts
            this.onOffComponent         = this.Parent.GetComponent<OnOffComponent>();
            this.vehicleComponent       = this.Parent.GetComponent<VehicleComponent>();
            this.craftingComponent      = this.Parent.GetComponent<CraftingComponent>();
            this.powerGridComponent     = this.Parent.GetComponent<PowerGridComponent>();

            this.status = this.Parent.GetComponent<StatusComponent>().CreateStatusElement();
            this.partSlotComponent = this.Parent.GetComponent<PartSlotComponent>();
            this.FinalizeUI();

		}
        
        public override void Tick()
        {
            this.TickDamage();
            //this.status.SetStatusMessage(false, Localizer.Format(this.TickStatus()));
            this.UpdateUI();
        }

        //ui List for showing components
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

        private void UpdateUI()
        {   
            Dictionary<string, PartSlot> uiLinkDict = new Dictionary<string, PartSlot>();

            foreach (PartSlot partSlot in partSlotComponent.partSlotCollection.partSlots)
            {
                uiLinkDict[partSlot.name] = partSlot;
            }
            foreach (PartListElement partListElement in this.partsListUIElements)
            {   
                PartSlot partSlot = uiLinkDict[partListElement.partName];
                if(partSlotComponent.IsSlotOccupied(partSlot))
                {
                    RepairableItem part = (RepairableItem) partSlotComponent.GetPartFromSlot(partSlot);
                    partListElement.Status = part.Durability.ToString("0.0") + "%";
                }
                else
                {
                    partListElement.Status = "No part inserted in slot";
                }
            }
        }

		private void FinalizeUI()
		{
			this.partsListUIElements.Clear();
			if (this.partSlotComponent.partSlotCollection != null)
			{
				foreach (var partSlot in this.partSlotComponent.partSlotCollection.partSlots)
				{
					CreatePartSlotUIElement(partSlot);
				}
			}
		}

		private void CreatePartSlotUIElement(PartSlot partSlot)
		{
			PartListElement partListElement = new PartListElement();
			partListElement.partName = partSlot.name;
			partListElement.status = "Not Installed";
			this.partsListUIElements.Add(partListElement);
		}

		/*private string TickStatus()
        {
            string returnString = "";

            foreach (PartSlot partSlot in partSlotComponent.partSlotCollection.partSlots)
            {
                RepairableItem part = (RepairableItem) partSlotComponent.GetPartFromSlot(partSlot);
                if (part != null)
                {
                    returnString += " " + partSlot.name + ": " + part.Durability.ToString("0") + "%";
                }
            }
            if (this.powerGridComponent?.Enabled ?? false) returnString += this.powerGridComponent.Enabled;
            return returnString;
        }*/

		private void TickDamage()
        {
            foreach (PartSlot partSlot in partSlotComponent.partSlotCollection.partSlots)
            {
                float damage;
                float damageSum = 0;

                //onTick Damage
                partSlot.properties.TryGetValue("degOnTick", out damage);
                damageSum += damage;

                //onTick Damage and tickWhileOn Damage
                if (this.onOffComponent?.On ?? false)
                {
					partSlot.properties.TryGetValue("degOnTickWhileOn", out damage);
					damageSum += damage;
				}

                //Crafting Damage
                if (this.craftingComponent?.Operating ?? false)
                {
                    partSlot.properties.TryGetValue("degOnCraftTick", out damage);
                    damageSum += damage;
                }

                //Vehicle Damage
                if (this.vehicleComponent?.Operating ?? false)
                {
                    partSlot.properties.TryGetValue("degOnVehicleTick", out damage);
                    damageSum += damage;
                }

                //PowerGrid Damage
                if (this.powerGridComponent?.Enabled ?? false)
                {
                    partSlot.properties.TryGetValue("degOnPowerGridTick", out damage);
                    damageSum += damage;
                }

                //Apply damage
                var tickTime = ServiceHolder<IWorldObjectManager>.Obj.TickDeltaTime;
                this.DamagePart(partSlot, damageSum * tickTime);
            }
        }

		[RPC]
        public void DamagePart(PartSlot partSlot, float damage)
        {
            RepairableItem part = (RepairableItem) partSlotComponent.GetPartFromSlot(partSlot);
            if (part != null)
            {
                if (part.Durability - damage > 0)
                {
                    part.Durability -= part.DurabilityRate * damage;
                }
                else
                {
                    part.Durability = 0;
                }
            }
        }

        /*
		//selector for pulling out and inserting parts into slots
		[Eco]
        public enum enumOptions2
        {
            Slot1,
            Slot2,
            Slot3,
            Slot4,
            Slot5
        };
        enumOptions2 enumSelection {get; set;}
        [Eco, ClientInterfaceProperty, LocDisplayName("Slot Select")]
        public enumOptions2 EnumSelector
        {
            get => enumSelection;
            set
            {
                if(value == enumSelection) return;
                enumSelection = value;
                this.Changed(nameof(EnumSelector)); 
            }
        }
        */
        

		// Pop-out button
		[RPC, Autogen]
        public virtual void PullOutPart(Player player)
        {
            // partSlotComponent.PullOutAll(player);
            // if(this.hasPartInserted)
            // {
            //     if (player.User.Inventory.NonEmptyStacks.Count() < player.User.Inventory.Stacks.Count())
            //     {
            //         RepairableItem item = new MachinePartsItem();
            //         item.Durability = this.partDurability;
            //         Result result = player.User.Inventory.TryAddItem(item);
            //         if(result.Success) {
            //             this.hasPartInserted = false;
            //             this.partDurability = 0f;
            //             player.MsgLocStr("<color=green>Pulled out part");
            //             return;
            //         }
            //     }
            //     player.MsgLocStr("<color=red>No space in inventory to pull out parts!");
            //     return;
            // } else {
            //     player.MsgLocStr("<color=red>No parts to pull out!");
            //     return;
            // }
        }

        
         // Pull out by tag
        [RPC, Autogen]
        public virtual void PullOutPartByTags(Player player)
        {
            
            //partSlotComponent.PullOutByTags(player, new List<Tag> {TagManager.Tag("Maintenance Machine Frame"), TagManager.Tag("Maintenance Tier 1")});
        }
        

        // Put-in button
        [RPC, Autogen]
        public virtual void PutInPart(Player player)
        {
            //partSlotComponent.PutInSelected(player);
            // ItemStack itemStack = player.User.Inventory.Toolbar.SelectedStack;
            // var isItemValid = itemStack?.Item != null && itemStack.Item is RepairableMachinePartsItem;
            // if(isItemValid) {
            //     if(!this.hasPartInserted)
            //     {
            //         RepairableItem repItem = (RepairableItem) itemStack.Item;
            //         this.partDurability = repItem.Durability;
            //         itemStack.TryModifyStack(player.User, -1); // Try to delete the item
            //         this.hasPartInserted = true;
            //         player.MsgLocStr("<color=green>Put in part");
            //     } else {
            //         player.MsgLocStr("<color=red>Could not put in part");
            //     }
            // } else {
            //     player.MsgLocStr("<color=red>No valid part in hand");
            // }
        }
    }
}
