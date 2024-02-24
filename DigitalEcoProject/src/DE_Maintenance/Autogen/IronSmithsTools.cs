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
    [Ecopedia("Items", "Products", subPageName: "Iron Smiths Tools")]
    public partial class IronSmithsToolsRecipe : RecipeFamily
    {
        public IronSmithsToolsRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                name: "IronSmithsTools",
                displayName: Localizer.DoStr("Iron Smiths Tools"),

                ingredients: new List<IngredientElement>
                { new IngredientElement(typeof(IronBarItem), 4, typeof(CarpentrySkill), typeof(CarpentryLavishResourcesTalent)), new IngredientElement("WoodBoard", 20, typeof(CarpentrySkill), typeof(CarpentryLavishResourcesTalent)), },

                items: new List<CraftingElement>
                {
                    new CraftingElement<IronSmithsToolsItem>()
                });

            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 0.1f;
            this.LaborInCalories = CreateLaborInCaloriesValue(500, typeof(CarpentrySkill));
            this.CraftMinutes = CreateCraftTimeValue(5);

            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Iron Smiths Tools"), typeof(IronSmithsToolsRecipe));
            this.ModsPostInitialize();

            CraftingComponent.AddRecipe(tableType: typeof(CarpentryTableObject), recipe: this);
        }
        partial void ModsPreInitialize();
        partial void ModsPostInitialize();
    }

    [Serialized]
    [LocDisplayName("Iron Smiths Tools")]
    [LocDescription("An iron set of smiths tools")]
    [RepairRequiresSkill(typeof(CarpentrySkill), 1)]
    [Weight(1000)]
    [Category("Tool")]
    [Tag("Smiths Tools"), Tag("MTier 2")]
    [Ecopedia("Maintenance Items", "Bench Tools", createAsSubPage: true)]
    public partial class IronSmithsToolsItem : RepairableItem
    {
        public override Item RepairItem                 => Item.Get<IronBarItem>();
        public override int FullRepairAmount            => 3;
        //set durability by changing the denominator below
        public override float DurabilityRate            => DurabilityMax / 300f;
        public override IDynamicValue SkilledRepairCost => new SkillModifiedValue(3, SmeltingSkill.MultiplicativeStrategy, typeof(CarpentrySkill), Localizer.DoStr("repair cost"), DynamicValueType.Efficiency);
    }
}