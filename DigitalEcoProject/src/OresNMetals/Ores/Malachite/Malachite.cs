﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using Eco.Gameplay.Blocks;
using Eco.Gameplay.Components;
using Eco.Gameplay.DynamicValues;
using Eco.Gameplay.Items;
using Eco.Gameplay.Objects;
using Eco.Gameplay.Players;
using Eco.Gameplay.Skills;
using Eco.Gameplay.Systems;
using Eco.Gameplay.Systems.TextLinks;
using Eco.Core.Items;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;
using Eco.Shared.Utils;
using Eco.Shared.SharedTypes;
using Eco.World;
using Eco.World.Blocks;
using Eco.World.Water;
using Eco.Gameplay.Pipes;
using Eco.Core.Controller;
using Eco.Gameplay.Items.Recipes;

namespace Eco.Mods.TechTree
{
    [Serialized]
    [Solid, Wall, Minable(2)]
    public partial class MalachiteOreBlock :
        Block
        , IRepresentsItem
    {
        public virtual Type RepresentedItemType { get { return typeof(MalachiteOreItem); } }
    }

    [Serialized]
    [LocDisplayName("Malachite")]
    [LocDescription("Malachite is a green banded mineral which is commonly refined into copper.")]
    [MaxStackSize(20)]
    [Weight(10000)]
    [ResourcePile]
    [Ecopedia("Natural Resources", "Ore", createAsSubPage: true)]
    [Tag("Ore")]
    [Tag("Excavatable")]
    public partial class MalachiteOreItem :

    BlockItem<MalachiteOreBlock>
    {
        public override LocString DisplayNamePlural { get { return Localizer.DoStr("MalachiteOre"); } }

        public override bool CanStickToWalls { get { return false; } }

        private static Type[] blockTypes = new Type[] {
            typeof(MalachiteOreStacked1Block),
            typeof(MalachiteOreStacked2Block),
            typeof(MalachiteOreStacked3Block),
            typeof(MalachiteOreStacked4Block)
        };

        public override Type[] BlockTypes { get { return blockTypes; } }
    }

    [Tag("Ore")]
    [Tag("Excavatable")]
    [Tag(BlockTags.PartialStack)]
    [Serialized, Solid] public class MalachiteOreStacked1Block : PickupableBlock, IWaterLoggedBlock { }
    [Tag("Ore")]
    [Tag("Excavatable")]
    [Tag(BlockTags.PartialStack)]
    [Serialized, Solid] public class MalachiteOreStacked2Block : PickupableBlock, IWaterLoggedBlock { }
    [Tag("Ore")]
    [Tag("Excavatable")]
    [Tag(BlockTags.PartialStack)]
    [Serialized, Solid] public class MalachiteOreStacked3Block : PickupableBlock, IWaterLoggedBlock { }
    [Tag("Ore")]
    [Tag("Excavatable")]
    [Tag(BlockTags.FullStack)]
    [Serialized, Solid, Wall] public class MalachiteOreStacked4Block : PickupableBlock, IWaterLoggedBlock { } //Only a wall if it's all 4 MalachiteOre
}
