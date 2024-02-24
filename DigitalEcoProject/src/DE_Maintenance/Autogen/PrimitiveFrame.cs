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
    [Ecopedia("Items", "Products", subPageName: "Primitive Frame")]
    public partial class PrimitiveFrameRecipe : RecipeFamily
    {
        public PrimitiveFrameRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                name: "PrimitiveFrame",
                displayName: Localizer.DoStr("Primitive Frame"),

                ingredients: new List<IngredientElement>
                { new IngredientElement("Wood", 10), new IngredientElement(typeof(StoneItem), 10), new IngredientElement(typeof(PlantFibersItem), 10), },

                items: new List<CraftingElement>
                {
                    new CraftingElement<PrimitiveFrameItem>()
                });

            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 0.1f;
            this.LaborInCalories = CreateLaborInCaloriesValue(500, typeof(GatheringSkill));
            this.CraftMinutes = CreateCraftTimeValue(5);

            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Primitive Frame"), typeof(PrimitiveFrameRecipe));
            this.ModsPostInitialize();

            CraftingComponent.AddRecipe(tableType: typeof(WorkbenchObject), recipe: this);
        }
        partial void ModsPreInitialize();
        partial void ModsPostInitialize();
    }

    [Serialized]
    [LocDisplayName("Primitive Frame")]
    [LocDescription("This primitive frame just barely holds your machine together")]
    [RepairRequiresSkill(typeof(GatheringSkill), 1)]
    [Weight(1000)]
    [Category("Tool")]
    [Tag("Frame"), Tag("MTier 1")]
    [Ecopedia("Maintenance Items", "Bench Tools", createAsSubPage: true)]
    public partial class PrimitiveFrameItem : RepairableItem
    {
        public override Item RepairItem                 => Item.Get<PlantFibersItem>();
        public override int FullRepairAmount            => 40;
        //set durability by changing the denominator below
        public override float DurabilityRate            => DurabilityMax / 25f;
        public override IDynamicValue SkilledRepairCost => new SkillModifiedValue(40, SmeltingSkill.MultiplicativeStrategy, typeof(GatheringSkill), Localizer.DoStr("repair cost"), DynamicValueType.Efficiency);
    }
}