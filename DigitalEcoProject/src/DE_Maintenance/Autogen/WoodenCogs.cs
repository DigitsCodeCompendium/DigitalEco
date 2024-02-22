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
    [Ecopedia("Items", "Products", subPageName: "Wooden Cogs")]
    public partial class WoodenCogsRecipe : RecipeFamily
    {
        public WoodenCogsRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                name: "WoodenCogs",
                displayName: Localizer.DoStr("Wooden Cogs"),

                ingredients: new List<IngredientElement>
                { new IngredientElement("Wood", 10, typeof(BasicEngineeringSkill)), new IngredientElement("WoodBoard", 10, typeof(BasicEngineeringSkill)),},

                items: new List<CraftingElement>
                {
                    new CraftingElement<WoodenCogsItem>()
                });

            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 0.1f;
            this.LaborInCalories = CreateLaborInCaloriesValue(500, typeof(BasicEngineeringSkill));
            this.CraftMinutes = CreateCraftTimeValue(5);

            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Wooden Cogs"), typeof(WoodenCogsRecipe));
            this.ModsPostInitialize();

            CraftingComponent.AddRecipe(tableType: typeof(WainwrightTableObject), recipe: this);
        }
        partial void ModsPreInitialize();
        partial void ModsPostInitialize();
    }

    [Serialized]
    [LocDisplayName("Wooden Cogs")]
    [LocDescription("A set of wooden cogs for some machine")]
    [RepairRequiresSkill(typeof(BasicEngineeringSkill), 1)]
    [Weight(1000)]
    [Category("Tool")]
    [Tag("Cogs"), Tag("MTier 1")]
    [Ecopedia("Maintenance Items", "Bench Tools", createAsSubPage: true)]
    public partial class WoodenCogsItem : RepairableItem
    {
        public override Item RepairItem                 => Item.Get<HewnLogItem>();
        public override int FullRepairAmount            => 9;
        //set durability by changing the denominator below
        public override float DurabilityRate            => DurabilityMax / 100f;
        public override IDynamicValue SkilledRepairCost => new SkillModifiedValue(9, SmeltingSkill.MultiplicativeStrategy, typeof(BasicEngineeringSkill), Localizer.DoStr("repair cost"), DynamicValueType.Efficiency);
    }
}