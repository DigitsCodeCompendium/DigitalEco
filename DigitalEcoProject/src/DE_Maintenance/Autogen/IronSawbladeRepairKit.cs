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
    [RequiresSkill(typeof(SmeltingSkill), 1)]
    [ForceCreateView]
    [Ecopedia("Items", "Products", subPageName: "Iron Sawblade Repair Kit")]
    public partial class IronSawbladeRepairKitRecipe : RecipeFamily
    {
        public IronSawbladeRepairKitRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                name: "IronSawbladeRepairKit",
                displayName: Localizer.DoStr("Iron Sawblade Repair Kit"),

                ingredients: new List<IngredientElement>
                { new IngredientElement(typeof(IronBarItem), 10, typeof(SmeltingSkill), typeof(SmeltingLavishResourcesTalent)), new IngredientElement("HewnLog", 3, typeof(SmeltingSkill), typeof(SmeltingLavishResourcesTalent)), },

                items: new List<CraftingElement>
                {
                    new CraftingElement<IronSawbladeRepairKitItem>()
                });

            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 0.1f;
            this.LaborInCalories = CreateLaborInCaloriesValue(500, typeof(SmeltingSkill));
            this.CraftMinutes = CreateCraftTimeValue(5);

            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Iron Sawblade Repair Kit"), typeof(IronSawbladeRepairKitRecipe));
            this.ModsPostInitialize();

            CraftingComponent.AddRecipe(tableType: typeof(AnvilObject), recipe: this);
        }
        partial void ModsPreInitialize();
        partial void ModsPostInitialize();
    }

    [Serialized]
    [LocDisplayName("Iron Sawblade Repair Kit")]
    [LocDescription("An iron sawblade repair kit for quick repairs on your sawblades")]
    [RepairRequiresSkill(typeof(SmeltingSkill), 1)]
    [Weight(1000)]
    [Category("Tool")]
    [Tag("Sawblade Kit"), Tag("MTier 2")]
    [Ecopedia("Maintenance Items", "Bench Tools", createAsSubPage: true)]
    public partial class IronSawbladeRepairKitItem : RepairableItem
    {
        public override Item RepairItem                 => Item.Get<IronBarItem>();
        public override int FullRepairAmount            => 9;
        //set durability by changing the denominator below
        public override float DurabilityRate            => DurabilityMax / 300f;
        public override IDynamicValue SkilledRepairCost => new SkillModifiedValue(9, SmeltingSkill.MultiplicativeStrategy, typeof(SmeltingSkill), Localizer.DoStr("repair cost"), DynamicValueType.Efficiency);
    }
}