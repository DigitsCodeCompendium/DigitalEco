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
    [Ecopedia("Items", "Products", subPageName: "Basic Glassware")]
    public partial class BasicGlasswareRecipe : RecipeFamily
    {
        public BasicGlasswareRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                name: "BasicGlassware",
                displayName: Localizer.DoStr("Basic Glassware"),

                ingredients: new List<IngredientElement>
                { new IngredientElement(typeof(GlassItem), 5, typeof(GlassworkingSkill), typeof(GlassworkingLavishResourcesTalent)), },

                items: new List<CraftingElement>
                {
                    new CraftingElement<BasicGlasswareItem>()
                });

            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 0.1f;
            this.LaborInCalories = CreateLaborInCaloriesValue(500, typeof(GlassworkingSkill));
            this.CraftMinutes = CreateCraftTimeValue(5);

            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Basic Glassware"), typeof(BasicGlasswareRecipe));
            this.ModsPostInitialize();

            CraftingComponent.AddRecipe(tableType: typeof(GlassworksObject), recipe: this);
        }
        partial void ModsPreInitialize();
        partial void ModsPostInitialize();
    }

    [Serialized]
    [LocDisplayName("Basic Glassware")]
    [LocDescription("A set of basic lab glassware")]
    [RepairRequiresSkill(typeof(GlassworkingSkill), 1)]
    [Weight(1000)]
    [Category("Tool")]
    [Tag("Glassware"), Tag("MTier 2")]
    [Ecopedia("Maintenance Items", "Bench Tools", createAsSubPage: true)]
    public partial class BasicGlasswareItem : RepairableItem
    {
        public override Item RepairItem                 => Item.Get<GlassItem>();
        public override int FullRepairAmount            => 4;
        //set durability by changing the denominator below
        public override float DurabilityRate            => DurabilityMax / 300f;
        public override IDynamicValue SkilledRepairCost => new SkillModifiedValue(4, SmeltingSkill.MultiplicativeStrategy, typeof(GlassworkingSkill), Localizer.DoStr("repair cost"), DynamicValueType.Efficiency);
    }
}