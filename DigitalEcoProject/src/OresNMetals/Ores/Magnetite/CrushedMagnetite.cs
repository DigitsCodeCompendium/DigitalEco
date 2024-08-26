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
    [RequiresSkill(typeof(MiningSkill), 1)]
    public partial class CrushedMagnetiteOreLv2Recipe : Recipe
    {
        public CrushedMagnetiteOreLv2Recipe()
        {
            this.Init(
                name: "CrushedMagnetiteOre",  //noloc
                displayName: Localizer.DoStr("Crushed Magnetite Lv2"),

                ingredients: new List<IngredientElement>
                {
                new IngredientElement(typeof(MagnetiteOreItem), 20, true),
                },

                items: new List<CraftingElement>
                {
                new CraftingElement<CrushedMagnetiteOreItem>(4),
                new CraftingElement<CrushedBasaltItem>(1),
                }
            );

            // Register our RecipeFamily instance with the crafting system so it can be crafted.
            CraftingComponent.AddTagProduct(typeof(StampMillObject), typeof(CrushedHematiteOreLv2Recipe), this);
        }
    }

    [RequiresSkill(typeof(MiningSkill), 1)]
    public partial class CrushedMagnetiteOreLv3Recipe : Recipe
    {
        public CrushedMagnetiteOreLv3Recipe()
        {
            this.Init(
                name: "CrushedMagnetiteOre",  //noloc
                displayName: Localizer.DoStr("Crushed Magnetite Lv3"),

                ingredients: new List<IngredientElement>
                {
                new IngredientElement(typeof(MagnetiteOreItem), 20, true),
                },

                items: new List<CraftingElement>
                {
                new CraftingElement<CrushedMagnetiteOreItem>(5)
                }
            );

            // Register our RecipeFamily instance with the crafting system so it can be crafted.
            CraftingComponent.AddTagProduct(typeof(JawCrusherObject), typeof(CrushedHematiteOreLv3Recipe), this);
        }
    }

    [Serialized]
    [Solid, Wall, Diggable]
    [RequiresSkill(typeof(MiningSkill), 1)]
    [Tag(BlockTags.Diggable)]
    public partial class CrushedMagnetiteOreBlock :
        Block
        , IRepresentsItem
    {
        public virtual Type RepresentedItemType { get { return typeof(CrushedMagnetiteOreItem); } }
    }

    [Serialized]
    [LocDisplayName("Crushed MagnetiteOre")]
    [LocDescription("MagnetiteOre rocks that have been crushed into a fine gravel.")]
    [MaxStackSize(10)]
    [Weight(26000)]
    [StartsDiscovered]
    [Ecopedia("Blocks", "Processed Rock", createAsSubPage: true)]
    [Tag("Excavatable")]
    [RequiresTool(typeof(ShovelItem))]
    public partial class CrushedMagnetiteOreItem :

    BlockItem<CrushedMagnetiteOreBlock>
    {
        public override LocString DisplayNamePlural { get { return Localizer.DoStr("Crushed MagnetiteOre"); } }

        public override bool CanStickToWalls { get { return false; } }
    }
}