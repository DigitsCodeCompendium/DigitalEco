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
    [Ecopedia("Items", "Products", subPageName: "Basic Sealant")]
    public partial class BasicSealantRecipe : RecipeFamily
    {
        public BasicSealantRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                name: "BasicSealant",
                displayName: Localizer.DoStr("Basic Sealant"),

                ingredients: new List<IngredientElement>
                { new IngredientElement(typeof(TallowItem), 6, typeof(MillingSkill), typeof(MillingLavishResourcesTalent)), new IngredientElement(typeof(GlassItem), 5, typeof(MillingSkill), typeof(MillingLavishResourcesTalent)), new IngredientElement(typeof(QuicklimeItem), 2, typeof(MillingSkill), typeof(MillingLavishResourcesTalent)), },

                items: new List<CraftingElement>
                {
                    new CraftingElement<BasicSealantItem>()
                });

            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 0.1f;
            this.LaborInCalories = CreateLaborInCaloriesValue(500, typeof(MillingSkill));
            this.CraftMinutes = CreateCraftTimeValue(5);

            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Basic Sealant"), typeof(BasicSealantRecipe));
            this.ModsPostInitialize();

            CraftingComponent.AddRecipe(tableType: typeof(MillObject), recipe: this);
        }
        partial void ModsPreInitialize();
        partial void ModsPostInitialize();
    }

    [Serialized]
    [LocDisplayName("Basic Sealant")]
    [LocDescription("A basic plant based sealant for keeping fluids in their place")]
    [RepairRequiresSkill(typeof(MillingSkill), 1)]
    [Weight(1000)]
    [Category("Tool")]
    [Tag("Sealant"), Tag("MTier 2")]
    [Ecopedia("Maintenance Items", "Bench Tools", createAsSubPage: true)]
    public partial class BasicSealantItem : RepairableItem
    {
        public override Item RepairItem                 => Item.Get<TallowItem>();
        public override int FullRepairAmount            => 5;
        //set durability by changing the denominator below
        public override float DurabilityRate            => DurabilityMax / 300f;
        public override IDynamicValue SkilledRepairCost => new SkillModifiedValue(5, SmeltingSkill.MultiplicativeStrategy, typeof(MillingSkill), Localizer.DoStr("repair cost"), DynamicValueType.Efficiency);
    }
}