namespace Digits.DE_Maintenance
{
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

    [Serialized]
    [RequireComponent(typeof(StatusComponent))]
    [LocDisplayName("Maintenance"), LocDescription("Provides information about object maintenance")]
    [NoIcon]
    [AutogenClass]
    public class MaintenanceComponent : WorldObjectComponent, IController, IHasClientControlledContainers
    {
        private StatusElement status;
        private OnOffComponent onOffComponent;
        private CraftingComponent craftingComponent;

        [Serialized] enum partSlots {}
        [Serialized] private bool hasPartInserted;
        [Serialized] private float partDurability;
        public float tickDurabilityDamage;

        public MaintenanceComponent()
        {
            this.PartsList ??= new ControllerList<PartListElement>(this, nameof(PartsList));
        }

        public void Initialize()
        {
            base.Initialize();

            this.status = this.Parent.GetComponent<StatusComponent>().CreateStatusElement();

            hasPartInserted = true;
        }

        public void InitOnOffComponent()
        {
            this.onOffComponent = this.Parent.GetComponent<OnOffComponent>();
        }

        public void InitCraftingComponent()
        {
            this.craftingComponent = this.Parent.GetComponent<CraftingComponent>();
        }
        
        public override void Tick()
        {
            this.DamagePart(tickDurabilityDamage);
            this.status.SetStatusMessage(false, Localizer.Format("Machine Parts are currently at {0}%", Text.Info(partDurability)));
        }

        //ui List for showing components
        ControllerList<PartListElement> partsList { get; set; }
        [Eco, ClientInterfaceProperty, GuestHidden, PropReadOnly, LocDisplayName("Parts Overview")]
        public ControllerList<PartListElement> PartsList
        {
            get => partsList;
            set
            {
                if (value == partsList) return;
                partsList = value;
                this.Changed(nameof(PartsList));
            }
        }

        public void CreatePartSlots(string[] partSlotNames)
        {
            partsList.Clear();
            foreach (string partSlotName in partSlotNames)
            {
                PartListElement partSlot = new PartListElement();
                partSlot.partName = partSlotName;
                partSlot.status = "Not Installed";
                partsList.Add(partSlot);
            }
        }

        [RPC]
        public void DamagePart(float damage)
        {
            if (hasPartInserted)
            {
                if (this.partDurability - damage > 0) { partDurability -= damage; }
                else { partDurability = 0; }
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
        enumOptions enumSelection {get; set;}
        [Eco, ClientInterfaceProperty, LocDisplayName("Slot Select")]
        public enumOptions EnumSelector
        {
            get => enumSelection;
            set
            {
                if(value == enumSelection) return;
                enumSelection = value;
                this.Changed(nameof(EnumSelector)); 
            }
        }


        // Pop-out button
        [RPC, Autogen]
        public virtual void PullOutPart(Player player)
        {
            if(this.hasPartInserted)
            {
                if (player.User.Inventory.NonEmptyStacks.Count() < player.User.Inventory.Stacks.Count())
                {
                    RepairableItem item = new MachinePartsItem();
                    item.Durability = this.partDurability;
                    Result result = player.User.Inventory.TryAddItem(item);
                    if(result.Success) {
                        this.hasPartInserted = false;
                        this.partDurability = 0f;
                        player.MsgLocStr("<color=green>Pulled out part");
                        return;
                    }
                }
                player.MsgLocStr("<color=red>No space in inventory to pull out parts!");
                return;
            } else {
                player.MsgLocStr("<color=red>No parts to pull out!");
                return;
            }
        }

        // Put-in button
        [RPC, Autogen]
        public virtual void PutInPart(Player player)
        {
            ItemStack itemStack = player.User.Inventory.Toolbar.SelectedStack;
            var isItemValid = itemStack?.Item != null && itemStack.Item is RepairableMachinePartsItem;
            if(isItemValid) {
                if(!this.hasPartInserted)
                {
                    RepairableItem repItem = (RepairableItem) itemStack.Item;
                    this.partDurability = repItem.Durability;
                    itemStack.TryModifyStack(player.User, -1); // Try to delete the item
                    this.hasPartInserted = true;
                    player.MsgLocStr("<color=green>Put in part");
                } else {
                    player.MsgLocStr("<color=red>Could not put in part");
                }
            } else {
                player.MsgLocStr("<color=red>No valid part in hand");
            }
        }
    }
}
