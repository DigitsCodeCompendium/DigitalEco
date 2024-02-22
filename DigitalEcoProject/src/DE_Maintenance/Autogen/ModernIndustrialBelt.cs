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
    [RequiresSkill(typeof(ButcherySkill), 1)]
    [ForceCreateView]
    [Ecopedia("Items", "Products", subPageName: "Modern Industrial Belt")]
    public partial class ModernIndustrialBeltRecipe : RecipeFamily
    {
        public ModernIndustrialBeltRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                name: "ModernIndustrialBelt",
                displayName: Localizer.DoStr("Modern Industrial Belt"),

                ingredients: new List<IngredientElement>
                { new IngredientElement(typeof(SyntheticRubberItem), 8, typeof(ButcherySkill), typeof(ButcheryLavishResourcesTalent)), },

                items: new List<CraftingElement>
                {
                    new CraftingElement<ModernIndustrialBeltItem>()
                });

            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 0.1f;
            this.LaborInCalories = CreateLaborInCaloriesValue(500, typeof(ButcherySkill));
            this.CraftMinutes = CreateCraftTimeValue(5);

            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Modern Industrial Belt"), typeof(ModernIndustrialBeltRecipe));
            this.ModsPostInitialize();

            CraftingComponent.AddRecipe(tableType: typeof(ButcheryTableObject), recipe: this);
        }
        partial void ModsPreInitialize();
        partial void ModsPostInitialize();
    }

    [Serialized]
    [LocDisplayName("Modern Industrial Belt")]
    [LocDescription("A modern rubber industrial belt for moving around mechanical power")]
    [RepairRequiresSkill(typeof(ButcherySkill), 1)]
    [Weight(1000)]
    [Category("Tool")]
    [Tag("Industrial Belt"), Tag("MTier 4")]
    [Ecopedia("Maintenance Items", "Bench Tools", createAsSubPage: true)]
    public partial class ModernIndustrialBeltItem : RepairableItem
    {
        public override Item RepairItem                 => Item.Get<SyntheticRubberItem>();
        public override int FullRepairAmount            => 7;
        //set durability by changing the denominator below
        public override float DurabilityRate            => DurabilityMax / 700;
        public override IDynamicValue SkilledRepairCost => new SkillModifiedValue(7, SmeltingSkill.MultiplicativeStrategy, typeof(ButcherySkill), Localizer.DoStr("repair cost"), DynamicValueType.Efficiency);
    }
}