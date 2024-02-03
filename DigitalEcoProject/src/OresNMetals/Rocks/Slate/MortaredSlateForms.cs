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
using Eco.Gameplay.Systems.TextLinks;
using Eco.Shared.Serialization;
using Eco.Shared.Utils;
using Eco.World;
using Eco.World.Water;
using Eco.World.Blocks;
using Eco.Gameplay.Pipes;
using Tag = Eco.Core.Items.TagAttribute;

namespace Eco.Mods.TechTree
{
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(FloorFormType), typeof(MortaredSlateItem))]
    [Tag("Constructable")]
    public partial class MortaredSlateFloorBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(MortaredSlateItem); } }
    }
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(CubeFormType), typeof(MortaredSlateItem))]
    [Tag("Constructable")]
    public partial class MortaredSlateCubeBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(MortaredSlateItem); } }
    }
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(RoofCubeFormType), typeof(MortaredSlateItem))]
    [Tag("Constructable")]
    public partial class MortaredSlateRoofCubeBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(MortaredSlateItem); } }
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(WallFormType), typeof(MortaredSlateItem))]
    [Tag("Constructable")]
    public partial class MortaredSlateWallBlock :
        Block, IRepresentsItem, IWaterLoggedBlock
    {
        public Type RepresentedItemType { get { return typeof(MortaredSlateItem); } }
    }
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(RoofFormType), typeof(MortaredSlateItem))]
    [Tag("Constructable")]
    public partial class MortaredSlateRoofBlock :
        Block, IRepresentsItem, IWaterLoggedBlock
    {
        public Type RepresentedItemType { get { return typeof(MortaredSlateItem); } }
    }
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(ColumnFormType), typeof(MortaredSlateItem))]
    [Tag("Constructable")]
    public partial class MortaredSlateColumnBlock :
        Block, IRepresentsItem, IWaterLoggedBlock
    {
        public Type RepresentedItemType { get { return typeof(MortaredSlateItem); } }
    }
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(WindowGrillesFormType), typeof(MortaredSlateItem))]
    [Tag("Constructable")]
    public partial class MortaredSlateWindowGrillesBlock :
        Block, IRepresentsItem, IWaterLoggedBlock
    {
        public Type RepresentedItemType { get { return typeof(MortaredSlateItem); } }
    }
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(RoofPeakSetFormType), typeof(MortaredSlateItem))]
    [Tag("Constructable")]
    public partial class MortaredSlateRoofPeakSetBlock :
        Block, IRepresentsItem, IWaterLoggedBlock
    {
        public Type RepresentedItemType { get { return typeof(MortaredSlateItem); } }
    }





    [RotatedVariants(typeof(MortaredSlateStairsBlock), typeof(MortaredSlateStairs90Block), typeof(MortaredSlateStairs180Block), typeof(MortaredSlateStairs270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(StairsFormType), typeof(MortaredSlateItem))]
    [Tag("Constructable")]
    public partial class MortaredSlateStairsBlock : Block, IWaterLoggedBlock
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class MortaredSlateStairs90Block : Block, IWaterLoggedBlock
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class MortaredSlateStairs180Block : Block, IWaterLoggedBlock
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class MortaredSlateStairs270Block : Block, IWaterLoggedBlock
    { }
    [RotatedVariants(typeof(MortaredSlateRoofSideBlock), typeof(MortaredSlateRoofSide90Block), typeof(MortaredSlateRoofSide180Block), typeof(MortaredSlateRoofSide270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(RoofSideFormType), typeof(MortaredSlateItem))]
    [Tag("Constructable")]
    public partial class MortaredSlateRoofSideBlock : Block, IWaterLoggedBlock
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class MortaredSlateRoofSide90Block : Block, IWaterLoggedBlock
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class MortaredSlateRoofSide180Block : Block, IWaterLoggedBlock
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class MortaredSlateRoofSide270Block : Block, IWaterLoggedBlock
    { }
    [RotatedVariants(typeof(MortaredSlateRoofTurnBlock), typeof(MortaredSlateRoofTurn90Block), typeof(MortaredSlateRoofTurn180Block), typeof(MortaredSlateRoofTurn270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(RoofTurnFormType), typeof(MortaredSlateItem))]
    [Tag("Constructable")]
    public partial class MortaredSlateRoofTurnBlock : Block, IWaterLoggedBlock
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class MortaredSlateRoofTurn90Block : Block, IWaterLoggedBlock
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class MortaredSlateRoofTurn180Block : Block, IWaterLoggedBlock
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class MortaredSlateRoofTurn270Block : Block, IWaterLoggedBlock
    { }
    [RotatedVariants(typeof(MortaredSlateRoofCornerBlock), typeof(MortaredSlateRoofCorner90Block), typeof(MortaredSlateRoofCorner180Block), typeof(MortaredSlateRoofCorner270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(RoofCornerFormType), typeof(MortaredSlateItem))]
    [Tag("Constructable")]
    public partial class MortaredSlateRoofCornerBlock : Block, IWaterLoggedBlock
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class MortaredSlateRoofCorner90Block : Block, IWaterLoggedBlock
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class MortaredSlateRoofCorner180Block : Block, IWaterLoggedBlock
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class MortaredSlateRoofCorner270Block : Block, IWaterLoggedBlock
    { }
    [RotatedVariants(typeof(MortaredSlateRoofPeakBlock), typeof(MortaredSlateRoofPeak90Block), typeof(MortaredSlateRoofPeak180Block), typeof(MortaredSlateRoofPeak270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(RoofPeakFormType), typeof(MortaredSlateItem))]
    [Tag("Constructable")]
    public partial class MortaredSlateRoofPeakBlock : Block, IWaterLoggedBlock
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class MortaredSlateRoofPeak90Block : Block, IWaterLoggedBlock
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class MortaredSlateRoofPeak180Block : Block, IWaterLoggedBlock
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class MortaredSlateRoofPeak270Block : Block, IWaterLoggedBlock
    { }

}