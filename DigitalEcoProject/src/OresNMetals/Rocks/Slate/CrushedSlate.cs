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
    [Ecopedia("Blocks", "Processed Rock", subPageName: "Crushed Slate Item")]
    public partial class CrushedSlateRecipe : Recipe
    {
        public CrushedSlateRecipe()
        {
            this.Init(
                name: "CrushedSlate",  //noloc
                displayName: Localizer.DoStr("Crushed Slate"),

                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(SlateItem), 12, true),
                },

                items: new List<CraftingElement>
                {
                    new CraftingElement<CrushedSlateItem>(3)
                }
            );

            // Register our RecipeFamily instance with the crafting system so it can be crafted.
            CraftingComponent.AddTagProduct(typeof(ArrastraObject), typeof(CrushedRockRecipe), this);
        }
    }

    [RequiresSkill(typeof(MiningSkill), 1)]
    public partial class CrushedSlateLv2Recipe : Recipe
    {
        public CrushedSlateLv2Recipe()
        {
            this.Init(
                name: "CrushedSlate",  //noloc
                displayName: Localizer.DoStr("Crushed Slate Lv2"),

                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(SlateItem), 20, true),
                },

                items: new List<CraftingElement>
                {
                    new CraftingElement<CrushedSlateItem>(5)
                }
            );

            // Register our RecipeFamily instance with the crafting system so it can be crafted.
            CraftingComponent.AddTagProduct(typeof(StampMillObject), typeof(CrushedRockLv2Recipe), this);
        }
    }

    [RequiresSkill(typeof(MiningSkill), 1)]
    public partial class CrushedSlateLv3Recipe : Recipe
    {
        public CrushedSlateLv3Recipe()
        {
            this.Init(
                name: "CrushedSlate",  //noloc
                displayName: Localizer.DoStr("Crushed Slate Lv3"),

                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(SlateItem), 20, true),
                },

                items: new List<CraftingElement>
                {
                    new CraftingElement<CrushedSlateItem>(5)
                }
            );

            // Register our RecipeFamily instance with the crafting system so it can be crafted.
            CraftingComponent.AddTagProduct(typeof(JawCrusherObject), typeof(CrushedRockLv3Recipe), this);
        }
    }

    [Serialized]
    [Solid, Wall, Diggable]
    [RequiresSkill(typeof(MiningSkill), 1)]
    [Tag(BlockTags.Diggable)]
    public partial class CrushedSlateBlock :
        Block
        , IRepresentsItem
    {
        public virtual Type RepresentedItemType { get { return typeof(CrushedSlateItem); } }
    }

    [Serialized]
    [LocDisplayName("Crushed Slate")]
    [LocDescription("Slate rocks that have been crushed into a fine gravel.")]
    [MaxStackSize(10)]
    [Weight(26000)]
    [StartsDiscovered]
    [Ecopedia("Blocks", "Processed Rock", createAsSubPage: true)]
    [Tag("CrushedRock")]
    [Tag("Excavatable")]
    [RequiresTool(typeof(ShovelItem))]
    public partial class CrushedSlateItem :

    BlockItem<CrushedSlateBlock>
    {
        public override LocString DisplayNamePlural { get { return Localizer.DoStr("Crushed Slate"); } }

        public override bool CanStickToWalls { get { return false; } }
    }
}