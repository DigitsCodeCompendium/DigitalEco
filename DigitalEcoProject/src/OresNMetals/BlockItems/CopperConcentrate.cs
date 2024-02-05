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
    [Ecopedia("Blocks", "Processed Rock", subPageName: "Copper Concentrate Item")]
    public partial class CopperConcentrateChalcopyriteRecipe : RecipeFamily
    {
        public CopperConcentrateChalcopyriteRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                name: "CopperConcentrateChalcopyrite",  //noloc
                displayName: Localizer.DoStr("Concentrate Chalcopyrite"),

                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(CrushedChalcopyriteOreItem), 20, typeof(MiningSkill)),
                },

                items: new List<CraftingElement>
                {
                    new CraftingElement<CopperConcentrateItem>(3),
                    new CraftingElement<WetTailingsItem>(typeof(MiningSkill), 7),
                });
            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 2; // Defines how much experience is gained when crafted.

            // Defines the amount of labor required and the required skill to add labor
            this.LaborInCalories = CreateLaborInCaloriesValue(50, typeof(MiningSkill));

            // Defines our crafting time for the recipe
            this.CraftMinutes = CreateCraftTimeValue(beneficiary: typeof(CopperConcentrateChalcopyriteRecipe), start: 1.5f, skillType: typeof(MiningSkill));

            this.Initialize(displayText: Localizer.DoStr("Copper Concentrate"), recipeType: typeof(CopperConcentrateChalcopyriteRecipe));

            // Register our RecipeFamily instance with the crafting system so it can be crafted.
            CraftingComponent.AddRecipe(tableType: typeof(RockerBoxObject), recipe: this);
        }
    }

    [RequiresSkill(typeof(MiningSkill), 1)]
    [Ecopedia("Blocks", "Processed Rock", subPageName: "Copper Concentrate Item")]
    public partial class CopperConcentrateChalcopyriteLv2Recipe : RecipeFamily
    {
        public CopperConcentrateChalcopyriteLv2Recipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                name: "CopperConcentrateChalcopyrite",  //noloc
                displayName: Localizer.DoStr("Concentrate Chalcopyrite"),

                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(CrushedChalcopyriteOreItem), 10, typeof(MiningSkill)),
                },

                items: new List<CraftingElement>
                {
                    new CraftingElement<CopperConcentrateItem>(3),
                    new CraftingElement<WetTailingsItem>(typeof(MiningSkill), 7),
                });
            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 2; // Defines how much experience is gained when crafted.

            // Defines the amount of labor required and the required skill to add labor
            this.LaborInCalories = CreateLaborInCaloriesValue(50, typeof(MiningSkill));

            // Defines our crafting time for the recipe
            this.CraftMinutes = CreateCraftTimeValue(beneficiary: typeof(CopperConcentrateChalcopyriteLv2Recipe), start: 1.5f, skillType: typeof(MiningSkill));

            // Perform pre/post initialization for user mods and initialize our recipe instance with the display name "Copper Concentrate"
            this.ModsPreInitialize();
            this.Initialize(displayText: Localizer.DoStr("Copper Concentrate Lv2"), recipeType: typeof(CopperConcentrateChalcopyriteLv2Recipe));
            this.ModsPostInitialize();

            // Register our RecipeFamily instance with the crafting system so it can be crafted.
            CraftingComponent.AddRecipe(tableType: typeof(FrothFloatationCellObject), recipe: this);
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
    public partial class CopperConcentrateBlock :
        Block
        , IRepresentsItem
    {
        public virtual Type RepresentedItemType { get { return typeof(CopperConcentrateItem); } }
    }

    [Serialized]
    [LocDisplayName("Copper Concentrate")]
    [LocDescription("Copper ore that has been concentrated to remove impurities. Ore concentrate is used by smiths to smelt metal bars.")]
    [MaxStackSize(10)]
    [Weight(20000)]
    [Ecopedia("Blocks", "Processed Rock", createAsSubPage: true)]
    [Tag("ConcentratedOre")]
    [Tag("Excavatable")]
    [RequiresTool(typeof(ShovelItem))]
    public partial class CopperConcentrateItem :

    BlockItem<CopperConcentrateBlock>
    {
        public override LocString DisplayNamePlural { get { return Localizer.DoStr("Copper Concentrate"); } }

        public override bool CanStickToWalls { get { return false; } }
    }

}
