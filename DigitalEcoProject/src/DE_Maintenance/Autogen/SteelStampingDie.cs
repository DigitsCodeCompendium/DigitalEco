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
    [RequiresSkill(typeof(MechanicsSkill), 1)]
    [ForceCreateView]
    [Ecopedia("Items", "Products", subPageName: "Steel Stamping Die")]
    public partial class SteelStampingDieRecipe : RecipeFamily
    {
        public SteelStampingDieRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                name: "SteelStampingDie",
                displayName: Localizer.DoStr("Steel Stamping Die"),

                ingredients: new List<IngredientElement>
                { new IngredientElement(typeof(SteelBarItem), 25, typeof(MechanicsSkill), typeof(MechanicsLavishResourcesTalent)), new IngredientElement(typeof(RivetItem), 30, typeof(MechanicsSkill), typeof(MechanicsLavishResourcesTalent)), },

                items: new List<CraftingElement>
                {
                    new CraftingElement<SteelStampingDieItem>()
                });

            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 0.1f;
            this.LaborInCalories = CreateLaborInCaloriesValue(500, typeof(MechanicsSkill));
            this.CraftMinutes = CreateCraftTimeValue(5);

            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Steel Stamping Die"), typeof(SteelStampingDieRecipe));
            this.ModsPostInitialize();

            CraftingComponent.AddRecipe(tableType: typeof(ElectricPlanerObject), recipe: this);
        }
        partial void ModsPreInitialize();
        partial void ModsPostInitialize();
    }

    [Serialized]
    [LocDisplayName("Steel Stamping Die")]
    [LocDescription("A steel stamping die")]
    [RepairRequiresSkill(typeof(MechanicsSkill), 1)]
    [Weight(1000)]
    [Category("Tool")]
    [Tag("Stamping Die"), Tag("MTier 3")]
    [Ecopedia("Maintenance Items", "Bench Tools", createAsSubPage: true)]
    public partial class SteelStampingDieItem : RepairableItem
    {
        public override Item RepairItem                 => Item.Get<RivetItem>();
        public override int FullRepairAmount            => 27;
        //set durability by changing the denominator below
        public override float DurabilityRate            => DurabilityMax / 500f;
        public override IDynamicValue SkilledRepairCost => new SkillModifiedValue(27, SmeltingSkill.MultiplicativeStrategy, typeof(MechanicsSkill), Localizer.DoStr("repair cost"), DynamicValueType.Efficiency);
    }
}