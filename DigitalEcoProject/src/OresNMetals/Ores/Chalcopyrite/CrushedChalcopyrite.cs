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
    [Ecopedia("Blocks", "Processed Rock", subPageName: "Crushed Chalcopyrite Item")]
    public partial class CrushedChalcopyriteOreRecipe : Recipe
    {
        public CrushedChalcopyriteOreRecipe()
        {
            this.Init(
                name: "CrushedChalcopyriteOre",  //noloc
                displayName: Localizer.DoStr("Crushed Chalcopyrite"),

                ingredients: new List<IngredientElement>
                {
                new IngredientElement(typeof(ChalcopyriteOreItem), 12, true),
                },

                items: new List<CraftingElement>
                {
                new CraftingElement<CrushedChalcopyriteOreItem>(2),
                new CraftingElement<CrushedGraniteItem>(1),
                }
            );

            // Register our RecipeFamily instance with the crafting system so it can be crafted.
            CraftingComponent.AddTagProduct(typeof(ArrastraObject), typeof(CrushedHematiteOreRecipe), this);
        }
    }

    [RequiresSkill(typeof(MiningSkill), 1)]
    public partial class CrushedChalcopyriteOreLv2Recipe : Recipe
    {
        public CrushedChalcopyriteOreLv2Recipe()
        {
            this.Init(
                name: "CrushedChalcopyriteOreLv2",  //noloc
                displayName: Localizer.DoStr("Crushed Chalcopyrite Lv2"),

                ingredients: new List<IngredientElement>
                {
                new IngredientElement(typeof(ChalcopyriteOreItem), 20, true),
                },

                items: new List<CraftingElement>
                {
                new CraftingElement<CrushedChalcopyriteOreItem>(4),
                new CraftingElement<CrushedGraniteItem>(1),
                }
            );

            // Register our RecipeFamily instance with the crafting system so it can be crafted.
            CraftingComponent.AddTagProduct(typeof(StampMillObject), typeof(CrushedHematiteOreLv2Recipe), this);
        }
    }

    [RequiresSkill(typeof(MiningSkill), 1)]
    public partial class CrushedChalcopyriteOreLv3Recipe : Recipe
    {
        public CrushedChalcopyriteOreLv3Recipe()
        {
            this.Init(
                name: "CrushedChalcopyriteOreLv3",  //noloc
                displayName: Localizer.DoStr("Crushed Chalcopyrite Lv3"),

                ingredients: new List<IngredientElement>
                {
                new IngredientElement(typeof(ChalcopyriteOreItem), 20, true),
                },

                items: new List<CraftingElement>
                {
                new CraftingElement<CrushedChalcopyriteOreItem>(5)
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
    public partial class CrushedChalcopyriteOreBlock :
        Block
        , IRepresentsItem
    {
        public virtual Type RepresentedItemType { get { return typeof(CrushedChalcopyriteOreItem); } }
    }

    [Serialized]
    [LocDisplayName("Crushed Chalcopyrite")]
    [LocDescription("ChalcopyriteOre rocks that have been crushed into a fine gravel.")]
    [MaxStackSize(10)]
    [Weight(26000)]
    [StartsDiscovered]
    [Ecopedia("Blocks", "Processed Rock", createAsSubPage: true)]
    [Tag("Excavatable")]
    [RequiresTool(typeof(ShovelItem))]
    public partial class CrushedChalcopyriteOreItem :

    BlockItem<CrushedChalcopyriteOreBlock>
    {
        public override LocString DisplayNamePlural { get { return Localizer.DoStr("Crushed Chalcopyrite"); } }

        public override bool CanStickToWalls { get { return false; } }
    }
}