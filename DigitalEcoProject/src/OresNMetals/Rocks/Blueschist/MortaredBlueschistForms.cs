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
    [IsForm(typeof(FloorFormType), typeof(MortaredBlueschistItem))]
    [Tag("Constructable")]
    public partial class MortaredBlueschistFloorBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(MortaredBlueschistItem); } }
    }
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(CubeFormType), typeof(MortaredBlueschistItem))]
    [Tag("Constructable")]
    public partial class MortaredBlueschistCubeBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(MortaredBlueschistItem); } }
    }
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(RoofCubeFormType), typeof(MortaredBlueschistItem))]
    [Tag("Constructable")]
    public partial class MortaredBlueschistRoofCubeBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(MortaredBlueschistItem); } }
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(WallFormType), typeof(MortaredBlueschistItem))]
    [Tag("Constructable")]
    public partial class MortaredBlueschistWallBlock :
        Block, IRepresentsItem, IWaterLoggedBlock
    {
        public Type RepresentedItemType { get { return typeof(MortaredBlueschistItem); } }
    }
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(RoofFormType), typeof(MortaredBlueschistItem))]
    [Tag("Constructable")]
    public partial class MortaredBlueschistRoofBlock :
        Block, IRepresentsItem, IWaterLoggedBlock
    {
        public Type RepresentedItemType { get { return typeof(MortaredBlueschistItem); } }
    }
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(ColumnFormType), typeof(MortaredBlueschistItem))]
    [Tag("Constructable")]
    public partial class MortaredBlueschistColumnBlock :
        Block, IRepresentsItem, IWaterLoggedBlock
    {
        public Type RepresentedItemType { get { return typeof(MortaredBlueschistItem); } }
    }
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(WindowGrillesFormType), typeof(MortaredBlueschistItem))]
    [Tag("Constructable")]
    public partial class MortaredBlueschistWindowGrillesBlock :
        Block, IRepresentsItem, IWaterLoggedBlock
    {
        public Type RepresentedItemType { get { return typeof(MortaredBlueschistItem); } }
    }
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(RoofPeakSetFormType), typeof(MortaredBlueschistItem))]
    [Tag("Constructable")]
    public partial class MortaredBlueschistRoofPeakSetBlock :
        Block, IRepresentsItem, IWaterLoggedBlock
    {
        public Type RepresentedItemType { get { return typeof(MortaredBlueschistItem); } }
    }





    [RotatedVariants(typeof(MortaredBlueschistStairsBlock), typeof(MortaredBlueschistStairs90Block), typeof(MortaredBlueschistStairs180Block), typeof(MortaredBlueschistStairs270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(StairsFormType), typeof(MortaredBlueschistItem))]
    [Tag("Constructable")]
    public partial class MortaredBlueschistStairsBlock : Block, IWaterLoggedBlock
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class MortaredBlueschistStairs90Block : Block, IWaterLoggedBlock
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class MortaredBlueschistStairs180Block : Block, IWaterLoggedBlock
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class MortaredBlueschistStairs270Block : Block, IWaterLoggedBlock
    { }
    [RotatedVariants(typeof(MortaredBlueschistRoofSideBlock), typeof(MortaredBlueschistRoofSide90Block), typeof(MortaredBlueschistRoofSide180Block), typeof(MortaredBlueschistRoofSide270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(RoofSideFormType), typeof(MortaredBlueschistItem))]
    [Tag("Constructable")]
    public partial class MortaredBlueschistRoofSideBlock : Block, IWaterLoggedBlock
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class MortaredBlueschistRoofSide90Block : Block, IWaterLoggedBlock
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class MortaredBlueschistRoofSide180Block : Block, IWaterLoggedBlock
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class MortaredBlueschistRoofSide270Block : Block, IWaterLoggedBlock
    { }
    [RotatedVariants(typeof(MortaredBlueschistRoofTurnBlock), typeof(MortaredBlueschistRoofTurn90Block), typeof(MortaredBlueschistRoofTurn180Block), typeof(MortaredBlueschistRoofTurn270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(RoofTurnFormType), typeof(MortaredBlueschistItem))]
    [Tag("Constructable")]
    public partial class MortaredBlueschistRoofTurnBlock : Block, IWaterLoggedBlock
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class MortaredBlueschistRoofTurn90Block : Block, IWaterLoggedBlock
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class MortaredBlueschistRoofTurn180Block : Block, IWaterLoggedBlock
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class MortaredBlueschistRoofTurn270Block : Block, IWaterLoggedBlock
    { }
    [RotatedVariants(typeof(MortaredBlueschistRoofCornerBlock), typeof(MortaredBlueschistRoofCorner90Block), typeof(MortaredBlueschistRoofCorner180Block), typeof(MortaredBlueschistRoofCorner270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(RoofCornerFormType), typeof(MortaredBlueschistItem))]
    [Tag("Constructable")]
    public partial class MortaredBlueschistRoofCornerBlock : Block, IWaterLoggedBlock
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class MortaredBlueschistRoofCorner90Block : Block, IWaterLoggedBlock
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class MortaredBlueschistRoofCorner180Block : Block, IWaterLoggedBlock
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class MortaredBlueschistRoofCorner270Block : Block, IWaterLoggedBlock
    { }
    [RotatedVariants(typeof(MortaredBlueschistRoofPeakBlock), typeof(MortaredBlueschistRoofPeak90Block), typeof(MortaredBlueschistRoofPeak180Block), typeof(MortaredBlueschistRoofPeak270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(RoofPeakFormType), typeof(MortaredBlueschistItem))]
    [Tag("Constructable")]
    public partial class MortaredBlueschistRoofPeakBlock : Block, IWaterLoggedBlock
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class MortaredBlueschistRoofPeak90Block : Block, IWaterLoggedBlock
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class MortaredBlueschistRoofPeak180Block : Block, IWaterLoggedBlock
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class MortaredBlueschistRoofPeak270Block : Block, IWaterLoggedBlock
    { }

}