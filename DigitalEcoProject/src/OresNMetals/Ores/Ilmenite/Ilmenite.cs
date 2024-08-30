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
    [Solid, Wall, Minable(4)]
    public partial class IlmeniteOreBlock :
        Block
        , IRepresentsItem
    {
        public virtual Type RepresentedItemType { get { return typeof(IlmeniteOreItem); } }
    }

    [Serialized]
    [LocDisplayName("Ilmenite")]
    [LocDescription("Ilmenite is an important ore... for a metal we can't yet understand. It seems like we can refine some iron out of it, but not too much.")]
    [MaxStackSize(20)]
    [Weight(10000)]
    [ResourcePile]
    [Ecopedia("Natural Resources", "Ore", createAsSubPage: true)]
    [Tag("Ore")]
    [Tag("Excavatable")]
    public partial class IlmeniteOreItem :

    BlockItem<IlmeniteOreBlock>
    {
        public override LocString DisplayNamePlural { get { return Localizer.DoStr("Ilmenite"); } }

        public override bool CanStickToWalls { get { return false; } }

        private static Type[] blockTypes = new Type[] {
            typeof(IlmeniteOreStacked1Block),
            typeof(IlmeniteOreStacked2Block),
            typeof(IlmeniteOreStacked3Block),
            typeof(IlmeniteOreStacked4Block)
        };

        public override Type[] BlockTypes { get { return blockTypes; } }
    }

    [Tag("Ore")]
    [Tag("Excavatable")]
    [Tag(BlockTags.PartialStack)]
    [Serialized, Solid] public class IlmeniteOreStacked1Block : PickupableBlock, IWaterLoggedBlock { }
    [Tag("Ore")]
    [Tag("Excavatable")]
    [Tag(BlockTags.PartialStack)]
    [Serialized, Solid] public class IlmeniteOreStacked2Block : PickupableBlock, IWaterLoggedBlock { }
    [Tag("Ore")]
    [Tag("Excavatable")]
    [Tag(BlockTags.PartialStack)]
    [Serialized, Solid] public class IlmeniteOreStacked3Block : PickupableBlock, IWaterLoggedBlock { }
    [Tag("Ore")]
    [Tag("Excavatable")]
    [Tag(BlockTags.FullStack)]
    [Serialized, Solid, Wall] public class IlmeniteOreStacked4Block : PickupableBlock, IWaterLoggedBlock { } //Only a wall if it's all 4 IlmeniteOre
}
