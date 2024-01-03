using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Linq;
using Eco.Gameplay.Components;
using Eco.Gameplay.Items;
using Eco.Gameplay.Objects;
using Eco.Gameplay.Utils;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;
using Eco.Shared.Networking;
using Eco.Shared.IoC;
using Eco.Core.Controller;
using Eco.Core.Utils;
using Digits.PartSlotting;
using Eco.Gameplay.Players;
using Eco.Gameplay.EcopediaRoot;

namespace Digits.Maintenance
{
    [Serialized]
    [RequireComponent(typeof(StatusComponent))]
    [RequireComponent(typeof(PartSlotComponent))]
    [LocDescription("Provides information about object maintenance"), CreateComponentTabLoc("Maintenance", true)]
    [NoIcon]
    [AutogenClass]
    public class MaintenanceComponent : WorldObjectComponent, IController, IHasClientControlledContainers
    {
        private bool enabled;
        public override bool Enabled => enabled;

        public override WorldObjectComponentClientAvailability Availability => WorldObjectComponentClientAvailability.UI;
        //required components
        private StatusElement status;
        private PartSlotComponent partSlotComponent;

        //optional components
        private OnOffComponent?         onOffComponent;
        private CraftingComponent?      craftingComponent;
        private VehicleComponent?       vehicleComponent;
        private PowerGridComponent?     powerGridComponent;

        public Dictionary<string, Dictionary<string, float>> slotProperties;
        private Dictionary<string, PartSlot> partSlotsByName;

        public MaintenanceComponent()
        {
            this.PartsListUIElements ??= new ControllerList<PartListElement>(this, nameof(PartsListUIElements));
            this.enabled = true;
        }

        public void Initialize()
        {
            this.partsListUIElements.Clear();
            //dictionaries that handle data storage for properties and linking partSlots with the names of the part slots
            partSlotsByName = new Dictionary<string, PartSlot>();
            slotProperties = new Dictionary<string, Dictionary<string, float>>();

            //grab possible components to monitor for damaging parts
            this.onOffComponent         = this.Parent.GetComponent<OnOffComponent>();
            this.vehicleComponent       = this.Parent.GetComponent<VehicleComponent>();
            this.craftingComponent      = this.Parent.GetComponent<CraftingComponent>();
            this.powerGridComponent     = this.Parent.GetComponent<PowerGridComponent>();

            this.status = this.Parent.GetComponent<StatusComponent>().CreateStatusElement();
            this.partSlotComponent = this.Parent.GetComponent<PartSlotComponent>();
		}
        
        public override void Tick()
        {
            this.TickDamage();
            this.TickStatus();
            this.CheckDisableConditions();
            this.UpdateUI();
        }
        
        //Updates UI status in the autogen ui
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
                    RepairableItem? part = partSlotComponent.GetPartFromSlot(partSlot)?.Item as RepairableItem;
                    if(part != null) partListElement.Status = part.Durability.ToString("0.0") + "% -> " + part.DisplayName;
                    else partListElement.Status = "Null error";
                }
                else
                {
                    partListElement.Status = "No part inserted in slot";
                }
            }
        }

        public void CreatePartSlot(string name, TagCollection tagCollection, Dictionary<string, float> degradationTypes, bool disableMachineWhenBroken = false)
        {
            this.CreatePartSlotUIElement(name);

            if (disableMachineWhenBroken)
            {
                degradationTypes["disableOnBroken"] = 0f;
            }
            this.slotProperties[name] = degradationTypes;

            //Get that part slot then add it to this dict to keep track of it by name
            this.partSlotComponent.CreatePartSlot(name, tagCollection);
            partSlotsByName[name] = this.partSlotComponent.GetPartSlot(name);
        }

        private void CreatePartSlotUIElement(string name)
        {
            PartListElement partListElement = new PartListElement();
            partListElement.partName = name;
            partListElement.status = "Not Installed";
            this.partsListUIElements.Add(partListElement);
        }

        private void TickStatus()
        {
            if (this.enabled)
            {
                this.status.SetStatusMessage(true, Localizer.Format("Machine maintenance is okay"));
            }
            else
            {
                this.status.SetStatusMessage(false, Localizer.Format("A part is broken or not inserted, preventing this machine from functioning"));
            }
			
		}

        private void CheckDisableConditions()
        {
            foreach (PartSlot partSlot in partSlotsByName.Values)
            {
                RepairableItem? durItem = partSlotComponent.GetPartFromSlot(partSlot)?.Item as RepairableItem;
                if (slotProperties[partSlot.name].TryGetValue("disableOnBroken", out float threshold))
                {
                    if (durItem != null)
                    {
                        if (durItem.Durability <= threshold)
                        {
                            this.enabled = false;
                            return;
                        }
                        else this.enabled = true;
                    }
                    else
                    {
                        this.enabled = false;
                        return;
                    }
                }
            }
        }

		private void TickDamage()
        {
            foreach (string partSlotName in partSlotsByName.Keys)
            {
                PartSlot partSlot = partSlotsByName[partSlotName];
                Dictionary<string, float> properties = slotProperties[partSlotName];

                float damage;
                float damageSum = 0;

                //onTick Damage
                properties.TryGetValue("degOnTick", out damage);
                damageSum += damage;

                //onTick Damage and tickWhileOn Damage
                if (this.onOffComponent?.On ?? false)
                {
					properties.TryGetValue("degOnTickWhileOn", out damage);
					damageSum += damage;
				}

                //Crafting Damage
                if (this.craftingComponent?.Operating ?? false)
                {
                    properties.TryGetValue("degOnCraftTick", out damage);
                    damageSum += damage;
                }

                //Vehicle Damage
                if (this.vehicleComponent?.Operating ?? false)
                {
                    properties.TryGetValue("degOnVehicleTick", out damage);
                    damageSum += damage;
                }

                //PowerGrid Damage
                if (this.powerGridComponent?.Enabled ?? false)
                {
                    properties.TryGetValue("degOnPowerGridTick", out damage);
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
            RepairableItem? part = partSlotComponent.GetPartFromSlot(partSlot)?.Item as RepairableItem;
            if (part != null)
            {
                if (part.Durability - (part.DurabilityRate * damage) > 0)
                {
                    part.Durability -= part.DurabilityRate * damage;
                }
                else
                {
                    part.Durability = 0;
                }
            }
        }

        //-------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------
        //! UI AUTOGEN STUFF, do not edit anything under this line unless it is UI stuff.
        //currently buttons are disabled until partSlotComponent is better developed

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
       


        // Take-out button
        [RPC, Autogen]
        public virtual void TakeOutOfSlot(Player player)
        {
            if (this.partSlotsByName.Values == null) return;
            ItemStack? itemStack = this.partSlotComponent.GetPartFromSlot(this.partSlotsByName.Values.ToList()[(int)enumSelection]);
            if (itemStack == null) return;

            Result result = this.partSlotComponent.Inventory.MoveItems(itemStack, player.User.Inventory, 1);
            if (result.Success)
            {
                player.MsgLocStr("<color=green>Put in part");
                return;
            }
            else
            {
                player.MsgLocStr("<color=red>Could not insert part!");
                return;
            }

        }

        // Put-in button
        [RPC, Autogen]
        public virtual void PutIntoSlot(Player player)
        {
            this.partSlotComponent.PutPlayerSelectedItemIntoPartSlot(player);
        }
    }
}
