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
    [Solid, Wall, Minable(8)]
    public partial class MagnetiteOreBlock :
        Block
        , IRepresentsItem
    {
        public virtual Type RepresentedItemType { get { return typeof(MagnetiteOreItem); } }
    }

    [Serialized]
    [LocDisplayName("Magnetite")]
    [LocDescription("Magnetite is very easy to refine into iron. The hard part of using magnetite is finding it and digging it up. There are rumors that it can be found deep under the ocean.")]
    [MaxStackSize(20)]
    [Weight(10000)]
    [ResourcePile]
    [Ecopedia("Natural Resources", "Ore", createAsSubPage: true)]
    [Tag("Ore")]
    [Tag("Excavatable")]
    public partial class MagnetiteOreItem :

    BlockItem<MagnetiteOreBlock>
    {
        public override LocString DisplayNamePlural { get { return Localizer.DoStr("Magnetite"); } }

        public override bool CanStickToWalls { get { return false; } }

        private static Type[] blockTypes = new Type[] {
            typeof(MagnetiteOreStacked1Block),
            typeof(MagnetiteOreStacked2Block),
            typeof(MagnetiteOreStacked3Block),
            typeof(MagnetiteOreStacked4Block)
        };

        public override Type[] BlockTypes { get { return blockTypes; } }
    }

    [Tag("Ore")]
    [Tag("Excavatable")]
    [Tag(BlockTags.PartialStack)]
    [Serialized, Solid] public class MagnetiteOreStacked1Block : PickupableBlock, IWaterLoggedBlock { }
    [Tag("Ore")]
    [Tag("Excavatable")]
    [Tag(BlockTags.PartialStack)]
    [Serialized, Solid] public class MagnetiteOreStacked2Block : PickupableBlock, IWaterLoggedBlock { }
    [Tag("Ore")]
    [Tag("Excavatable")]
    [Tag(BlockTags.PartialStack)]
    [Serialized, Solid] public class MagnetiteOreStacked3Block : PickupableBlock, IWaterLoggedBlock { }
    [Tag("Ore")]
    [Tag("Excavatable")]
    [Tag(BlockTags.FullStack)]
    [Serialized, Solid, Wall] public class MagnetiteOreStacked4Block : PickupableBlock, IWaterLoggedBlock { } //Only a wall if it's all 4 MagnetiteOre
}