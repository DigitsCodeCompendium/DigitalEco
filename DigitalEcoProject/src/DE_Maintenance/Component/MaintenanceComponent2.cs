using Eco.Core.Controller;
using Eco.Core.Utils;
using Eco.Gameplay.Components;
using Eco.Gameplay.Items;
using Eco.Gameplay.Objects;
using Eco.Gameplay.Players;
using Eco.Gameplay.Systems.TextLinks;
using Eco.Gameplay.Utils;
using Eco.Shared.IoC;
using Eco.Shared.Localization;
using Eco.Shared.Networking;
using Eco.Shared.Serialization;
using Eco.Shared.Utils;
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
        private PowerGridComponent?     powerGridComponent;

        private StatusElement           status;

        public Dictionary<string, Dictionary<string, float>> slotDegradation;

        public MaintenanceComponent2() 
        {
            this.enabled = true;
            this.PartSlots ??= new ControllerList<MPartSlot>(this, nameof(PartSlots));
            this.slotDegradation ??= new Dictionary<string, Dictionary<string, float>>();
        }

        public void Initialize()
        {
            //grab possible components to monitor for damaging parts
            this.onOffComponent         = this.Parent.GetComponent<OnOffComponent>();
            this.vehicleComponent       = this.Parent.GetComponent<VehicleComponent>();
            this.craftingComponent      = this.Parent.GetComponent<CraftingComponent>();
            this.powerGridComponent     = this.Parent.GetComponent<PowerGridComponent>();

            this.status                 = this.Parent.GetComponent<StatusComponent>().CreateStatusElement();
        }

        public override void Tick()
        {
            this.TickDamage();
            this.CheckDisableConditions();
            this.TickStatus();
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
            if (inventoryRestriction is MaintenanceTypesRestriction)
            {
                MaintenanceTypesRestriction maintenanceTypesRestriction = inventoryRestriction as MaintenanceTypesRestriction;

                string typehint = "";
                typehint += "Requires ";
                typehint += TagManager.Tag(maintenanceTypesRestriction.genericType).UILink();
                typehint += ", and of tier";

                foreach (string tagTier in maintenanceTypesRestriction.tierTags)
                {
                    typehint += ", " + TagManager.Tag(tagTier).UILink();
                }

                partSlot.TypeHints = typehint;
            }
            this.Changed(nameof(PartSlots));
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

        private void DamagePart(string name, float damage)
        {
            MPartSlot? partSlot = GetPartSlot(name);
            if (partSlot == null /*|| partSlot.Inventory.IsEmpty*/)
            {
                return;
            }

            RepairableItem? item = partSlot.Inventory.Stacks.First().Item as RepairableItem;
            if (item == null)
            {
                return;
            }

            if (item.Durability - (item.DurabilityRate * damage) > 0)
                item.Durability -= item.DurabilityRate * damage;
            else
                item.Durability = 0;
        }

        private void TickDamage()
        {
            foreach (MPartSlot partSlot in partSlots)
            {
                Dictionary<string, float> properties;
                slotDegradation.TryGetValue(partSlot.partName, out properties);

                if (properties != null)
                {
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
                    this.DamagePart(partSlot.partName, damageSum * tickTime);
                }
            }
        }

        private void CheckDisableConditions()
        {
            foreach (MPartSlot partSlot in partSlots)
            {
                RepairableItem? durItem = partSlot.Inventory.Stacks.First().Item as RepairableItem;

                if (durItem != null)
                {
                    if (durItem.Durability <= 0)
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

        private void TickStatus()
        {
            if (this.enabled)
            {
                this.status.SetStatusMessage(true, Localizer.Format("Maintenance: Machine maintenance is okay"));
            }
            else
            {
                this.status.SetStatusMessage(false, Localizer.Format("Maintenance: A part is broken or not inserted, preventing this machine from functioning"));
            }
        }

        // Handler for moving all items to player inventory on break.
        public override InventoryMoveResult TryPickup(Player player, InventoryChangeSet playerInvChanges, Inventory targetInventory, bool force)
        {
            foreach (MPartSlot partSlot in partSlots)
            {
                if (!partSlot.Inventory.IsEmpty)
                {
                    return Result.LocalizeStr("Cannot pick up the machine while parts are still inside!");
                }
            }
            return Result.Succeeded;

            //.MoveAsManyItemsAsPossible(this.Inventory, targetInventory); // if we are not forcing, return move result
            /*
            //If it's not empty and we're forcing, move those too.
            if (force)
            {
                foreach (MPartSlot partSlot in partSlots)
                {
                    if (!partSlot.Inventory.IsEmpty)
                    {
                        foreach (var stack in partSlot.Inventory.NonEmptyStacks)
                        {
                            if (stack.Empty()) continue;
                            //playerInvChanges.ClearStack(stack);
                            playerInvChanges.AddItem(stack.Item, stack.Quantity, targetInventory);
                        }
                    }
                }
            }
            return base.TryPickup(player, playerInvChanges, targetInventory, force);*/

        }

        //-------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------
        //! UI AUTOGEN STUFF, do not edit anything under this line unless it is UI stuff.

        ControllerList<MPartSlot> partSlots { get; set; }
        [Eco, ClientInterfaceProperty, GuestHidden, PropReadOnly, LocDisplayName("Parts Overview"), UIListTypeName("IEnumerableHeader"), HideRootListEntry]
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
