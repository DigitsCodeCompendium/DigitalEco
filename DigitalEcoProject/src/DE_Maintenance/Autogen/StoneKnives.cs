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
    [RequiresSkill(typeof(MasonrySkill), 1)]
    [ForceCreateView]
    [Ecopedia("Items", "Products", subPageName: "Stone Knives")]
    public partial class StoneKnivesRecipe : RecipeFamily
    {
        public StoneKnivesRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                name: "StoneKnives",
                displayName: Localizer.DoStr("Stone Knives"),

                ingredients: new List<IngredientElement>
                { new IngredientElement("Rock", 20), new IngredientElement("HewnLog", 10), },

                items: new List<CraftingElement>
                {
                    new CraftingElement<StoneKnivesItem>()
                });

            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 0.1f;
            this.LaborInCalories = CreateLaborInCaloriesValue(500, typeof(MasonrySkill));
            this.CraftMinutes = CreateCraftTimeValue(5);

            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Stone Knives"), typeof(StoneKnivesRecipe));
            this.ModsPostInitialize();

            CraftingComponent.AddRecipe(tableType: typeof(MasonryTableObject), recipe: this);
        }
        partial void ModsPreInitialize();
        partial void ModsPostInitialize();
    }

    [Serialized]
    [LocDisplayName("Stone Knives")]
    [LocDescription("A set of stone knives for all your cutting needs")]
    [RepairRequiresSkill(typeof(MasonrySkill), 1)]
    [Weight(1000)]
    [Category("Tool")]
    [Tag("Knives"), Tag("MTier 1")]
    [Ecopedia("Maintenance Items", "Bench Tools", createAsSubPage: true)]
    public partial class StoneKnivesItem : RepairableItem
    {
        public override Item RepairItem                 => Item.Get<BasaltItem>();
        public override int FullRepairAmount            => 18;
        //set durability by changing the denominator below
        public override float DurabilityRate            => DurabilityMax / 100f;
        public override IDynamicValue SkilledRepairCost => new SkillModifiedValue(18, SmeltingSkill.MultiplicativeStrategy, typeof(MasonrySkill), Localizer.DoStr("repair cost"), DynamicValueType.Efficiency);
    }
}