﻿using System;
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

namespace Eco.Mods.TechTree
{
    [RequiresSkill(typeof(MiningSkill), 1)]
    [Ecopedia("Blocks", "Processed Rock", subPageName: "Crushed Cupric Slag Item")]
    public partial class CrushedCupricSlagLv2Recipe : Recipe
    {
        public CrushedCupricSlagLv2Recipe()
        {
            this.Init(
                name: "CrushedCupricSlag",  //noloc
                displayName: Localizer.DoStr("Crushed Cupric Slag"),

                // Defines the ingredients needed to craft this recipe. An ingredient items takes the following inputs
                // type of the item, the amount of the item, the skill required, and the talent used.
                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(CupricSlagItem), 20, true),
                },

                // Define our recipe output items.
                // For every output item there needs to be one CraftingElement entry with the type of the final item and the amount
                // to create.
                items: new List<CraftingElement>
                {
                    new CraftingElement<CrushedCupricSlagItem>(5)
                }
            );

            // Register our RecipeFamily instance with the crafting system so it can be crafted.
            CraftingComponent.AddTagProduct(typeof(StampMillObject), typeof(CrushedSlagLv2Recipe), this);
        }
    }

    [RequiresSkill(typeof(MiningSkill), 1)]
    [Ecopedia("Blocks", "Processed Rock", subPageName: "Crushed Cupric Slag Item")]
    public partial class CrushedCupricSlagLv3Recipe : Recipe
    {
        public CrushedCupricSlagLv3Recipe()
        {
            this.Init(
                name: "CrushedCupricSlag",  //noloc
                displayName: Localizer.DoStr("Crushed Cupric Slag"),

                // Defines the ingredients needed to craft this recipe. An ingredient items takes the following inputs
                // type of the item, the amount of the item, the skill required, and the talent used.
                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(CupricSlagItem), 20, true),
                },

                // Define our recipe output items.
                // For every output item there needs to be one CraftingElement entry with the type of the final item and the amount
                // to create.
                items: new List<CraftingElement>
                {
                    new CraftingElement<CrushedCupricSlagItem>(5)
                }
            );

            // Register our RecipeFamily instance with the crafting system so it can be crafted.
            CraftingComponent.AddTagProduct(typeof(JawCrusherObject), typeof(CrushedSlagLv3Recipe), this);
        }
    }

    [Serialized]
    [Solid, Wall, Diggable]
    [RequiresSkill(typeof(MiningSkill), 1)]
    [Tag(BlockTags.Diggable)]
    public partial class CrushedCupricSlagBlock :
        Block
        , IRepresentsItem
    {
        public virtual Type RepresentedItemType { get { return typeof(CrushedCupricSlagItem); } }
    }

    [Serialized]
    [LocDisplayName("Crushed Cupric Slag")]
    [LocDescription("Cupric Slag rocks that have been crushed into a fine gravel.")]
    [MaxStackSize(10)]
    [Weight(26000)]
    [StartsDiscovered]
    [Ecopedia("Blocks", "Processed Rock", createAsSubPage: true)]
    [Tag("CrushedRock")]
    [Tag("Silica")]
    [Tag("Excavatable")]
    [RequiresTool(typeof(ShovelItem))]
    public partial class CrushedCupricSlagItem :

    BlockItem<CrushedCupricSlagBlock>
    {
        public override LocString DisplayNamePlural { get { return Localizer.DoStr("Crushed Cupric Slag"); } }

        public override bool CanStickToWalls { get { return false; } }
    }
}