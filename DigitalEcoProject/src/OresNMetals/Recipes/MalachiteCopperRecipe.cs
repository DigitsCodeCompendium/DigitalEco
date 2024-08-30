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
	public partial class MalachiteCopperRecipe : RecipeFamily
	{
		public MalachiteCopperRecipe()
		{
			var recipe = new Recipe();
			recipe.Init(
				name: "MalachiteCopper",
				displayName: Localizer.DoStr("Malachite Copper"),

				ingredients: new List<IngredientElement>
				{
					new IngredientElement(typeof(CoalItem), 1, typeof(SmeltingSkill), typeof(SmeltingLavishResourcesTalent)),
					new IngredientElement(typeof(MalachiteOreItem), 12, true),
				},
				items: new List<CraftingElement>
				{
					new CraftingElement<CopperBarItem>(2),
					new CraftingElement<SlagItem>(typeof(SmeltingSkill), 8),
					new CraftingElement<CupricSlagItem>(typeof(SmeltingSkill), 2),
				});

			this.Recipes = new List<Recipe> { recipe };
			this.ExperienceOnCraft = 2f;
			this.LaborInCalories = CreateLaborInCaloriesValue(50, typeof(SmeltingSkill));
			this.CraftMinutes = CreateCraftTimeValue(beneficiary: typeof(MalachiteCopperRecipe), start: 2f, skillType: typeof(SmeltingSkill), typeof(SmeltingFocusedSpeedTalent), typeof(SmeltingParallelSpeedTalent));

			this.ModsPreInitialize();
			this.Initialize(displayText: Localizer.DoStr("Malachite Copper"), recipeType: typeof(MalachiteCopperRecipe));
			this.ModsPostInitialize();

			CraftingComponent.AddRecipe(tableType: typeof(BloomeryObject), recipe: this);
		}
		partial void ModsPreInitialize();
		partial void ModsPostInitialize();
	}
}