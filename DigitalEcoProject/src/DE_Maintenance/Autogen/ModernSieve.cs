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
    [RequiresSkill(typeof(TailoringSkill), 1)]
    [ForceCreateView]
    [Ecopedia("Items", "Products", subPageName: "Modern Sieve")]
    public partial class ModernSieveRecipe : RecipeFamily
    {
        public ModernSieveRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                name: "ModernSieve",
                displayName: Localizer.DoStr("Modern Sieve"),

                ingredients: new List<IngredientElement>
                {  new IngredientElement(typeof(SteelBarItem), 8, typeof(TailoringSkill), typeof(TailoringLavishResourcesTalent)), new IngredientElement(typeof(FiberglassItem), 8, typeof(TailoringSkill), typeof(TailoringLavishResourcesTalent)), },

                items: new List<CraftingElement>
                {
                    new CraftingElement<ModernSieveItem>()
                });

            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 0.1f;
            this.LaborInCalories = CreateLaborInCaloriesValue(500, typeof(TailoringSkill));
            this.CraftMinutes = CreateCraftTimeValue(5);

            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Modern Sieve"), typeof(ModernSieveRecipe));
            this.ModsPostInitialize();

            CraftingComponent.AddRecipe(tableType: typeof(AdvancedTailoringTableObject), recipe: this);
        }
        partial void ModsPreInitialize();
        partial void ModsPostInitialize();
    }

    [Serialized]
    [LocDisplayName("Modern Sieve")]
    [LocDescription("A modern steel-fiberglass composite sieve for seperating out small particles")]
    [RepairRequiresSkill(typeof(TailoringSkill), 1)]
    [Weight(1000)]
    [Category("Tool")]
    [Tag("Sieve"), Tag("MTier 4")]
    [Ecopedia("Maintenance Items", "Bench Tools", createAsSubPage: true)]
    public partial class ModernSieveItem : RepairableItem
    {
        public override Item RepairItem                 => Item.Get<FiberglassItem>();
        public override int FullRepairAmount            => 7;
        //set durability by changing the denominator below
        public override float DurabilityRate            => DurabilityMax / 700f;
        public override IDynamicValue SkilledRepairCost => new SkillModifiedValue(7, SmeltingSkill.MultiplicativeStrategy, typeof(TailoringSkill), Localizer.DoStr("repair cost"), DynamicValueType.Efficiency);
    }
}