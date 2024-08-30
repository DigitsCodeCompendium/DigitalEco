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
	public partial class CrushChalcopyriteRecipe : RecipeFamily
	{
		public CrushChalcopyriteRecipe()
		{
			var recipe = new Recipe();
			recipe.Init(
				name: "CrushChalcopyrite",
				displayName: Localizer.DoStr("Crush Chalcopyrite"),

				ingredients: new List<IngredientElement>
				{
					new IngredientElement(typeof(ChalcopyriteOreItem), 12, true),
				},
				items: new List<CraftingElement>
				{
					new CraftingElement<CrushedChalcopyriteOreItem>(2),
					new CraftingElement<CrushedGraniteItem>(1),
				});

			this.Recipes = new List<Recipe> { recipe };
			this.ExperienceOnCraft = 2f;
			this.LaborInCalories = CreateLaborInCaloriesValue(50, typeof(MiningSkill));
			this.CraftMinutes = CreateCraftTimeValue(beneficiary: typeof(CrushChalcopyriteRecipe), start: 2f, skillType: typeof(MiningSkill));

			this.ModsPreInitialize();
			this.Initialize(displayText: Localizer.DoStr("Crush Chalcopyrite"), recipeType: typeof(CrushChalcopyriteRecipe));
			this.ModsPostInitialize();

			CraftingComponent.AddRecipe(tableType: typeof(ArrastraObject), recipe: this);
		}
		partial void ModsPreInitialize();
		partial void ModsPostInitialize();
	}
}