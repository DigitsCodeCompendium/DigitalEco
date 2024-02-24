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
    [Ecopedia("Items", "Products", subPageName: "Modern Bearings Kit")]
    public partial class ModernBearingsKitRecipe : RecipeFamily
    {
        public ModernBearingsKitRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                name: "ModernBearingsKit",
                displayName: Localizer.DoStr("Modern Bearings Kit"),

                ingredients: new List<IngredientElement>
                { new IngredientElement(typeof(PlasticItem), 10, typeof(MechanicsSkill), typeof(MechanicsLavishResourcesTalent)), new IngredientElement(typeof(EpoxyItem), 5, typeof(MechanicsSkill), typeof(MechanicsLavishResourcesTalent)), new IngredientElement(typeof(SteelBarItem), 5, typeof(MechanicsSkill), typeof(MechanicsLavishResourcesTalent)), },

                items: new List<CraftingElement>
                {
                    new CraftingElement<ModernBearingsKitItem>()
                });

            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 0.1f;
            this.LaborInCalories = CreateLaborInCaloriesValue(500, typeof(MechanicsSkill));
            this.CraftMinutes = CreateCraftTimeValue(5);

            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Modern Bearings Kit"), typeof(ModernBearingsKitRecipe));
            this.ModsPostInitialize();

            CraftingComponent.AddRecipe(tableType: typeof(ElectricLatheObject), recipe: this);
        }
        partial void ModsPreInitialize();
        partial void ModsPostInitialize();
    }

    [Serialized]
    [LocDisplayName("Modern Bearings Kit")]
    [LocDescription("A kit of modern sealed bearings of various sizes and types for quickly servicing a machine")]
    [RepairRequiresSkill(typeof(MechanicsSkill), 1)]
    [Weight(1000)]
    [Category("Tool")]
    [Tag("Bearings Kit"), Tag("MTier 4")]
    [Ecopedia("Maintenance Items", "Bench Tools", createAsSubPage: true)]
    public partial class ModernBearingsKitItem : RepairableItem
    {
        public override Item RepairItem                 => Item.Get<PlasticItem>();
        public override int FullRepairAmount            => 9;
        //set durability by changing the denominator below
        public override float DurabilityRate            => DurabilityMax / 700f;
        public override IDynamicValue SkilledRepairCost => new SkillModifiedValue(9, SmeltingSkill.MultiplicativeStrategy, typeof(MechanicsSkill), Localizer.DoStr("repair cost"), DynamicValueType.Efficiency);
    }
}