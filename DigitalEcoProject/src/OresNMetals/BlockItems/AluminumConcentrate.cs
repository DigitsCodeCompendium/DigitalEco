using System;
using System.Collections.Generic;
using System.ComponentModel;
using Eco.Gameplay.Components;
using Eco.Gameplay.Items;
using Eco.Gameplay.Skills;
using Eco.Core.Items;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;
using Eco.Shared.SharedTypes;
using Eco.World.Blocks;
using Eco.Gameplay.Items.Recipes;

namespace Eco.Mods.TechTree
{
    [Serialized]
    [Solid, Wall, Diggable]
    [RequiresSkill(typeof(MiningSkill), 1)]
    [Tag(BlockTags.Diggable)]
    public partial class AluminumConcentrateBlock :
        Block
        , IRepresentsItem
    {
        public virtual Type RepresentedItemType { get { return typeof(AluminumConcentrateItem); } }
    }

    [Serialized]
    [LocDisplayName("Aluminum Concentrate")]
    [LocDescription("Aluminum ore that has been concentrated to remove impurities. Ore concentrate is used by smiths to smelt metal bars.")]
    [MaxStackSize(10)]
    [Weight(20000)]
    [Ecopedia("Blocks", "Processed Rock", createAsSubPage: true)]
    [Tag("ConcentratedOre")]
    [Tag("Excavatable")]
    [Category("Hidden")]
    [RequiresTool(typeof(ShovelItem))]
    public partial class AluminumConcentrateItem :

    BlockItem<AluminumConcentrateBlock>
    {
        public override LocString DisplayNamePlural { get { return Localizer.DoStr("Aluminum Concentrate"); } }

        public override bool CanStickToWalls { get { return false; } }
    }

}
