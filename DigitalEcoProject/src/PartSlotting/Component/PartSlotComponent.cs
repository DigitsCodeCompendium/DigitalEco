using Digits.DE_Maintenance;
using Eco.Core.Controller;
using Eco.Core.Utils;
using Eco.Gameplay.Items;
using Eco.Gameplay.Objects;
using Eco.Gameplay.Players;
using Eco.Gameplay.Utils;
using Eco.Shared.Items;
using Eco.Shared.Localization;
using Eco.Shared.Networking;
using Eco.Shared.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Eco.Gameplay.Items.AuthorizationInventory;

namespace Digits.PartSlotting
{
    [Serialized]
    [CreateComponentTabLoc("Partslots", true), LocDescription("Provides information about parts slotted into this machine")]
    [NoIcon]
    [AutogenClass]
    public class PartSlotComponent : WorldObjectComponent, IInventoryWorldObjectComponent, IHasClientControlledContainers
    {
        public readonly ThreadSafeAction OnChanged = new();

        // Set up Inventory requirements
        [Serialized, SyncToView, PropReadOnly] public AuthorizationInventory? Inventory { get; private set; }
        Inventory IInventoryWorldObjectComponent.Inventory => this.Inventory;
        public override WorldObjectComponentClientAvailability Availability => WorldObjectComponentClientAvailability.UI;

        public PartSlotCollection? partSlotCollection;

        public PartSlotComponent()
        {
            // this needs to be here for some reason. Dont know why
            this.PartsListUIElements ??= new ControllerList<PartListElement>(this, nameof(PartsListUIElements));
        }

        public void FinalizePartSlots(PartSlotCollection partSlotCollection_in)
        {
            this.partSlotCollection = partSlotCollection_in;
            this.Inventory = new AuthorizationInventory(this.partSlotCollection.partSlots.Count, AuthorizationFlags.AuthedMayAdd | AuthorizationFlags.AuthedMayRemove, AccessType.FullAccess);
            this.Inventory.SetOwner(this.Parent);
            this.Inventory.OnChanged.Add(_ => this.OnChanged.Invoke());

            this.FinalizeUI();
        }

        public override void Tick()
        {
            this.UpdateUI();
        }

        public List<Tag> GetValidGenericTags()
        {
            List<Tag> tags= new List<Tag>();
            foreach (PartSlot partSlot in this.partSlotCollection.partSlots)
            {
                tags.Add(partSlot.tagCollection.genericTag);
            }
            return tags;
        }

        public Item? GetPartFromSlot(PartSlot partSlot)
        {
            // Find the corresponding item and return it or return null?
            //! Only needs to search for generic tag, not tier!
            var validStacks = this.Inventory.NonEmptyStacks.Where(stack => stack.Item.Type.HasTag(partSlot.tagCollection.genericTag));
            if (validStacks != null && validStacks.Any())
            {
                if (validStacks.Sum(stack => stack.Quantity) > 0) // Check that we only found one matching item
                {
                    return validStacks.First().Item; // Return one item
                }
                else
                {
                    return null; //! Some error occurred, we found multiple items that match!
                }
            }
            else
            {
                return null;
            }
        }


