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
    [Ecopedia("Blocks", "Metals", subPageName: "Iron Bar Item")]
    public partial class IronBarRecipe : RecipeFamily
    {
        public IronBarRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                name: "CrackIronBloom",  //noloc
                displayName: Localizer.DoStr("Crack Iron Bloom"),

                // Defines the ingredients needed to craft this recipe. An ingredient items takes the following inputs
                // type of the item, the amount of the item, the skill required, and the talent used.
                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(IronBloomItem), 1, true),
                    new IngredientElement(typeof(CrushedLimestoneItem), 1, typeof(SmeltingSkill)),
                },

                // Define our recipe output items.
                // For every output item there needs to be one CraftingElement entry with the type of the final item and the amount
                // to create.
                items: new List<CraftingElement>
                {
                    new CraftingElement<IronBarItem>(6),
                    new CraftingElement<FerrousSlagItem>(2),
                });
            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 2; // Defines how much experience is gained when crafted.
            
            // Defines the amount of labor required and the required skill to add labor
            this.LaborInCalories = CreateLaborInCaloriesValue(60, typeof(SmeltingSkill));

            // Defines our crafting time for the recipe
            this.CraftMinutes = CreateCraftTimeValue(beneficiary: typeof(IronBarRecipe), start: 0.6f, skillType: typeof(SmeltingSkill), typeof(SmeltingFocusedSpeedTalent), typeof(SmeltingParallelSpeedTalent));

            // Perform pre/post initialization for user mods and initialize our recipe instance with the display name "Iron Bar"
            this.ModsPreInitialize();
            this.Initialize(displayText: Localizer.DoStr("Crack Iron Bloom"), recipeType: typeof(IronBarRecipe));
            this.ModsPostInitialize();

            // Register our RecipeFamily instance with the crafting system so it can be crafted.
            CraftingComponent.AddRecipe(tableType: typeof(AnvilObject), recipe: this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    [RequiresSkill(typeof(SmeltingSkill), 1)]
    public partial class WorkPigIronRecipe : RecipeFamily
    {
        public WorkPigIronRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                name: "WorkPigIron",  //noloc
                displayName: Localizer.DoStr("Work Pigiron"),

                // Defines the ingredients needed to craft this recipe. An ingredient items takes the following inputs
                // type of the item, the amount of the item, the skill required, and the talent used.
                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(PigIronBarItem), 8, true),
                    new IngredientElement(typeof(QuicklimeItem), 1, typeof(SmeltingSkill), typeof(SmeltingLavishResourcesTalent)),
                },

                // Define our recipe output items.
                // For every output item there needs to be one CraftingElement entry with the type of the final item and the amount
                // to create.
                items: new List<CraftingElement>
                {
                    new CraftingElement<IronBarItem>(8),
                    new CraftingElement<FerrousSlagItem>(typeof(SmeltingSkill), 1, typeof(SmeltingLavishResourcesTalent)),
                });
            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 2; // Defines how much experience is gained when crafted.

            // Defines the amount of labor required and the required skill to add labor
            this.LaborInCalories = CreateLaborInCaloriesValue(60, typeof(SmeltingSkill));

            // Defines our crafting time for the recipe
            this.CraftMinutes = CreateCraftTimeValue(beneficiary: typeof(WorkPigIronRecipe), start: 5, skillType: typeof(SmeltingSkill), typeof(SmeltingFocusedSpeedTalent), typeof(SmeltingParallelSpeedTalent));

            // Perform pre/post initialization for user mods and initialize our recipe instance with the display name "Smelt Iron"
            this.ModsPreInitialize();
            this.Initialize(displayText: Localizer.DoStr("Work Pigiron"), recipeType: typeof(WorkPigIronRecipe));
            this.ModsPostInitialize();

            // Register our RecipeFamily instance with the crafting system so it can be crafted.
            CraftingComponent.AddRecipe(tableType: typeof(AnvilObject), recipe: this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    [Serialized]
    [Solid, Wall, Constructed]
    [RequiresSkill(typeof(SmeltingSkill), 1)]
        public partial class IronBarBlock :
        Block
        , IRepresentsItem
    {
        public virtual Type RepresentedItemType { get { return typeof(IronBarItem); } }
    }

    [Serialized]
    [LocDisplayName("Iron Bar")]
    [LocDescription("Refined bar of iron.")]
    [MaxStackSize(20)]
    [Weight(15000)]
    [Ecopedia("Blocks", "Metals", createAsSubPage: true)]
    [Currency][Tag("Currency")]
    [Tag("Metal")]
    public partial class IronBarItem :
 
    BlockItem<IronBarBlock>
    {

        public override bool CanStickToWalls { get { return false; } }

        private static Type[] blockTypes = new Type[] {
            typeof(IronBarStacked1Block),
            typeof(IronBarStacked2Block),
            typeof(IronBarStacked3Block),
            typeof(IronBarStacked4Block)
        };
        
        public override Type[] BlockTypes { get { return blockTypes; } }
    }

    [Tag("Metal")]
    [Tag(BlockTags.PartialStack)]
    [Serialized, Solid] public class IronBarStacked1Block : PickupableBlock, IWaterLoggedBlock { }
    [Tag("Metal")]
    [Tag(BlockTags.PartialStack)]
    [Serialized, Solid] public class IronBarStacked2Block : PickupableBlock, IWaterLoggedBlock { }
    [Tag("Metal")]
    [Tag(BlockTags.PartialStack)]
    [Serialized, Solid] public class IronBarStacked3Block : PickupableBlock, IWaterLoggedBlock { }
    [Tag("Metal")]
    [Tag(BlockTags.FullStack)]
    [Serialized, Solid,Wall] public class IronBarStacked4Block : PickupableBlock, IWaterLoggedBlock { } //Only a wall if it's all 4 IronBar
}
