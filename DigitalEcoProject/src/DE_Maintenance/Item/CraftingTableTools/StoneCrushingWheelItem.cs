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
using System.Diagnostics.CodeAnalysis;
using Digits.PartSlotting;

namespace Digits.Maintenance
{
    [RequiresSkill(typeof(LoggingSkill), 1)]
    [ForceCreateView]
    [Ecopedia("Items", "Products", subPageName: "Stone Crushing Wheel")]
    public partial class StoneCrushingWheelRecipe : RecipeFamily
    {
        public StoneCrushingWheelRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                name: "StoneCrushingWheel",
                displayName: Localizer.DoStr("Stone Crushing Wheel"),

                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(IronBarItem), 4, typeof(LoggingSkill)),
new IngredientElement("WoodBoard", 4, typeof(LoggingSkill))
                },

                items: new List<CraftingElement>
                {
                    new CraftingElement<StoneCrushingWheelItem>()
                });

            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 20;
            this.LaborInCalories = CreateLaborInCaloriesValue(300f, typeof(LoggingSkill));
            this.CraftMinutes = CreateCraftTimeValue(10f);

            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Stone Crushing Wheel"), typeof(StoneCrushingWheelRecipe));
            this.ModsPostInitialize();

            CraftingComponent.AddRecipe(tableType: typeof(MaintenanceBenchObject), recipe: this);
        }
        partial void ModsPreInitialize();
        partial void ModsPostInitialize();
    }

    [Serialized]
    [LocDisplayName("Stone Crushing Wheel")]
    [LocDescription("A large heavy wheel used for crushing.")]
    [Tier(1)]
    [RepairRequiresSkill(typeof(LoggingSkill), 1)]
    [Weight(5000)]
    [Category("tool")]
    [Tag("Maintenance Tool Crushing Wheel"), Tag("Maintenance Tier 1")]
    [Ecopedia("Maintenance Items", "Bench Tools", createAsSubPage: true)]
    public partial class StoneCrushingWheelItem : RepairableItem, ISlottableItem
    {
        public override Item RepairItem                 => Item.Get<IronBarItem>();
        public override int FullRepairAmount            => 4;
        //set durability by changing the denominator below
        public override float DurabilityRate            => DurabilityMax / 100f;
        public override IDynamicValue SkilledRepairCost => new SkillModifiedValue(4, SmeltingSkill.MultiplicativeStrategy, typeof(LoggingSkill), Localizer.DoStr("repair cost"), DynamicValueType.Efficiency);
    }
}