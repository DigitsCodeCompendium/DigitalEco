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
	public partial class WorkPigIronLv2Recipe : RecipeFamily
	{
		public WorkPigIronLv2Recipe()
		{
			var recipe = new Recipe();
			recipe.Init(
				name: "WorkPigIronLv2",
				displayName: Localizer.DoStr("Work Pig Iron Lv2"),

				ingredients: new List<IngredientElement>
				{
					new IngredientElement(typeof(PigIronBarItem), 11, typeof(SmeltingSkill), typeof(SmeltingLavishResourcesTalent)),
				},
				items: new List<CraftingElement>
				{
					new CraftingElement<IronBarItem>(10),
					new CraftingElement<FerrousSlagItem>(typeof(SmeltingSkill), 1),
				});

			this.Recipes = new List<Recipe> { recipe };
			this.ExperienceOnCraft = 2f;
			this.LaborInCalories = CreateLaborInCaloriesValue(50, typeof(SmeltingSkill));
			this.CraftMinutes = CreateCraftTimeValue(beneficiary: typeof(WorkPigIronLv2Recipe), start: 2f, skillType: typeof(SmeltingSkill), typeof(SmeltingFocusedSpeedTalent), typeof(SmeltingParallelSpeedTalent));

			this.ModsPreInitialize();
			this.Initialize(displayText: Localizer.DoStr("Work Pig Iron Lv2"), recipeType: typeof(WorkPigIronLv2Recipe));
			this.ModsPostInitialize();

			CraftingComponent.AddRecipe(tableType: typeof(PowerHammerObject), recipe: this);
		}
		partial void ModsPreInitialize();
		partial void ModsPostInitialize();
	}
}