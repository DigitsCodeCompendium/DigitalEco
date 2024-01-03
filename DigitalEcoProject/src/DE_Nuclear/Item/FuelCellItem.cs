
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using Eco.Mods.TechTree;

namespace Digits.Nuclear
{
    [RequiresSkill(typeof(MiningSkill), 7)] 
    public partial class FuelCellRecipe : RecipeFamily
    {
        public FuelCellRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                name: "Copper Ore Uranium Extraction",
                displayName: Localizer.DoStr("Copper Ore Uranium Extraction"),

                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(CrushedCopperOreItem), 100 * 2, typeof(MiningSkill)),
                    new IngredientElement(typeof(SteelPlateItem), 2, typeof(MiningSkill)),
                },

                items: new List<CraftingElement>
                {
                    new CraftingElement<FuelCellItem>(1),  
                    new CraftingElement<CopperConcentrateItem>(20),
                    new CraftingElement<WetTailingsItem>(30),
                }
            );
            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 20;
            this.LaborInCalories = CreateLaborInCaloriesValue(10000, typeof(MiningSkill)); 
            this.CraftMinutes = CreateCraftTimeValue(120.0f);

            this.ModsPreInitialize();
            this.Initialize(displayText: Localizer.DoStr("Copper Ore Uranium Extraction"), recipeType: typeof(FuelCellRecipe));
            this.ModsPostInitialize();

            CraftingComponent.AddRecipe(tableType: typeof(FrothFloatationCellObject), recipe: this);
        }

        partial void ModsPreInitialize();
        partial void ModsPostInitialize();
    }

    [Serialized]
    [LocDisplayName("Fuel Cell")]
    [Weight(100)]
    [Fuel(8000000)][Tag("Fuel")]                      
    //[Ecopedia("Items", "Tools", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]                                                                           
    [Tag("Uranium Fuel")]         
    [LocDescription("A highly shielded cell of uranium which contains a very large amount of energy.")]                        
    public partial class FuelCellItem : Item
    {

    }
}