        // Check if part slot is occupied
        public bool IsSlotOccupied(PartSlot partSlot)
        {
            var validItemCountInSlot = this.Inventory.TotalNumberOfItems(partSlot.tagCollection.genericTag);
            if (validItemCountInSlot > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Put into slot if available
        public void PutIntoSlot(Player player, ItemStack itemStack, PartSlot partSlot)
        {
            if (!IsSlotOccupied(partSlot))
            {
                Result result = player.User.Inventory.MoveItems(itemStack, this.Inventory, 1);
                if (result.Success)
                {
                    player.MsgLocStr("<color=green>Put in part");
                }
                else
                {
                    player.MsgLocStr("<color=red>Could not insert part!");
                }
            }
            else
            {
                player.MsgLocStr("<color=red>Slot is already filled!");
                return;
            }
            // var validStacks = this.Inventory.NonEmptyStacks.Where(stack => stack.Item.Type.HasTag(partSlot.tagCollection.genericTag));


        }


        // Handle removal of items from inventory during pickup of world object
        // This is a necessary override, do not edit.
        public override InventoryMoveResult TryPickup(Player player, InventoryChangeSet playerInvChanges, Inventory targetInventory, bool force)
        {
            // if no modules are installed object can be picked up
            if (this.Inventory?.IsEmpty != false) return Result.Succeeded;

            // if force is set to true then pick up object and installed modules
            if (force)
            {
                foreach ((var type, var amount) in this.Inventory.TypeToCount)
                    playerInvChanges.AddItems(type, amount, targetInventory);

                return Result.Succeeded;
            }

            return playerInvChanges.MoveAsManyItemsAsPossible(this.Inventory, targetInventory); // if we are not forcing, return move result
        }





        // Function that updates ui components
        private void UpdateUI()
        {
            Dictionary<string, PartSlot> uiLinkDict = new Dictionary<string, PartSlot>();

            foreach (PartSlot partSlot in this.partSlotCollection.partSlots)
            {
                uiLinkDict[partSlot.name] = partSlot;
            }
            foreach (PartListElement partListElement in this.partsListUIElements)
            {
                PartSlot partSlot = uiLinkDict[partListElement.partName];
                if (this.IsSlotOccupied(partSlot))
                {
                    partListElement.Status = "Part Inserted";
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
            if (this.partSlotCollection != null)
            {
                foreach (var partSlot in this.partSlotCollection.partSlots)
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
        

        //-------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------
        //! UI AUTOGEN STUFF, do not edit anything under this line unless it is UI stuff.



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
        public enum enumOptions
        {
            Slot1,
            Slot2,
            Slot3,
            Slot4,
            Slot5
        };
        enumOptions enumSelection { get; set; }
        [Eco, ClientInterfaceProperty, LocDisplayName("Slot Select")]
        public enumOptions EnumSelector
        {
            get => enumSelection;
            set
            {
                if (value == enumSelection) return;
                enumSelection = value;
                this.Changed(nameof(EnumSelector));
            }
        }


        // Pop-out button
        [RPC, Autogen]
        public virtual void PullOutPart(Player player)
        {
            //this.PullOutAll(player);

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

            //this.PullOutByTags(player, new List<Tag> { TagManager.Tag("Maintenance Machine Frame"), TagManager.Tag("Maintenance Tier 1") });
        }

        // Put-in button
        [RPC, Autogen]
        public virtual void PutIntoSlot(Player player)
        {
            ItemStack itemStack = player.User.Inventory.Toolbar.SelectedStack;
            var isItemValid = itemStack?.Item != null && itemStack.Item is ISlottableItem;
            if (!isItemValid) return;

            // TODO Following steps:
            // Get list of all possible valid generic tags for all slots on this machine
            List<Tag> validTags = GetValidGenericTags();
            Tag? slotTag = null;
            foreach(Tag tag in itemStack.Item.Tags())
            {
                if(validTags.Contains(tag))
                {
                    slotTag = tag; // We found the corresponding tag that links the part to a slot within the part slot collection
                    break;
                }
            }

            if (slotTag != null)
            {
                // Get the exact partslot based on this tag
                foreach (PartSlot partSlot in this.partSlotCollection.partSlots)
                {
                    if (partSlot.tagCollection.genericTag == slotTag) // We found the matching part slot
                    {
                        bool isSlotOccupied = this.IsSlotOccupied(partSlot);
                        player.MsgLocStr("<color=yellow> Occupied?" + isSlotOccupied);
                        if (!isSlotOccupied)
                        {
                            this.PutIntoSlot(player, itemStack, partSlot);
                            player.MsgLocStr("<color=green>Successfully inserted part into part slot");
                            return;
                        } else
                        {
                            player.MsgLocStr("<color=red>Part slot is occupied, could not insert");
                            return;
                        }
                    }
                }
                player.MsgLocStr("<color=red>Failed to do reverse lookup of slot tag to find valid partSlot! RUH ROH");
            } else {
                player.MsgLocStr("<color=red>Could not find a matching generic tag");
                return;
            }

            

            // Check if item has any of those tags
            
            //this.PutInSelected(player);

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
