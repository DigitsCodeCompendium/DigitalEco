using Eco.Core.Controller;
using Eco.Core.Utils;
using Eco.Gameplay.EcopediaRoot;
using Eco.Gameplay.Items;
using Eco.Gameplay.Objects;
using Eco.Gameplay.Players;
using Eco.Gameplay.Utils;
using Eco.Mods.TechTree;
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
    //[CreateComponentTabLoc("Partslots", true), LocDescription("Provides information about parts slotted into this machine")]
    [NoIcon]
    //[AutogenClass]
    public class PartSlotComponent : WorldObjectComponent, IInventoryWorldObjectComponent//, IHasClientControlledContainers
    {
        public readonly ThreadSafeAction OnChanged = new();

        // Set up Inventory requirements
        [Serialized, SyncToView, PropReadOnly] public AuthorizationInventory? Inventory { get; private set; }
        Inventory IInventoryWorldObjectComponent.Inventory => this.Inventory;
        public override WorldObjectComponentClientAvailability Availability => WorldObjectComponentClientAvailability.UI;

        public PartSlotCollection? partSlotCollection;

        public PartSlotComponent()
        {
            //? this needs to be here for some reason. Dont know why
            this.PartsListUIElements ??= new ControllerList<PartListElement>(this, nameof(PartsListUIElements));
        }

        public void Setup(int numSlots)
        {
            // Check that the inventory has not already been set up (i.e. from a previous server launch)
            if(this.Inventory == null)
            {
                this.Inventory = new AuthorizationInventory(numSlots, AuthorizationFlags.AuthedMayAdd | AuthorizationFlags.AuthedMayRemove, AccessType.FullAccess);

            }
            // Important for Pickup on break
            this.Inventory.SetOwner(this.Parent);
            this.Inventory.OnChanged.Add(_ => this.OnChanged.Invoke());

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

        public void CreatePartSlot(string name, TagCollection tagCollection)
        {
            if (this.partSlotCollection == null) this.partSlotCollection = new PartSlotCollection();
            if (!this.partSlotCollection.DoesSlotExist(name))
            {
                this.partSlotCollection.CreatePartSlot(name, tagCollection);
            } 
        }

        public PartSlot? GetPartSlot(string name)
        {
            if (this.partSlotCollection == null) return null;
            foreach (PartSlot partSlot in this.partSlotCollection.partSlots)
            {
                if (partSlot.name == name) return partSlot;
            }
            return null;
        }

        public ItemStack? GetPartFromSlot(PartSlot partSlot)
        {
            if (partSlot == null) return null;
            // Find the corresponding item and return it or return null?
            //! Only needs to search for generic tag, not tier!
            var validStacks = this.Inventory.NonEmptyStacks.Where(stack => stack.Item.Type.HasTag(partSlot.tagCollection.genericTag));
            if (validStacks != null && validStacks.Any())
            {
                if (validStacks.Sum(stack => stack.Quantity) > 0) // Check that we only found one matching item
                {
                    return validStacks.First(); // Return one item
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
        // TODO See if we can move this into PartSlot class
        public bool IsSlotOccupied(PartSlot partSlot) //
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

        public void PutPlayerSelectedItemIntoPartSlot(Player player)
        {
            ItemStack itemStack = player.User.Inventory.Toolbar.SelectedStack;
            var isItemValid = itemStack?.Item != null && itemStack.Item is ISlottableItem;
            if (!isItemValid) return;

            // Get list of all possible valid generic tags for all slots on this machine
            List<Tag> validTags = GetValidGenericTags();
            Tag? genericSlotTag = null;
            foreach (Tag tag in itemStack.Item.Tags())
            {
                player.MsgLocStr("<color=white>checking tag:" + tag);
                if (validTags.Contains(tag))
                {
                    genericSlotTag = tag; // We found the corresponding tag that links the part to a slot within the part slot collection
                    break;
                }
            }

            // Return if we could not find a matching generic tag
            if (genericSlotTag == null)
            {
                player.MsgLocStr("<color=red>Could not find a matching generic tag");
                return;
            }

            // Debug print
            player.MsgLocStr("<color=white>Slot tag found?:" + genericSlotTag?.Name ?? "False");

            // Get the exact partslot based on this tag
            foreach (PartSlot partSlot in this.partSlotCollection.partSlots)
            {
                if (partSlot.tagCollection.genericTag == genericSlotTag) // We found the matching part slot
                {
                    bool isSlotOccupied = this.IsSlotOccupied(partSlot);
                    bool isCompatible = partSlot.isPartCompatible(itemStack.Item);
                    player.MsgLocStr("<color=yellow> Occupied?" + isSlotOccupied);
                    if (!isSlotOccupied && isCompatible)
                    {
                        //this.PutIntoSlot(player, itemStack, partSlot);
                        Result result = player.User.Inventory.MoveItems(itemStack, this.Inventory, 1);
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
                    else
                    {
                        player.MsgLocStr("<color=red>Part slot is occupied or of incompatible tier, could not insert");
                        return;
                    }
                }
                player.MsgLocStr("<color=red>No match for:" + partSlot.tagCollection.genericTag);
            }
            player.MsgLocStr("<color=red>Failed to do reverse lookup of slot tag to find valid partSlot! RUH ROH");
        }

        // Handler for moving all items to player inventory on break.
        public override InventoryMoveResult TryPickup(Player player, InventoryChangeSet playerInvChanges, Inventory targetInventory, bool force)
        {
            if (!force) return playerInvChanges.MoveAsManyItemsAsPossible(this.Inventory, targetInventory); // if we are not forcing, return move result

            //If it's not empty and we're forcing, move those too.
            if (!this.Inventory.IsEmpty && force)
            {
                foreach (var stack in this.Inventory.NonEmptyStacks)
                {
                    if (stack.Empty()) continue;
                    playerInvChanges.ClearStack(stack);
                    playerInvChanges.AddItem(stack.Item, stack.Quantity, targetInventory);
                }
            }

            return base.TryPickup(player, playerInvChanges, targetInventory, force);
        }

        //!UI FUNCTIONS
        
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
        
        public void FinalizeUI()
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

        // Take-out button
        [RPC, Autogen]
        public virtual void TakeOutOfSlot(Player player)
        {
            if(this.partSlotCollection == null) return;
            ItemStack? itemStack = GetPartFromSlot(partSlotCollection.partSlots[(int)enumSelection]);
            if (itemStack == null) return;

            Result result = this.Inventory.MoveItems(itemStack, player.User.Inventory, 1);
            if(result.Success)
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
            PutPlayerSelectedItemIntoPartSlot(player);
        }
    }
}
