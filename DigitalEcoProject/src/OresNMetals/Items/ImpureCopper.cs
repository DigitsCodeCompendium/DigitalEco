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
    [RequiresSkill(typeof(SmeltingSkill), 7)]
    public partial class ImpureCopperRecipe : RecipeFamily
    {
        public ImpureCopperRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                name: "ImpureCopper",
                displayName: Localizer.DoStr("Impure Copper"),

                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(CopperConcentrateItem), 2, typeof(SmeltingSkill), typeof(SmeltingLavishResourcesTalent)),
                    new IngredientElement(typeof(SandItem), 2, typeof(SmeltingSkill), typeof(SmeltingLavishResourcesTalent)),
                },

                items: new List<CraftingElement>
                {
                    new CraftingElement<ImpureCopperItem>(1),
                    new CraftingElement<CupricSlagItem>(typeof(SmeltingSkill), 1, typeof(SmeltingLavishResourcesTalent)),
                    new CraftingElement<SulphuricSlagItem>(typeof(SmeltingSkill), 3, typeof(SmeltingLavishResourcesTalent)),
                }
            );
            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 2;
            this.LaborInCalories = CreateLaborInCaloriesValue(100, typeof(SmeltingSkill));
            this.CraftMinutes = CreateCraftTimeValue(beneficiary: typeof(ImpureCopperRecipe), start: 0.6f, skillType: typeof(SmeltingSkill), typeof(SmeltingFocusedSpeedTalent), typeof(SmeltingParallelSpeedTalent));

            this.ModsPreInitialize();
            this.Initialize(displayText: Localizer.DoStr("Impure Copper"), recipeType: typeof(ImpureCopperRecipe));
            this.ModsPostInitialize();

            CraftingComponent.AddRecipe(tableType: typeof(BlastFurnaceObject), recipe: this);
        }

        partial void ModsPreInitialize();
        partial void ModsPostInitialize();
    }

    [Serialized]
    [LocDisplayName("Impure Copper")]
    [LocDescription("Impure Copper")]
    [Weight(100)]
    public partial class ImpureCopperItem : Item
    {
    }
}
