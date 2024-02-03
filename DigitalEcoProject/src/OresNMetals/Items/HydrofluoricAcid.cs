
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
    public partial class HydrofluoricAcidRecipe : RecipeFamily
    {
        public HydrofluoricAcidRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                name: "Hydrofluoric Acid",
                displayName: Localizer.DoStr("Hydrofluoric Acid"),

                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(CrushedFluoriteOreItem), 2, typeof(MiningSkill)),
                    new IngredientElement(typeof(SulphuricAcidItem), 2, typeof(MiningSkill)),
                },

                items: new List<CraftingElement>
                {
                    new CraftingElement<HydrofluoricAcidItem>(1),
                    //new CraftingElement<GypsumItem>(1),
                }
            );
            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 20;
            this.LaborInCalories = CreateLaborInCaloriesValue(100, typeof(MiningSkill)); 
            this.CraftMinutes = CreateCraftTimeValue(2.0f);

            this.ModsPreInitialize();
            this.Initialize(displayText: Localizer.DoStr("Hydrofluoric Acid"), recipeType: typeof(HydrofluoricAcidRecipe));
            this.ModsPostInitialize();

            CraftingComponent.AddRecipe(tableType: typeof(ReactionChamberObject), recipe: this);
        }

        partial void ModsPreInitialize();
        partial void ModsPostInitialize();
    }

    [Serialized]
    [LocDisplayName("Hydrofluoric Acid")]
    [LocDescription("Hydrofluoric Acid")]
    [Weight(100)]
    [Tag("Chemical")]                                               
    public partial class HydrofluoricAcidItem : Item
    {
    }
}