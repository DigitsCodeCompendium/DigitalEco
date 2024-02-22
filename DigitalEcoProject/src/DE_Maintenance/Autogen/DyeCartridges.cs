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
    [RequiresSkill(typeof(MillingSkill), 1)]
    [ForceCreateView]
    [Ecopedia("Items", "Products", subPageName: "Dye Cartridges")]
    public partial class DyeCartridgesRecipe : RecipeFamily
    {
        public DyeCartridgesRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                name: "DyeCartridges",
                displayName: Localizer.DoStr("Dye Cartridges"),

                ingredients: new List<IngredientElement>
                { new IngredientElement("Wood", 1), },

                items: new List<CraftingElement>
                {
                    new CraftingElement<DyeCartridgesItem>()
                });

            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 0.1f;
            this.LaborInCalories = CreateLaborInCaloriesValue(500, typeof(MillingSkill));
            this.CraftMinutes = CreateCraftTimeValue(5);

            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Dye Cartridges"), typeof(DyeCartridgesRecipe));
            this.ModsPostInitialize();

            CraftingComponent.AddRecipe(tableType: typeof(MillObject), recipe: this);
        }
        partial void ModsPreInitialize();
        partial void ModsPostInitialize();
    }

    [Serialized]
    [LocDisplayName("Dye Cartridges")]
    [LocDescription("A set of dyes cartriges for a machine")]
    [RepairRequiresSkill(typeof(MillingSkill), 1)]
    [Weight(1000)]
    [Category("Tool")]
    [Tag("Dye"), Tag("MTier 2")]
    [Ecopedia("Maintenance Items", "Bench Tools", createAsSubPage: true)]
    public partial class DyeCartridgesItem : RepairableItem
    {
        public override Item RepairItem                 => Item.Get<OilPaintItem>();
        public override int FullRepairAmount            => 1;
        //set durability by changing the denominator below
        public override float DurabilityRate            => DurabilityMax / 300;
        public override IDynamicValue SkilledRepairCost => new SkillModifiedValue(1, SmeltingSkill.MultiplicativeStrategy, typeof(MillingSkill), Localizer.DoStr("repair cost"), DynamicValueType.Efficiency);
    }
}