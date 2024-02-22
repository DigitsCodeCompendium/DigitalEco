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
    [Ecopedia("Items", "Products", subPageName: "Advanced Scribes Set")]
    public partial class AdvancedScribesSetRecipe : RecipeFamily
    {
        public AdvancedScribesSetRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                name: "AdvancedScribesSet",
                displayName: Localizer.DoStr("Advanced Scribes Set"),

                ingredients: new List<IngredientElement>
                { new IngredientElement("Lumber", 6, typeof(GatheringSkill)), new IngredientElement(typeof(PaperItem), 20, typeof(GatheringSkill)), new IngredientElement(typeof(CharcoalItem), 3, typeof(GatheringSkill)),},

                items: new List<CraftingElement>
                {
                    new CraftingElement<AdvancedScribesSetItem>()
                });

            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 0.1f;
            this.LaborInCalories = CreateLaborInCaloriesValue(500, typeof(GatheringSkill));
            this.CraftMinutes = CreateCraftTimeValue(5);

            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Advanced Scribes Set"), typeof(AdvancedScribesSetRecipe));
            this.ModsPostInitialize();

            CraftingComponent.AddRecipe(tableType: typeof(WorkbenchObject), recipe: this);
        }
        partial void ModsPreInitialize();
        partial void ModsPostInitialize();
    }

    [Serialized]
    [LocDisplayName("Advanced Scribes Set")]
    [LocDescription("An advanced set of writing tools")]
    [RepairRequiresSkill(typeof(GatheringSkill), 1)]
    [Weight(1000)]
    [Category("Tool")]
    [Tag("Scribe Set"), Tag("MTier 3")]
    [Ecopedia("Maintenance Items", "Bench Tools", createAsSubPage: true)]
    public partial class AdvancedScribesSetItem : RepairableItem
    {
        public override Item RepairItem                 => Item.Get<CharcoalItem>();
        public override int FullRepairAmount            => 2;
        //set durability by changing the denominator below
        public override float DurabilityRate            => DurabilityMax / 500f;
        public override IDynamicValue SkilledRepairCost => new SkillModifiedValue(2, SmeltingSkill.MultiplicativeStrategy, typeof(GatheringSkill), Localizer.DoStr("repair cost"), DynamicValueType.Efficiency);
    }
}