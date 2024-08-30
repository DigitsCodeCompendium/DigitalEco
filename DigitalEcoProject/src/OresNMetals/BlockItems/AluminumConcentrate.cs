using System;
using System.Collections.Generic;
using System.ComponentModel;
using Eco.Gameplay.Components;
using Eco.Gameplay.Items;
using Eco.Gameplay.Skills;
using Eco.Core.Items;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;
using Eco.Shared.SharedTypes;
using Eco.World.Blocks;
using Eco.Gameplay.Items.Recipes;

namespace Eco.Mods.TechTree
{
    [RequiresSkill(typeof(MiningSkill), 1)]
    [Ecopedia("Blocks", "Processed Rock", subPageName: "Aluminum Concentrate Item")]
    public partial class AluminumConcentrateRecipe : RecipeFamily
    {
        public AluminumConcentrateRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                name: "AluminumConcentrate",  //noloc
                displayName: Localizer.DoStr("Aluminum Concentrate"),

                // Defines the ingredients needed to craft this recipe. An ingredient items takes the following inputs
                // type of the item, the amount of the item, the skill required, and the talent used.
                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(AluminaItem), 7, typeof(MiningSkill)),
                    new IngredientElement(typeof(CrushedCryoliteOreItem), 7, typeof(MiningSkill)),
                    //new IngredientElement(typeof(CokeAnodeItem), 7, typeof(MiningSkill)),
                },

                // Define our recipe output items.
                // For every output item there needs to be one CraftingElement entry with the type of the final item and the amount
                // to create.
                items: new List<CraftingElement>
                {
                    new CraftingElement<AluminumConcentrateItem>(),
                });
            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 2; // Defines how much experience is gained when crafted.

            // Defines the amount of labor required and the required skill to add labor
            this.LaborInCalories = CreateLaborInCaloriesValue(50, typeof(MiningSkill));

            // Defines our crafting time for the recipe
            this.CraftMinutes = CreateCraftTimeValue(beneficiary: typeof(AluminumConcentrateRecipe), start: 1.5f, skillType: typeof(MiningSkill));

            // Perform pre/post initialization for user mods and initialize our recipe instance with the display name "Aluminum Concentrate"
            this.ModsPreInitialize();
            this.Initialize(displayText: Localizer.DoStr("Aluminum Concentrate"), recipeType: typeof(AluminumConcentrateRecipe));
            this.ModsPostInitialize();

            // Register our RecipeFamily instance with the crafting system so it can be crafted.
            CraftingComponent.AddRecipe(tableType: typeof(ElectrolyserObject), recipe: this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    [Serialized]
    [Solid, Wall, Diggable]
    [RequiresSkill(typeof(MiningSkill), 1)]
    [Tag(BlockTags.Diggable)]
    public partial class AluminumConcentrateBlock :
        Block
        , IRepresentsItem
    {
        public virtual Type RepresentedItemType { get { return typeof(AluminumConcentrateItem); } }
    }

    [Serialized]
    [LocDisplayName("Aluminum Concentrate")]
    [LocDescription("Aluminum ore that has been concentrated to remove impurities. Ore concentrate is used by smiths to smelt metal bars.")]
    [MaxStackSize(10)]
    [Weight(20000)]
    [Ecopedia("Blocks", "Processed Rock", createAsSubPage: true)]
    [Tag("ConcentratedOre")]
    [Tag("Excavatable")]
    [RequiresTool(typeof(ShovelItem))]
    public partial class AluminumConcentrateItem :

    BlockItem<AluminumConcentrateBlock>
    {
        public override LocString DisplayNamePlural { get { return Localizer.DoStr("Aluminum Concentrate"); } }

        public override bool CanStickToWalls { get { return false; } }
    }

}
