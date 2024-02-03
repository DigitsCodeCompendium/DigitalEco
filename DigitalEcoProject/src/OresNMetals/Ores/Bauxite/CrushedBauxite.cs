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
    [Ecopedia("Blocks", "Processed Rock", subPageName: "Crushed Bauxite Item")]
    public partial class CrushedBauxiteOreRecipe : Recipe
    {
        public CrushedBauxiteOreRecipe()
        {
            this.Init(
                name: "CrushedBauxiteOre",  //noloc
                displayName: Localizer.DoStr("Crushed Bauxite"),

                ingredients: new List<IngredientElement>
                {
                new IngredientElement(typeof(BauxiteOreItem), 12, true),
                },

                items: new List<CraftingElement>
                {
                new CraftingElement<CrushedBauxiteOreItem>(2),
                new CraftingElement<CrushedShaleItem>(1),
                }
            );

            // Register our RecipeFamily instance with the crafting system so it can be crafted.
            CraftingComponent.AddTagProduct(typeof(ArrastraObject), typeof(CrushedHematiteOreRecipe), this);
        }
    }

    [RequiresSkill(typeof(MiningSkill), 1)]
    public partial class CrushedBauxiteOreLv2Recipe : Recipe
    {
        public CrushedBauxiteOreLv2Recipe()
        {
            this.Init(
                name: "CrushedBauxiteOreLv2",  //noloc
                displayName: Localizer.DoStr("Crushed Bauxite Lv2"),

                ingredients: new List<IngredientElement>
                {
                new IngredientElement(typeof(BauxiteOreItem), 20, true),
                },

                items: new List<CraftingElement>
                {
                new CraftingElement<CrushedBauxiteOreItem>(4),
                new CraftingElement<CrushedShaleItem>(1),
                }
            );

            // Register our RecipeFamily instance with the crafting system so it can be crafted.
            CraftingComponent.AddTagProduct(typeof(StampMillObject), typeof(CrushedHematiteOreLv2Recipe), this);
        }
    }

    [RequiresSkill(typeof(MiningSkill), 1)]
    public partial class CrushedBauxiteOreLv3Recipe : Recipe
    {
        public CrushedBauxiteOreLv3Recipe()
        {
            this.Init(
                name: "CrushedBauxiteOreLv3",  //noloc
                displayName: Localizer.DoStr("Crushed Bauxite Lv3"),

                ingredients: new List<IngredientElement>
                {
                new IngredientElement(typeof(BauxiteOreItem), 20, true),
                },

                items: new List<CraftingElement>
                {
                new CraftingElement<CrushedBauxiteOreItem>(5)
                }
            );

            // Register our RecipeFamily instance with the crafting system so it can be crafted.
            CraftingComponent.AddTagProduct(typeof(JawCrusherObject), typeof(CrushedHematiteOreLv3Recipe), this);
        }
    }

    [Serialized]
    [Solid, Wall, Diggable]
    [RequiresSkill(typeof(MiningSkill), 1)]
    [Tag(BlockTags.Diggable)]
    public partial class CrushedBauxiteOreBlock :
        Block
        , IRepresentsItem
    {
        public virtual Type RepresentedItemType { get { return typeof(CrushedBauxiteOreItem); } }
    }

    [Serialized]
    [LocDisplayName("Crushed Bauxite")]
    [LocDescription("Bauxite rocks that have been crushed into a fine gravel.")]
    [MaxStackSize(10)]
    [Weight(26000)]
    [StartsDiscovered]
    [Ecopedia("Blocks", "Processed Rock", createAsSubPage: true)]
    [Tag("Excavatable")]
    [RequiresTool(typeof(ShovelItem))]
    public partial class CrushedBauxiteOreItem :

    BlockItem<CrushedBauxiteOreBlock>
    {
        public override LocString DisplayNamePlural { get { return Localizer.DoStr("Crushed Bauxite"); } }

        public override bool CanStickToWalls { get { return false; } }
    }
}