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
    [Ecopedia("Items", "Products", subPageName: "Modern Scribes Set")]
    public partial class ModernScribesSetRecipe : RecipeFamily
    {
        public ModernScribesSetRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                name: "ModernScribesSet",
                displayName: Localizer.DoStr("Modern Scribes Set"),

                ingredients: new List<IngredientElement>
                { new IngredientElement("Wood", 1), },

                items: new List<CraftingElement>
                {
                    new CraftingElement<ModernScribesSetItem>()
                });

            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 0.1f;
            this.LaborInCalories = CreateLaborInCaloriesValue(500, typeof(GatheringSkill));
            this.CraftMinutes = CreateCraftTimeValue(5);

            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Modern Scribes Set"), typeof(ModernScribesSetRecipe));
            this.ModsPostInitialize();

            CraftingComponent.AddRecipe(tableType: typeof(ElectronicsAssemblyObject), recipe: this);
        }
        partial void ModsPreInitialize();
        partial void ModsPostInitialize();
    }

    [Serialized]
    [LocDisplayName("Modern Scribes Set")]
    [LocDescription("A modern tablet for all your writing needs")]
    [RepairRequiresSkill(typeof(GatheringSkill), 1)]
    [Weight(1000)]
    [Category("Tool")]
    [Tag("Scribe Set"), Tag("MTier 4")]
    [Ecopedia("Maintenance Items", "Bench Tools", createAsSubPage: true)]
    public partial class ModernScribesSetItem : RepairableItem
    {
        public override Item RepairItem                 => Item.Get<BasicCircuitItem>();
        public override int FullRepairAmount            => 1;
        //set durability by changing the denominator below
        public override float DurabilityRate            => DurabilityMax / 700f;
        public override IDynamicValue SkilledRepairCost => new SkillModifiedValue(1, SmeltingSkill.MultiplicativeStrategy, typeof(GatheringSkill), Localizer.DoStr("repair cost"), DynamicValueType.Efficiency);
    }
}