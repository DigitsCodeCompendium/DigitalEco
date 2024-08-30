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
	[RequiresSkill(typeof(SmeltingSkill), 0)]
	public partial class BloomCrackingRecipe : RecipeFamily
	{
		public BloomCrackingRecipe()
		{
			var recipe = new Recipe();
			recipe.Init(
				name: "BloomCracking",
				displayName: Localizer.DoStr("Bloom Cracking"),

				ingredients: new List<IngredientElement>
				{
					new IngredientElement(typeof(IronBloomItem), 1, true),
				},
				items: new List<CraftingElement>
				{
					new CraftingElement<IronBarItem>(6),
					new CraftingElement<FerrousSlagItem>(2),
				});

			this.Recipes = new List<Recipe> { recipe };
			this.ExperienceOnCraft = 5f;
			this.LaborInCalories = CreateLaborInCaloriesValue(200, typeof(SmeltingSkill));
			this.CraftMinutes = CreateCraftTimeValue(beneficiary: typeof(BloomCrackingRecipe), start: 2f, skillType: typeof(SmeltingSkill), typeof(SmeltingFocusedSpeedTalent), typeof(SmeltingParallelSpeedTalent));

			this.ModsPreInitialize();
			this.Initialize(displayText: Localizer.DoStr("Bloom Cracking"), recipeType: typeof(BloomCrackingRecipe));
			this.ModsPostInitialize();

			CraftingComponent.AddRecipe(tableType: typeof(AnvilObject), recipe: this);
		}
		partial void ModsPreInitialize();
		partial void ModsPostInitialize();
	}
}