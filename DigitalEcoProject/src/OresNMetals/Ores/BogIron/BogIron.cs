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
    [Solid, Wall, Diggable]
    [RequiresSkill(typeof(MiningSkill), 1)]
    [Tag(BlockTags.Diggable)]
    public partial class BogIronOreBlock :
        Block
        , IRepresentsItem
    {
        public virtual Type RepresentedItemType { get { return typeof(BogIronOreItem); } }
    }

    [Serialized]
    [LocDisplayName("Bog Iron Ore")]
    [LocDescription("Bog iron")]
    [MaxStackSize(10)]
    [Weight(26000)]
    [StartsDiscovered]
    [Ecopedia("Blocks", "Processed Rock", createAsSubPage: true)]
    [Tag("Excavatable")]
    [RequiresTool(typeof(ShovelItem))]
    public partial class BogIronOreItem :

    BlockItem<BogIronOreBlock>
    {
        public override LocString DisplayNamePlural { get { return Localizer.DoStr("Bog Iron Ore"); } }

        public override bool CanStickToWalls { get { return false; } }
    }
}