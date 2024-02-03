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
    [Ecopedia("Blocks", "Processed Rock", subPageName: "Crushed Limestone Item")]
    public partial class CrushedLimestoneRecipe : Recipe
    {
        public CrushedLimestoneRecipe()
        {
            this.Init(
                name: "CrushedLimestone",  //noloc
                displayName: Localizer.DoStr("Crushed Limestone"),

                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(LimestoneItem), 12, true),
                },

                items: new List<CraftingElement>
                {
                    new CraftingElement<CrushedLimestoneItem>(3)
                }
            );

            // Register our RecipeFamily instance with the crafting system so it can be crafted.
            CraftingComponent.AddTagProduct(typeof(ArrastraObject), typeof(CrushedRockRecipe), this);
        }
    }

    [RequiresSkill(typeof(MiningSkill), 1)]
    public partial class CrushedLimestoneLv2Recipe : Recipe
    {
        public CrushedLimestoneLv2Recipe()
        {
            this.Init(
                name: "CrushedLimestone",  //noloc
                displayName: Localizer.DoStr("Crushed Limestone Lv2"),

                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(LimestoneItem), 20, true),
                },

                items: new List<CraftingElement>
                {
                    new CraftingElement<CrushedLimestoneItem>(5)
                }
            );

            // Register our RecipeFamily instance with the crafting system so it can be crafted.
            CraftingComponent.AddTagProduct(typeof(StampMillObject), typeof(CrushedRockLv2Recipe), this);
        }
    }

    [RequiresSkill(typeof(MiningSkill), 1)]
    public partial class CrushedLimestoneLv3Recipe : Recipe
    {
        public CrushedLimestoneLv3Recipe()
        {
            this.Init(
                name: "CrushedLimestone",  //noloc
                displayName: Localizer.DoStr("Crushed Limestone Lv3"),

                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(LimestoneItem), 20, true),
                },

                items: new List<CraftingElement>
                {
                    new CraftingElement<CrushedLimestoneItem>(5)
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
    public partial class CrushedLimestoneBlock :
        Block
        , IRepresentsItem
    {
        public virtual Type RepresentedItemType { get { return typeof(CrushedLimestoneItem); } }
    }

    [Serialized]
    [LocDisplayName("Crushed Limestone")]
    [LocDescription("Limestone rocks that have been crushed into a fine gravel.")]
    [MaxStackSize(10)]
    [Weight(26000)]
    [StartsDiscovered]
    [Ecopedia("Blocks", "Processed Rock", createAsSubPage: true)]
    [Tag("CrushedRock")]
    [Tag("Excavatable")]
    [RequiresTool(typeof(ShovelItem))]
    public partial class CrushedLimestoneItem :

    BlockItem<CrushedLimestoneBlock>
    {
        public override LocString DisplayNamePlural { get { return Localizer.DoStr("Crushed Limestone"); } }

        public override bool CanStickToWalls { get { return false; } }
    }
}