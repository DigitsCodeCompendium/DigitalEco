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
    [RequiresSkill(typeof(TailoringSkill), 1)]
    [ForceCreateView]
    [Ecopedia("Items", "Products", subPageName: "Advanced Industrial Insulation")]
    public partial class AdvancedIndustrialInsulationRecipe : RecipeFamily
    {
        public AdvancedIndustrialInsulationRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                name: "AdvancedIndustrialInsulation",
                displayName: Localizer.DoStr("Advanced Industrial Insulation"),

                ingredients: new List<IngredientElement>
                { new IngredientElement(typeof(BasaltItem), 80, typeof(TailoringSkill), typeof(TailoringLavishResourcesTalent)), },

                items: new List<CraftingElement>
                {
                    new CraftingElement<AdvancedIndustrialInsulationItem>()
                });

            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 0.1f;
            this.LaborInCalories = CreateLaborInCaloriesValue(500, typeof(TailoringSkill));
            this.CraftMinutes = CreateCraftTimeValue(5);

            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Advanced Industrial Insulation"), typeof(AdvancedIndustrialInsulationRecipe));
            this.ModsPostInitialize();

            CraftingComponent.AddRecipe(tableType: typeof(BlastFurnaceObject), recipe: this);
        }
        partial void ModsPreInitialize();
        partial void ModsPostInitialize();
    }

    [Serialized]
    [LocDisplayName("Advanced Industrial Insulation")]
    [LocDescription("A high temperature insulative blanket for industrial applications")]
    [RepairRequiresSkill(typeof(TailoringSkill), 1)]
    [Weight(1000)]
    [Category("Tool")]
    [Tag("Industrial Insulation"), Tag("MTier 3")]
    [Ecopedia("Maintenance Items", "Bench Tools", createAsSubPage: true)]
    public partial class AdvancedIndustrialInsulationItem : RepairableItem
    {
        public override Item RepairItem                 => Item.Get<BasaltItem>();
        public override int FullRepairAmount            => 72;
        //set durability by changing the denominator below
        public override float DurabilityRate            => DurabilityMax / 500;
        public override IDynamicValue SkilledRepairCost => new SkillModifiedValue(72, SmeltingSkill.MultiplicativeStrategy, typeof(TailoringSkill), Localizer.DoStr("repair cost"), DynamicValueType.Efficiency);
    }
}