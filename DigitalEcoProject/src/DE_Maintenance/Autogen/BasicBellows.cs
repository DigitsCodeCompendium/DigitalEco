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
    [Ecopedia("Items", "Products", subPageName: "Basic Bellows")]
    public partial class BasicBellowsRecipe : RecipeFamily
    {
        public BasicBellowsRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                name: "BasicBellows",
                displayName: Localizer.DoStr("Basic Bellows"),

                ingredients: new List<IngredientElement>
                { new IngredientElement(typeof(LeatherHideItem), 15, typeof(ButcherySkill), typeof(ButcheryLavishResourcesTalent)), new IngredientElement(typeof(LumberItem), 5, typeof(ButcherySkill), typeof(ButcheryLavishResourcesTalent)), new IngredientElement(typeof(NailItem), 10, typeof(ButcherySkill), typeof(ButcheryLavishResourcesTalent)), },

                items: new List<CraftingElement>
                {
                    new CraftingElement<BasicBellowsItem>()
                });

            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 0.1f;
            this.LaborInCalories = CreateLaborInCaloriesValue(500, typeof(ButcherySkill));
            this.CraftMinutes = CreateCraftTimeValue(5);

            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Basic Bellows"), typeof(BasicBellowsRecipe));
            this.ModsPostInitialize();

            CraftingComponent.AddRecipe(tableType: typeof(ButcheryTableObject), recipe: this);
        }
        partial void ModsPreInitialize();
        partial void ModsPostInitialize();
    }

    [Serialized]
    [LocDisplayName("Basic Bellows")]
    [LocDescription("A basic set of bellows for blowing air into a fire")]
    [RepairRequiresSkill(typeof(ButcherySkill), 1)]
    [Weight(1000)]
    [Category("Tool")]
    [Tag("Bellows"), Tag("MTier 2")]
    [Ecopedia("Maintenance Items", "Bench Tools", createAsSubPage: true)]
    public partial class BasicBellowsItem : RepairableItem
    {
        public override Item RepairItem                 => Item.Get<LeatherHideItem>();
        public override int FullRepairAmount            => 9;
        //set durability by changing the denominator below
        public override float DurabilityRate            => DurabilityMax / 300f;
        public override IDynamicValue SkilledRepairCost => new SkillModifiedValue(9, SmeltingSkill.MultiplicativeStrategy, typeof(ButcherySkill), Localizer.DoStr("repair cost"), DynamicValueType.Efficiency);
    }
}