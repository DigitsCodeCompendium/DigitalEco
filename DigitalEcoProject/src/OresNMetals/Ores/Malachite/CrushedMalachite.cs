using System;
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
    [Ecopedia("Blocks", "Processed Rock", subPageName: "Crushed Malachite Item")]
    public partial class CrushedMalachiteOreRecipe : Recipe
    {
        public CrushedMalachiteOreRecipe()
        {
            this.Init(
                name: "CrushedMalachiteOre",  //noloc
                displayName: Localizer.DoStr("Crushed Malachite"),

                ingredients: new List<IngredientElement>
                {
                new IngredientElement(typeof(MalachiteOreItem), 12, true),
                },

                items: new List<CraftingElement>
                {
                new CraftingElement<CrushedMalachiteOreItem>(2),
                new CraftingElement<CrushedMixedRockItem>(1),
                }
            );

            // Register our RecipeFamily instance with the crafting system so it can be crafted.
            CraftingComponent.AddTagProduct(typeof(ArrastraObject), typeof(CrushedHematiteOreRecipe), this);
        }
    }

    [RequiresSkill(typeof(MiningSkill), 1)]
    public partial class CrushedMalachiteOreLv2Recipe : Recipe
    {
        public CrushedMalachiteOreLv2Recipe()
        {
            this.Init(
                name: "CrushedMalachiteOreLv2",  //noloc
                displayName: Localizer.DoStr("Crushed Malachite Lv2"),

                ingredients: new List<IngredientElement>
                {
                new IngredientElement(typeof(MalachiteOreItem), 20, true),
                },

                items: new List<CraftingElement>
                {
                new CraftingElement<CrushedMalachiteOreItem>(4),
                new CraftingElement<CrushedMixedRockItem>(1),
                }
            );

            // Register our RecipeFamily instance with the crafting system so it can be crafted.
            CraftingComponent.AddTagProduct(typeof(StampMillObject), typeof(CrushedHematiteOreLv2Recipe), this);
        }
    }

    [RequiresSkill(typeof(MiningSkill), 1)]
    public partial class CrushedMalachiteOreLv3Recipe : Recipe
    {
        public CrushedMalachiteOreLv3Recipe()
        {
            this.Init(
                name: "CrushedMalachiteOreLv3",  //noloc
                displayName: Localizer.DoStr("Crushed Malachite Lv3"),

                ingredients: new List<IngredientElement>
                {
                new IngredientElement(typeof(MalachiteOreItem), 20, true),
                },

                items: new List<CraftingElement>
                {
                new CraftingElement<CrushedMalachiteOreItem>(5)
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
    public partial class CrushedMalachiteOreBlock :
        Block
        , IRepresentsItem
    {
        public virtual Type RepresentedItemType { get { return typeof(CrushedMalachiteOreItem); } }
    }

    [Serialized]
    [LocDisplayName("Crushed MalachiteOre")]
    [LocDescription("MalachiteOre rocks that have been crushed into a fine gravel.")]
    [MaxStackSize(10)]
    [Weight(26000)]
    [StartsDiscovered]
    [Ecopedia("Blocks", "Processed Rock", createAsSubPage: true)]
    [Tag("Excavatable")]
    [RequiresTool(typeof(ShovelItem))]
    public partial class CrushedMalachiteOreItem :

    BlockItem<CrushedMalachiteOreBlock>
    {
        public override LocString DisplayNamePlural { get { return Localizer.DoStr("Crushed MalachiteOre"); } }

        public override bool CanStickToWalls { get { return false; } }
    }
}