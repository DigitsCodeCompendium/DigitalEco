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
    [Ecopedia("Items", "Products", subPageName: "Modern Crushing Wheels")]
    public partial class ModernCrushingWheelsRecipe : RecipeFamily
    {
        public ModernCrushingWheelsRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                name: "ModernCrushingWheels",
                displayName: Localizer.DoStr("Modern Crushing Wheels"),

                ingredients: new List<IngredientElement>
                { new IngredientElement(typeof(SyntheticRubberItem), 2, typeof(IndustrySkill), typeof(IndustryLavishResourcesTalent)), new IngredientElement(typeof(SteelPlateItem), 10, typeof(IndustrySkill), typeof(IndustryLavishResourcesTalent)), new IngredientElement(typeof(SteelAxleItem), 1, typeof(IndustrySkill), typeof(IndustryLavishResourcesTalent)), },

                items: new List<CraftingElement>
                {
                    new CraftingElement<ModernCrushingWheelsItem>()
                });

            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 0.1f;
            this.LaborInCalories = CreateLaborInCaloriesValue(500, typeof(IndustrySkill));
            this.CraftMinutes = CreateCraftTimeValue(5);

            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Modern Crushing Wheels"), typeof(ModernCrushingWheelsRecipe));
            this.ModsPostInitialize();

            CraftingComponent.AddRecipe(tableType: typeof(WainwrightTableObject), recipe: this);
        }
        partial void ModsPreInitialize();
        partial void ModsPostInitialize();
    }

    [Serialized]
    [LocDisplayName("Modern Crushing Wheels")]
    [LocDescription("A set of modern crushing wheels for crushing materials into a smaller form")]
    [RepairRequiresSkill(typeof(IndustrySkill), 1)]
    [Weight(1000)]
    [Category("Tool")]
    [Tag("Crushing Wheels"), Tag("MTier 4")]
    [Ecopedia("Maintenance Items", "Bench Tools", createAsSubPage: true)]
    public partial class ModernCrushingWheelsItem : RepairableItem
    {
        public override Item RepairItem                 => Item.Get<SteelPlateItem>();
        public override int FullRepairAmount            => 9;
        //set durability by changing the denominator below
        public override float DurabilityRate            => DurabilityMax / 700f;
        public override IDynamicValue SkilledRepairCost => new SkillModifiedValue(9, SmeltingSkill.MultiplicativeStrategy, typeof(IndustrySkill), Localizer.DoStr("repair cost"), DynamicValueType.Efficiency);
    }
}