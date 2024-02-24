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
    [Ecopedia("Items", "Products", subPageName: "Primitive Thread Kit")]
    public partial class PrimitiveThreadKitRecipe : RecipeFamily
    {
        public PrimitiveThreadKitRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                name: "PrimitiveThreadKit",
                displayName: Localizer.DoStr("Primitive Thread Kit"),

                ingredients: new List<IngredientElement>
                { new IngredientElement(typeof(PlantFibersItem), 40, typeof(GatheringSkill)), new IngredientElement("HewnLog", 2, typeof(GatheringSkill)), },

                items: new List<CraftingElement>
                {
                    new CraftingElement<PrimitiveThreadKitItem>()
                });

            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 0.1f;
            this.LaborInCalories = CreateLaborInCaloriesValue(500, typeof(GatheringSkill));
            this.CraftMinutes = CreateCraftTimeValue(5);

            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Primitive Thread Kit"), typeof(PrimitiveThreadKitRecipe));
            this.ModsPostInitialize();

            CraftingComponent.AddRecipe(tableType: typeof(FiberScutchingStationObject), recipe: this);
        }
        partial void ModsPreInitialize();
        partial void ModsPostInitialize();
    }

    [Serialized]
    [LocDisplayName("Primitive Thread Kit")]
    [LocDescription("A primitive spool of plant fiber thread for machines")]
    [RepairRequiresSkill(typeof(GatheringSkill), 1)]
    [Weight(1000)]
    [Category("Tool")]
    [Tag("Thread"), Tag("MTier 1")]
    [Ecopedia("Maintenance Items", "Bench Tools", createAsSubPage: true)]
    public partial class PrimitiveThreadKitItem : RepairableItem
    {
        public override Item RepairItem                 => Item.Get<PlantFibersItem>();
        public override int FullRepairAmount            => 36;
        //set durability by changing the denominator below
        public override float DurabilityRate            => DurabilityMax / 100f;
        public override IDynamicValue SkilledRepairCost => new SkillModifiedValue(36, SmeltingSkill.MultiplicativeStrategy, typeof(GatheringSkill), Localizer.DoStr("repair cost"), DynamicValueType.Efficiency);
    }
}