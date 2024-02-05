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
    [Ecopedia("Blocks", "Processed Rock", subPageName: "Iron Concentrate Item")]
    public partial class IronConcentrateHematiteRecipe : RecipeFamily
    {
        public IronConcentrateHematiteRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                name: "IronConcentrate",  //noloc
                displayName: Localizer.DoStr("Concentrate Hematite"),

                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(CrushedHematiteOreItem), 25, typeof(MiningSkill)),
                },

                items: new List<CraftingElement>
                {
                    new CraftingElement<IronConcentrateItem>(2),
                    new CraftingElement<WetTailingsItem>(typeof(MiningSkill), 7),
                });
            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 2; // Defines how much experience is gained when crafted.

            this.LaborInCalories = CreateLaborInCaloriesValue(50, typeof(MiningSkill));

            this.CraftMinutes = CreateCraftTimeValue(beneficiary: typeof(IronConcentrateHematiteRecipe), start: 1.5f, skillType: typeof(MiningSkill));

            this.Initialize(displayText: Localizer.DoStr("Iron Concentrate"), recipeType: typeof(IronConcentrateHematiteRecipe));

            CraftingComponent.AddRecipe(tableType: typeof(RockerBoxObject), recipe: this);
        }
    }

    public partial class IronConcentrateHematiteLv2Recipe : RecipeFamily
    {
        public IronConcentrateHematiteLv2Recipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                name: "IronConcentrate",  //noloc
                displayName: Localizer.DoStr("Concentrate Hematite Lv2"),

                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(CrushedHematiteOreItem), 25, typeof(MiningSkill)),
                },

                items: new List<CraftingElement>
                {
                    new CraftingElement<IronConcentrateItem>(4),
                    new CraftingElement<WetTailingsItem>(typeof(MiningSkill), 5),
                });
            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 2; // Defines how much experience is gained when crafted.

            this.LaborInCalories = CreateLaborInCaloriesValue(50, typeof(MiningSkill));

            this.CraftMinutes = CreateCraftTimeValue(beneficiary: typeof(IronConcentrateHematiteLv2Recipe), start: 1.5f, skillType: typeof(MiningSkill));

            this.Initialize(displayText: Localizer.DoStr("Iron Concentrate Lv2"), recipeType: typeof(IronConcentrateHematiteLv2Recipe));

            CraftingComponent.AddRecipe(tableType: typeof(FrothFloatationCellObject), recipe: this);
        }
    }

    public partial class IronDryConcentrateHematiteRecipe : RecipeFamily
    {
        public IronDryConcentrateHematiteRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                name: "IronDryConcentrate",  //noloc
                displayName: Localizer.DoStr("Dry Concentrate Hematite"),

                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(CrushedHematiteOreItem), 15, typeof(MiningSkill)),
                },

                items: new List<CraftingElement>
                {
                    new CraftingElement<IronConcentrateItem>(2),
                    new CraftingElement<TailingsItem>(typeof(MiningSkill), 3),
                });
            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 2; // Defines how much experience is gained when crafted.

            this.LaborInCalories = CreateLaborInCaloriesValue(50, typeof(MiningSkill));

            this.CraftMinutes = CreateCraftTimeValue(beneficiary: typeof(IronDryConcentrateHematiteRecipe), start: 1.5f, skillType: typeof(MiningSkill));

            this.Initialize(displayText: Localizer.DoStr("Dry Concentrate Iron"), recipeType: typeof(IronDryConcentrateHematiteRecipe));

            CraftingComponent.AddRecipe(tableType: typeof(ScreeningMachineObject), recipe: this);
        }
    }

    public partial class IronDryConcentrateHematiteLv2Recipe : RecipeFamily
    {
        public IronDryConcentrateHematiteLv2Recipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                name: "IronDryConcentrateLv2",  //noloc
                displayName: Localizer.DoStr("Dry Concentrate Hematite Lv2"),

                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(CrushedHematiteOreItem), 25, typeof(MiningSkill)),
                },

                items: new List<CraftingElement>
                {
                    new CraftingElement<IronConcentrateItem>(4),
                    new CraftingElement<TailingsItem>(typeof(MiningSkill), 5),
                });
            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 2; // Defines how much experience is gained when crafted.

            this.LaborInCalories = CreateLaborInCaloriesValue(50, typeof(MiningSkill));

            this.CraftMinutes = CreateCraftTimeValue(beneficiary: typeof(IronDryConcentrateHematiteLv2Recipe), start: 1.5f, skillType: typeof(MiningSkill));

            this.Initialize(displayText: Localizer.DoStr("Dry Concentrate Iron Lv2"), recipeType: typeof(IronDryConcentrateHematiteLv2Recipe));

            CraftingComponent.AddRecipe(tableType: typeof(SensorBasedBeltSorterObject), recipe: this);
        }
    }

    [Serialized]
    [Solid, Wall, Diggable]
    [RequiresSkill(typeof(MiningSkill), 1)]
    [Tag(BlockTags.Diggable)]
    public partial class IronConcentrateBlock :
        Block
        , IRepresentsItem
    {
        public virtual Type RepresentedItemType { get { return typeof(IronConcentrateItem); } }
    }

    [Serialized]
    [LocDisplayName("Iron Concentrate")]
    [LocDescription("Iron ore that has been concentrated to remove impurities. Ore concentrate is used by smiths to smelt metal bars.")]
    [MaxStackSize(10)]
    [Weight(20000)]
    [Ecopedia("Blocks", "Processed Rock", createAsSubPage: true)]
    [Tag("ConcentratedOre")]
    [Tag("Excavatable")]
    [RequiresTool(typeof(ShovelItem))]
    public partial class IronConcentrateItem :

    BlockItem<IronConcentrateBlock>
    {
        public override LocString DisplayNamePlural { get { return Localizer.DoStr("Iron Concentrate"); } }

        public override bool CanStickToWalls { get { return false; } }
    }

}
