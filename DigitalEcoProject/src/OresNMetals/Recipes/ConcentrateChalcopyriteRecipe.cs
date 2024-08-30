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
	[RequiresSkill(typeof(MiningSkill), 0)]
	public partial class ConcentrateChalcopyriteRecipe : RecipeFamily
	{
		public ConcentrateChalcopyriteRecipe()
		{
			var recipe = new Recipe();
			recipe.Init(
				name: "ConcentrateChalcopyrite",
				displayName: Localizer.DoStr("Concentrate Chalcopyrite"),

				ingredients: new List<IngredientElement>
				{
					new IngredientElement(typeof(CrushedChalcopyriteOreItem), 15, typeof(MiningSkill)),
				},
				items: new List<CraftingElement>
				{
					new CraftingElement<CopperConcentrateItem>(3),
					new CraftingElement<WetTailingsItem>(typeof(MiningSkill), 12),
				});

			this.Recipes = new List<Recipe> { recipe };
			this.ExperienceOnCraft = 2f;
			this.LaborInCalories = CreateLaborInCaloriesValue(50, typeof(MiningSkill));
			this.CraftMinutes = CreateCraftTimeValue(beneficiary: typeof(ConcentrateChalcopyriteRecipe), start: 2f, skillType: typeof(MiningSkill));

			this.ModsPreInitialize();
			this.Initialize(displayText: Localizer.DoStr("Concentrate Chalcopyrite"), recipeType: typeof(ConcentrateChalcopyriteRecipe));
			this.ModsPostInitialize();

			CraftingComponent.AddRecipe(tableType: typeof(RockerBoxObject), recipe: this);
		}
		partial void ModsPreInitialize();
		partial void ModsPostInitialize();
	}
}