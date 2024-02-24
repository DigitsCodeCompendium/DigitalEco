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
    [Ecopedia("Items", "Products", subPageName: "Basic Lubricant")]
    public partial class BasicLubricantRecipe : RecipeFamily
    {
        public BasicLubricantRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                name: "BasicLubricant",
                displayName: Localizer.DoStr("Basic Lubricant"),

                ingredients: new List<IngredientElement>
                { new IngredientElement(typeof(FlaxseedOilItem), 5, typeof(MillingSkill), typeof(MillingLavishResourcesTalent)), new IngredientElement(typeof(GlassItem), 5, typeof(MillingSkill), typeof(MillingLavishResourcesTalent)), },

                items: new List<CraftingElement>
                {
                    new CraftingElement<BasicLubricantItem>()
                });

            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 0.1f;
            this.LaborInCalories = CreateLaborInCaloriesValue(500, typeof(MillingSkill));
            this.CraftMinutes = CreateCraftTimeValue(5);

            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Basic Lubricant"), typeof(BasicLubricantRecipe));
            this.ModsPostInitialize();

            CraftingComponent.AddRecipe(tableType: typeof(MillObject), recipe: this);
        }
        partial void ModsPreInitialize();
        partial void ModsPostInitialize();
    }

    [Serialized]
    [LocDisplayName("Basic Lubricant")]
    [LocDescription("A basic plant based lubricant for lubricating your things")]
    [RepairRequiresSkill(typeof(MillingSkill), 1)]
    [Weight(1000)]
    [Category("Tool")]
    [Tag("Lubricant"), Tag("MTier 2")]
    [Ecopedia("Maintenance Items", "Bench Tools", createAsSubPage: true)]
    public partial class BasicLubricantItem : RepairableItem
    {
        public override Item RepairItem                 => Item.Get<FlaxseedOilItem>();
        public override int FullRepairAmount            => 4;
        //set durability by changing the denominator below
        public override float DurabilityRate            => DurabilityMax / 300f;
        public override IDynamicValue SkilledRepairCost => new SkillModifiedValue(4, SmeltingSkill.MultiplicativeStrategy, typeof(MillingSkill), Localizer.DoStr("repair cost"), DynamicValueType.Efficiency);
    }
}