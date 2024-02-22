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
    [RequiresSkill(typeof(ButcherySkill), 1)]
    [ForceCreateView]
    [Ecopedia("Items", "Products", subPageName: "Modern Bellows")]
    public partial class ModernBellowsRecipe : RecipeFamily
    {
        public ModernBellowsRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                name: "ModernBellows",
                displayName: Localizer.DoStr("Modern Bellows"),

                ingredients: new List<IngredientElement>
                { new IngredientElement("Wood", 1), },

                items: new List<CraftingElement>
                {
                    new CraftingElement<ModernBellowsItem>()
                });

            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 0.1f;
            this.LaborInCalories = CreateLaborInCaloriesValue(500, typeof(ButcherySkill));
            this.CraftMinutes = CreateCraftTimeValue(5);

            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Modern Bellows"), typeof(ModernBellowsRecipe));
            this.ModsPostInitialize();

            CraftingComponent.AddRecipe(tableType: typeof(ButcheryTableObject), recipe: this);
        }
        partial void ModsPreInitialize();
        partial void ModsPostInitialize();
    }

    [Serialized]
    [LocDisplayName("Modern Bellows")]
    [LocDescription("A modern set of bellows for blowing air into a fire")]
    [RepairRequiresSkill(typeof(ButcherySkill), 1)]
    [Weight(1000)]
    [Category("Tool")]
    [Tag("Bellows"), Tag("MTier 4")]
    [Ecopedia("Maintenance Items", "Bench Tools", createAsSubPage: true)]
    public partial class ModernBellowsItem : RepairableItem
    {
        public override Item RepairItem                 => Item.Get<NylonItem>();
        public override int FullRepairAmount            => 1;
        //set durability by changing the denominator below
        public override float DurabilityRate            => DurabilityMax / 700f;
        public override IDynamicValue SkilledRepairCost => new SkillModifiedValue(1, SmeltingSkill.MultiplicativeStrategy, typeof(ButcherySkill), Localizer.DoStr("repair cost"), DynamicValueType.Efficiency);
    }
}