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
    [Ecopedia("Blocks", "Processed Rock", subPageName: "Crushed Greenschist Item")]
    public partial class CrushedGreenschistRecipe : Recipe
    {
        public CrushedGreenschistRecipe()
        {
            this.Init(
                name: "CrushedGreenschist",  //noloc
                displayName: Localizer.DoStr("Crushed Greenschist"),

                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(GreenschistItem), 12, true),
                },

                items: new List<CraftingElement>
                {
                    new CraftingElement<CrushedGreenschistItem>(3)
                }
            );

            // Register our RecipeFamily instance with the crafting system so it can be crafted.
            CraftingComponent.AddTagProduct(typeof(ArrastraObject), typeof(CrushedRockRecipe), this);
        }
    }

    [RequiresSkill(typeof(MiningSkill), 1)]
    public partial class CrushedGreenschistLv2Recipe : Recipe
    {
        public CrushedGreenschistLv2Recipe()
        {
            this.Init(
                name: "CrushedGreenschist",  //noloc
                displayName: Localizer.DoStr("Crushed Greenschist Lv2"),

                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(GreenschistItem), 20, true),
                },

                items: new List<CraftingElement>
                {
                    new CraftingElement<CrushedGreenschistItem>(5)
                }
            );

            // Register our RecipeFamily instance with the crafting system so it can be crafted.
            CraftingComponent.AddTagProduct(typeof(StampMillObject), typeof(CrushedRockLv2Recipe), this);
        }
    }

    [RequiresSkill(typeof(MiningSkill), 1)]
    public partial class CrushedGreenschistLv3Recipe : Recipe
    {
        public CrushedGreenschistLv3Recipe()
        {
            this.Init(
                name: "CrushedGreenschist",  //noloc
                displayName: Localizer.DoStr("Crushed Greenschist Lv3"),

                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(GreenschistItem), 20, true),
                },

                items: new List<CraftingElement>
                {
                    new CraftingElement<CrushedGreenschistItem>(5)
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
    public partial class CrushedGreenschistBlock :
        Block
        , IRepresentsItem
    {
        public virtual Type RepresentedItemType { get { return typeof(CrushedGreenschistItem); } }
    }

    [Serialized]
    [LocDisplayName("Crushed Greenschist")]
    [LocDescription("Greenschist rocks that have been crushed into a fine gravel.")]
    [MaxStackSize(10)]
    [Weight(26000)]
    [StartsDiscovered]
    [Ecopedia("Blocks", "Processed Rock", createAsSubPage: true)]
    [Tag("CrushedRock")]
    [Tag("Excavatable")]
    [RequiresTool(typeof(ShovelItem))]
    public partial class CrushedGreenschistItem :

    BlockItem<CrushedGreenschistBlock>
    {
        public override LocString DisplayNamePlural { get { return Localizer.DoStr("Crushed Greenschist"); } }

        public override bool CanStickToWalls { get { return false; } }
    }
}