using System;
using System.Collections.Generic;
using System.ComponentModel;
using Eco.Gameplay.Components;
using Eco.Gameplay.Skills;
using Eco.Core.Items;
using Eco.Shared.Localization;
using Eco.Gameplay.Items.Recipes;

namespace Eco.Mods.TechTree
{
    [RequiresSkill(typeof(MiningSkill), 1)]
    [Ecopedia("Blocks", "Processed Rock", subPageName: "Iron Concentrate Item")]
    public partial class IronConcentrateBogIronRecipe : Recipe
    {
        public IronConcentrateBogIronRecipe()
        {
            this.Init(
                name: "IronConcentrateBogIron",  //noloc
                displayName: Localizer.DoStr("Concentrate Bog iron"),

                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(CrushedBogIronOreItem), 5, typeof(MiningSkill)),
                },

                items: new List<CraftingElement>
                {
                    new CraftingElement<IronConcentrateItem>(1),
                    new CraftingElement<WetTailingsItem>(typeof(MiningSkill), 2),
                }
            );

            CraftingComponent.AddTagProduct(typeof(RockerBoxObject), typeof(IronConcentrateHematiteRecipe), this);
        }
    }

    public partial class IronConcentrateBogIronLv2Recipe : Recipe
    {
        public IronConcentrateBogIronLv2Recipe()
        {
            this.Init(
                name: "IronConcentrateBogIronLv2",  //noloc
                displayName: Localizer.DoStr("Concentrate Bog iron Lv2"),

                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(CrushedBogIronOreItem), 5, typeof(MiningSkill)),
                },

                items: new List<CraftingElement>
                {
                    new CraftingElement<IronConcentrateItem>(2),
                    new CraftingElement<WetTailingsItem>(typeof(MiningSkill), 1),
                }
            );

            CraftingComponent.AddTagProduct(typeof(FrothFloatationCellObject), typeof(IronConcentrateHematiteLv2Recipe), this);
        }
    }

    /*
    public partial class IronDryConcentrateBogIronRecipe : Recipe
    {
        public IronDryConcentrateBogIronRecipe()
        {
            this.Init(
                name: "IronDryConcentrateBogIron",  //noloc
                displayName: Localizer.DoStr("Dry Concentrate Bog iron"),

                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(CrushedBogIronOreItem), 5, typeof(MiningSkill)),
                },

                items: new List<CraftingElement>
                {
                    new CraftingElement<IronConcentrateItem>(),
                    new CraftingElement<TailingsItem>(typeof(MiningSkill), 2),
                }
            );

            CraftingComponent.AddTagProduct(typeof(ScreeningMachineObject), typeof(IronDryConcentrateHematiteRecipe), this);
        }
    }

    public partial class IronDryConcentrateBogIronLv2Recipe : Recipe
    {
        public IronDryConcentrateBogIronLv2Recipe()
        {
            this.Init(
                name: "IronDryConcentrateBogIronLv2",  //noloc
                displayName: Localizer.DoStr("Dry Concentrate Bog iron Lv2"),

                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(CrushedBogIronOreItem), 5, typeof(MiningSkill)),
                },

                items: new List<CraftingElement>
                {
                    new CraftingElement<IronConcentrateItem>(),
                    new CraftingElement<TailingsItem>(typeof(MiningSkill), 2),
                }
            );

            CraftingComponent.AddTagProduct(typeof(SensorBasedBeltSorterObject), typeof(IronDryConcentrateHematiteLv2Recipe), this);
        }
    }
    */
}
