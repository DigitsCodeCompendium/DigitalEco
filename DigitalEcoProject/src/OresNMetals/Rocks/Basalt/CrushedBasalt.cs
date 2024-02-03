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
    [Ecopedia("Blocks", "Processed Rock", subPageName: "Crushed Basalt Item")]
    public partial class CrushedBasaltRecipe : Recipe
    {
        public CrushedBasaltRecipe()
        {
            this.Init(
                name: "CrushedBasalt",  //noloc
                displayName: Localizer.DoStr("Crushed Basalt"),

                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(BasaltItem), 12, true),
                },

                items: new List<CraftingElement>
                {
                    new CraftingElement<CrushedBasaltItem>(3)
                }
            );

            // Register our RecipeFamily instance with the crafting system so it can be crafted.
            CraftingComponent.AddTagProduct(typeof(ArrastraObject), typeof(CrushedRockRecipe), this);
        }
    }

    [RequiresSkill(typeof(MiningSkill), 1)]
    public partial class CrushedBasaltLv2Recipe : Recipe
    {
        public CrushedBasaltLv2Recipe()
        {
            this.Init(
                name: "CrushedBasalt",  //noloc
                displayName: Localizer.DoStr("Crushed Basalt Lv2"),

                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(BasaltItem), 20, true),
                },

                items: new List<CraftingElement>
                {
                    new CraftingElement<CrushedBasaltItem>(5)
                }
            );

            // Register our RecipeFamily instance with the crafting system so it can be crafted.
            CraftingComponent.AddTagProduct(typeof(StampMillObject), typeof(CrushedRockLv2Recipe), this);
        }
    }

    [RequiresSkill(typeof(MiningSkill), 1)]
    public partial class CrushedBasaltLv3Recipe : Recipe
    {
        public CrushedBasaltLv3Recipe()
        {
            this.Init(
                name: "CrushedBasalt",  //noloc
                displayName: Localizer.DoStr("Crushed Basalt Lv3"),

                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(BasaltItem), 20, true),
                },

                items: new List<CraftingElement>
                {
                    new CraftingElement<CrushedBasaltItem>(5)
                }
            );

            // Register our RecipeFamily instance with the crafting system so it can be crafted.
            CraftingComponent.AddTagProduct(typeof(JawCrusherObject), typeof(CrushedRockLv3Recipe), this);
        }
    }

    [Serialized]
    [Solid, Wall, Diggable]
    [Tag(BlockTags.Diggable)]
    public partial class CrushedBasaltBlock :
        Block
        , IRepresentsItem
    {
        public virtual Type RepresentedItemType { get { return typeof(CrushedBasaltItem); } }
    }

    [Serialized]
    [LocDisplayName("Crushed Basalt")]
    [LocDescription("Basalt rocks that have been crushed into a fine gravel.")]
    [MaxStackSize(10)]
    [Weight(30000)]
    [StartsDiscovered]
    [Ecopedia("Blocks", "Processed Rock", createAsSubPage: true)]
    [Tag("CrushedRock")]
    [Tag("Excavatable")]
    [RequiresTool(typeof(ShovelItem))]
    public partial class CrushedBasaltItem :

    BlockItem<CrushedBasaltBlock>
    {
        public override LocString DisplayNamePlural { get { return Localizer.DoStr("Crushed Basalt"); } }

        public override bool CanStickToWalls { get { return false; } }
    }
}