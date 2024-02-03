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
    [IsForm(typeof(FloorFormType), typeof(MortaredBasaltItem))]
    [Tag("Constructable")]
    public partial class MortaredBasaltFloorBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(MortaredBasaltItem); } }
    }
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(CubeFormType), typeof(MortaredBasaltItem))]
    [Tag("Constructable")]
    public partial class MortaredBasaltCubeBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(MortaredBasaltItem); } }
    }
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(RoofCubeFormType), typeof(MortaredBasaltItem))]
    [Tag("Constructable")]
    public partial class MortaredBasaltRoofCubeBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(MortaredBasaltItem); } }
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(WallFormType), typeof(MortaredBasaltItem))]
    [Tag("Constructable")]
    public partial class MortaredBasaltWallBlock :
        Block, IRepresentsItem, IWaterLoggedBlock
    {
        public Type RepresentedItemType { get { return typeof(MortaredBasaltItem); } }
    }
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(RoofFormType), typeof(MortaredBasaltItem))]
    [Tag("Constructable")]
    public partial class MortaredBasaltRoofBlock :
        Block, IRepresentsItem, IWaterLoggedBlock
    {
        public Type RepresentedItemType { get { return typeof(MortaredBasaltItem); } }
    }
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(ColumnFormType), typeof(MortaredBasaltItem))]
    [Tag("Constructable")]
    public partial class MortaredBasaltColumnBlock :
        Block, IRepresentsItem, IWaterLoggedBlock
    {
        public Type RepresentedItemType { get { return typeof(MortaredBasaltItem); } }
    }
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(WindowGrillesFormType), typeof(MortaredBasaltItem))]
    [Tag("Constructable")]
    public partial class MortaredBasaltWindowGrillesBlock :
        Block, IRepresentsItem, IWaterLoggedBlock
    {
        public Type RepresentedItemType { get { return typeof(MortaredBasaltItem); } }
    }
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(RoofPeakSetFormType), typeof(MortaredBasaltItem))]
    [Tag("Constructable")]
    public partial class MortaredBasaltRoofPeakSetBlock :
        Block, IRepresentsItem, IWaterLoggedBlock
    {
        public Type RepresentedItemType { get { return typeof(MortaredBasaltItem); } }
    }





    [RotatedVariants(typeof(MortaredBasaltStairsBlock), typeof(MortaredBasaltStairs90Block), typeof(MortaredBasaltStairs180Block), typeof(MortaredBasaltStairs270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(StairsFormType), typeof(MortaredBasaltItem))]
    [Tag("Constructable")]
    public partial class MortaredBasaltStairsBlock : Block, IWaterLoggedBlock
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class MortaredBasaltStairs90Block : Block, IWaterLoggedBlock
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class MortaredBasaltStairs180Block : Block, IWaterLoggedBlock
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class MortaredBasaltStairs270Block : Block, IWaterLoggedBlock
    { }
    [RotatedVariants(typeof(MortaredBasaltRoofSideBlock), typeof(MortaredBasaltRoofSide90Block), typeof(MortaredBasaltRoofSide180Block), typeof(MortaredBasaltRoofSide270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(RoofSideFormType), typeof(MortaredBasaltItem))]
    [Tag("Constructable")]
    public partial class MortaredBasaltRoofSideBlock : Block, IWaterLoggedBlock
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class MortaredBasaltRoofSide90Block : Block, IWaterLoggedBlock
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class MortaredBasaltRoofSide180Block : Block, IWaterLoggedBlock
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class MortaredBasaltRoofSide270Block : Block, IWaterLoggedBlock
    { }
    [RotatedVariants(typeof(MortaredBasaltRoofTurnBlock), typeof(MortaredBasaltRoofTurn90Block), typeof(MortaredBasaltRoofTurn180Block), typeof(MortaredBasaltRoofTurn270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(RoofTurnFormType), typeof(MortaredBasaltItem))]
    [Tag("Constructable")]
    public partial class MortaredBasaltRoofTurnBlock : Block, IWaterLoggedBlock
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class MortaredBasaltRoofTurn90Block : Block, IWaterLoggedBlock
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class MortaredBasaltRoofTurn180Block : Block, IWaterLoggedBlock
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class MortaredBasaltRoofTurn270Block : Block, IWaterLoggedBlock
    { }
    [RotatedVariants(typeof(MortaredBasaltRoofCornerBlock), typeof(MortaredBasaltRoofCorner90Block), typeof(MortaredBasaltRoofCorner180Block), typeof(MortaredBasaltRoofCorner270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(RoofCornerFormType), typeof(MortaredBasaltItem))]
    [Tag("Constructable")]
    public partial class MortaredBasaltRoofCornerBlock : Block, IWaterLoggedBlock
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class MortaredBasaltRoofCorner90Block : Block, IWaterLoggedBlock
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class MortaredBasaltRoofCorner180Block : Block, IWaterLoggedBlock
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class MortaredBasaltRoofCorner270Block : Block, IWaterLoggedBlock
    { }
    [RotatedVariants(typeof(MortaredBasaltRoofPeakBlock), typeof(MortaredBasaltRoofPeak90Block), typeof(MortaredBasaltRoofPeak180Block), typeof(MortaredBasaltRoofPeak270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(RoofPeakFormType), typeof(MortaredBasaltItem))]
    [Tag("Constructable")]
    public partial class MortaredBasaltRoofPeakBlock : Block, IWaterLoggedBlock
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class MortaredBasaltRoofPeak90Block : Block, IWaterLoggedBlock
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class MortaredBasaltRoofPeak180Block : Block, IWaterLoggedBlock
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class MortaredBasaltRoofPeak270Block : Block, IWaterLoggedBlock
    { }

}