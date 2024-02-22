using System;
using System.Collections.Generic;
using System.ComponentModel;
using Eco.Mods.TechTree;
using Eco.Gameplay.Blocks;
using Eco.Gameplay.Components;
using Eco.Gameplay.DynamicValues;
using Eco.Gameplay.Items;
using Eco.Gameplay.Objects;
using Eco.Gameplay.Players;
using Eco.Gameplay.Skills;
using Eco.Gameplay.Settlements;
using Eco.Gameplay.Systems;
using Eco.Gameplay.Systems.TextLinks;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;
using Eco.Shared.Utils;
using Eco.Core.Items;
using Eco.World;
using Eco.World.Blocks;
using Eco.Gameplay.Pipes;
using Eco.Core.Controller;
using Eco.Gameplay.Items.Recipes;


namespace Digits.Maintenance
{
    [RequiresSkill(typeof(CarpentrySkill), 1)]
    [ForceCreateView]
    [Ecopedia("Items", "Products", subPageName: "Steel Smiths Tools")]
    public partial class SteelSmithsToolsRecipe : RecipeFamily
    {
        public SteelSmithsToolsRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                name: "SteelSmithsTools",
                displayName: Localizer.DoStr("Steel Smiths Tools"),

                ingredients: new List<IngredientElement>
                { new IngredientElement(typeof(SteelBarItem), 5, typeof(CarpentrySkill), typeof(CarpentryLavishResourcesTalent)), new IngredientElement("Lumber", 15, typeof(CarpentrySkill), typeof(CarpentryLavishResourcesTalent)), },

                items: new List<CraftingElement>
                {
                    new CraftingElement<SteelSmithsToolsItem>()
                });

            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 0.1f;
            this.LaborInCalories = CreateLaborInCaloriesValue(500, typeof(CarpentrySkill));
            this.CraftMinutes = CreateCraftTimeValue(5);

            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Steel Smiths Tools"), typeof(SteelSmithsToolsRecipe));
            this.ModsPostInitialize();

            CraftingComponent.AddRecipe(tableType: typeof(SawmillObject), recipe: this);
        }
        partial void ModsPreInitialize();
        partial void ModsPostInitialize();
    }

    [Serialized]
    [LocDisplayName("Steel Smiths Tools")]
    [LocDescription("A steel set of smith's tools")]
    [RepairRequiresSkill(typeof(CarpentrySkill), 1)]
    [Weight(1000)]
    [Category("Tool")]
    [Tag("Smith's Tools"), Tag("MTier 3")]
    [Ecopedia("Maintenance Items", "Bench Tools", createAsSubPage: true)]
    public partial class SteelSmithsToolsItem : RepairableItem
    {
        public override Item RepairItem                 => Item.Get<SteelBarItem>();
        public override int FullRepairAmount            => 4;
        //set durability by changing the denominator below
        public override float DurabilityRate            => DurabilityMax / 500f;
        public override IDynamicValue SkilledRepairCost => new SkillModifiedValue(4, SmeltingSkill.MultiplicativeStrategy, typeof(CarpentrySkill), Localizer.DoStr("repair cost"), DynamicValueType.Efficiency);
    }
}