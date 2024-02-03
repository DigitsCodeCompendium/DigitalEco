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
    [IsForm(typeof(FloorFormType), typeof(MortaredMarbleItem))]
    [Tag("Constructable")]
    public partial class MortaredMarbleFloorBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(MortaredMarbleItem); } }
    }
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(CubeFormType), typeof(MortaredMarbleItem))]
    [Tag("Constructable")]
    public partial class MortaredMarbleCubeBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(MortaredMarbleItem); } }
    }
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(RoofCubeFormType), typeof(MortaredMarbleItem))]
    [Tag("Constructable")]
    public partial class MortaredMarbleRoofCubeBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(MortaredMarbleItem); } }
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(WallFormType), typeof(MortaredMarbleItem))]
    [Tag("Constructable")]
    public partial class MortaredMarbleWallBlock :
        Block, IRepresentsItem, IWaterLoggedBlock
    {
        public Type RepresentedItemType { get { return typeof(MortaredMarbleItem); } }
    }
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(RoofFormType), typeof(MortaredMarbleItem))]
    [Tag("Constructable")]
    public partial class MortaredMarbleRoofBlock :
        Block, IRepresentsItem, IWaterLoggedBlock
    {
        public Type RepresentedItemType { get { return typeof(MortaredMarbleItem); } }
    }
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(ColumnFormType), typeof(MortaredMarbleItem))]
    [Tag("Constructable")]
    public partial class MortaredMarbleColumnBlock :
        Block, IRepresentsItem, IWaterLoggedBlock
    {
        public Type RepresentedItemType { get { return typeof(MortaredMarbleItem); } }
    }
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(WindowGrillesFormType), typeof(MortaredMarbleItem))]
    [Tag("Constructable")]
    public partial class MortaredMarbleWindowGrillesBlock :
        Block, IRepresentsItem, IWaterLoggedBlock
    {
        public Type RepresentedItemType { get { return typeof(MortaredMarbleItem); } }
    }
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(RoofPeakSetFormType), typeof(MortaredMarbleItem))]
    [Tag("Constructable")]
    public partial class MortaredMarbleRoofPeakSetBlock :
        Block, IRepresentsItem, IWaterLoggedBlock
    {
        public Type RepresentedItemType { get { return typeof(MortaredMarbleItem); } }
    }





    [RotatedVariants(typeof(MortaredMarbleStairsBlock), typeof(MortaredMarbleStairs90Block), typeof(MortaredMarbleStairs180Block), typeof(MortaredMarbleStairs270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(StairsFormType), typeof(MortaredMarbleItem))]
    [Tag("Constructable")]
    public partial class MortaredMarbleStairsBlock : Block, IWaterLoggedBlock
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class MortaredMarbleStairs90Block : Block, IWaterLoggedBlock
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class MortaredMarbleStairs180Block : Block, IWaterLoggedBlock
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class MortaredMarbleStairs270Block : Block, IWaterLoggedBlock
    { }
    [RotatedVariants(typeof(MortaredMarbleRoofSideBlock), typeof(MortaredMarbleRoofSide90Block), typeof(MortaredMarbleRoofSide180Block), typeof(MortaredMarbleRoofSide270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(RoofSideFormType), typeof(MortaredMarbleItem))]
    [Tag("Constructable")]
    public partial class MortaredMarbleRoofSideBlock : Block, IWaterLoggedBlock
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class MortaredMarbleRoofSide90Block : Block, IWaterLoggedBlock
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class MortaredMarbleRoofSide180Block : Block, IWaterLoggedBlock
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class MortaredMarbleRoofSide270Block : Block, IWaterLoggedBlock
    { }
    [RotatedVariants(typeof(MortaredMarbleRoofTurnBlock), typeof(MortaredMarbleRoofTurn90Block), typeof(MortaredMarbleRoofTurn180Block), typeof(MortaredMarbleRoofTurn270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(RoofTurnFormType), typeof(MortaredMarbleItem))]
    [Tag("Constructable")]
    public partial class MortaredMarbleRoofTurnBlock : Block, IWaterLoggedBlock
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class MortaredMarbleRoofTurn90Block : Block, IWaterLoggedBlock
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class MortaredMarbleRoofTurn180Block : Block, IWaterLoggedBlock
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class MortaredMarbleRoofTurn270Block : Block, IWaterLoggedBlock
    { }
    [RotatedVariants(typeof(MortaredMarbleRoofCornerBlock), typeof(MortaredMarbleRoofCorner90Block), typeof(MortaredMarbleRoofCorner180Block), typeof(MortaredMarbleRoofCorner270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(RoofCornerFormType), typeof(MortaredMarbleItem))]
    [Tag("Constructable")]
    public partial class MortaredMarbleRoofCornerBlock : Block, IWaterLoggedBlock
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class MortaredMarbleRoofCorner90Block : Block, IWaterLoggedBlock
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class MortaredMarbleRoofCorner180Block : Block, IWaterLoggedBlock
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class MortaredMarbleRoofCorner270Block : Block, IWaterLoggedBlock
    { }
    [RotatedVariants(typeof(MortaredMarbleRoofPeakBlock), typeof(MortaredMarbleRoofPeak90Block), typeof(MortaredMarbleRoofPeak180Block), typeof(MortaredMarbleRoofPeak270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(RoofPeakFormType), typeof(MortaredMarbleItem))]
    [Tag("Constructable")]
    public partial class MortaredMarbleRoofPeakBlock : Block, IWaterLoggedBlock
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class MortaredMarbleRoofPeak90Block : Block, IWaterLoggedBlock
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class MortaredMarbleRoofPeak180Block : Block, IWaterLoggedBlock
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class MortaredMarbleRoofPeak270Block : Block, IWaterLoggedBlock
    { }

}