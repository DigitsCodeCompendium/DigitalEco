using System;
using System.Collections.Generic;
using System.ComponentModel;
using Eco.Mods.TechTree;
using Eco.Gameplay.Blocks;
using Eco.Gameplay.Components;
using Eco.Gameplay.DynamicValues;
using Eco.Gameplay.Items;
using Eco.Gameplay.Objects;
using Eco.Gameplay.Players;
using Eco.Gameplay.Skills;
using Eco.Gameplay.Settlements;
using Eco.Gameplay.Systems;
using Eco.Gameplay.Systems.TextLinks;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;
using Eco.Shared.Utils;
using Eco.Core.Items;
using Eco.World;
using Eco.World.Blocks;
using Eco.Gameplay.Pipes;
using Eco.Core.Controller;
using Eco.Gameplay.Items.Recipes;

namespace Eco.Mods.TechTree
{
	[RequiresSkill(typeof(AdvancedSmeltingSkill), 0)]
	public partial class WorkSteelRecipe : RecipeFamily
	{
		public WorkSteelRecipe()
		{
			var recipe = new Recipe();
			recipe.Init(
				name: "WorkSteel",
				displayName: Localizer.DoStr("Work Steel"),

				ingredients: new List<IngredientElement>
				{
					new IngredientElement(typeof(RawSteelItem), 3, typeof(AdvancedSmeltingSkill), typeof(AdvancedSmeltingLavishResourcesTalent)),
				},
				items: new List<CraftingElement>
				{
					new CraftingElement<SteelBarItem>(2),
				});

			this.Recipes = new List<Recipe> { recipe };
			this.ExperienceOnCraft = 2f;
			this.LaborInCalories = CreateLaborInCaloriesValue(50, typeof(AdvancedSmeltingSkill));
			this.CraftMinutes = CreateCraftTimeValue(beneficiary: typeof(WorkSteelRecipe), start: 2f, skillType: typeof(AdvancedSmeltingSkill), typeof(AdvancedSmeltingFocusedSpeedTalent), typeof(AdvancedSmeltingParallelSpeedTalent));

			this.ModsPreInitialize();
			this.Initialize(displayText: Localizer.DoStr("Work Steel"), recipeType: typeof(WorkSteelRecipe));
			this.ModsPostInitialize();

			CraftingComponent.AddRecipe(tableType: typeof(AnvilObject), recipe: this);
		}
		partial void ModsPreInitialize();
		partial void ModsPostInitialize();
	}
}