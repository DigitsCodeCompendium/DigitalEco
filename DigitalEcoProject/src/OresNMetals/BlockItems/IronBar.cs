using System;
using System.Collections.Generic;
using System.ComponentModel;
using Eco.Gameplay.Components;
using Eco.Gameplay.Items;
using Eco.Gameplay.Objects;
using Eco.Gameplay.Skills;
using Eco.Core.Items;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;
using Eco.Shared.SharedTypes;
using Eco.World.Blocks;
using Eco.World.Water;
using Eco.Gameplay.Items.Recipes;

namespace Eco.Mods.TechTree
{
    [Serialized]
    [Solid, Wall, Constructed]
    [RequiresSkill(typeof(SmeltingSkill), 1)]
        public partial class IronBarBlock :
        Block
        , IRepresentsItem
    {
        public virtual Type RepresentedItemType { get { return typeof(IronBarItem); } }
    }

    [Serialized]
    [LocDisplayName("Iron Bar")]
    [LocDescription("Refined bar of iron.")]
    [MaxStackSize(20)]
    [Weight(15000)]
    [Ecopedia("Blocks", "Metals", createAsSubPage: true)]
    [Currency][Tag("Currency")]
    [Tag("Metal")]
    public partial class IronBarItem :
 
    BlockItem<IronBarBlock>
    {

        public override bool CanStickToWalls { get { return false; } }

        private static Type[] blockTypes = new Type[] {
            typeof(IronBarStacked1Block),
            typeof(IronBarStacked2Block),
            typeof(IronBarStacked3Block),
            typeof(IronBarStacked4Block)
        };
        
        public override Type[] BlockTypes { get { return blockTypes; } }
    }

    [Tag("Metal")]
    [Tag(BlockTags.PartialStack)]
    [Serialized, Solid] public class IronBarStacked1Block : PickupableBlock, IWaterLoggedBlock { }
    [Tag("Metal")]
    [Tag(BlockTags.PartialStack)]
    [Serialized, Solid] public class IronBarStacked2Block : PickupableBlock, IWaterLoggedBlock { }
    [Tag("Metal")]
    [Tag(BlockTags.PartialStack)]
    [Serialized, Solid] public class IronBarStacked3Block : PickupableBlock, IWaterLoggedBlock { }
    [Tag("Metal")]
    [Tag(BlockTags.FullStack)]
    [Serialized, Solid,Wall] public class IronBarStacked4Block : PickupableBlock, IWaterLoggedBlock { } //Only a wall if it's all 4 IronBar
}
