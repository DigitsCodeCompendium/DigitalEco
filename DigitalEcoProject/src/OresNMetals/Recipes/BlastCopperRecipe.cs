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
	public partial class BlastCopperRecipe : RecipeFamily
	{
		public BlastCopperRecipe()
		{
			var recipe = new Recipe();
			recipe.Init(
				name: "BlastCopper",
				displayName: Localizer.DoStr("Blast Copper"),

				ingredients: new List<IngredientElement>
				{
					new IngredientElement("Silica", 1, typeof(AdvancedSmeltingSkill), typeof(AdvancedSmeltingLavishResourcesTalent)),
					new IngredientElement(typeof(CopperConcentrateItem), 2, true),
				},
				items: new List<CraftingElement>
				{
					new CraftingElement<ImpureCopperItem>(1),
					new CraftingElement<SulphuricSlagItem>(typeof(AdvancedSmeltingSkill), 4),
					new CraftingElement<FerrousSlagItem>(typeof(AdvancedSmeltingSkill), 3),
					new CraftingElement<CupricSlagItem>(typeof(AdvancedSmeltingSkill), 1),
				});

			this.Recipes = new List<Recipe> { recipe };
			this.ExperienceOnCraft = 2f;
			this.LaborInCalories = CreateLaborInCaloriesValue(50, typeof(AdvancedSmeltingSkill));
			this.CraftMinutes = CreateCraftTimeValue(beneficiary: typeof(BlastCopperRecipe), start: 2f, skillType: typeof(AdvancedSmeltingSkill), typeof(AdvancedSmeltingFocusedSpeedTalent), typeof(AdvancedSmeltingParallelSpeedTalent));

			this.ModsPreInitialize();
			this.Initialize(displayText: Localizer.DoStr("Blast Copper"), recipeType: typeof(BlastCopperRecipe));
			this.ModsPostInitialize();

			CraftingComponent.AddRecipe(tableType: typeof(BlastFurnaceObject), recipe: this);
		}
		partial void ModsPreInitialize();
		partial void ModsPostInitialize();
	}
}