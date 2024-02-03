using System;
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
    public partial class MarbleBlock :
        Block
        , IRepresentsItem
    {
        public virtual Type RepresentedItemType { get { return typeof(MarbleItem); } }
    }

    [Serialized]
    [LocDisplayName("Marble")]
    [LocDescription("Marble is a metamorphic rock formed from limestone")]
    [MaxStackSize(20)]
    [Weight(10000)]
    [ResourcePile]
    [Ecopedia("Natural Resources", "Ore", createAsSubPage: true)]
    [Tag("Rock")]
    [Tag("Excavatable")]
    public partial class MarbleItem :

    BlockItem<MarbleBlock>
    {
        public override LocString DisplayNamePlural { get { return Localizer.DoStr("Marble"); } }

        public override bool CanStickToWalls { get { return false; } }

        private static Type[] blockTypes = new Type[] {
            typeof(MarbleStacked1Block),
            typeof(MarbleStacked2Block),
            typeof(MarbleStacked3Block),
            typeof(MarbleStacked4Block)
        };

        public override Type[] BlockTypes { get { return blockTypes; } }
    }

    [Tag("Rock")]
    [Tag("Excavatable")]
    [Tag(BlockTags.PartialStack)]
    [Serialized, Solid] public class MarbleStacked1Block : PickupableBlock, IWaterLoggedBlock { }
    [Tag("Rock")]
    [Tag("Excavatable")]
    [Tag(BlockTags.PartialStack)]
    [Serialized, Solid] public class MarbleStacked2Block : PickupableBlock, IWaterLoggedBlock { }
    [Tag("Rock")]
    [Tag("Excavatable")]
    [Tag(BlockTags.PartialStack)]
    [Serialized, Solid] public class MarbleStacked3Block : PickupableBlock, IWaterLoggedBlock { }
    [Tag("Rock")]
    [Tag("Excavatable")]
    [Tag(BlockTags.FullStack)]
    [Serialized, Solid, Wall] public class MarbleStacked4Block : PickupableBlock, IWaterLoggedBlock { } //Only a wall if it's all 4 Marble
}
