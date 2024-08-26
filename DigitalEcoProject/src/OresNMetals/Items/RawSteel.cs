using Eco.Gameplay.Components;
using Eco.Gameplay.Items.Recipes;
using Eco.Gameplay.Items;
using Eco.Gameplay.Skills;
using Eco.Mods.TechTree;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digits.Geology
{
    [RequiresSkill(typeof(AdvancedSmeltingSkill), 7)]
    public partial class RawSteelRecipe : RecipeFamily
    {
        public RawSteelRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                name: "RawSteel",
                displayName: Localizer.DoStr("Raw Steel"),

                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(PigIronBarItem), 1),
                    new IngredientElement(typeof(QuicklimeItem), 1, typeof(AdvancedSmeltingSkill)),
                },

                items: new List<CraftingElement>
                {
                    new CraftingElement<RawSteelItem>(1),
                    new CraftingElement<FerrousSlagItem>(typeof(AdvancedSmeltingSkill), 1),
                }
            );

            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 20;
            this.LaborInCalories = CreateLaborInCaloriesValue(100, typeof(AdvancedSmeltingSkill));
            this.CraftMinutes = CreateCraftTimeValue(2.0f);

            this.ModsPreInitialize();
            this.Initialize(displayText: Localizer.DoStr("Raw Steel"), recipeType: typeof(RawSteelRecipe));
            this.ModsPostInitialize();

            CraftingComponent.AddRecipe(tableType: typeof(BlastFurnaceObject), recipe: this);
        }

        partial void ModsPreInitialize();
        partial void ModsPostInitialize();
    }

    [Serialized]
    [LocDisplayName("Raw Steel")]
    [LocDescription("Raw Steel that needs to be shaped into bars")]
    [MaxStackSize(20)]
    [Weight(40000)]
    public partial class RawSteelItem : Item
    {
    }
}
