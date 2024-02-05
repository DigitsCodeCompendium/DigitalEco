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
    [RequiresSkill(typeof(MiningSkill), 7)]
    public partial class PureCopperRecipe : RecipeFamily
    {
        public PureCopperRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                name: "PureCopper",
                displayName: Localizer.DoStr("Purify Copper"),

                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(ImpureCopperItem), 4, typeof(MiningSkill)),
                    new IngredientElement(typeof(SulphuricAcidItem), 1, typeof(MiningSkill)),
                },

                items: new List<CraftingElement>
                {
                    new CraftingElement<PureCopperItem>(4),
                    new CraftingElement<GoldConcentrateItem>(1),
                }
            );
            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 20;
            this.LaborInCalories = CreateLaborInCaloriesValue(100, typeof(MiningSkill));
            this.CraftMinutes = CreateCraftTimeValue(2.0f);

            this.ModsPreInitialize();
            this.Initialize(displayText: Localizer.DoStr("Purify Copper"), recipeType: typeof(PureCopperRecipe));
            this.ModsPostInitialize();

            CraftingComponent.AddRecipe(tableType: typeof(ElectrolyserObject), recipe: this);
        }

        partial void ModsPreInitialize();
        partial void ModsPostInitialize();
    }

    [Serialized]
    [LocDisplayName("Pure Copper")]
    [LocDescription("Pure Copper")]
    [Weight(100)]
    public partial class PureCopperItem : Item
    {
    }
}
