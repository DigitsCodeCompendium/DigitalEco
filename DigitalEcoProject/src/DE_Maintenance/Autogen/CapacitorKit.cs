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
    [RequiresSkill(typeof(FertilizersSkill), 1)]
    [ForceCreateView]
    [Ecopedia("Items", "Products", subPageName: "Capacitor Kit")]
    public partial class CapacitorKitRecipe : RecipeFamily
    {
        public CapacitorKitRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                name: "CapacitorKit",
                displayName: Localizer.DoStr("Capacitor Kit"),

                ingredients: new List<IngredientElement>
                { new IngredientElement(typeof(QuicklimeItem), 10, typeof(FertilizersSkill), typeof(FertilizersLavishResourcesTalent)), new IngredientElement(typeof(SteelBarItem), 15, typeof(FertilizersSkill), typeof(FertilizersLavishResourcesTalent)), },

                items: new List<CraftingElement>
                {
                    new CraftingElement<CapacitorKitItem>()
                });

            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 0.1f;
            this.LaborInCalories = CreateLaborInCaloriesValue(500, typeof(FertilizersSkill));
            this.CraftMinutes = CreateCraftTimeValue(5);

            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Capacitor Kit"), typeof(CapacitorKitRecipe));
            this.ModsPostInitialize();

            CraftingComponent.AddRecipe(tableType: typeof(FarmersTableObject), recipe: this);
        }
        partial void ModsPreInitialize();
        partial void ModsPostInitialize();
    }

    [Serialized]
    [LocDisplayName("Capacitor Kit")]
    [LocDescription("A kit of capcitors of various sizes and types for quickly servicing a machine")]
    [RepairRequiresSkill(typeof(FertilizersSkill), 1)]
    [Weight(1000)]
    [Category("Tool")]
    [Tag("Capacitor Kit"), Tag("MTier 4")]
    [Ecopedia("Maintenance Items", "Bench Tools", createAsSubPage: true)]
    public partial class CapacitorKitItem : RepairableItem
    {
        public override Item RepairItem                 => Item.Get<QuicklimeItem>();
        public override int FullRepairAmount            => 9;
        //set durability by changing the denominator below
        public override float DurabilityRate            => DurabilityMax / 700f;
        public override IDynamicValue SkilledRepairCost => new SkillModifiedValue(9, SmeltingSkill.MultiplicativeStrategy, typeof(FertilizersSkill), Localizer.DoStr("repair cost"), DynamicValueType.Efficiency);
    }
}