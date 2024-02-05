
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Eco.Gameplay.Components;
using Eco.Gameplay.Items;
using Eco.Gameplay.Skills;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;
using Eco.Gameplay.Items.Recipes;
using Eco.Mods.TechTree;

namespace Digits.Geology
{
    [RequiresSkill(typeof(MiningSkill), 7)] 
    public partial class IronBloomRecipe : RecipeFamily
    {
        public IronBloomRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                name: "IronBloom",  //noloc
                displayName: Localizer.DoStr("Iron Bloom"),

                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(IronConcentrateItem), 2, typeof(SmeltingSkill), typeof(SmeltingLavishResourcesTalent)),
                },

                items: new List<CraftingElement>
                {
                    new CraftingElement<IronBloomItem>(1),
                }
            );

            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 20;
            this.LaborInCalories = CreateLaborInCaloriesValue(100, typeof(MiningSkill)); 
            this.CraftMinutes = CreateCraftTimeValue(2.0f);

            this.ModsPreInitialize();
            this.Initialize(displayText: Localizer.DoStr("Iron Bloom"), recipeType: typeof(IronBloomRecipe));
            this.ModsPostInitialize();

            CraftingComponent.AddRecipe(tableType: typeof(BloomeryObject), recipe: this);
        }

        partial void ModsPreInitialize();
        partial void ModsPostInitialize();
    }

    [Serialized]
    [LocDisplayName("Iron Bloom")]
    [LocDescription("Iron Bloom")]
    [Weight(60000)]
    [MaxStackSize(10)]
    public partial class IronBloomItem : Item
    {
    }
}