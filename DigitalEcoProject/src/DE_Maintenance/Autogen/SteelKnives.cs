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
    [RequiresSkill(typeof(AdvancedSmeltingSkill), 1)]
    [ForceCreateView]
    [Ecopedia("Items", "Products", subPageName: "Steel Knives")]
    public partial class SteelKnivesRecipe : RecipeFamily
    {
        public SteelKnivesRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                name: "SteelKnives",
                displayName: Localizer.DoStr("Steel Knives"),

                ingredients: new List<IngredientElement>
                { new IngredientElement(typeof(SteelBarItem), 10, typeof(AdvancedSmeltingSkill), typeof(AdvancedSmeltingLavishResourcesTalent)), new IngredientElement("Lumber", 5, typeof(AdvancedSmeltingSkill), typeof(AdvancedSmeltingLavishResourcesTalent)), },

                items: new List<CraftingElement>
                {
                    new CraftingElement<SteelKnivesItem>()
                });

            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 0.1f;
            this.LaborInCalories = CreateLaborInCaloriesValue(500, typeof(AdvancedSmeltingSkill));
            this.CraftMinutes = CreateCraftTimeValue(5);

            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Steel Knives"), typeof(SteelKnivesRecipe));
            this.ModsPostInitialize();

            CraftingComponent.AddRecipe(tableType: typeof(AnvilObject), recipe: this);
        }
        partial void ModsPreInitialize();
        partial void ModsPostInitialize();
    }

    [Serialized]
    [LocDisplayName("Steel Knives")]
    [LocDescription("A set of sharp steel knives for all your cutting needs")]
    [RepairRequiresSkill(typeof(AdvancedSmeltingSkill), 1)]
    [Weight(1000)]
    [Category("Tool")]
    [Tag("Knives"), Tag("MTier 3")]
    [Ecopedia("Maintenance Items", "Bench Tools", createAsSubPage: true)]
    public partial class SteelKnivesItem : RepairableItem
    {
        public override Item RepairItem                 => Item.Get<SteelBarItem>();
        public override int FullRepairAmount            => 9;
        //set durability by changing the denominator below
        public override float DurabilityRate            => DurabilityMax / 500f;
        public override IDynamicValue SkilledRepairCost => new SkillModifiedValue(9, SmeltingSkill.MultiplicativeStrategy, typeof(AdvancedSmeltingSkill), Localizer.DoStr("repair cost"), DynamicValueType.Efficiency);
    }
}