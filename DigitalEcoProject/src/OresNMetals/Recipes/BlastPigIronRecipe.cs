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
	public partial class BlastPigIronRecipe : RecipeFamily
	{
		public BlastPigIronRecipe()
		{
			var recipe = new Recipe();
			recipe.Init(
				name: "BlastPigIron",
				displayName: Localizer.DoStr("Blast Pig Iron"),

				ingredients: new List<IngredientElement>
				{
					new IngredientElement(typeof(QuicklimeItem), 1, typeof(SmeltingSkill), typeof(SmeltingLavishResourcesTalent)),
					new IngredientElement(typeof(IronConcentrateItem), 1, true),
				},
				items: new List<CraftingElement>
				{
					new CraftingElement<PigIronBarItem>(4),
					new CraftingElement<FerrousSlagItem>(typeof(SmeltingSkill), 1),
				});

			this.Recipes = new List<Recipe> { recipe };
			this.ExperienceOnCraft = 2f;
			this.LaborInCalories = CreateLaborInCaloriesValue(50, typeof(SmeltingSkill));
			this.CraftMinutes = CreateCraftTimeValue(beneficiary: typeof(BlastPigIronRecipe), start: 2f, skillType: typeof(SmeltingSkill), typeof(SmeltingFocusedSpeedTalent), typeof(SmeltingParallelSpeedTalent));

			this.ModsPreInitialize();
			this.Initialize(displayText: Localizer.DoStr("Blast Pig Iron"), recipeType: typeof(BlastPigIronRecipe));
			this.ModsPostInitialize();

			CraftingComponent.AddRecipe(tableType: typeof(BlastFurnaceObject), recipe: this);
		}
		partial void ModsPreInitialize();
		partial void ModsPostInitialize();
	}
}