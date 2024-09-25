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
	public partial class ConcentrateIlmeniteLv2Recipe : RecipeFamily
	{
		public ConcentrateIlmeniteLv2Recipe()
		{
			var recipe = new Recipe();
			recipe.Init(
				name: "ConcentrateIlmeniteLv2",
				displayName: Localizer.DoStr("Concentrate Ilmenite Lv2"),

				ingredients: new List<IngredientElement>
				{
					new IngredientElement(typeof(CrushedIlmeniteOreItem), 10, typeof(MiningSkill)),
				},
				items: new List<CraftingElement>
				{
					new CraftingElement<IronConcentrateItem>(1),
					new CraftingElement<WetTailingsItem>(typeof(MiningSkill), 2),
				});

			this.Recipes = new List<Recipe> { recipe };
			this.ExperienceOnCraft = 2f;
			this.LaborInCalories = CreateLaborInCaloriesValue(50, typeof(MiningSkill));
			this.CraftMinutes = CreateCraftTimeValue(beneficiary: typeof(ConcentrateIlmeniteLv2Recipe), start: 1.5f, skillType: typeof(MiningSkill));

			this.ModsPreInitialize();
			this.Initialize(displayText: Localizer.DoStr("Concentrate Ilmenite Lv2"), recipeType: typeof(ConcentrateIlmeniteLv2Recipe));
			this.ModsPostInitialize();

			CraftingComponent.AddRecipe(tableType: typeof(FrothFloatationCellObject), recipe: this);
		}
		partial void ModsPreInitialize();
		partial void ModsPostInitialize();
	}
}