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
    [RequiresSkill(typeof(CompositesSkill), 1)]
    [ForceCreateView]
    [Ecopedia("Items", "Products", subPageName: "Modern Clamp")]
    public partial class ModernClampRecipe : RecipeFamily
    {
        public ModernClampRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                name: "ModernClamp",
                displayName: Localizer.DoStr("Modern Clamp"),

                ingredients: new List<IngredientElement>
                { new IngredientElement("Wood", 1), },

                items: new List<CraftingElement>
                {
                    new CraftingElement<ModernClampItem>()
                });

            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 0.1f;
            this.LaborInCalories = CreateLaborInCaloriesValue(500, typeof(CompositesSkill));
            this.CraftMinutes = CreateCraftTimeValue(5);

            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Modern Clamp"), typeof(ModernClampRecipe));
            this.ModsPostInitialize();

            CraftingComponent.AddRecipe(tableType: typeof(AdvancedCarpentryTableObject), recipe: this);
        }
        partial void ModsPreInitialize();
        partial void ModsPostInitialize();
    }

    [Serialized]
    [LocDisplayName("Modern Clamp")]
    [LocDescription("A modern clamp for holding things together")]
    [RepairRequiresSkill(typeof(CompositesSkill), 1)]
    [Weight(1000)]
    [Category("Tool")]
    [Tag("Clamp"), Tag("MTier 4")]
    [Ecopedia("Maintenance Items", "Bench Tools", createAsSubPage: true)]
    public partial class ModernClampItem : RepairableItem
    {
        public override Item RepairItem                 => Item.Get<FiberglassItem>();
        public override int FullRepairAmount            => 1;
        //set durability by changing the denominator below
        public override float DurabilityRate            => DurabilityMax / 700f;
        public override IDynamicValue SkilledRepairCost => new SkillModifiedValue(1, SmeltingSkill.MultiplicativeStrategy, typeof(CompositesSkill), Localizer.DoStr("repair cost"), DynamicValueType.Efficiency);
    }
}