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
    [Solid, Wall, Diggable]
    [RequiresSkill(typeof(MiningSkill), 1)]
    [Tag(BlockTags.Diggable)]
    public partial class CrushedAlumnicSlagBlock :
        Block
        , IRepresentsItem
    {
        public virtual Type RepresentedItemType { get { return typeof(CrushedAlumnicSlagItem); } }
    }

    [Serialized]
    [LocDisplayName("Crushed Alumnic Slag")]
    [LocDescription("Alumnic Slag that has been crushed into a fine gravel.")]
    [MaxStackSize(10)]
    [Weight(24000)]
    [StartsDiscovered]
    [Ecopedia("Blocks", "Processed Rock", createAsSubPage: true)]
    [Category("Hidden")]
    [Tag("CrushedRock")]
    [RequiresTool(typeof(ShovelItem))]
    public partial class CrushedAlumnicSlagItem: BlockItem<CrushedAlumnicSlagBlock>
    {
        public override LocString DisplayNamePlural { get { return Localizer.DoStr("Crushed Alumnic Slag"); } }

        public override bool CanStickToWalls { get { return false; } }
    }
}