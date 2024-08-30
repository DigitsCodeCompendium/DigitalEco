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
	public partial class CopperBarRecipe : RecipeFamily
	{
		public CopperBarRecipe()
		{
			var recipe = new Recipe();
			recipe.Init(
				name: "CopperBar",
				displayName: Localizer.DoStr("Copper Bar"),

				ingredients: new List<IngredientElement>
				{
					new IngredientElement("Coal", 1, typeof(SmeltingSkill), typeof(SmeltingLavishResourcesTalent)),
					new IngredientElement(typeof(CopperConcentrateItem), 2, true),
				},
				items: new List<CraftingElement>
				{
					new CraftingElement<CopperBarItem>(4),
					new CraftingElement<SulphuricSlagItem>(typeof(SmeltingSkill), 2),
					new CraftingElement<CupricSlagItem>(typeof(SmeltingSkill), 2),
					new CraftingElement<SlagItem>(typeof(SmeltingSkill), 4),
				});

			this.Recipes = new List<Recipe> { recipe };
			this.ExperienceOnCraft = 2f;
			this.LaborInCalories = CreateLaborInCaloriesValue(50, typeof(SmeltingSkill));
			this.CraftMinutes = CreateCraftTimeValue(beneficiary: typeof(CopperBarRecipe), start: 2f, skillType: typeof(SmeltingSkill), typeof(SmeltingFocusedSpeedTalent), typeof(SmeltingParallelSpeedTalent));

			this.ModsPreInitialize();
			this.Initialize(displayText: Localizer.DoStr("Copper Bar"), recipeType: typeof(CopperBarRecipe));
			this.ModsPostInitialize();

			CraftingComponent.AddRecipe(tableType: typeof(BloomeryObject), recipe: this);
		}
		partial void ModsPreInitialize();
		partial void ModsPostInitialize();
	}
}