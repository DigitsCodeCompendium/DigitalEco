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
    [RequiresSkill(typeof(BasicEngineeringSkill), 1)]
    [ForceCreateView]
    [Ecopedia("Items", "Products", subPageName: "Advanced Windmill Sails")]
    public partial class AdvancedWindmillSailsRecipe : RecipeFamily
    {
        public AdvancedWindmillSailsRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                name: "AdvancedWindmillSails",
                displayName: Localizer.DoStr("Advanced Windmill Sails"),

                ingredients: new List<IngredientElement>
                { new IngredientElement(typeof(CottonFabricItem), 20, typeof(BasicEngineeringSkill), typeof(BasicEngineeringLavishResourcesTalent)), new IngredientElement(typeof(CottonThreadItem), 10, typeof(BasicEngineeringSkill), typeof(BasicEngineeringLavishResourcesTalent)), new IngredientElement(typeof(SteelAxleItem), 1, typeof(BasicEngineeringSkill), typeof(BasicEngineeringLavishResourcesTalent)), },

                items: new List<CraftingElement>
                {
                    new CraftingElement<AdvancedWindmillSailsItem>()
                });

            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 0.1f;
            this.LaborInCalories = CreateLaborInCaloriesValue(500, typeof(BasicEngineeringSkill));
            this.CraftMinutes = CreateCraftTimeValue(5);

            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Advanced Windmill Sails"), typeof(AdvancedWindmillSailsRecipe));
            this.ModsPostInitialize();

            CraftingComponent.AddRecipe(tableType: typeof(WainwrightTableObject), recipe: this);
        }
        partial void ModsPreInitialize();
        partial void ModsPostInitialize();
    }

    [Serialized]
    [LocDisplayName("Advanced Windmill Sails")]
    [LocDescription("A set of fabric covered sails for capturing windpower on a windmill")]
    [RepairRequiresSkill(typeof(BasicEngineeringSkill), 1)]
    [Weight(1000)]
    [Category("Tool")]
    [Tag("Windmill Sails"), Tag("MTier 3")]
    [Ecopedia("Maintenance Items", "Bench Tools", createAsSubPage: true)]
    public partial class AdvancedWindmillSailsItem : RepairableItem
    {
        public override Item RepairItem                 => Item.Get<CottonFabricItem>();
        public override int FullRepairAmount            => 18;
        //set durability by changing the denominator below
        public override float DurabilityRate            => DurabilityMax / 500f;
        public override IDynamicValue SkilledRepairCost => new SkillModifiedValue(18, SmeltingSkill.MultiplicativeStrategy, typeof(BasicEngineeringSkill), Localizer.DoStr("repair cost"), DynamicValueType.Efficiency);
    }
}