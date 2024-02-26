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
    [Ecopedia("Items", "Products", subPageName: "Lumber Cogs")]
    public partial class LumberCogsRecipe : RecipeFamily
    {
        public LumberCogsRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                name: "LumberCogs",
                displayName: Localizer.DoStr("Lumber Cogs"),

                ingredients: new List<IngredientElement>
                { new IngredientElement("Lumber", 10, typeof(BasicEngineeringSkill)), new IngredientElement("WoodBoard", 20, typeof(BasicEngineeringSkill)),},

                items: new List<CraftingElement>
                {
                    new CraftingElement<LumberCogsItem>()
                });

            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 0.1f;
            this.LaborInCalories = CreateLaborInCaloriesValue(500, typeof(BasicEngineeringSkill));
            this.CraftMinutes = CreateCraftTimeValue(5);

            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Lumber Cogs"), typeof(LumberCogsRecipe));
            this.ModsPostInitialize();

            CraftingComponent.AddRecipe(tableType: typeof(WainwrightTableObject), recipe: this);
        }
        partial void ModsPreInitialize();
        partial void ModsPostInitialize();
    }

    [Serialized]
    [LocDisplayName("Lumber Cogs")]
    [LocDescription("A set of lumber cogs for some machine")]
    [RepairRequiresSkill(typeof(BasicEngineeringSkill), 1)]
    [Weight(1000)]
    [Category("Tool")]
    [Tag("Cogs"), Tag("MTier 2")]
    [Ecopedia("Maintenance Items", "Bench Tools", createAsSubPage: true)]
    public partial class LumberCogsItem : RepairableItem
    {
        public override Item RepairItem                 => Item.Get<Item>();
		public override Tag RepairTag => TagManager.Tag("Lumber");
        public override int FullRepairAmount            => 9;
        //set durability by changing the denominator below
        public override float DurabilityRate            => DurabilityMax / 300f;
        public override IDynamicValue SkilledRepairCost => new SkillModifiedValue(9, SmeltingSkill.MultiplicativeStrategy, typeof(BasicEngineeringSkill), Localizer.DoStr("repair cost"), DynamicValueType.Efficiency);
    }
}