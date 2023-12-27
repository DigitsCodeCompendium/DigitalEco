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

    [Serialized]
    [RequireComponent(typeof(StatusComponent))]
    [NoIcon]
    [LocDisplayName("Maintenance Component"), LocDescription("Provides information about object maintenance")]
    [AutogenClass]
    public class MaintenanceComponent : WorldObjectComponent, IController
    {

        [Serialized] private bool hasPartInserted;

        public void Initialize()
        {
            base.Initialize();

            hasPartInserted = true;
        }

        // Pop-out button
        [RPC, Autogen]
        public virtual void PullOutPart(Player player)
        {
            if(this.hasPartInserted)
            {
                if (player.User.Inventory.NonEmptyStacks.Count() < player.User.Inventory.Stacks.Count())
                {
                    Result result = player.User.Inventory.TryAddItem(new MachinePartsItem());
                    if(result.Success) {
                        this.hasPartInserted = false;
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
