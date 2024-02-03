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
    [Ecopedia("Blocks", "Processed Rock", subPageName: "Crushed Marble Item")]
    public partial class CrushedMarbleRecipe : Recipe
    {
        public CrushedMarbleRecipe()
        {
            this.Init(
                name: "CrushedMarble",  //noloc
                displayName: Localizer.DoStr("Crushed Marble"),

                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(MarbleItem), 12, true),
                },

                items: new List<CraftingElement>
                {
                    new CraftingElement<CrushedMarbleItem>(3)
                }
            );

            // Register our RecipeFamily instance with the crafting system so it can be crafted.
            CraftingComponent.AddTagProduct(typeof(ArrastraObject), typeof(CrushedRockRecipe), this);
        }
    }

    [RequiresSkill(typeof(MiningSkill), 1)]
    public partial class CrushedMarbleLv2Recipe : Recipe
    {
        public CrushedMarbleLv2Recipe()
        {
            this.Init(
                name: "CrushedMarble",  //noloc
                displayName: Localizer.DoStr("Crushed Marble Lv2"),

                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(MarbleItem), 20, true),
                },

                items: new List<CraftingElement>
                {
                    new CraftingElement<CrushedMarbleItem>(5)
                }
            );

            // Register our RecipeFamily instance with the crafting system so it can be crafted.
            CraftingComponent.AddTagProduct(typeof(StampMillObject), typeof(CrushedRockLv2Recipe), this);
        }
    }

    [RequiresSkill(typeof(MiningSkill), 1)]
    public partial class CrushedMarbleLv3Recipe : Recipe
    {
        public CrushedMarbleLv3Recipe()
        {
            this.Init(
                name: "CrushedMarble",  //noloc
                displayName: Localizer.DoStr("Crushed Marble Lv3"),

                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(MarbleItem), 20, true),
                },

                items: new List<CraftingElement>
                {
                    new CraftingElement<CrushedMarbleItem>(5)
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
    public partial class CrushedMarbleBlock :
        Block
        , IRepresentsItem
    {
        public virtual Type RepresentedItemType { get { return typeof(CrushedMarbleItem); } }
    }

    [Serialized]
    [LocDisplayName("Crushed Marble")]
    [LocDescription("Marble rocks that have been crushed into a fine gravel.")]
    [MaxStackSize(10)]
    [Weight(26000)]
    [StartsDiscovered]
    [Ecopedia("Blocks", "Processed Rock", createAsSubPage: true)]
    [Tag("CrushedRock")]
    [Tag("Excavatable")]
    [RequiresTool(typeof(ShovelItem))]
    public partial class CrushedMarbleItem :

    BlockItem<CrushedMarbleBlock>
    {
        public override LocString DisplayNamePlural { get { return Localizer.DoStr("Crushed Marble"); } }

        public override bool CanStickToWalls { get { return false; } }
    }
}