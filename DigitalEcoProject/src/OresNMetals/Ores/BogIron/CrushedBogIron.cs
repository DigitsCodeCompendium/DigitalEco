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
    [Ecopedia("Blocks", "Processed Rock", subPageName: "Crushed BogIron Item")]
    public partial class CrushedBogIronOreRecipe : Recipe
    {
        public CrushedBogIronOreRecipe()
        {
            this.Init(
                name: "CrushedBogIronOre",  //noloc
                displayName: Localizer.DoStr("Crushed Bog Iron"),

                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(BogIronOreItem), 12, true),
                },

                items: new List<CraftingElement>
                {
                    new CraftingElement<CrushedBogIronOreItem>(2),
                    new CraftingElement<ClayItem>(1),
                }
            );

            // Register our RecipeFamily instance with the crafting system so it can be crafted.
            CraftingComponent.AddTagProduct(typeof(ArrastraObject), typeof(CrushedHematiteOreRecipe), this);
        }
    }

    [RequiresSkill(typeof(MiningSkill), 1)]
    public partial class CrushedBogIronOreLv2Recipe : Recipe
    {
        public CrushedBogIronOreLv2Recipe()
        {
            this.Init(
                name: "CrushedBogIronOreLv2",  //noloc
                displayName: Localizer.DoStr("Crushed Bog Iron Lv2"),

                ingredients: new List<IngredientElement>
                {
                new IngredientElement(typeof(BogIronOreItem), 20, true),
                },

                items: new List<CraftingElement>
                {
                new CraftingElement<CrushedBogIronOreItem>(4),
                new CraftingElement<ClayItem>(1),
                }
            );

            // Register our RecipeFamily instance with the crafting system so it can be crafted.
            CraftingComponent.AddTagProduct(typeof(StampMillObject), typeof(CrushedHematiteOreLv2Recipe), this);
        }
    }

    [RequiresSkill(typeof(MiningSkill), 1)]
    public partial class CrushedBogIronOreLv3Recipe : Recipe
    {
        public CrushedBogIronOreLv3Recipe()
        {
            this.Init(
                name: "CrushedBogIronOreLv3",  //noloc
                displayName: Localizer.DoStr("Crushed Bog Iron Lv3"),

                ingredients: new List<IngredientElement>
                {
                new IngredientElement(typeof(BogIronOreItem), 20, true),
                },

                items: new List<CraftingElement>
                {
                new CraftingElement<CrushedBogIronOreItem>(5),
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
    public partial class CrushedBogIronOreBlock :
        Block
        , IRepresentsItem
    {
        public virtual Type RepresentedItemType { get { return typeof(CrushedBogIronOreItem); } }
    }

    [Serialized]
    [LocDisplayName("Crushed Bog Iron")]
    [LocDescription("Bog iron ore rocks that have been crushed into a fine gravel.")]
    [MaxStackSize(10)]
    [Weight(26000)]
    [StartsDiscovered]
    [Ecopedia("Blocks", "Processed Rock", createAsSubPage: true)]
    [Tag("Excavatable")]
    [RequiresTool(typeof(ShovelItem))]
    public partial class CrushedBogIronOreItem :

    BlockItem<CrushedBogIronOreBlock>
    {
        public override LocString DisplayNamePlural { get { return Localizer.DoStr("Crushed Bog Iron"); } }

        public override bool CanStickToWalls { get { return false; } }
    }
}