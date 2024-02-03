using System;
using System.Collections.Generic;
using System.ComponentModel;
using Eco.Gameplay.Items;
using Eco.Gameplay.Skills;
using Eco.Core.Items;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;
using Eco.Shared.SharedTypes;
using Eco.World.Blocks;

namespace Eco.Mods.TechTree
{
    [Serialized]
    [Solid, Wall, Diggable]
    [RequiresSkill(typeof(MiningSkill), 1)]
    [Tag(BlockTags.Diggable)]
        public partial class CrushedCopperOreBlock :
        Block
        , IRepresentsItem
    {
        public virtual Type RepresentedItemType { get { return typeof(CrushedCopperOreItem); } }
    }

    [Serialized]
    [LocDisplayName("Crushed Copper Ore")]
    [LocDescription("Crushed copper ore that is ready to be concentrated.")]
    [MaxStackSize(10)]
    [Weight(28000)]
    [StartsDiscovered]
    [Ecopedia("Blocks", "Processed Rock", createAsSubPage: true)]
    [Tag("Excavatable")]
    [RequiresTool(typeof(ShovelItem))]
    public partial class CrushedCopperOreItem :
 
    BlockItem<CrushedCopperOreBlock>
    {
        public override LocString DisplayNamePlural { get { return Localizer.DoStr("Crushed Copper Ore"); } }

        public override bool CanStickToWalls { get { return false; } }
    }

}
