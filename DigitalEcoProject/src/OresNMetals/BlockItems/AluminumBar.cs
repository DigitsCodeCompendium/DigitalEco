﻿// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.
// <auto-generated from BlockTemplate.tt/>

namespace Eco.Mods.TechTree
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Objects;
    using Eco.Gameplay.Skills;
    using Eco.Core.Items;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.SharedTypes;
    using Eco.World.Blocks;
    using Eco.World.Water;
    using Eco.Gameplay.Items.Recipes;

    [RequiresSkill(typeof(SmeltingSkill), 1)]
    [Ecopedia("Blocks", "Metals", subPageName: "Aluminum Bar Item")]
    public partial class AluminumBarRecipe : RecipeFamily
    {
        public AluminumBarRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                name: "AluminumBar",  //noloc
                displayName: Localizer.DoStr("Aluminum Bar"),

                // Defines the ingredients needed to craft this recipe. An ingredient items takes the following inputs
                // type of the item, the amount of the item, the skill required, and the talent used.
                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(AluminumConcentrateItem), 1, typeof(SmeltingSkill), typeof(SmeltingLavishResourcesTalent)),
                },

                // Define our recipe output items.
                // For every output item there needs to be one CraftingElement entry with the type of the final item and the amount
                // to create.
                items: new List<CraftingElement>
                {
                    new CraftingElement<AluminumBarItem>(4),
                    new CraftingElement<AlumnicSlagItem>(typeof(SmeltingSkill), 1, typeof(SmeltingLavishResourcesTalent)),
                });
            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 2; // Defines how much experience is gained when crafted.

            // Defines the amount of labor required and the required skill to add labor
            this.LaborInCalories = CreateLaborInCaloriesValue(60, typeof(SmeltingSkill));

            // Defines our crafting time for the recipe
            this.CraftMinutes = CreateCraftTimeValue(beneficiary: typeof(AluminumBarRecipe), start: 0.6f, skillType: typeof(SmeltingSkill), typeof(SmeltingFocusedSpeedTalent), typeof(SmeltingParallelSpeedTalent));

            // Perform pre/post initialization for user mods and initialize our recipe instance with the display name "Aluminum Bar"
            this.ModsPreInitialize();
            this.Initialize(displayText: Localizer.DoStr("Aluminum Bar"), recipeType: typeof(AluminumBarRecipe));
            this.ModsPostInitialize();

            // Register our RecipeFamily instance with the crafting system so it can be crafted.
            CraftingComponent.AddRecipe(tableType: typeof(BlastFurnaceObject), recipe: this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    [Serialized]
    [Solid, Wall, Constructed]
    [RequiresSkill(typeof(SmeltingSkill), 1)]
    public partial class AluminumBarBlock :
        Block
        , IRepresentsItem
    {
        public virtual Type RepresentedItemType { get { return typeof(AluminumBarItem); } }
    }

    [Serialized]
    [LocDisplayName("Aluminum Bar")]
    [LocDescription("Refined bar of Aluminum.")]
    [MaxStackSize(20)]
    [Weight(15000)]
    [Ecopedia("Blocks", "Metals", createAsSubPage: true)]
    [Currency]
    [Tag("Currency")]
    [Tag("Metal")]
    public partial class AluminumBarItem :

    BlockItem<AluminumBarBlock>
    {

        public override bool CanStickToWalls { get { return false; } }

        private static Type[] blockTypes = new Type[] {
            typeof(AluminumBarStacked1Block),
            typeof(AluminumBarStacked2Block),
            typeof(AluminumBarStacked3Block),
            typeof(AluminumBarStacked4Block)
        };

        public override Type[] BlockTypes { get { return blockTypes; } }
    }

    [Tag("Metal")]
    [Tag(BlockTags.PartialStack)]
    [Serialized, Solid] public class AluminumBarStacked1Block : PickupableBlock, IWaterLoggedBlock { }
    [Tag("Metal")]
    [Tag(BlockTags.PartialStack)]
    [Serialized, Solid] public class AluminumBarStacked2Block : PickupableBlock, IWaterLoggedBlock { }
    [Tag("Metal")]
    [Tag(BlockTags.PartialStack)]
    [Serialized, Solid] public class AluminumBarStacked3Block : PickupableBlock, IWaterLoggedBlock { }
    [Tag("Metal")]
    [Tag(BlockTags.FullStack)]
    [Serialized, Solid, Wall] public class AluminumBarStacked4Block : PickupableBlock, IWaterLoggedBlock { } //Only a wall if it's all 4 AluminumBar
}
