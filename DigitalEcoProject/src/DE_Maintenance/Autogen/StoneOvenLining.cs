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
    [Ecopedia("Items", "Products", subPageName: "Stone Oven Lining")]
    public partial class StoneOvenLiningRecipe : RecipeFamily
    {
        public StoneOvenLiningRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                name: "StoneOvenLining",
                displayName: Localizer.DoStr("Stone Oven Lining"),

                ingredients: new List<IngredientElement>
                { new IngredientElement(typeof(BasaltItem), 40, typeof(MasonrySkill), typeof(MasonryLavishResourcesTalent)), },

                items: new List<CraftingElement>
                {
                    new CraftingElement<StoneOvenLiningItem>()
                });

            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 0.1f;
            this.LaborInCalories = CreateLaborInCaloriesValue(500, typeof(MasonrySkill));
            this.CraftMinutes = CreateCraftTimeValue(5);

            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Stone Oven Lining"), typeof(StoneOvenLiningRecipe));
            this.ModsPostInitialize();

            CraftingComponent.AddRecipe(tableType: typeof(MasonryTableObject), recipe: this);
        }
        partial void ModsPreInitialize();
        partial void ModsPostInitialize();
    }

    [Serialized]
    [LocDisplayName("Stone Oven Lining")]
    [LocDescription("A insulative high temperature stone for lining the inside of ovens")]
    [RepairRequiresSkill(typeof(MasonrySkill), 1)]
    [Weight(1000)]
    [Category("Tool")]
    [Tag("Oven Insulation"), Tag("MTier 1")]
    [Ecopedia("Maintenance Items", "Bench Tools", createAsSubPage: true)]
    public partial class StoneOvenLiningItem : RepairableItem
    {
        public override Item RepairItem                 => Item.Get<BasaltItem>();
        public override int FullRepairAmount            => 36;
        //set durability by changing the denominator below
        public override float DurabilityRate            => DurabilityMax / 100f;
        public override IDynamicValue SkilledRepairCost => new SkillModifiedValue(36, SmeltingSkill.MultiplicativeStrategy, typeof(MasonrySkill), Localizer.DoStr("repair cost"), DynamicValueType.Efficiency);
    }
}