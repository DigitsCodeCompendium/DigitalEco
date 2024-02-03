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
    [Ecopedia("Blocks", "Processed Rock", subPageName: "Crushed Shale Item")]
    public partial class CrushedShaleRecipe : Recipe
    {
        public CrushedShaleRecipe()
        {
            this.Init(
                name: "CrushedShale",  //noloc
                displayName: Localizer.DoStr("Crushed Shale"),

                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(ShaleItem), 12, true),
                },

                items: new List<CraftingElement>
                {
                    new CraftingElement<CrushedShaleItem>(3)
                }
            );

            // Register our RecipeFamily instance with the crafting system so it can be crafted.
            CraftingComponent.AddTagProduct(typeof(ArrastraObject), typeof(CrushedRockRecipe), this);
        }
    }

    [RequiresSkill(typeof(MiningSkill), 1)]
    public partial class CrushedShaleLv2Recipe : Recipe
    {
        public CrushedShaleLv2Recipe()
        {
            this.Init(
                name: "CrushedShale",  //noloc
                displayName: Localizer.DoStr("Crushed Shale Lv2"),

                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(ShaleItem), 20, true),
                },

                items: new List<CraftingElement>
                {
                    new CraftingElement<CrushedShaleItem>(5)
                }
            );

            // Register our RecipeFamily instance with the crafting system so it can be crafted.
            CraftingComponent.AddTagProduct(typeof(StampMillObject), typeof(CrushedRockLv2Recipe), this);
        }
    }

    [RequiresSkill(typeof(MiningSkill), 1)]
    public partial class CrushedShaleLv3Recipe : Recipe
    {
        public CrushedShaleLv3Recipe()
        {
            this.Init(
                name: "CrushedShale",  //noloc
                displayName: Localizer.DoStr("Crushed Shale Lv3"),

                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(ShaleItem), 20, true),
                },

                items: new List<CraftingElement>
                {
                    new CraftingElement<CrushedShaleItem>(5)
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
    public partial class CrushedShaleBlock :
        Block
        , IRepresentsItem
    {
        public virtual Type RepresentedItemType { get { return typeof(CrushedShaleItem); } }
    }

    [Serialized]
    [LocDisplayName("Crushed Shale")]
    [LocDescription("Shale rocks that have been crushed into a fine gravel.")]
    [MaxStackSize(10)]
    [Weight(24000)]
    [StartsDiscovered]
    [Ecopedia("Blocks", "Processed Rock", createAsSubPage: true)]
    [Tag("CrushedRock")]
    [Tag("Excavatable")]
    [RequiresTool(typeof(ShovelItem))]
    public partial class CrushedShaleItem :

    BlockItem<CrushedShaleBlock>
    {
        public override LocString DisplayNamePlural { get { return Localizer.DoStr("Crushed Shale"); } }

        public override bool CanStickToWalls { get { return false; } }
    }
}