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
    public partial class GreenschistBlock :
        Block
        , IRepresentsItem
    {
        public virtual Type RepresentedItemType { get { return typeof(GreenschistItem); } }
    }

    [Serialized]
    [LocDisplayName("Greenschist")]
    [LocDescription("Greenschist is a metamorphic rock formed from sandstone.")]
    [MaxStackSize(20)]
    [Weight(10000)]
    [ResourcePile]
    [Ecopedia("Natural Resources", "Ore", createAsSubPage: true)]
    [Tag("Rock")]
    [Tag("Excavatable")]
    public partial class GreenschistItem :

    BlockItem<GreenschistBlock>
    {
        public override LocString DisplayNamePlural { get { return Localizer.DoStr("Greenschist"); } }

        public override bool CanStickToWalls { get { return false; } }

        private static Type[] blockTypes = new Type[] {
            typeof(GreenschistStacked1Block),
            typeof(GreenschistStacked2Block),
            typeof(GreenschistStacked3Block),
            typeof(GreenschistStacked4Block)
        };

        public override Type[] BlockTypes { get { return blockTypes; } }
    }

    [Tag("Rock")]
    [Tag("Excavatable")]
    [Tag(BlockTags.PartialStack)]
    [Serialized, Solid] public class GreenschistStacked1Block : PickupableBlock, IWaterLoggedBlock { }
    [Tag("Rock")]
    [Tag("Excavatable")]
    [Tag(BlockTags.PartialStack)]
    [Serialized, Solid] public class GreenschistStacked2Block : PickupableBlock, IWaterLoggedBlock { }
    [Tag("Rock")]
    [Tag("Excavatable")]
    [Tag(BlockTags.PartialStack)]
    [Serialized, Solid] public class GreenschistStacked3Block : PickupableBlock, IWaterLoggedBlock { }
    [Tag("Rock")]
    [Tag("Excavatable")]
    [Tag(BlockTags.FullStack)]
    [Serialized, Solid, Wall] public class GreenschistStacked4Block : PickupableBlock, IWaterLoggedBlock { } //Only a wall if it's all 4 Greenschist
}
