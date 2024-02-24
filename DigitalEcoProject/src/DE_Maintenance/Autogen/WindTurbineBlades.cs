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
    [RequiresSkill(typeof(IndustrySkill), 1)]
    [ForceCreateView]
    [Ecopedia("Items", "Products", subPageName: "Wind Turbine Blades")]
    public partial class WindTurbineBladesRecipe : RecipeFamily
    {
        public WindTurbineBladesRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                name: "WindTurbineBlades",
                displayName: Localizer.DoStr("Wind Turbine Blades"),

                ingredients: new List<IngredientElement>
                { new IngredientElement(typeof(FiberglassItem), 40, typeof(IndustrySkill), typeof(IndustryLavishResourcesTalent)), new IngredientElement(typeof(RivetItem), 20, typeof(IndustrySkill), typeof(IndustryLavishResourcesTalent)), new IngredientElement(typeof(SteelAxleItem), 1, typeof(IndustrySkill), typeof(IndustryLavishResourcesTalent)), },

                items: new List<CraftingElement>
                {
                    new CraftingElement<WindTurbineBladesItem>()
                });

            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 0.1f;
            this.LaborInCalories = CreateLaborInCaloriesValue(500, typeof(IndustrySkill));
            this.CraftMinutes = CreateCraftTimeValue(5);

            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Wind Turbine Blades"), typeof(WindTurbineBladesRecipe));
            this.ModsPostInitialize();

            CraftingComponent.AddRecipe(tableType: typeof(RoboticAssemblyLineObject), recipe: this);
        }
        partial void ModsPreInitialize();
        partial void ModsPostInitialize();
    }

    [Serialized]
    [LocDisplayName("Wind Turbine Blades")]
    [LocDescription("A set of fiberglass windturbine blades for capturing wind energy")]
    [RepairRequiresSkill(typeof(IndustrySkill), 1)]
    [Weight(1000)]
    [Category("Tool")]
    [Tag("Windmill Sails"), Tag("MTier 4")]
    [Ecopedia("Maintenance Items", "Bench Tools", createAsSubPage: true)]
    public partial class WindTurbineBladesItem : RepairableItem
    {
        public override Item RepairItem                 => Item.Get<FiberglassItem>();
        public override int FullRepairAmount            => 36;
        //set durability by changing the denominator below
        public override float DurabilityRate            => DurabilityMax / 700f;
        public override IDynamicValue SkilledRepairCost => new SkillModifiedValue(36, SmeltingSkill.MultiplicativeStrategy, typeof(IndustrySkill), Localizer.DoStr("repair cost"), DynamicValueType.Efficiency);
    }
}