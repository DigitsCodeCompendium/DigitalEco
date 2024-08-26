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
    /*
    [Category("Hidden")]
    [RequiresSkill(typeof(MiningSkill), 1)]
    [Ecopedia("Blocks", "Processed Rock", subPageName: "Crushed Pitchblende Item")]
    public partial class CrushedPitchblendeOreRecipe : Recipe
    {
        public CrushedPitchblendeOreRecipe()
        {
            this.Init(
                name: "CrushedPitchblendeOre",  //noloc
                displayName: Localizer.DoStr("Crushed Pitchblende"),

                ingredients: new List<IngredientElement>
                {
                new IngredientElement(typeof(PitchblendeOreItem), 12, true),
                },

                items: new List<CraftingElement>
                {
                new CraftingElement<CrushedPitchblendeOreItem>(3)
                }
            );

            // Register our RecipeFamily instance with the crafting system so it can be crafted.
            CraftingComponent.AddTagProduct(typeof(ArrastraObject), typeof(CrushedHematiteOreRecipe), this);
        }
    }
    [Category("Hidden")]
    [RequiresSkill(typeof(MiningSkill), 1)]
    public partial class CrushedPitchblendeOreLv2Recipe : Recipe
    {
        public CrushedPitchblendeOreLv2Recipe()
        {
            this.Init(
                name: "CrushedPitchblendeOreLv2",  //noloc
                displayName: Localizer.DoStr("Crushed Pitchblende Lv2"),

                ingredients: new List<IngredientElement>
                {
                new IngredientElement(typeof(PitchblendeOreItem), 20, true),
                },

                items: new List<CraftingElement>
                {
                new CraftingElement<CrushedPitchblendeOreItem>(5)
                }
            );

            // Register our RecipeFamily instance with the crafting system so it can be crafted.
            CraftingComponent.AddTagProduct(typeof(StampMillObject), typeof(CrushedHematiteOreLv2Recipe), this);
        }
    }
    [Category("Hidden")]
    [RequiresSkill(typeof(MiningSkill), 1)]
    public partial class CrushedPitchblendeOreLv3Recipe : Recipe
    {
        public CrushedPitchblendeOreLv3Recipe()
        {
            this.Init(
                name: "CrushedPitchblendeOreLv3",  //noloc
                displayName: Localizer.DoStr("Crushed Pitchblende Lv3"),

                ingredients: new List<IngredientElement>
                {
                new IngredientElement(typeof(PitchblendeOreItem), 20, true),
                },

                items: new List<CraftingElement>
                {
                new CraftingElement<CrushedPitchblendeOreItem>(5)
                }
            );

            // Register our RecipeFamily instance with the crafting system so it can be crafted.
            CraftingComponent.AddTagProduct(typeof(JawCrusherObject), typeof(CrushedHematiteOreLv3Recipe), this);
        }
    }*/

    [Serialized]
    [Solid, Wall, Diggable]
    [RequiresSkill(typeof(MiningSkill), 1)]
    [Tag(BlockTags.Diggable)]
    public partial class CrushedPitchblendeOreBlock :
        Block
        , IRepresentsItem
    {
        public virtual Type RepresentedItemType { get { return typeof(CrushedPitchblendeOreItem); } }
    }

    [Serialized]
    [LocDisplayName("Crushed PitchblendeOre")]
    [LocDescription("PitchblendeOre rocks that have been crushed into a fine gravel.")]
    [MaxStackSize(10)]
    [Weight(26000)]
    [StartsDiscovered]
    [Category("Hidden")]
    [Ecopedia("Blocks", "Processed Rock", createAsSubPage: true)]
    [Tag("Excavatable")]
    [RequiresTool(typeof(ShovelItem))]
    public partial class CrushedPitchblendeOreItem :

    BlockItem<CrushedPitchblendeOreBlock>
    {
        public override LocString DisplayNamePlural { get { return Localizer.DoStr("Crushed PitchblendeOre"); } }

        public override bool CanStickToWalls { get { return false; } }
    }
}