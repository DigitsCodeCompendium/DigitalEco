namespace Digits.DE_Maintenance
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
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

    using static Eco.Gameplay.Items.AuthorizationInventory;
    using System.Linq;

    [Serialized]
    public class MaintenanceInventoryComponent : WorldObjectComponent, IInventoryWorldObjectComponent
    {
        public readonly ThreadSafeAction OnChanged = new();

        public override WorldObjectComponentClientAvailability Availability => WorldObjectComponentClientAvailability.UI;
        [Serialized, SyncToView, PropReadOnly] public AuthorizationInventory? Inventory { get; private set; }
        Inventory IInventoryWorldObjectComponent.Inventory => this.Inventory!;

        private int numSlots = 3; // TODO Make this not hardcoded

        public MaintenanceInventoryComponent() { }

        public override void Initialize()
        {
            if (this.Inventory == null)
                this.Inventory = new AuthorizationInventory(numSlots, AuthorizationFlags.AuthedMayAdd | AuthorizationFlags.AuthedMayRemove, AccessType.FullAccess);
            this.Inventory.SetOwner(this.Parent);
            this.Inventory.OnChanged.Add(_ => this.OnChanged.Invoke());
            base.Initialize();
        }
        
        public override void Tick()
        {

        }

        // Take a part slot from the maint component and get the corresponding item
        // Return the item that corresponds to an occupied part slot

        public Item GetPartFromSlot(PartSlot partSlot)
        {
            // Find the corresponding item and return it or return null?
            //! Only needs to search for generic tag, not tier!
            var validStacks = this.Inventory.NonEmptyStacks.Where(stack => stack.Item.Type.HasTag(partSlot.tagCollection.genericTag));
            if(validStacks != null && validStacks.Any())
            {
                if(validStacks.Sum(stack => stack.Quantity) == 1) // Check that we only found one matching item
                {
                    return validStacks.First().Item; // Return one item
                } else {
                    return null; //! Some error occurred, we found multiple items that match!
                }
            } else {
                return null;
            }
        }

        // Pulls out all maintenance items
        public void PullOutAll(Player player)
        {
            var itemStacks = this.Inventory.NonEmptyStacks;
            this.Inventory.MoveAsManyItemsAsPossible(player.User.Inventory, player.User); // This respects inventory space and weight!
            // TODO Find a way to check this result, but honestly we don't care, it's just doing its best that it can.
        }

        // Pull out items by list of tags
        public void PullOutByTags(Player player, List<Tag> tags)
        {
            player.MsgLocStr("<color=green>Trying to pull by tag");
            // var res = this.Inventory.MoveAsManyItemsAsPossible(player.User.Inventory, stack => stack.Item.Tags().Contains("Chisels"), player.User);
            
            IEnumerable<ItemStack> validStacks = this.Inventory.NonEmptyStacks;
            foreach(var tag in tags) {
                var tmp = validStacks.Where(stack => stack.Item.Type.HasTag(tag));
                if(tmp != null && tmp.Any()) // Check if IEnumerable is not empty/null
                {
                    validStacks = tmp;
                } else {
                    player.MsgLocStr("<color=red>Could not meet all tag conditions");
                    return;
                }
            }

            // Now assume anything in validStacks is... well... valid...
            foreach(var itemStack in validStacks)
            {
                var result = this.Inventory.MoveItems(itemStack, player.User.Inventory, -1, player.User);
                if(!(result.Success))
                {
                    player.MsgLocStr("<color=red>Failed to move all items");
                    return;
                }
                player.MsgLocStr("<color=green>Moved item stack");
            }
        }

        // // Searches internal inventory by tag collection
        // private IEnumerable<ItemStack> FindByTags(List<Tag> tags)
        // {
        //     IEnumerable<ItemStack> validStacks = this.Inventory.NonEmptyStacks;
        //     foreach(var tag in tags) {
        //         var tmp = validStacks.Where(stack => stack.Item.Type.HasTag(tag));
        //         if(tmp != null && tmp.Any()) // Check if IEnumerable is not empty/null
        //         {
        //             validStacks = tmp;
        //         } else {
        //             return null; // Return null if nothing was found
        //         }
        //     }
        //     return validStacks;
        // }

        // Insert player's selected item into the maintenance inventory //! Does not currently check for duplicates
        public void PutInSelected(Player player)
        {
            ItemStack itemStack = player.User.Inventory.Toolbar.SelectedStack;                          // Get selected item
            var isItemValid = itemStack?.Item != null && itemStack.Item is RepairableMachinePartsItem;  // Check validity
            if(isItemValid) {
                // var isItemAlreadyInserted = CheckIfAlreadyInserted(itemStack);                          // Check if already in machine
                // if(isItemAlreadyInserted)
                // {
                    Result result = player.User.Inventory.MoveItems(itemStack, this.Inventory, 1);      // Try to move item
                    if(result.Success) {
                        player.MsgLocStr("<color=green>Put in part");
                    } else {
                        player.MsgLocStr("<color=red>Could not insert part!");
                    }
                // } else {
                //     player.MsgLocStr("<color=red>Already contains this part type!");
                //     return;
                // }
            } else {
                player.MsgLocStr("<color=red>No valid part in hand");
            }
        }

        // Checks if internal inventory already has item
        private bool CheckIfAlreadyInserted(ItemStack itemStack)
        {
            if(this.Inventory.Contains(new ItemStack[] {itemStack} )) // Fudgy way to force it to be an IEnumerable so I don't have to re-write their contains function to work with individual stacks...
            {
                return true;
            } else {
                return false;
            }
        }

        // Put into slot if available
        public void PutIntoSlot(ItemStack itemStack, PartSlot slot)
        {
            var validStacks = this.Inventory.NonEmptyStacks.Where(stack => stack.Item.Type.HasTag(partSlot.tagCollection.genericTag));
        }

        // // Keeping for easy debugging
        // // Synthesize into
        // [RPC, Autogen]
        // public virtual void SynthesizeIntoInventory(Player player)
        // {
        //     if (this.Inventory.NonEmptyStacks.Count() < this.Inventory.Stacks.Count())
        //     {
        //         Result result = this.Inventory.TryAddItem(new MachinePartsItem());
        //         if(result.Success) {
        //             player.MsgLocStr("<color=green>Synthesized part into inventory");
        //             return;
        //         }
        //     }
        //     player.MsgLocStr("<color=red>No space in inventory to synthesize!");
        //     return;
        // }

        // // Pull-out button
        // [RPC, Autogen]
        // public virtual void PullOutPart(Player player)
        // {
        //     this.PullOutAll(player);
        //     // var itemStacks = this.Inventory.NonEmptyStacks;
        //     // this.Inventory.MoveAsManyItemsAsPossible(player.User.Inventory, player.User); // This respects inventory space and weight!
        //     // // TODO Find a way to check this result, but honestly we don't care, it's just doing its best that it can.
        // }

        
        // // Put-in button
        // [RPC, Autogen]
        // public virtual void PutInPart(Player player)
        // {
        //     this.PutInSelected(player);
        //     // ItemStack itemStack = player.User.Inventory.Toolbar.SelectedStack;
        //     // var isItemValid = itemStack?.Item != null && itemStack.Item is RepairableMachinePartsItem;
        //     // if(isItemValid) {
        //     //     Result result = player.User.Inventory.MoveItems(itemStack, this.Inventory, 1); // Try to move item
        //     //     if(result.Success) {
        //     //         player.MsgLocStr("<color=green>Put in part");
        //     //     } else {
        //     //         player.MsgLocStr("<color=red>Could not insert part!");
        //     //     }
        //     // } else {
        //     //     player.MsgLocStr("<color=red>No valid part in hand");
        //     // }
        // }

        // Handle removal of items from inventory during pickup of world object
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

    }
}
