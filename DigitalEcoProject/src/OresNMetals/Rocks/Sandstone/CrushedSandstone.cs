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
    [Ecopedia("Blocks", "Processed Rock", subPageName: "Crushed Sandstone Item")]
    public partial class CrushedSandstoneRecipe : Recipe
    {
        public CrushedSandstoneRecipe()
        {
            this.Init(
                name: "CrushedSandstone",  //noloc
                displayName: Localizer.DoStr("Crushed Sandstone"),

                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(SandstoneItem), 12, true),
                },

                items: new List<CraftingElement>
                {
                    new CraftingElement<CrushedSandstoneItem>(3)
                }
            );

            // Register our RecipeFamily instance with the crafting system so it can be crafted.
            CraftingComponent.AddTagProduct(typeof(ArrastraObject), typeof(CrushedRockRecipe), this);
        }
    }

    [RequiresSkill(typeof(MiningSkill), 1)]
    public partial class CrushedSandstoneLv2Recipe : Recipe
    {
        public CrushedSandstoneLv2Recipe()
        {
            this.Init(
                name: "CrushedSandstone",  //noloc
                displayName: Localizer.DoStr("Crushed Sandstone Lv2"),

                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(SandstoneItem), 20, true),
                },

                items: new List<CraftingElement>
                {
                    new CraftingElement<CrushedSandstoneItem>(5)
                }
            );

            // Register our RecipeFamily instance with the crafting system so it can be crafted.
            CraftingComponent.AddTagProduct(typeof(StampMillObject), typeof(CrushedRockLv2Recipe), this);
        }
    }

    [RequiresSkill(typeof(MiningSkill), 1)]
    public partial class CrushedSandstoneLv3Recipe : Recipe
    {
        public CrushedSandstoneLv3Recipe()
        {
            this.Init(
                name: "CrushedSandstone",  //noloc
                displayName: Localizer.DoStr("Crushed Sandstone Lv3"),

                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(SandstoneItem), 20, true),
                },

                items: new List<CraftingElement>
                {
                    new CraftingElement<CrushedSandstoneItem>(5)
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
    public partial class CrushedSandstoneBlock :
        Block
        , IRepresentsItem
    {
        public virtual Type RepresentedItemType { get { return typeof(CrushedSandstoneItem); } }
    }

    [Serialized]
    [LocDisplayName("Crushed Sandstone")]
    [LocDescription("Sandstone rocks that have been crushed into a fine gravel.")]
    [MaxStackSize(10)]
    [Weight(24000)]
    [StartsDiscovered]
    [Ecopedia("Blocks", "Processed Rock", createAsSubPage: true)]
    [Tag("CrushedRock")]
    [Tag("Silica")]
    [Tag("Excavatable")]
    [RequiresTool(typeof(ShovelItem))]
    public partial class CrushedSandstoneItem :

    BlockItem<CrushedSandstoneBlock>
    {
        public override LocString DisplayNamePlural { get { return Localizer.DoStr("Crushed Sandstone"); } }

        public override bool CanStickToWalls { get { return false; } }
    }
}