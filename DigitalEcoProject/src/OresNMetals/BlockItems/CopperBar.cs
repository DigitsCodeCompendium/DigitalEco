﻿using System;
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
        public partial class CopperBarBlock :
        Block
        , IRepresentsItem
    {
        public virtual Type RepresentedItemType { get { return typeof(CopperBarItem); } }
    }

    [Serialized]
    [LocDisplayName("Copper Bar")]
    [LocDescription("Refined bar of copper.")]
    [MaxStackSize(20)]
    [Weight(18000)]
    [Ecopedia("Blocks", "Metals", createAsSubPage: true)]
    [Currency][Tag("Currency")]
    [Tag("Metal")]
    public partial class CopperBarItem :
 
    BlockItem<CopperBarBlock>
    {

        public override bool CanStickToWalls { get { return false; } }

        private static Type[] blockTypes = new Type[] {
            typeof(CopperBarStacked1Block),
            typeof(CopperBarStacked2Block),
            typeof(CopperBarStacked3Block),
            typeof(CopperBarStacked4Block)
        };
        
        public override Type[] BlockTypes { get { return blockTypes; } }
    }

    [Tag("Metal")]
    [Tag(BlockTags.PartialStack)]
    [Serialized, Solid] public class CopperBarStacked1Block : PickupableBlock, IWaterLoggedBlock { }
    [Tag("Metal")]
    [Tag(BlockTags.PartialStack)]
    [Serialized, Solid] public class CopperBarStacked2Block : PickupableBlock, IWaterLoggedBlock { }
    [Tag("Metal")]
    [Tag(BlockTags.PartialStack)]
    [Serialized, Solid] public class CopperBarStacked3Block : PickupableBlock, IWaterLoggedBlock { }
    [Tag("Metal")]
    [Tag(BlockTags.FullStack)]
    [Serialized, Solid,Wall] public class CopperBarStacked4Block : PickupableBlock, IWaterLoggedBlock { } //Only a wall if it's all 4 CopperBar
}
