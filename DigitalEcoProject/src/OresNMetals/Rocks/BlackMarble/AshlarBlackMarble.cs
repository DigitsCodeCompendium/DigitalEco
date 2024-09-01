﻿// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.
// <auto-generated from BlockTemplate.tt/>

namespace Eco.Mods.TechTree
{
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
    using Eco.Gameplay.Systems;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Core.Items;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;

    using Eco.Shared.SharedTypes;
    using Eco.World;
    using Eco.World.Blocks;
    using Eco.World.Water;
    using Eco.Gameplay.Pipes;
    using Eco.Core.Controller;
    using Eco.Gameplay.Items.Recipes;
    using Eco.Shared.Graphics;
    using Eco.World.Color;

    [RequiresSkill(typeof(AdvancedMasonrySkill), 1)]
    [Ecopedia("Blocks", "Building Materials", subPageName: "Ashlar BlackMarble Item")]
    public partial class AshlarBlackMarbleRecipe : RecipeFamily
    {
        public AshlarBlackMarbleRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                name: "AshlarBlackMarble",  //noloc
                displayName: Localizer.DoStr("Ashlar BlackMarble"),

                // Defines the ingredients needed to craft this recipe. An ingredient items takes the following inputs
                // type of the item, the amount of the item, the skill required, and the talent used.
                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(BlackMarbleItem), 20, typeof(AdvancedMasonrySkill), typeof(AdvancedMasonryLavishResourcesTalent)),
                    new IngredientElement(typeof(CementItem), 6, typeof(AdvancedMasonrySkill), typeof(AdvancedMasonryLavishResourcesTalent)),
                    new IngredientElement(typeof(SteelBarItem), 1, typeof(AdvancedMasonrySkill), typeof(AdvancedMasonryLavishResourcesTalent)),
                },

                // Define our recipe output items.
                // For every output item there needs to be one CraftingElement entry with the type of the final item and the amount
                // to create.
                items: new List<CraftingElement>
                {
                    new CraftingElement<AshlarBlackMarbleItem>(2),
                    new CraftingElement<CrushedBlackMarbleItem>(typeof(AdvancedMasonrySkill), 2, typeof(AdvancedMasonryLavishResourcesTalent)),
                });
            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 1.5f; // Defines how much experience is gained when crafted.

            // Defines the amount of labor required and the required skill to add labor
            this.LaborInCalories = CreateLaborInCaloriesValue(180, typeof(AdvancedMasonrySkill));

            // Defines our crafting time for the recipe
            this.CraftMinutes = CreateCraftTimeValue(beneficiary: typeof(AshlarBlackMarbleRecipe), start: 0.64f, skillType: typeof(AdvancedMasonrySkill), typeof(AdvancedMasonryFocusedSpeedTalent), typeof(AdvancedMasonryParallelSpeedTalent));

            // Perform pre/post initialization for user mods and initialize our recipe instance with the display name "Ashlar BlackMarble"
            this.ModsPreInitialize();
            this.Initialize(displayText: Localizer.DoStr("Ashlar BlackMarble"), recipeType: typeof(AshlarBlackMarbleRecipe));
            this.ModsPostInitialize();

            // Register our RecipeFamily instance with the crafting system so it can be crafted.
            CraftingComponent.AddRecipe(tableType: typeof(AdvancedMasonryTableObject), recipe: this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    [Serialized]
    [Solid, Wall, Constructed, BuildRoomMaterialOption]
    [BlockTier(5)]
    [RequiresSkill(typeof(AdvancedMasonrySkill), 1)]
    public partial class AshlarBlackMarbleBlock :
        Block
        , IRepresentsItem
    {
        public virtual Type RepresentedItemType { get { return typeof(AshlarBlackMarbleItem); } }
    }

    [Serialized]
    [LocDisplayName("Ashlar BlackMarble")]
    [LocDescription("Ashlar is finely cut stone made by an expert mason. Ashlar stone is an especially decorative building material that comes in a variety of styles based on the type of rock used.")]
    [MaxStackSize(20)]
    [Weight(10000)]
    [Ecopedia("Blocks", "Building Materials", createAsSubPage: true)]
    [Tag("AshlarStone")]
    [Tag("Constructable")]
    [Tier(5)]
    public partial class AshlarBlackMarbleItem :

    BlockItem<AshlarBlackMarbleBlock>
    {
        public override LocString DisplayNamePlural { get { return Localizer.DoStr("Ashlar BlackMarble"); } }

        public override bool CanStickToWalls { get { return false; } }

        private static Type[] blockTypes = new Type[] {
            typeof(AshlarBlackMarbleStacked1Block),
            typeof(AshlarBlackMarbleStacked2Block),
            typeof(AshlarBlackMarbleStacked3Block),
            typeof(AshlarBlackMarbleStacked4Block)
        };

        public override Type[] BlockTypes { get { return blockTypes; } }
    }

    [Tag("AshlarStone")]
    [Tag("Constructable")]
    [Tag(BlockTags.PartialStack)]
    [Serialized, Solid] public class AshlarBlackMarbleStacked1Block : PickupableBlock, IWaterLoggedBlock { }
    [Tag("AshlarStone")]
    [Tag("Constructable")]
    [Tag(BlockTags.PartialStack)]
    [Serialized, Solid] public class AshlarBlackMarbleStacked2Block : PickupableBlock, IWaterLoggedBlock { }
    [Tag("AshlarStone")]
    [Tag("Constructable")]
    [Tag(BlockTags.PartialStack)]
    [Serialized, Solid] public class AshlarBlackMarbleStacked3Block : PickupableBlock, IWaterLoggedBlock { }
    [Tag("AshlarStone")]
    [Tag("Constructable")]
    [Tag(BlockTags.FullStack)]
    [Serialized, Solid, Wall] public class AshlarBlackMarbleStacked4Block : PickupableBlock, IWaterLoggedBlock { } //Only a wall if it's all 4 AshlarBlackMarble
}
