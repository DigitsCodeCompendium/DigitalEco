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
    [Ecopedia("Blocks", "Processed Rock", subPageName: "Crushed Ilmenite Item")]
    public partial class CrushedIlmeniteOreRecipe : Recipe
    {
        public CrushedIlmeniteOreRecipe()
        {
            this.Init(
                name: "CrushedIlmeniteOre",  //noloc
                displayName: Localizer.DoStr("Crushed Ilmenite"),

                ingredients: new List<IngredientElement>
                {
                new IngredientElement(typeof(IlmeniteOreItem), 12, true),
                },

                items: new List<CraftingElement>
                {
                new CraftingElement<CrushedIlmeniteOreItem>(2),
                new CraftingElement<CrushedBlueschistItem>(1),
                }
            );

            // Register our RecipeFamily instance with the crafting system so it can be crafted.
            CraftingComponent.AddTagProduct(typeof(ArrastraObject), typeof(CrushedHematiteOreRecipe), this);
        }
    }

    [RequiresSkill(typeof(MiningSkill), 1)]
    public partial class CrushedIlmeniteOreLv2Recipe : Recipe
    {
        public CrushedIlmeniteOreLv2Recipe()
        {
            this.Init(
                name: "CrushedIlmeniteOre",  //noloc
                displayName: Localizer.DoStr("Crushed Ilmenite Lv2"),

                ingredients: new List<IngredientElement>
                {
                new IngredientElement(typeof(IlmeniteOreItem), 20, true),
                },

                items: new List<CraftingElement>
                {
                new CraftingElement<CrushedIlmeniteOreItem>(4),
                new CraftingElement<CrushedBlueschistItem>(1),
                }
            );

            // Register our RecipeFamily instance with the crafting system so it can be crafted.
            CraftingComponent.AddTagProduct(typeof(StampMillObject), typeof(CrushedHematiteOreLv2Recipe), this);
        }
    }

    [RequiresSkill(typeof(MiningSkill), 1)]
    public partial class CrushedIlmeniteOreLv3Recipe : Recipe
    {
        public CrushedIlmeniteOreLv3Recipe()
        {
            this.Init(
                name: "CrushedIlmeniteOre",  //noloc
                displayName: Localizer.DoStr("Crushed Ilmenite Lv3"),

                ingredients: new List<IngredientElement>
                {
                new IngredientElement(typeof(IlmeniteOreItem), 20, true),
                },

                items: new List<CraftingElement>
                {
                new CraftingElement<CrushedIlmeniteOreItem>(5)
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
    public partial class CrushedIlmeniteOreBlock :
        Block
        , IRepresentsItem
    {
        public virtual Type RepresentedItemType { get { return typeof(CrushedIlmeniteOreItem); } }
    }

    [Serialized]
    [LocDisplayName("Crushed Ilmenite")]
    [LocDescription("Ilmenite rocks that have been crushed into a fine gravel.")]
    [MaxStackSize(10)]
    [Weight(26000)]
    [StartsDiscovered]
    [Ecopedia("Blocks", "Processed Rock", createAsSubPage: true)]
    [Tag("Excavatable")]
    [RequiresTool(typeof(ShovelItem))]
    public partial class CrushedIlmeniteOreItem :

    BlockItem<CrushedIlmeniteOreBlock>
    {
        public override LocString DisplayNamePlural { get { return Localizer.DoStr("Crushed Ilmenite"); } }

        public override bool CanStickToWalls { get { return false; } }
    }
}