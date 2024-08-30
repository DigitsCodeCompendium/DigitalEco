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
    public partial class CrushedBauxiteOreBlock :
        Block
        , IRepresentsItem
    {
        public virtual Type RepresentedItemType { get { return typeof(CrushedBauxiteOreItem); } }
    }

    [Serialized]
    [LocDisplayName("Crushed Bauxite")]
    [LocDescription("Bauxite rocks that have been crushed into a fine gravel.")]
    [MaxStackSize(10)]
    [Weight(26000)]
    [StartsDiscovered]
    [Ecopedia("Blocks", "Processed Rock", createAsSubPage: true)]
    [Category("Hidden")]
    [Tag("Excavatable")]
    [RequiresTool(typeof(ShovelItem))]
    public partial class CrushedBauxiteOreItem :

    BlockItem<CrushedBauxiteOreBlock>
    {
        public override LocString DisplayNamePlural { get { return Localizer.DoStr("Crushed Bauxite"); } }

        public override bool CanStickToWalls { get { return false; } }
    }
}