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
	public partial class CrushHematiteLv2Recipe : RecipeFamily
	{
		public CrushHematiteLv2Recipe()
		{
			var recipe = new Recipe();
			recipe.Init(
				name: "CrushHematiteLv2",
				displayName: Localizer.DoStr("Crush Hematite Lv2"),

				ingredients: new List<IngredientElement>
				{
					new IngredientElement(typeof(HematiteOreItem), 20, true),
				},
				items: new List<CraftingElement>
				{
					new CraftingElement<CrushedHematiteOreItem>(4),
					new CraftingElement<CrushedSandstoneItem>(1),
				});

			this.Recipes = new List<Recipe> { recipe };
			this.ExperienceOnCraft = 0.5f;
			this.LaborInCalories = CreateLaborInCaloriesValue(70, typeof(MiningSkill));
			this.CraftMinutes = CreateCraftTimeValue(beneficiary: typeof(CrushHematiteLv2Recipe), start: 2f, skillType: typeof(MiningSkill));

			this.ModsPreInitialize();
			this.Initialize(displayText: Localizer.DoStr("Crush Hematite Lv2"), recipeType: typeof(CrushHematiteLv2Recipe));
			this.ModsPostInitialize();

			CraftingComponent.AddRecipe(tableType: typeof(StampMillObject), recipe: this);
		}
		partial void ModsPreInitialize();
		partial void ModsPostInitialize();
	}
}