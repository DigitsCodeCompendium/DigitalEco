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
    [RequiresSkill(typeof(PotterySkill), 1)]
    [ForceCreateView]
    [Ecopedia("Items", "Products", subPageName: "Concrete Oven Lining")]
    public partial class ConcreteOvenLiningRecipe : RecipeFamily
    {
        public ConcreteOvenLiningRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                name: "ConcreteOvenLining",
                displayName: Localizer.DoStr("Concrete Oven Lining"),

                ingredients: new List<IngredientElement>
                { new IngredientElement("Concrete", 10, typeof(PotterySkill), typeof(PotteryLavishResourcesTalent)), },

                items: new List<CraftingElement>
                {
                    new CraftingElement<ConcreteOvenLiningItem>()
                });

            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 0.1f;
            this.LaborInCalories = CreateLaborInCaloriesValue(500, typeof(PotterySkill));
            this.CraftMinutes = CreateCraftTimeValue(5);

            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Concrete Oven Lining"), typeof(ConcreteOvenLiningRecipe));
            this.ModsPostInitialize();

            CraftingComponent.AddRecipe(tableType: typeof(CementKilnObject), recipe: this);
        }
        partial void ModsPreInitialize();
        partial void ModsPostInitialize();
    }

    [Serialized]
    [LocDisplayName("Concrete Oven Lining")]
    [LocDescription("A insulative high temperature concrete for lining the inside of ovens")]
    [RepairRequiresSkill(typeof(PotterySkill), 1)]
    [Weight(1000)]
    [Category("Tool")]
    [Tag("Oven Insulation"), Tag("MTier 3")]
    [Ecopedia("Maintenance Items", "Bench Tools", createAsSubPage: true)]
    public partial class ConcreteOvenLiningItem : RepairableItem
    {
        public override Item RepairItem                 => Item.Get<CementItem>();
        public override int FullRepairAmount            => 3;
        //set durability by changing the denominator below
        public override float DurabilityRate            => DurabilityMax / 500f;
        public override IDynamicValue SkilledRepairCost => new SkillModifiedValue(3, SmeltingSkill.MultiplicativeStrategy, typeof(PotterySkill), Localizer.DoStr("repair cost"), DynamicValueType.Efficiency);
    }
}