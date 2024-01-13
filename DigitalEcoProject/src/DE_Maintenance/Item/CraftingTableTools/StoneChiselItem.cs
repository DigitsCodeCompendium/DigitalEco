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
    [Ecopedia("Items", "Products", subPageName: "Stone Chisel")]
    public partial class StoneChiselRecipe : RecipeFamily
    {
        public StoneChiselRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                name: "StoneChisel",
                displayName: Localizer.DoStr("Stone Chisel"),

                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(IronBarItem), 4, typeof(LoggingSkill)),
new IngredientElement("WoodBoard", 4, typeof(LoggingSkill))
                },

                items: new List<CraftingElement>
                {
                    new CraftingElement<StoneChiselItem>()
                });

            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 20;
            this.LaborInCalories = CreateLaborInCaloriesValue(300f, typeof(LoggingSkill));
            this.CraftMinutes = CreateCraftTimeValue(10f);

            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Stone Chisel"), typeof(StoneChiselRecipe));
            this.ModsPostInitialize();

            CraftingComponent.AddRecipe(tableType: typeof(MaintenanceBenchObject), recipe: this);
        }
        partial void ModsPreInitialize();
        partial void ModsPostInitialize();
    }

    [Serialized]
    [LocDisplayName("Stone Chisel")]
    [LocDescription("A stone chisel used for shaping materials")]
    [Tier(1)]
    [RepairRequiresSkill(typeof(LoggingSkill), 1)]
    [Weight(500)]
    [Category("tool")]
    [Tag("Maintenance Tool Chisel"), Tag("Maintenance Tier 1")]
    [Ecopedia("Maintenance Items", "Bench Tools", createAsSubPage: true)]
    public partial class StoneChiselItem : RepairableItem, ISlottableItem
    {
        public override Item RepairItem                 => Item.Get<IronBarItem>();
        public override int FullRepairAmount            => 4;
        //set durability by changing the denominator below
        public override float DurabilityRate            => DurabilityMax / 100f;
        public override IDynamicValue SkilledRepairCost => new SkillModifiedValue(4, SmeltingSkill.MultiplicativeStrategy, typeof(LoggingSkill), Localizer.DoStr("repair cost"), DynamicValueType.Efficiency);
    }
}