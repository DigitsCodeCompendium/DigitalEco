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
    public partial class IronConcentrateIlmeniteRecipe : Recipe
    {
        public IronConcentrateIlmeniteRecipe()
        {
            this.Init(
                name: "IronConcentrateIlmenite",  //noloc
                displayName: Localizer.DoStr("Concentrate Ilmenite"),

                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(CrushedIlmeniteOreItem), 20, typeof(MiningSkill)),
                },

                items: new List<CraftingElement>
                {
                    new CraftingElement<IronConcentrateItem>(),
                    new CraftingElement<WetTailingsItem>(typeof(MiningSkill), 4),
                }
            );

            CraftingComponent.AddTagProduct(typeof(RockerBoxObject), typeof(IronConcentrateHematiteRecipe), this);
        }
    }

    public partial class IronConcentrateIlmeniteLv2Recipe : Recipe
    {
        public IronConcentrateIlmeniteLv2Recipe()
        {
            this.Init(
                name: "IronConcentrateIlmeniteLv2",  //noloc
                displayName: Localizer.DoStr("Concentrate Ilmenite Lv2"),

                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(CrushedIlmeniteOreItem), 10, typeof(MiningSkill)),
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

    public partial class IronDryConcentrateIlmeniteRecipe : Recipe
    {
        public IronDryConcentrateIlmeniteRecipe()
        {
            this.Init(
                name: "IronDryConcentrateIlmenite",  //noloc
                displayName: Localizer.DoStr("Dry Concentrate Ilmenite"),

                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(CrushedIlmeniteOreItem), 24, typeof(MiningSkill)),
                },

                items: new List<CraftingElement>
                {
                    new CraftingElement<IronConcentrateItem>(2),
                    new CraftingElement<TailingsItem>(typeof(MiningSkill), 5),
                }
            );

            CraftingComponent.AddTagProduct(typeof(ScreeningMachineObject), typeof(IronDryConcentrateHematiteRecipe), this);
        }
    }

    public partial class IronDryConcentrateIlmeniteLv2Recipe : Recipe
    {
        public IronDryConcentrateIlmeniteLv2Recipe()
        {
            this.Init(
                name: "IronDryConcentrateIlmeniteLv2",  //noloc
                displayName: Localizer.DoStr("Dry Concentrate Ilmenite Lv2"),

                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(CrushedIlmeniteOreItem), 10, typeof(MiningSkill)),
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
}
