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
    public partial class CrushedSulphuricSlagBlock :
        Block
        , IRepresentsItem
    {
        public virtual Type RepresentedItemType { get { return typeof(CrushedSulphuricSlagItem); } }
    }

    [Serialized]
    [LocDisplayName("Crushed Sulphuric Slag")]
    [LocDescription("Sulphuric Slag rocks that have been crushed into a fine gravel.")]
    [MaxStackSize(10)]
    [Weight(26000)]
    [StartsDiscovered]
    [Ecopedia("Blocks", "Processed Rock", createAsSubPage: true)]
    [Tag("CrushedRock")]
    [RequiresTool(typeof(ShovelItem))]
    public partial class CrushedSulphuricSlagItem :

    BlockItem<CrushedSulphuricSlagBlock>
    {
        public override LocString DisplayNamePlural { get { return Localizer.DoStr("Crushed Sulphuric Slag"); } }

        public override bool CanStickToWalls { get { return false; } }
    }
}