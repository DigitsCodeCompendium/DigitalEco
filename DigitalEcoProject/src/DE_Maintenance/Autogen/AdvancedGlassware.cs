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
    [RequiresSkill(typeof(GlassworkingSkill), 1)]
    [ForceCreateView]
    [Ecopedia("Items", "Products", subPageName: "Advanced Glassware")]
    public partial class AdvancedGlasswareRecipe : RecipeFamily
    {
        public AdvancedGlasswareRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                name: "AdvancedGlassware",
                displayName: Localizer.DoStr("Advanced Glassware"),

                ingredients: new List<IngredientElement>
                { new IngredientElement(typeof(GlassItem), 10, typeof(GlassworkingSkill), typeof(GlassworkingLavishResourcesTalent)), new IngredientElement(typeof(SyntheticRubberItem), 2, typeof(GlassworkingSkill), typeof(GlassworkingLavishResourcesTalent)), },

                items: new List<CraftingElement>
                {
                    new CraftingElement<AdvancedGlasswareItem>()
                });

            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 0.1f;
            this.LaborInCalories = CreateLaborInCaloriesValue(500, typeof(GlassworkingSkill));
            this.CraftMinutes = CreateCraftTimeValue(5);

            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Advanced Glassware"), typeof(AdvancedGlasswareRecipe));
            this.ModsPostInitialize();

            CraftingComponent.AddRecipe(tableType: typeof(GlassworksObject), recipe: this);
        }
        partial void ModsPreInitialize();
        partial void ModsPostInitialize();
    }

    [Serialized]
    [LocDisplayName("Advanced Glassware")]
    [LocDescription("A set of advanced lab glassware")]
    [RepairRequiresSkill(typeof(GlassworkingSkill), 1)]
    [Weight(1000)]
    [Category("Tool")]
    [Tag("Glassware"), Tag("MTier 3")]
    [Ecopedia("Maintenance Items", "Bench Tools", createAsSubPage: true)]
    public partial class AdvancedGlasswareItem : RepairableItem
    {
        public override Item RepairItem                 => Item.Get<GlassItem>();
        public override int FullRepairAmount            => 9;
        //set durability by changing the denominator below
        public override float DurabilityRate            => DurabilityMax / 500f;
        public override IDynamicValue SkilledRepairCost => new SkillModifiedValue(9, SmeltingSkill.MultiplicativeStrategy, typeof(GlassworkingSkill), Localizer.DoStr("repair cost"), DynamicValueType.Efficiency);
    }
}