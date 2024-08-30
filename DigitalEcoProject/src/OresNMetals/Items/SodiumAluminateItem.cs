
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

namespace Eco.Mods.TechTree
{
    [RequiresSkill(typeof(MiningSkill), 7)] 
    public partial class SodiumAluminateRecipe : RecipeFamily
    {
        public SodiumAluminateRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                name: "Sodium Aluminate",
                displayName: Localizer.DoStr("Sodium Aluminate"),

                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(CrushedBauxiteOreItem),    2, typeof(MiningSkill)),
                    new IngredientElement(typeof(SodiumHydroxideItem),      2, typeof(MiningSkill)),
                },

                items: new List<CraftingElement>
                {
                    new CraftingElement<SodiumAluminateItem>(1),  
                }
            );
            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 1;
            this.LaborInCalories = CreateLaborInCaloriesValue(100, typeof(MiningSkill)); 
            this.CraftMinutes = CreateCraftTimeValue(2.0f);

            this.ModsPreInitialize();
            this.Initialize(displayText: Localizer.DoStr("Sodium Aluminate"), recipeType: typeof(SodiumAluminateRecipe));
            this.ModsPostInitialize();

            CraftingComponent.AddRecipe(tableType: typeof(ReactionChamberObject), recipe: this);
        }

        partial void ModsPreInitialize();
        partial void ModsPostInitialize();
    }

    [Serialized]
    [LocDisplayName("Sodium Aluminate")]
    [LocDescription("Sodium Aluminate")]
    [Weight(100)]
    [Tag("Chemical")]                                               
    public partial class SodiumAluminateItem : Item
    {
    }
}