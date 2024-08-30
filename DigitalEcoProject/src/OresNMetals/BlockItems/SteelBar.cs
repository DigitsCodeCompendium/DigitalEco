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
    [Solid, Wall, Constructed]
    [RequiresSkill(typeof(AdvancedSmeltingSkill), 1)]
    public partial class SteelBarBlock :
        Block
        , IRepresentsItem
    {
        public virtual Type RepresentedItemType { get { return typeof(SteelBarItem); } }
    }

    [Serialized]
    [LocDisplayName("Steel Bar")]
    [LocDescription("Refined bar of steel.")]
    [MaxStackSize(20)]
    [Weight(20000)]
    [Ecopedia("Blocks", "Metals", createAsSubPage: true)]
    [Currency]
    [Tag("Currency")]
    [Tag("Metal")]
    public partial class SteelBarItem :

    BlockItem<SteelBarBlock>
    {

        public override bool CanStickToWalls { get { return false; } }

        private static Type[] blockTypes = new Type[] {
            typeof(SteelBarStacked1Block),
            typeof(SteelBarStacked2Block),
            typeof(SteelBarStacked3Block),
            typeof(SteelBarStacked4Block)
        };

        public override Type[] BlockTypes { get { return blockTypes; } }
    }

    [Tag("Metal")]
    [Tag(BlockTags.PartialStack)]
    [Serialized, Solid] public class SteelBarStacked1Block : PickupableBlock, IWaterLoggedBlock { }
    [Tag("Metal")]
    [Tag(BlockTags.PartialStack)]
    [Serialized, Solid] public class SteelBarStacked2Block : PickupableBlock, IWaterLoggedBlock { }
    [Tag("Metal")]
    [Tag(BlockTags.PartialStack)]
    [Serialized, Solid] public class SteelBarStacked3Block : PickupableBlock, IWaterLoggedBlock { }
    [Tag("Metal")]
    [Tag(BlockTags.FullStack)]
    [Serialized, Solid, Wall] public class SteelBarStacked4Block : PickupableBlock, IWaterLoggedBlock { } //Only a wall if it's all 4 SteelBar
}
