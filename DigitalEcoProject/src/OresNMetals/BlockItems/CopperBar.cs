using System;
using System.Collections.Generic;
using System.ComponentModel;
using Eco.Gameplay.Components;
using Eco.Gameplay.Items;
using Eco.Gameplay.Objects;
using Eco.Gameplay.Skills;
using Eco.Core.Items;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;
using Eco.Shared.SharedTypes;
using Eco.World.Blocks;
using Eco.World.Water;
using Eco.Gameplay.Items.Recipes;
using Digits.Geology;

namespace Eco.Mods.TechTree
{
    [RequiresSkill(typeof(SmeltingSkill), 1)]
    [Ecopedia("Blocks", "Metals", subPageName: "Copper Bar Item")]
    public partial class CopperBarRecipe : RecipeFamily
    {
        public CopperBarRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                name: "SmeltMalachite",  //noloc
                displayName: Localizer.DoStr("Smelt Malachite"),

                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(CrushedMalachiteOreItem), 5, typeof(SmeltingSkill), typeof(SmeltingLavishResourcesTalent)),
                    new IngredientElement(typeof(CrushedLimestoneItem), 1, typeof(SmeltingSkill), typeof(SmeltingLavishResourcesTalent)),
                },

                items: new List<CraftingElement>
                {
                    new CraftingElement<CopperBarItem>(12),
                    new CraftingElement<CupricSlagItem>(typeof(SmeltingSkill), 8, typeof(SmeltingLavishResourcesTalent)),
                    new CraftingElement<SlagItem>(typeof(SmeltingSkill), 4, typeof(SmeltingLavishResourcesTalent)),
                });
            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 2; // Defines how much experience is gained when crafted.
            
            // Defines the amount of labor required and the required skill to add labor
            this.LaborInCalories = CreateLaborInCaloriesValue(60, typeof(SmeltingSkill));

            // Defines our crafting time for the recipe
            this.CraftMinutes = CreateCraftTimeValue(beneficiary: typeof(CopperBarRecipe), start: 0.6f, skillType: typeof(SmeltingSkill), typeof(SmeltingFocusedSpeedTalent), typeof(SmeltingParallelSpeedTalent));

            // Perform pre/post initialization for user mods and initialize our recipe instance with the display name "Copper Bar"
            this.ModsPreInitialize();
            this.Initialize(displayText: Localizer.DoStr("Smelt Malachite"), recipeType: typeof(CopperBarRecipe));
            this.ModsPostInitialize();

            // Register our RecipeFamily instance with the crafting system so it can be crafted.
            CraftingComponent.AddRecipe(tableType: typeof(BloomeryObject), recipe: this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    [RequiresSkill(typeof(SmeltingSkill), 1)]
    public partial class SmeltCopperRecipe : RecipeFamily
    {
        public SmeltCopperRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                name: "SmeltCopperConcentrate",  //noloc
                displayName: Localizer.DoStr("Smelt Copper Concentrate"),

                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(CopperConcentrateItem), 2, typeof(SmeltingSkill), typeof(SmeltingLavishResourcesTalent)),
                },

                items: new List<CraftingElement>
                {
                    new CraftingElement<CopperBarItem>(4),
                    new CraftingElement<CupricSlagItem>(typeof(SmeltingSkill), 2, typeof(SmeltingLavishResourcesTalent)),
                    new CraftingElement<SulphuricSlagItem>(typeof(SmeltingSkill), 2, typeof(SmeltingLavishResourcesTalent)),
                });
            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 2; // Defines how much experience is gained when crafted.

            // Defines the amount of labor required and the required skill to add labor
            this.LaborInCalories = CreateLaborInCaloriesValue(60, typeof(SmeltingSkill));

            // Defines our crafting time for the recipe
            this.CraftMinutes = CreateCraftTimeValue(beneficiary: typeof(SmeltCopperRecipe), start: 6, skillType: typeof(SmeltingSkill), typeof(SmeltingFocusedSpeedTalent), typeof(SmeltingParallelSpeedTalent));

            // Perform pre/post initialization for user mods and initialize our recipe instance with the display name "Smelt Copper"
            this.ModsPreInitialize();
            this.Initialize(displayText: Localizer.DoStr("Smelt Copper Concentrate"), recipeType: typeof(SmeltCopperRecipe));
            this.ModsPostInitialize();

            // Register our RecipeFamily instance with the crafting system so it can be crafted.
            CraftingComponent.AddRecipe(tableType: typeof(BlastFurnaceObject), recipe: this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    [RequiresSkill(typeof(SmeltingSkill), 1)]
    public partial class SmeltImpureCopperRecipe : RecipeFamily
    {
        public SmeltImpureCopperRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                name: "SmeltImpureCopper",  //noloc
                displayName: Localizer.DoStr("Smelt Impure Copper"),

                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(ImpureCopperItem), 3, typeof(SmeltingSkill), typeof(SmeltingLavishResourcesTalent)),
                },

                items: new List<CraftingElement>
                {
                    new CraftingElement<CopperBarItem>(16),
                    new CraftingElement<SlagItem>(typeof(SmeltingSkill), 4, typeof(SmeltingLavishResourcesTalent)),
                });
            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 2; // Defines how much experience is gained when crafted.

            // Defines the amount of labor required and the required skill to add labor
            this.LaborInCalories = CreateLaborInCaloriesValue(60, typeof(SmeltingSkill));

            // Defines our crafting time for the recipe
            this.CraftMinutes = CreateCraftTimeValue(beneficiary: typeof(SmeltImpureCopperRecipe), start: 6, skillType: typeof(SmeltingSkill), typeof(SmeltingFocusedSpeedTalent), typeof(SmeltingParallelSpeedTalent));

            // Perform pre/post initialization for user mods and initialize our recipe instance with the display name "Smelt Copper"
            this.ModsPreInitialize();
            this.Initialize(displayText: Localizer.DoStr("Smelt Impure Copper"), recipeType: typeof(SmeltImpureCopperRecipe));
            this.ModsPostInitialize();

            // Register our RecipeFamily instance with the crafting system so it can be crafted.
            CraftingComponent.AddRecipe(tableType: typeof(BlastFurnaceObject), recipe: this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    public partial class SmeltPureCopperRecipe : RecipeFamily
    {
        public SmeltPureCopperRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                name: "SmeltPureCopper",  //noloc
                displayName: Localizer.DoStr("Smelt Pure Copper"),

                // Defines the ingredients needed to craft this recipe. An ingredient items takes the following inputs
                // type of the item, the amount of the item, the skill required, and the talent used.
                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(PureCopperItem), 1, typeof(SmeltingSkill), typeof(SmeltingLavishResourcesTalent)),
                },

                // Define our recipe output items.
                // For every output item there needs to be one CraftingElement entry with the type of the final item and the amount
                // to create.
                items: new List<CraftingElement>
                {
                    new CraftingElement<CopperBarItem>(8),
                });
            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 2; // Defines how much experience is gained when crafted.

            // Defines the amount of labor required and the required skill to add labor
            this.LaborInCalories = CreateLaborInCaloriesValue(60, typeof(SmeltingSkill));

            // Defines our crafting time for the recipe
            this.CraftMinutes = CreateCraftTimeValue(beneficiary: typeof(SmeltImpureCopperRecipe), start: 6, skillType: typeof(SmeltingSkill), typeof(SmeltingFocusedSpeedTalent), typeof(SmeltingParallelSpeedTalent));

            // Perform pre/post initialization for user mods and initialize our recipe instance with the display name "Smelt Copper"
            this.ModsPreInitialize();
            this.Initialize(displayText: Localizer.DoStr("Smelt Pure Copper"), recipeType: typeof(SmeltPureCopperRecipe));
            this.ModsPostInitialize();

            // Register our RecipeFamily instance with the crafting system so it can be crafted.
            CraftingComponent.AddRecipe(tableType: typeof(BlastFurnaceObject), recipe: this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    [Serialized]
    [Solid, Wall, Constructed]
    [RequiresSkill(typeof(SmeltingSkill), 1)]
        public partial class CopperBarBlock :
        Block
        , IRepresentsItem
    {
        public virtual Type RepresentedItemType { get { return typeof(CopperBarItem); } }
    }

    [Serialized]
    [LocDisplayName("Copper Bar")]
    [LocDescription("Refined bar of copper.")]
    [MaxStackSize(20)]
    [Weight(18000)]
    [Ecopedia("Blocks", "Metals", createAsSubPage: true)]
    [Currency][Tag("Currency")]
    [Tag("Metal")]
    public partial class CopperBarItem :
 
    BlockItem<CopperBarBlock>
    {

        public override bool CanStickToWalls { get { return false; } }

        private static Type[] blockTypes = new Type[] {
            typeof(CopperBarStacked1Block),
            typeof(CopperBarStacked2Block),
            typeof(CopperBarStacked3Block),
            typeof(CopperBarStacked4Block)
        };
        
        public override Type[] BlockTypes { get { return blockTypes; } }
    }

    [Tag("Metal")]
    [Tag(BlockTags.PartialStack)]
    [Serialized, Solid] public class CopperBarStacked1Block : PickupableBlock, IWaterLoggedBlock { }
    [Tag("Metal")]
    [Tag(BlockTags.PartialStack)]
    [Serialized, Solid] public class CopperBarStacked2Block : PickupableBlock, IWaterLoggedBlock { }
    [Tag("Metal")]
    [Tag(BlockTags.PartialStack)]
    [Serialized, Solid] public class CopperBarStacked3Block : PickupableBlock, IWaterLoggedBlock { }
    [Tag("Metal")]
    [Tag(BlockTags.FullStack)]
    [Serialized, Solid,Wall] public class CopperBarStacked4Block : PickupableBlock, IWaterLoggedBlock { } //Only a wall if it's all 4 CopperBar
}
