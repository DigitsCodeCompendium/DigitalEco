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

namespace Eco.Mods.TechTree
{
    [RequiresSkill(typeof(SmeltingSkill), 1)]
    [Ecopedia("Blocks", "Metals", subPageName: "PigIron Bar Item")]
    public partial class PigIronBarRecipe : RecipeFamily
    {
        public PigIronBarRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                name: "PigIronBar",  //noloc
                displayName: Localizer.DoStr("PigIron Bar"),

                // Defines the ingredients needed to craft this recipe. An ingredient items takes the following inputs
                // type of the item, the amount of the item, the skill required, and the talent used.
                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(IronConcentrateItem), 1, typeof(SmeltingSkill), typeof(SmeltingLavishResourcesTalent)),
                    new IngredientElement(typeof(QuicklimeItem), 1, typeof(SmeltingSkill), typeof(SmeltingLavishResourcesTalent)),
                },

                // Define our recipe output items.
                // For every output item there needs to be one CraftingElement entry with the type of the final item and the amount
                // to create.
                items: new List<CraftingElement>
                {
                    new CraftingElement<PigIronBarItem>(4),
                    new CraftingElement<FerrousSlagItem>(typeof(SmeltingSkill), 1, typeof(SmeltingLavishResourcesTalent)),
                });
            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 2; // Defines how much experience is gained when crafted.
            
            // Defines the amount of labor required and the required skill to add labor
            this.LaborInCalories = CreateLaborInCaloriesValue(60, typeof(SmeltingSkill));

            // Defines our crafting time for the recipe
            this.CraftMinutes = CreateCraftTimeValue(beneficiary: typeof(PigIronBarRecipe), start: 0.6f, skillType: typeof(SmeltingSkill), typeof(SmeltingFocusedSpeedTalent), typeof(SmeltingParallelSpeedTalent));

            // Perform pre/post initialization for user mods and initialize our recipe instance with the display name "PigIron Bar"
            this.ModsPreInitialize();
            this.Initialize(displayText: Localizer.DoStr("PigIron Bar"), recipeType: typeof(PigIronBarRecipe));
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
    [LocDisplayName("PigIron Bar")]
    [LocDescription("Bar of PigIron. It can be further proccesed into steel in a blast furnace or regular iron through work on an anvil.")]
    [MaxStackSize(20)]
    [Weight(15000)]
    [Ecopedia("Blocks", "Metals", createAsSubPage: true)]
    [Tag("Metal")]
    public partial class PigIronBarItem :Item { }
}
