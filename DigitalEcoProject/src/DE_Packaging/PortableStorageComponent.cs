// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.

namespace Digits.Packing
{
    using System.Linq;
    using System;
    using Eco.Shared;
    using Eco.Core.Controller;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Objects;
    using Eco.Gameplay.Items.PersistentData;
    using Eco.Gameplay.Garbage;
    using Eco.Gameplay.Utils;
    using Eco.Shared.Serialization;
    using static Eco.Gameplay.Items.AuthorizationInventory;
    using Eco.Gameplay.Components.Storage;
    using Digits.Maintenance;
    using Eco.Core.Utils;
    using Eco.Gameplay.Players;
    using System.ComponentModel;
    using Eco.Core.Serialization.Serializers;

    //using Eco.Gameplay.Items.PersistentData;

    [Serialized, CreateComponentTabLoc("Storage"), HasIcon("StorageComponent")]
    public class PortableStorageComponent : StorageComponent, IPersistentData
    {
        public override WorldObjectComponentClientAvailability Availability => WorldObjectComponentClientAvailability.UI;

        [Serialized] public Inventory Storage { get { return InventoryData.Inventory; } set { InventoryData.Inventory = value; } }
        [SyncToView, Serialized] public InventoryItemData InventoryData { get;  set; }
        public override Inventory Inventory => this.Storage;

        public PortableStorageComponent() { }
        public PortableStorageComponent(int numSlots) => this.Initialize(numSlots);
        public PortableStorageComponent(int numSlots, int maxWeight) => this.Initialize(numSlots, maxWeight);

        /// <summary> Some specialized objects (like refrigerator) are designed to preserve food for a certain amount (shelf life and time remaining increase by this multiplier) </summary>
        public float ShelfLifeMultiplier { get; set; } = 1f;

        public object PersistentData { get => this.InventoryData; set => this.InventoryData = value as InventoryItemData; }

        public override void Initialize()
        {
            this.InventoryData ??= new InventoryItemData();

            if (!(this.Storage is AuthorizationInventory))
            {
                // ensure the inventory type is authorization inventory (migration)
                var newInventory = new AuthorizationInventory(
                    this.Storage.Stacks.Count(),
                    AuthorizationFlags.AuthedMayAdd | AuthorizationFlags.AuthedMayRemove);
                newInventory.ReplaceStacks(this.Storage.Stacks);
                this.InventoryData.Inventory = newInventory;
            }

            //Subscribe to WorldObject.Operating changes to update ShelfLifeMultiplier
            if (!Mathf.Equals(this.ShelfLifeMultiplier, 1f))
                this.Parent.SubscribeAndCall(nameof(WorldObject.Enabled), this.UpdateShelfLifeMultiplier);

            base.Initialize();
        }

        /// <summary> Check if WorldObject is enabled and update the ShelfLifeMultiplier provided by this storage </summary>
        void UpdateShelfLifeMultiplier()
        {
            //Check WorldObject is operating to apply ShelfLifeMultiplier
            var shelfLifeMultiplier = this.Parent.Enabled ? this.ShelfLifeMultiplier : 1;
            if (!Mathf.Equals(this.Storage.ShelfLifeMultiplier, shelfLifeMultiplier)) //Only update if different value
            {
                this.Storage.ShelfLifeMultiplier = shelfLifeMultiplier;
                Inventory.InventoryEffectsChanged.Invoke(this.Storage);
            }
        }

        public void Initialize(int numSlots, int maxWeight, params InventoryRestriction[] restrictions)
        {
            this.Initialize(numSlots);
            WeightRestriction.Add(this.Storage, maxWeight, restrictions.OfType<StackLimitRestriction>().Any(x => x.Enabled)); // Enable max stack size surpassing if there's a StackLimitRestriction.
            foreach (var r in restrictions) this.Inventory.AddInvRestriction(r);
        }

        public void Initialize(int numSlots)
        {
            this.InventoryData ??= new InventoryItemData();

            this.InventoryData.Inventory ??= new AuthorizationInventory(numSlots, AuthorizationFlags.AuthedMayAdd | AuthorizationFlags.AuthedMayRemove);
            this.Storage.SetOwner(this.Parent); // Set the owner of the inventory to be the parent world object.
        }

        public override InventoryMoveResult TryPickup(Player player, InventoryChangeSet playerInvChanges, Inventory targetInventory, bool force)
        {
            return Result.Succeeded;
        }
    }
}
