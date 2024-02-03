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
    [IsForm(typeof(FloorFormType), typeof(MortaredBlackMarbleItem))]
    [Tag("Constructable")]
    public partial class MortaredBlackMarbleFloorBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(MortaredBlackMarbleItem); } }
    }
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(CubeFormType), typeof(MortaredBlackMarbleItem))]
    [Tag("Constructable")]
    public partial class MortaredBlackMarbleCubeBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(MortaredBlackMarbleItem); } }
    }
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(RoofCubeFormType), typeof(MortaredBlackMarbleItem))]
    [Tag("Constructable")]
    public partial class MortaredBlackMarbleRoofCubeBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(MortaredBlackMarbleItem); } }
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(WallFormType), typeof(MortaredBlackMarbleItem))]
    [Tag("Constructable")]
    public partial class MortaredBlackMarbleWallBlock :
        Block, IRepresentsItem, IWaterLoggedBlock
    {
        public Type RepresentedItemType { get { return typeof(MortaredBlackMarbleItem); } }
    }
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(RoofFormType), typeof(MortaredBlackMarbleItem))]
    [Tag("Constructable")]
    public partial class MortaredBlackMarbleRoofBlock :
        Block, IRepresentsItem, IWaterLoggedBlock
    {
        public Type RepresentedItemType { get { return typeof(MortaredBlackMarbleItem); } }
    }
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(ColumnFormType), typeof(MortaredBlackMarbleItem))]
    [Tag("Constructable")]
    public partial class MortaredBlackMarbleColumnBlock :
        Block, IRepresentsItem, IWaterLoggedBlock
    {
        public Type RepresentedItemType { get { return typeof(MortaredBlackMarbleItem); } }
    }
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(WindowGrillesFormType), typeof(MortaredBlackMarbleItem))]
    [Tag("Constructable")]
    public partial class MortaredBlackMarbleWindowGrillesBlock :
        Block, IRepresentsItem, IWaterLoggedBlock
    {
        public Type RepresentedItemType { get { return typeof(MortaredBlackMarbleItem); } }
    }
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(RoofPeakSetFormType), typeof(MortaredBlackMarbleItem))]
    [Tag("Constructable")]
    public partial class MortaredBlackMarbleRoofPeakSetBlock :
        Block, IRepresentsItem, IWaterLoggedBlock
    {
        public Type RepresentedItemType { get { return typeof(MortaredBlackMarbleItem); } }
    }





    [RotatedVariants(typeof(MortaredBlackMarbleStairsBlock), typeof(MortaredBlackMarbleStairs90Block), typeof(MortaredBlackMarbleStairs180Block), typeof(MortaredBlackMarbleStairs270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(StairsFormType), typeof(MortaredBlackMarbleItem))]
    [Tag("Constructable")]
    public partial class MortaredBlackMarbleStairsBlock : Block, IWaterLoggedBlock
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class MortaredBlackMarbleStairs90Block : Block, IWaterLoggedBlock
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class MortaredBlackMarbleStairs180Block : Block, IWaterLoggedBlock
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class MortaredBlackMarbleStairs270Block : Block, IWaterLoggedBlock
    { }
    [RotatedVariants(typeof(MortaredBlackMarbleRoofSideBlock), typeof(MortaredBlackMarbleRoofSide90Block), typeof(MortaredBlackMarbleRoofSide180Block), typeof(MortaredBlackMarbleRoofSide270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(RoofSideFormType), typeof(MortaredBlackMarbleItem))]
    [Tag("Constructable")]
    public partial class MortaredBlackMarbleRoofSideBlock : Block, IWaterLoggedBlock
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class MortaredBlackMarbleRoofSide90Block : Block, IWaterLoggedBlock
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class MortaredBlackMarbleRoofSide180Block : Block, IWaterLoggedBlock
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class MortaredBlackMarbleRoofSide270Block : Block, IWaterLoggedBlock
    { }
    [RotatedVariants(typeof(MortaredBlackMarbleRoofTurnBlock), typeof(MortaredBlackMarbleRoofTurn90Block), typeof(MortaredBlackMarbleRoofTurn180Block), typeof(MortaredBlackMarbleRoofTurn270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(RoofTurnFormType), typeof(MortaredBlackMarbleItem))]
    [Tag("Constructable")]
    public partial class MortaredBlackMarbleRoofTurnBlock : Block, IWaterLoggedBlock
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class MortaredBlackMarbleRoofTurn90Block : Block, IWaterLoggedBlock
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class MortaredBlackMarbleRoofTurn180Block : Block, IWaterLoggedBlock
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class MortaredBlackMarbleRoofTurn270Block : Block, IWaterLoggedBlock
    { }
    [RotatedVariants(typeof(MortaredBlackMarbleRoofCornerBlock), typeof(MortaredBlackMarbleRoofCorner90Block), typeof(MortaredBlackMarbleRoofCorner180Block), typeof(MortaredBlackMarbleRoofCorner270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(RoofCornerFormType), typeof(MortaredBlackMarbleItem))]
    [Tag("Constructable")]
    public partial class MortaredBlackMarbleRoofCornerBlock : Block, IWaterLoggedBlock
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class MortaredBlackMarbleRoofCorner90Block : Block, IWaterLoggedBlock
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class MortaredBlackMarbleRoofCorner180Block : Block, IWaterLoggedBlock
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class MortaredBlackMarbleRoofCorner270Block : Block, IWaterLoggedBlock
    { }
    [RotatedVariants(typeof(MortaredBlackMarbleRoofPeakBlock), typeof(MortaredBlackMarbleRoofPeak90Block), typeof(MortaredBlackMarbleRoofPeak180Block), typeof(MortaredBlackMarbleRoofPeak270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(RoofPeakFormType), typeof(MortaredBlackMarbleItem))]
    [Tag("Constructable")]
    public partial class MortaredBlackMarbleRoofPeakBlock : Block, IWaterLoggedBlock
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class MortaredBlackMarbleRoofPeak90Block : Block, IWaterLoggedBlock
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class MortaredBlackMarbleRoofPeak180Block : Block, IWaterLoggedBlock
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class MortaredBlackMarbleRoofPeak270Block : Block, IWaterLoggedBlock
    { }

}