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
    [Ecopedia("Blocks", "Processed Rock", subPageName: "Crushed Black Marble Item")]
    public partial class CrushedBlackMarbleRecipe : Recipe
    {
        public CrushedBlackMarbleRecipe()
        {
            this.Init(
                name: "CrushedBlackMarble",  //noloc
                displayName: Localizer.DoStr("Crushed Black Marble"),

                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(BlackMarbleItem), 12, true),
                },

                items: new List<CraftingElement>
                {
                    new CraftingElement<CrushedBlackMarbleItem>(3)
                }
            );

            // Register our RecipeFamily instance with the crafting system so it can be crafted.
            CraftingComponent.AddTagProduct(typeof(ArrastraObject), typeof(CrushedRockRecipe), this);
        }
    }

    [RequiresSkill(typeof(MiningSkill), 1)]
    public partial class CrushedBlackMarbleLv2Recipe : Recipe
    {
        public CrushedBlackMarbleLv2Recipe()
        {
            this.Init(
                name: "CrushedBlackMarble",  //noloc
                displayName: Localizer.DoStr("Crushed Black Marble Lv2"),

                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(BlackMarbleItem), 20, true),
                },

                items: new List<CraftingElement>
                {
                    new CraftingElement<CrushedBlackMarbleItem>(5)
                }
            );

            // Register our RecipeFamily instance with the crafting system so it can be crafted.
            CraftingComponent.AddTagProduct(typeof(StampMillObject), typeof(CrushedRockLv2Recipe), this);
        }
    }

    [RequiresSkill(typeof(MiningSkill), 1)]
    public partial class CrushedBlackMarbleLv3Recipe : Recipe
    {
        public CrushedBlackMarbleLv3Recipe()
        {
            this.Init(
                name: "CrushedBlackMarble",  //noloc
                displayName: Localizer.DoStr("Crushed Black Marble Lv3"),

                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(BlackMarbleItem), 20, true),
                },

                items: new List<CraftingElement>
                {
                    new CraftingElement<CrushedBlackMarbleItem>(5)
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
    public partial class CrushedBlackMarbleBlock :
        Block
        , IRepresentsItem
    {
        public virtual Type RepresentedItemType { get { return typeof(CrushedBlackMarbleItem); } }
    }

    [Serialized]
    [LocDisplayName("Crushed BlackMarble")]
    [LocDescription("BlackMarble rocks that have been crushed into a fine gravel.")]
    [MaxStackSize(10)]
    [Weight(26000)]
    [StartsDiscovered]
    [Ecopedia("Blocks", "Processed Rock", createAsSubPage: true)]
    [Tag("CrushedRock")]
    [Tag("Excavatable")]
    [RequiresTool(typeof(ShovelItem))]
    public partial class CrushedBlackMarbleItem :

    BlockItem<CrushedBlackMarbleBlock>
    {
        public override LocString DisplayNamePlural { get { return Localizer.DoStr("Crushed BlackMarble"); } }

        public override bool CanStickToWalls { get { return false; } }
    }
}