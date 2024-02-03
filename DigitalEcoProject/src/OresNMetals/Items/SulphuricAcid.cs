
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
    public partial class SulphuricAcidRecipe : RecipeFamily
    {
        public SulphuricAcidRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                name: "Sulphuric Acid",
                displayName: Localizer.DoStr("Sulphuric Acid"),

                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(CrushedSulphuricSlagItem), 2, typeof(MiningSkill)),
                },

                items: new List<CraftingElement>
                {
                    new CraftingElement<SulphuricAcidItem>(1),
                    new CraftingElement<WetTailingsItem>(1),
                }
            );
            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 20;
            this.LaborInCalories = CreateLaborInCaloriesValue(100, typeof(MiningSkill)); 
            this.CraftMinutes = CreateCraftTimeValue(2.0f);

            this.ModsPreInitialize();
            this.Initialize(displayText: Localizer.DoStr("Sulphuric Acid"), recipeType: typeof(SulphuricAcidRecipe));
            this.ModsPostInitialize();

            CraftingComponent.AddRecipe(tableType: typeof(ReactionChamberObject), recipe: this);
        }

        partial void ModsPreInitialize();
        partial void ModsPostInitialize();
    }

    [Serialized]
    [LocDisplayName("Sulphuric Acid")]
    [LocDescription("Sulphuric Acid")]
    [Weight(100)]
    [Tag("Chemical")]                                               
    public partial class SulphuricAcidItem : Item
    {
    }
}