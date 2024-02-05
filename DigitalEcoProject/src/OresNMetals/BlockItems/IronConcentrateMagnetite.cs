using System;
using System.Collections.Generic;
using System.ComponentModel;
using Eco.Gameplay.Components;
using Eco.Shared.Localization;
using Eco.Gameplay.Items.Recipes;

namespace Eco.Mods.TechTree
{
    /*
    [RequiresSkill(typeof(MiningSkill), 1)]
    [Ecopedia("Blocks", "Processed Rock", subPageName: "Iron Concentrate Item")]
    public partial class IronConcentrateMagnetiteRecipe : Recipe
    {
        public IronConcentrateMagnetiteRecipe()
        {
            this.Init(
                name: "IronConcentrateMagnetite",  //noloc
                displayName: Localizer.DoStr("Concentrate Magnetite"),

                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(CrushedMagnetiteOreItem), 5, typeof(MiningSkill)),
                },

                items: new List<CraftingElement>
                {
                    new CraftingElement<IronConcentrateItem>(),
                    new CraftingElement<WetTailingsItem>(typeof(MiningSkill), 2),
                }
            );

            CraftingComponent.AddTagProduct(typeof(RockerBoxObject), typeof(IronConcentrateHematiteRecipe), this);
        }
    }

    public partial class IronConcentrateMagnetiteLv2Recipe : Recipe
    {
        public IronConcentrateMagnetiteLv2Recipe()
        {
            this.Init(
                name: "IronConcentrateMagnetiteLv2",  //noloc
                displayName: Localizer.DoStr("Concentrate Magnetite Lv2"),

                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(CrushedMagnetiteOreItem), 5, typeof(MiningSkill)),
                },

                items: new List<CraftingElement>
                {
                    new CraftingElement<IronConcentrateItem>(),
                    new CraftingElement<WetTailingsItem>(typeof(MiningSkill), 2),
                }
            );

            CraftingComponent.AddTagProduct(typeof(FrothFloatationCellObject), typeof(IronConcentrateHematiteLv2Recipe), this);
        }
    }
    */
    public partial class IronDryConcentrateMagnetiteRecipe : Recipe
    {
        public IronDryConcentrateMagnetiteRecipe()
        {
            this.Init(
                name: "IronDryConcentrateMagnetite",  //noloc
                displayName: Localizer.DoStr("Dry Concentrate Magnetite"),

                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(CrushedMagnetiteOreItem), 8, typeof(MiningSkill)),
                },

                items: new List<CraftingElement>
                {
                    new CraftingElement<IronConcentrateItem>(4),
                    new CraftingElement<TailingsItem>(typeof(MiningSkill), 1),
                }
            );

            CraftingComponent.AddTagProduct(typeof(ScreeningMachineObject), typeof(IronDryConcentrateHematiteRecipe), this);
        }
    }

    public partial class IronDryConcentrateMagnetiteLv2Recipe : Recipe
    {
        public IronDryConcentrateMagnetiteLv2Recipe()
        {
            this.Init(
                name: "IronDryConcentrateMagnetiteLv2",  //noloc
                displayName: Localizer.DoStr("Dry Concentrate Magnetite Lv2"),

                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(CrushedMagnetiteOreItem), 10, typeof(MiningSkill)),
                },

                items: new List<CraftingElement>
                {
                    new CraftingElement<IronConcentrateItem>(6),
                    new CraftingElement<TailingsItem>(typeof(MiningSkill), 1),
                }
            );

            CraftingComponent.AddTagProduct(typeof(SensorBasedBeltSorterObject), typeof(IronDryConcentrateHematiteLv2Recipe), this);
        }
    }
}
