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
    public partial class CryoliteOreBlock :
        Block
        , IRepresentsItem
    {
        public virtual Type RepresentedItemType { get { return typeof(CryoliteOreItem); } }
    }

    [Serialized]
    [LocDisplayName("Cryolite")]
    [LocDescription("Cryolite is a green banded mineral which is commonly refined into copper.")]
    [MaxStackSize(20)]
    [Weight(10000)]
    [ResourcePile]
    [Ecopedia("Natural Resources", "Ore", createAsSubPage: true)]
    [Tag("Ore")]
    [Tag("Excavatable")]
    public partial class CryoliteOreItem :

    BlockItem<CryoliteOreBlock>
    {
        public override LocString DisplayNamePlural { get { return Localizer.DoStr("CryoliteOre"); } }

        public override bool CanStickToWalls { get { return false; } }

        private static Type[] blockTypes = new Type[] {
            typeof(CryoliteOreStacked1Block),
            typeof(CryoliteOreStacked2Block),
            typeof(CryoliteOreStacked3Block),
            typeof(CryoliteOreStacked4Block)
        };

        public override Type[] BlockTypes { get { return blockTypes; } }
    }

    [Tag("Ore")]
    [Tag("Excavatable")]
    [Tag(BlockTags.PartialStack)]
    [Serialized, Solid] public class CryoliteOreStacked1Block : PickupableBlock, IWaterLoggedBlock { }
    [Tag("Ore")]
    [Tag("Excavatable")]
    [Tag(BlockTags.PartialStack)]
    [Serialized, Solid] public class CryoliteOreStacked2Block : PickupableBlock, IWaterLoggedBlock { }
    [Tag("Ore")]
    [Tag("Excavatable")]
    [Tag(BlockTags.PartialStack)]
    [Serialized, Solid] public class CryoliteOreStacked3Block : PickupableBlock, IWaterLoggedBlock { }
    [Tag("Ore")]
    [Tag("Excavatable")]
    [Tag(BlockTags.FullStack)]
    [Serialized, Solid, Wall] public class CryoliteOreStacked4Block : PickupableBlock, IWaterLoggedBlock { } //Only a wall if it's all 4 CryoliteOre
}