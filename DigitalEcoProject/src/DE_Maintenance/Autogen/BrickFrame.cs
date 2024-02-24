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
    [RequiresSkill(typeof(PotterySkill), 1)]
    [ForceCreateView]
    [Ecopedia("Items", "Products", subPageName: "Brick Frame")]
    public partial class BrickFrameRecipe : RecipeFamily
    {
        public BrickFrameRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                name: "BrickFrame",
                displayName: Localizer.DoStr("Brick Frame"),

                ingredients: new List<IngredientElement>
                { new IngredientElement(typeof(BrickItem), 20, typeof(PotterySkill), typeof(PotteryLavishResourcesTalent)), },

                items: new List<CraftingElement>
                {
                    new CraftingElement<BrickFrameItem>()
                });

            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 0.1f;
            this.LaborInCalories = CreateLaborInCaloriesValue(500, typeof(PotterySkill));
            this.CraftMinutes = CreateCraftTimeValue(5);

            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Brick Frame"), typeof(BrickFrameRecipe));
            this.ModsPostInitialize();

            CraftingComponent.AddRecipe(tableType: typeof(KilnObject), recipe: this);
        }
        partial void ModsPreInitialize();
        partial void ModsPostInitialize();
    }

    [Serialized]
    [LocDisplayName("Brick Frame")]
    [LocDescription("A brick frame created by a potter to hold your machines together")]
    [RepairRequiresSkill(typeof(PotterySkill), 1)]
    [Weight(1000)]
    [Category("Tool")]
    [Tag("Frame"), Tag("MTier 2")]
    [Ecopedia("Maintenance Items", "Bench Tools", createAsSubPage: true)]
    public partial class BrickFrameItem : RepairableItem
    {
        public override Item RepairItem                 => Item.Get<BrickItem>();
        public override int FullRepairAmount            => 18;
        //set durability by changing the denominator below
        public override float DurabilityRate            => DurabilityMax / 300f;
        public override IDynamicValue SkilledRepairCost => new SkillModifiedValue(18, SmeltingSkill.MultiplicativeStrategy, typeof(PotterySkill), Localizer.DoStr("repair cost"), DynamicValueType.Efficiency);
    }
}