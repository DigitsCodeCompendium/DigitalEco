
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Eco.Gameplay.Components;
using Eco.Gameplay.Items;
using Eco.Gameplay.Skills;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;
using Eco.Core.Items;
using Eco.Gameplay.Items.Recipes;
using Eco.Mods.TechTree;

namespace Digits.Geology
{
    [RequiresSkill(typeof(MiningSkill), 7)] 
    public partial class AluminaRecipe : RecipeFamily
    {
        public AluminaRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                name: "Sodium Hydroxide",
                displayName: Localizer.DoStr("Sodium Hydroxide"),

                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(SodiumHydroxideItem), 2, typeof(MiningSkill)),
                    new IngredientElement(typeof(BauxiteConcentrateItem), 2, typeof(MiningSkill)),
                },

                items: new List<CraftingElement>
                {
                    new CraftingElement<AluminaItem>(1),
                }
            );
            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 20;
            this.LaborInCalories = CreateLaborInCaloriesValue(100, typeof(MiningSkill)); 
            this.CraftMinutes = CreateCraftTimeValue(2.0f);

            this.ModsPreInitialize();
            this.Initialize(displayText: Localizer.DoStr("Alumina"), recipeType: typeof(AluminaRecipe));
            this.ModsPostInitialize();

            CraftingComponent.AddRecipe(tableType: typeof(BayerMachineObject), recipe: this);
        }

        partial void ModsPreInitialize();
        partial void ModsPostInitialize();
    }

    [Serialized]
    [LocDisplayName("Alumina")]
    [LocDescription("Alumina")]
    [Weight(100)]
    [Tag("Chemical")]                                                
    public partial class AluminaItem : Item
    {
    }
}