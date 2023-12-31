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

namespace Digits.DE_Maintenance
{
    /// <summary>
    /// <para>Server side recipe definition for "Tier 1 Machine Frames".</para>
    /// <para>Machine frames make up the core of most machines.</para>
    /// </summary>
    [RequiresSkill(typeof(LoggingSkill), 1)]
    [ForceCreateView]
    [Ecopedia("Items", "Products", subPageName: "Modern Chisels")]
    public partial class ModernChiselsRecipe : RecipeFamily
    {
        public ModernChiselsRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                name: "ModernChisels",  //noloc
                displayName: Localizer.DoStr("Modern Chisels"),

                // Defines the ingredients needed to craft this recipe. An ingredient items takes the following inputs
                // type of the item, the amount of the item, the skill required, and the talent used.
                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(SteelBarItem), 15, typeof(LoggingSkill)), //noloc
                    new IngredientElement(typeof(FiberglassItem), 10, typeof(LoggingSkill)),
                },

                // Define our recipe output items.
                // For every output item there needs to be one CraftingElement entry with the type of the final item and the amount
                // to create.
                items: new List<CraftingElement>
                {
                    new CraftingElement<ModernChiselsItem>()
                });
            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 20f;
            this.LaborInCalories = CreateLaborInCaloriesValue(30, typeof(LoggingSkill));
            this.CraftMinutes = CreateCraftTimeValue(0.01f);

            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Modern Chisels"), typeof(ModernChiselsRecipe));
            this.ModsPostInitialize();

            CraftingComponent.AddRecipe(tableType: typeof(MaintenanceBenchObject), recipe: this);
        }


        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPreInitialize();
        partial void ModsPostInitialize();
    }
    
    /// <summary>
    /// <para>Server side item definition for the "ModernChisels" item.</para>
    /// <para>More information about Item objects can be found at https://docs.play.eco/api/server/eco.gameplay/Eco.Gameplay.Items.Item.html</para>
    /// </summary>
    [Serialized]
    [LocDisplayName("Modern Chisels")]
    [LocDescription("Modern chisels are primitive tools for shaping rock")]
    [Tier(1)]
    [RepairRequiresSkill(typeof(SmeltingSkill), 0)]
    [Weight(500)]
    [Category("Chisels")]
    [Tag("Maintenance Tool Chisels")]
    [Tag("Maintenance Tier 4")]
    [Ecopedia("Maintenance Items", "Bench Tools", createAsSubPage: true)]
    public partial class ModernChiselsItem : RepairableMachinePartsItem
    {
        public override Item RepairItem                 => Item.Get<SteelBarItem>();
        public override int FullRepairAmount            => 4;
        //set durability by changing the denominator below
        public override float DurabilityRate            => DurabilityMax / 1000f;
        public override IDynamicValue SkilledRepairCost => new SkillModifiedValue(4, SmeltingSkill.MultiplicativeStrategy, typeof(SmeltingSkill), Localizer.DoStr("repair cost"), DynamicValueType.Efficiency);
    }
}