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
    [Ecopedia("Blocks", "Processed Rock", subPageName: "Crushed Granite Item")]
    public partial class CrushedGraniteRecipe : Recipe
    {
        public CrushedGraniteRecipe()
        {
            this.Init(
                name: "CrushedGranite",  //noloc
                displayName: Localizer.DoStr("Crushed Granite"),

                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(GraniteItem), 12, true),
                },

                items: new List<CraftingElement>
                {
                    new CraftingElement<CrushedGraniteItem>(3)
                }
            );

            // Register our RecipeFamily instance with the crafting system so it can be crafted.
            CraftingComponent.AddTagProduct(typeof(ArrastraObject), typeof(CrushedRockRecipe), this);
        }
    }

    [RequiresSkill(typeof(MiningSkill), 1)]
    public partial class CrushedGraniteLv2Recipe : Recipe
    {
        public CrushedGraniteLv2Recipe()
        {
            this.Init(
                name: "CrushedGranite",  //noloc
                displayName: Localizer.DoStr("Crushed Granite Lv2"),

                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(GraniteItem), 20, true),
                },

                items: new List<CraftingElement>
                {
                    new CraftingElement<CrushedGraniteItem>(5)
                }
            );

            // Register our RecipeFamily instance with the crafting system so it can be crafted.
            CraftingComponent.AddTagProduct(typeof(StampMillObject), typeof(CrushedRockLv2Recipe), this);
        }
    }

    [RequiresSkill(typeof(MiningSkill), 1)]
    public partial class CrushedGraniteLv3Recipe : Recipe
    {
        public CrushedGraniteLv3Recipe()
        {
            this.Init(
                name: "CrushedGranite",  //noloc
                displayName: Localizer.DoStr("Crushed Granite Lv3"),

                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(GraniteItem), 20, true),
                },

                items: new List<CraftingElement>
                {
                    new CraftingElement<CrushedGraniteItem>(5)
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
    public partial class CrushedGraniteBlock :
        Block
        , IRepresentsItem
    {
        public virtual Type RepresentedItemType { get { return typeof(CrushedGraniteItem); } }
    }

    [Serialized]
    [LocDisplayName("Crushed Granite")]
    [LocDescription("Granite rocks that have been crushed into a fine gravel.")]
    [MaxStackSize(10)]
    [Weight(26000)]
    [StartsDiscovered]
    [Ecopedia("Blocks", "Processed Rock", createAsSubPage: true)]
    [Tag("CrushedRock")]
    [Tag("Silica")]
    [Tag("Excavatable")]
    [RequiresTool(typeof(ShovelItem))]
    public partial class CrushedGraniteItem :

    BlockItem<CrushedGraniteBlock>
    {
        public override LocString DisplayNamePlural { get { return Localizer.DoStr("Crushed Granite"); } }

        public override bool CanStickToWalls { get { return false; } }
    }
}