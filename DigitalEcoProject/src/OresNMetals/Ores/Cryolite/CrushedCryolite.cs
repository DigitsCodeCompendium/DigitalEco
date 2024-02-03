using System;
using System.Collections.Generic;
using System.ComponentModel;
using Eco.Gameplay.Components;
using Eco.Gameplay.Items;
using Eco.Gameplay.Skills;
using Eco.Core.Items;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;
using Eco.Shared.SharedTypes;
using Eco.World.Blocks;
using Eco.Gameplay.Items.Recipes;
using Digits.Geology;

namespace Eco.Mods.TechTree
{
    [RequiresSkill(typeof(MiningSkill), 1)]
    [Ecopedia("Blocks", "Processed Rock", subPageName: "Crushed Cryolite Item")]
    public partial class CrushedCryoliteOreRecipe : Recipe
    {
        public CrushedCryoliteOreRecipe()
        {
            this.Init(
                name: "CrushedCryoliteOre",  //noloc
                displayName: Localizer.DoStr("Crushed Cryolite"),

                ingredients: new List<IngredientElement>
                {
                new IngredientElement(typeof(CryoliteOreItem), 12, true),
                },

                items: new List<CraftingElement>
                {
                new CraftingElement<CrushedCryoliteOreItem>(2),
                new CraftingElement<CrushedMixedRockItem>(1),
                }
            );

            // Register our RecipeFamily instance with the crafting system so it can be crafted.
            CraftingComponent.AddTagProduct(typeof(ArrastraObject), typeof(CrushedHematiteOreRecipe), this);
        }
    }

    [RequiresSkill(typeof(MiningSkill), 1)]
    public partial class CrushedCryoliteOreLv2Recipe : Recipe
    {
        public CrushedCryoliteOreLv2Recipe()
        {
            this.Init(
                name: "CrushedCryoliteOreLv2",  //noloc
                displayName: Localizer.DoStr("Crushed Cryolite Lv2"),

                ingredients: new List<IngredientElement>
                {
                new IngredientElement(typeof(CryoliteOreItem), 20, true),
                },

                items: new List<CraftingElement>
                {
                new CraftingElement<CrushedCryoliteOreItem>(4),
                new CraftingElement<CrushedMixedRockItem>(1),
                }
            );

            // Register our RecipeFamily instance with the crafting system so it can be crafted.
            CraftingComponent.AddTagProduct(typeof(StampMillObject), typeof(CrushedHematiteOreLv2Recipe), this);
        }
    }

    [RequiresSkill(typeof(MiningSkill), 1)]
    public partial class CrushedCryoliteOreLv3Recipe : Recipe
    {
        public CrushedCryoliteOreLv3Recipe()
        {
            this.Init(
                name: "CrushedCryoliteOreLv3",  //noloc
                displayName: Localizer.DoStr("Crushed Cryolite Lv3"),

                ingredients: new List<IngredientElement>
                {
                new IngredientElement(typeof(CryoliteOreItem), 20, true),
                },

                items: new List<CraftingElement>
                {
                new CraftingElement<CrushedCryoliteOreItem>(5)
                }
            );

            // Register our RecipeFamily instance with the crafting system so it can be crafted.
            CraftingComponent.AddTagProduct(typeof(JawCrusherObject), typeof(CrushedHematiteOreLv3Recipe), this);
        }
    }

    public partial class SyntheticCryoliteOreRecipe : RecipeFamily
    {
        public SyntheticCryoliteOreRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                name: "SyntheticCryolite",  //noloc
                displayName: Localizer.DoStr("Synthetic Cryolite"),

                // Defines the ingredients needed to craft this recipe. An ingredient items takes the following inputs
                // type of the item, the amount of the item, the skill required, and the talent used.
                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(SodiumAluminateItem), 12, true),
                    new IngredientElement(typeof(HydrofluoricAcidItem), 12, true),
                },

                // Define our recipe output items.
                // For every output item there needs to be one CraftingElement entry with the type of the final item and the amount
                // to create.
                items: new List<CraftingElement>
                {
                    new CraftingElement<CryoliteOreItem>(3)
                });
            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 0.5f; // Defines how much experience is gained when crafted.

            // Defines the amount of labor required and the required skill to add labor
            this.LaborInCalories = CreateLaborInCaloriesValue(70, typeof(MiningSkill));

            // Defines our crafting time for the recipe
            this.CraftMinutes = CreateCraftTimeValue(beneficiary: typeof(SyntheticCryoliteOreRecipe), start: 2, skillType: typeof(MiningSkill));

            // Perform pre/post initialization for user mods and initialize our recipe instance with the display name "Crushed CryoliteOre"
            this.ModsPreInitialize();
            this.Initialize(displayText: Localizer.DoStr("Synthetic Cryolite"), recipeType: typeof(SyntheticCryoliteOreRecipe));
            this.ModsPostInitialize();

            // Register our RecipeFamily instance with the crafting system so it can be crafted.
            CraftingComponent.AddRecipe(tableType: typeof(ReactionChamberObject), recipe: this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    [Serialized]
    [Solid, Wall, Diggable]
    [RequiresSkill(typeof(MiningSkill), 1)]
    [Tag(BlockTags.Diggable)]
    public partial class CrushedCryoliteOreBlock :
        Block
        , IRepresentsItem
    {
        public virtual Type RepresentedItemType { get { return typeof(CrushedCryoliteOreItem); } }
    }

    [Serialized]
    [LocDisplayName("Crushed Cryolite")]
    [LocDescription("Cryolite rocks that have been crushed into a fine gravel.")]
    [MaxStackSize(10)]
    [Weight(26000)]
    [StartsDiscovered]
    [Ecopedia("Blocks", "Processed Rock", createAsSubPage: true)]
    [Tag("Excavatable")]
    [RequiresTool(typeof(ShovelItem))]
    public partial class CrushedCryoliteOreItem :

    BlockItem<CrushedCryoliteOreBlock>
    {
        public override LocString DisplayNamePlural { get { return Localizer.DoStr("Crushed Cryolite"); } }

        public override bool CanStickToWalls { get { return false; } }
    }
}