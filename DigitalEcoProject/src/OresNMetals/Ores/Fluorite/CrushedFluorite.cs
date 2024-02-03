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
    [Ecopedia("Blocks", "Processed Rock", subPageName: "Crushed Fluorite Item")]
    public partial class CrushedFluoriteOreRecipe : Recipe
    {
        public CrushedFluoriteOreRecipe()
        {
            this.Init(
                name: "CrushedFluoriteOre",  //noloc
                displayName: Localizer.DoStr("Crushed Fluorite"),

                ingredients: new List<IngredientElement>
                {
                new IngredientElement(typeof(FluoriteOreItem), 12, true),
                },

                items: new List<CraftingElement>
                {
                new CraftingElement<CrushedFluoriteOreItem>(2),
                new CraftingElement<CrushedGraniteItem>(1),
                }
            );

            // Register our RecipeFamily instance with the crafting system so it can be crafted.
            CraftingComponent.AddTagProduct(typeof(ArrastraObject), typeof(CrushedHematiteOreRecipe), this);
        }
    }

    [RequiresSkill(typeof(MiningSkill), 1)]
    public partial class CrushedFluoriteOreLv2Recipe : Recipe
    {
        public CrushedFluoriteOreLv2Recipe()
        {
            this.Init(
                name: "CrushedFluoriteOreLv2",  //noloc
                displayName: Localizer.DoStr("Crushed Fluorite Lv2"),

                ingredients: new List<IngredientElement>
                {
                new IngredientElement(typeof(FluoriteOreItem), 20, true),
                },

                items: new List<CraftingElement>
                {
                new CraftingElement<CrushedFluoriteOreItem>(4),
                new CraftingElement<CrushedGraniteItem>(1),
                }
            );

            // Register our RecipeFamily instance with the crafting system so it can be crafted.
            CraftingComponent.AddTagProduct(typeof(StampMillObject), typeof(CrushedHematiteOreLv2Recipe), this);
        }
    }

    [RequiresSkill(typeof(MiningSkill), 1)]
    public partial class CrushedFluoriteOreLv3Recipe : Recipe
    {
        public CrushedFluoriteOreLv3Recipe()
        {
            this.Init(
                name: "CrushedFluoriteOreLv3",  //noloc
                displayName: Localizer.DoStr("Crushed Fluorite Lv3"),

                ingredients: new List<IngredientElement>
                {
                new IngredientElement(typeof(FluoriteOreItem), 20, true),
                },

                items: new List<CraftingElement>
                {
                new CraftingElement<CrushedFluoriteOreItem>(5)
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
    public partial class CrushedFluoriteOreBlock :
        Block
        , IRepresentsItem
    {
        public virtual Type RepresentedItemType { get { return typeof(CrushedFluoriteOreItem); } }
    }

    [Serialized]
    [LocDisplayName("Crushed Fluorite")]
    [LocDescription("Fluorite rocks that have been crushed into a fine gravel.")]
    [MaxStackSize(10)]
    [Weight(26000)]
    [StartsDiscovered]
    [Ecopedia("Blocks", "Processed Rock", createAsSubPage: true)]
    [Tag("Excavatable")]
    [RequiresTool(typeof(ShovelItem))]
    public partial class CrushedFluoriteOreItem :

    BlockItem<CrushedFluoriteOreBlock>
    {
        public override LocString DisplayNamePlural { get { return Localizer.DoStr("Crushed Fluorite"); } }

        public override bool CanStickToWalls { get { return false; } }
    }
}