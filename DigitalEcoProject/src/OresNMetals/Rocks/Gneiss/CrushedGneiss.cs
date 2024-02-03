using System;
using System.Collections.Generic;
using System.ComponentModel;
using Eco.Gameplay.Components;
using Eco.Gameplay.Skills;
using Eco.Core.Items;
using Eco.Shared.Localization;
using Eco.Gameplay.Items.Recipes;
using Eco.Gameplay.Items;
using Eco.Shared.Serialization;
using Eco.Shared.SharedTypes;
using Eco.World.Blocks;

namespace Eco.Mods.TechTree
{
    [RequiresSkill(typeof(MiningSkill), 1)]
    [Ecopedia("Blocks", "Processed Rock", subPageName: "Crushed Gneiss Item")]
    public partial class CrushedGneissRecipe : Recipe
    {
        public CrushedGneissRecipe()
        {
            this.Init(
                name: "CrushedGneiss",  //noloc
                displayName: Localizer.DoStr("Crushed Gneiss"),

                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(GneissItem), 12, true),
                },

                items: new List<CraftingElement>
                {
                    new CraftingElement<CrushedGneissItem>(3)
                }
            );

            // Register our RecipeFamily instance with the crafting system so it can be crafted.
            CraftingComponent.AddTagProduct(typeof(ArrastraObject), typeof(CrushedRockRecipe), this);
        }
    }

    [RequiresSkill(typeof(MiningSkill), 1)]
    public partial class CrushedGneissLv2Recipe : Recipe
    {
        public CrushedGneissLv2Recipe()
        {
            this.Init(
                name: "CrushedGneiss",  //noloc
                displayName: Localizer.DoStr("Crushed Gneiss Lv2"),

                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(GneissItem), 20, true),
                },

                items: new List<CraftingElement>
                {
                    new CraftingElement<CrushedGneissItem>(5)
                }
            );

            // Register our RecipeFamily instance with the crafting system so it can be crafted.
            CraftingComponent.AddTagProduct(typeof(StampMillObject), typeof(CrushedRockLv2Recipe), this);
        }
    }

    [RequiresSkill(typeof(MiningSkill), 1)]
    public partial class CrushedGneissLv3Recipe : Recipe
    {
        public CrushedGneissLv3Recipe()
        {
            this.Init(
                name: "CrushedGneiss",  //noloc
                displayName: Localizer.DoStr("Crushed Gneiss Lv3"),

                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(GneissItem), 20, true),
                },

                items: new List<CraftingElement>
                {
                    new CraftingElement<CrushedGneissItem>(5)
                }
            );

            // Register our RecipeFamily instance with the crafting system so it can be crafted.
            CraftingComponent.AddTagProduct(typeof(JawCrusherObject), typeof(CrushedRockLv3Recipe), this);
        }
    }

    [Serialized]
    [Solid, Wall, Diggable]
    [Tag(BlockTags.Diggable)]
    public partial class CrushedGneissBlock :
        Block
        , IRepresentsItem
    {
        public virtual Type RepresentedItemType { get { return typeof(CrushedGneissItem); } }
    }

    [Serialized]
    [LocDisplayName("Crushed Gneiss")]
    [LocDescription("Gneiss rocks that have been crushed into a fine gravel.")]
    [MaxStackSize(10)]
    [Weight(28000)]
    [StartsDiscovered]
    [Ecopedia("Blocks", "Processed Rock", createAsSubPage: true)]
    [Tag("CrushedRock")]
    [Tag("Excavatable")]
    [RequiresTool(typeof(ShovelItem))]
    public partial class CrushedGneissItem :

    BlockItem<CrushedGneissBlock>
    {
        public override LocString DisplayNamePlural { get { return Localizer.DoStr("Crushed Gneiss"); } }

        public override bool CanStickToWalls { get { return false; } }
    }
}