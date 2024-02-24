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
    [Ecopedia("Items", "Products", subPageName: "Steel Sawblade Repair Kit")]
    public partial class SteelSawbladeRepairKitRecipe : RecipeFamily
    {
        public SteelSawbladeRepairKitRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                name: "SteelSawbladeRepairKit",
                displayName: Localizer.DoStr("Steel Sawblade Repair Kit"),

                ingredients: new List<IngredientElement>
                { new IngredientElement(typeof(SteelBarItem), 5, typeof(AdvancedSmeltingSkill), typeof(AdvancedSmeltingLavishResourcesTalent)), new IngredientElement("Lumber", 3, typeof(AdvancedSmeltingSkill), typeof(AdvancedSmeltingLavishResourcesTalent)), },

                items: new List<CraftingElement>
                {
                    new CraftingElement<SteelSawbladeRepairKitItem>()
                });

            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 0.1f;
            this.LaborInCalories = CreateLaborInCaloriesValue(500, typeof(AdvancedSmeltingSkill));
            this.CraftMinutes = CreateCraftTimeValue(5);

            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Steel Sawblade Repair Kit"), typeof(SteelSawbladeRepairKitRecipe));
            this.ModsPostInitialize();

            CraftingComponent.AddRecipe(tableType: typeof(AssemblyLineObject), recipe: this);
        }
        partial void ModsPreInitialize();
        partial void ModsPostInitialize();
    }

    [Serialized]
    [LocDisplayName("Steel Sawblade Repair Kit")]
    [LocDescription("A steel sawblade repair kit for quick repairs on your sawblades")]
    [RepairRequiresSkill(typeof(AdvancedSmeltingSkill), 1)]
    [Weight(1000)]
    [Category("Tool")]
    [Tag("Sawblade Kit"), Tag("MTier 3")]
    [Ecopedia("Maintenance Items", "Bench Tools", createAsSubPage: true)]
    public partial class SteelSawbladeRepairKitItem : RepairableItem
    {
        public override Item RepairItem                 => Item.Get<SteelBarItem>();
        public override int FullRepairAmount            => 4;
        //set durability by changing the denominator below
        public override float DurabilityRate            => DurabilityMax / 500f;
        public override IDynamicValue SkilledRepairCost => new SkillModifiedValue(4, SmeltingSkill.MultiplicativeStrategy, typeof(AdvancedSmeltingSkill), Localizer.DoStr("repair cost"), DynamicValueType.Efficiency);
    }
}