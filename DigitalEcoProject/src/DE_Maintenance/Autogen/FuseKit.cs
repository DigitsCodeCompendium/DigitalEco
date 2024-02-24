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
    [RequiresSkill(typeof(ElectronicsSkill), 1)]
    [ForceCreateView]
    [Ecopedia("Items", "Products", subPageName: "Fuse Kit")]
    public partial class FuseKitRecipe : RecipeFamily
    {
        public FuseKitRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                name: "FuseKit",
                displayName: Localizer.DoStr("Fuse Kit"),

                ingredients: new List<IngredientElement>
                { new IngredientElement(typeof(SteelPlateItem), 2, typeof(ElectronicsSkill), typeof(ElectronicsLavishResourcesTalent)), new IngredientElement(typeof(PaperItem), 5, typeof(ElectronicsSkill), typeof(ElectronicsLavishResourcesTalent)), new IngredientElement(typeof(CopperWiringItem), 2, typeof(ElectronicsSkill), typeof(ElectronicsLavishResourcesTalent)), },

                items: new List<CraftingElement>
                {
                    new CraftingElement<FuseKitItem>()
                });

            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 0.1f;
            this.LaborInCalories = CreateLaborInCaloriesValue(500, typeof(ElectronicsSkill));
            this.CraftMinutes = CreateCraftTimeValue(5);

            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Fuse Kit"), typeof(FuseKitRecipe));
            this.ModsPostInitialize();

            CraftingComponent.AddRecipe(tableType: typeof(ElectronicsAssemblyObject), recipe: this);
        }
        partial void ModsPreInitialize();
        partial void ModsPostInitialize();
    }

    [Serialized]
    [LocDisplayName("Fuse Kit")]
    [LocDescription("A kit of fuses of various sizes and types for quickly servicing a machine")]
    [RepairRequiresSkill(typeof(ElectronicsSkill), 1)]
    [Weight(1000)]
    [Category("Tool")]
    [Tag("Fuse Kit"), Tag("MTier 4")]
    [Ecopedia("Maintenance Items", "Bench Tools", createAsSubPage: true)]
    public partial class FuseKitItem : RepairableItem
    {
        public override Item RepairItem                 => Item.Get<CopperWiringItem>();
        public override int FullRepairAmount            => 4;
        //set durability by changing the denominator below
        public override float DurabilityRate            => DurabilityMax / 700f;
        public override IDynamicValue SkilledRepairCost => new SkillModifiedValue(4, SmeltingSkill.MultiplicativeStrategy, typeof(ElectronicsSkill), Localizer.DoStr("repair cost"), DynamicValueType.Efficiency);
    }
}