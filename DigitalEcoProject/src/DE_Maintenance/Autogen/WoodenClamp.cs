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
    [RequiresSkill(typeof(CarpentrySkill), 1)]
    [ForceCreateView]
    [Ecopedia("Items", "Products", subPageName: "Wooden Clamp")]
    public partial class WoodenClampRecipe : RecipeFamily
    {
        public WoodenClampRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                name: "WoodenClamp",
                displayName: Localizer.DoStr("Wooden Clamp"),

                ingredients: new List<IngredientElement>
                { new IngredientElement(typeof(BoardItem), 10, typeof(CarpentrySkill), typeof(CarpentryLavishResourcesTalent)), new IngredientElement("HewnLog", 5, typeof(CarpentrySkill), typeof(CarpentryLavishResourcesTalent)), },

                items: new List<CraftingElement>
                {
                    new CraftingElement<WoodenClampItem>()
                });

            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 0.1f;
            this.LaborInCalories = CreateLaborInCaloriesValue(500, typeof(CarpentrySkill));
            this.CraftMinutes = CreateCraftTimeValue(5);

            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Wooden Clamp"), typeof(WoodenClampRecipe));
            this.ModsPostInitialize();

            CraftingComponent.AddRecipe(tableType: typeof(CarpentryTableObject), recipe: this);
        }
        partial void ModsPreInitialize();
        partial void ModsPostInitialize();
    }

    [Serialized]
    [LocDisplayName("Wooden Clamp")]
    [LocDescription("A wooden clamp for holding things together")]
    [RepairRequiresSkill(typeof(CarpentrySkill), 1)]
    [Weight(1000)]
    [Category("Tool")]
    [Tag("Clamp"), Tag("MTier 1")]
    [Ecopedia("Maintenance Items", "Bench Tools", createAsSubPage: true)]
    public partial class WoodenClampItem : RepairableItem
    {
        public override Item RepairItem                 => Item.Get<HewnLogItem>();
        public override int FullRepairAmount            => 4;
        //set durability by changing the denominator below
        public override float DurabilityRate            => DurabilityMax / 100f;
        public override IDynamicValue SkilledRepairCost => new SkillModifiedValue(4, SmeltingSkill.MultiplicativeStrategy, typeof(CarpentrySkill), Localizer.DoStr("repair cost"), DynamicValueType.Efficiency);
    }
}