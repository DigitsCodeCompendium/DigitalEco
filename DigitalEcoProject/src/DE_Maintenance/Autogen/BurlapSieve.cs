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
    [RequiresSkill(typeof(GatheringSkill), 1)]
    [ForceCreateView]
    [Ecopedia("Items", "Products", subPageName: "Burlap Sieve")]
    public partial class BurlapSieveRecipe : RecipeFamily
    {
        public BurlapSieveRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                name: "BurlapSieve",
                displayName: Localizer.DoStr("Burlap Sieve"),

                ingredients: new List<IngredientElement>
                {  new IngredientElement(typeof(PlantFibersItem), 60, typeof(GatheringSkill)), },

                items: new List<CraftingElement>
                {
                    new CraftingElement<BurlapSieveItem>()
                });

            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 0.1f;
            this.LaborInCalories = CreateLaborInCaloriesValue(500, typeof(GatheringSkill));
            this.CraftMinutes = CreateCraftTimeValue(5);

            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Burlap Sieve"), typeof(BurlapSieveRecipe));
            this.ModsPostInitialize();

            CraftingComponent.AddRecipe(tableType: typeof(FiberScutchingStationObject), recipe: this);
        }
        partial void ModsPreInitialize();
        partial void ModsPostInitialize();
    }

    [Serialized]
    [LocDisplayName("Burlap Sieve")]
    [LocDescription("A simple burlap sieve for seperating out small particles")]
    [RepairRequiresSkill(typeof(GatheringSkill), 1)]
    [Weight(1000)]
    [Category("Tool")]
    [Tag("Sieve"), Tag("MTier 1")]
    [Ecopedia("Maintenance Items", "Bench Tools", createAsSubPage: true)]
    public partial class BurlapSieveItem : RepairableItem
    {
        public override Item RepairItem                 => Item.Get<PlantFibersItem>();
        public override int FullRepairAmount            => 54;
        //set durability by changing the denominator below
        public override float DurabilityRate            => DurabilityMax / 100;
        public override IDynamicValue SkilledRepairCost => new SkillModifiedValue(54, SmeltingSkill.MultiplicativeStrategy, typeof(GatheringSkill), Localizer.DoStr("repair cost"), DynamicValueType.Efficiency);
    }
}