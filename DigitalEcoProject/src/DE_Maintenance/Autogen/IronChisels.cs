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
    [RequiresSkill(typeof(MiningSkill), 1)]
    [ForceCreateView]
    [Ecopedia("Items", "Products", subPageName: "Iron Chisels")]
    public partial class IronChiselsRecipe : RecipeFamily
    {
        public IronChiselsRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                name: "IronChisels",
                displayName: Localizer.DoStr("Iron Chisels"),

                ingredients: new List<IngredientElement>
                { new IngredientElement(typeof(IronBarItem), 10, typeof(MiningSkill)), new IngredientElement("WoodBoard", 4, typeof(MiningSkill)), },

                items: new List<CraftingElement>
                {
                    new CraftingElement<IronChiselsItem>()
                });

            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 0.1f;
            this.LaborInCalories = CreateLaborInCaloriesValue(500, typeof(MiningSkill));
            this.CraftMinutes = CreateCraftTimeValue(5);

            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Iron Chisels"), typeof(IronChiselsRecipe));
            this.ModsPostInitialize();

            CraftingComponent.AddRecipe(tableType: typeof(AnvilObject), recipe: this);
        }
        partial void ModsPreInitialize();
        partial void ModsPostInitialize();
    }

    [Serialized]
    [LocDisplayName("Iron Chisels")]
    [LocDescription("An iron chisel for shaping materials")]
    [RepairRequiresSkill(typeof(MiningSkill), 1)]
    [Weight(1000)]
    [Category("Tool")]
    [Tag("Chisels"), Tag("MTier 2")]
    [Ecopedia("Maintenance Items", "Bench Tools", createAsSubPage: true)]
    public partial class IronChiselsItem : RepairableItem
    {
        public override Item RepairItem                 => Item.Get<IronBarItem>();
        public override int FullRepairAmount            => 3;
        //set durability by changing the denominator below
        public override float DurabilityRate            => DurabilityMax / 300f;
        public override IDynamicValue SkilledRepairCost => new SkillModifiedValue(3, SmeltingSkill.MultiplicativeStrategy, typeof(MiningSkill), Localizer.DoStr("repair cost"), DynamicValueType.Efficiency);
    }
}