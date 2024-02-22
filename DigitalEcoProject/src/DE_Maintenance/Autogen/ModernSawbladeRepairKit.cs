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
    [RequiresSkill(typeof(AdvancedSmeltingSkill), 1)]
    [ForceCreateView]
    [Ecopedia("Items", "Products", subPageName: "Modern Sawblade Repair Kit")]
    public partial class ModernSawbladeRepairKitRecipe : RecipeFamily
    {
        public ModernSawbladeRepairKitRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                name: "ModernSawbladeRepairKit",
                displayName: Localizer.DoStr("Modern Sawblade Repair Kit"),

                ingredients: new List<IngredientElement>
                { new IngredientElement("Wood", 1), },

                items: new List<CraftingElement>
                {
                    new CraftingElement<ModernSawbladeRepairKitItem>()
                });

            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 0.1f;
            this.LaborInCalories = CreateLaborInCaloriesValue(500, typeof(AdvancedSmeltingSkill));
            this.CraftMinutes = CreateCraftTimeValue(5);

            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Modern Sawblade Repair Kit"), typeof(ModernSawbladeRepairKitRecipe));
            this.ModsPostInitialize();

            CraftingComponent.AddRecipe(tableType: typeof(RoboticAssemblyLineObject), recipe: this);
        }
        partial void ModsPreInitialize();
        partial void ModsPostInitialize();
    }

    [Serialized]
    [LocDisplayName("Modern Sawblade Repair Kit")]
    [LocDescription("A modern sawblade repair kit for quick repairs on your sawblades")]
    [RepairRequiresSkill(typeof(AdvancedSmeltingSkill), 1)]
    [Weight(1000)]
    [Category("Tool")]
    [Tag("Sawblade Kit"), Tag("MTier 4")]
    [Ecopedia("Maintenance Items", "Bench Tools", createAsSubPage: true)]
    public partial class ModernSawbladeRepairKitItem : RepairableItem
    {
        public override Item RepairItem                 => Item.Get<FiberglassItem>();
        public override int FullRepairAmount            => 1;
        //set durability by changing the denominator below
        public override float DurabilityRate            => DurabilityMax / 700;
        public override IDynamicValue SkilledRepairCost => new SkillModifiedValue(1, SmeltingSkill.MultiplicativeStrategy, typeof(AdvancedSmeltingSkill), Localizer.DoStr("repair cost"), DynamicValueType.Efficiency);
    }
}