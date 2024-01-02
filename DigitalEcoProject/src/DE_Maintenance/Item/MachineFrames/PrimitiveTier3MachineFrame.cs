using System;
using System.Collections.Generic;
using System.ComponentModel;
using Eco.Mods.TechTree;
using Eco.Gameplay.Components;
using Eco.Gameplay.DynamicValues;
using Eco.Gameplay.Items;
using Eco.Gameplay.Skills;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;
using Eco.Core.Items;
using Eco.Core.Controller;
using Eco.Gameplay.Items.Recipes;
using Digits.PartSlotting;

namespace Digits.Maintenance
{
    /// <summary>
    /// <para>Server side recipe definition for "Tier 3 Machine Frames".</para>
    /// <para>Machine frames make up the core of most machines.</para>
    /// </summary>
    [RequiresSkill(typeof(LoggingSkill), 1)]
    [ForceCreateView]
    [Ecopedia("Items", "Products", subPageName: "Machine Parts Item")]
    public partial class PrimitiveTier3MachineFrameRecipe : RecipeFamily
    {
        public PrimitiveTier3MachineFrameRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                name: "PrimitiveTier3MachineFrame",  //noloc
                displayName: Localizer.DoStr("Primitive Tier 3 Machine Frame"),

                // Defines the ingredients needed to craft this recipe. An ingredient items takes the following inputs
                // type of the item, the amount of the item, the skill required, and the talent used.
                ingredients: new List<IngredientElement>
                {
                    new IngredientElement("Wood", 1, typeof(LoggingSkill)), //noloc
                },

                // Define our recipe output items.
                // For every output item there needs to be one CraftingElement entry with the type of the final item and the amount
                // to create.
                items: new List<CraftingElement>
                {
                    new CraftingElement<PrimitiveTier3MachineFrameItem>()
                });
            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 20f;
            this.LaborInCalories = CreateLaborInCaloriesValue(30, typeof(LoggingSkill));
            this.CraftMinutes = CreateCraftTimeValue(0.01f);

            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Primitive Tier 3 Machine Frame"), typeof(PrimitiveTier3MachineFrameRecipe));
            this.ModsPostInitialize();

            CraftingComponent.AddRecipe(tableType: typeof(MaintenanceBenchObject), recipe: this);
        }


        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPreInitialize();
        partial void ModsPostInitialize();
    }
    
    /// <summary>
    /// <para>Server side item definition for the "Tier3MachineFrame" item.</para>
    /// <para>More information about Item objects can be found at https://docs.play.eco/api/server/eco.gameplay/Eco.Gameplay.Items.Item.html</para>
    /// </summary>
    [Serialized] 
    [LocDisplayName("Primitive Tier 3 Machine Frame"), LocDescription("A machine frame keeps everything together and in place")]
    [Tier(3)]
    [RepairRequiresSkill(typeof(SmeltingSkill), 0)]
    [Weight(500)]
    [Category("Machine Frames")]
    [Tag("Maintenance Machine Frame"), Tag("Maintenance Tier 3")]
    [Ecopedia("Maintenance Items", "Machine Frames", createAsSubPage: true)]
    public partial class PrimitiveTier3MachineFrameItem : RepairableItem, ISlottableItem
    {
        public override Item RepairItem                 => Item.Get<IronBarItem>();
        public override int FullRepairAmount            => 4;
        //set durability by changing the denominator below
        public override float DurabilityRate            => DurabilityMax / 100f;
        public override IDynamicValue SkilledRepairCost => new SkillModifiedValue(4, SmeltingSkill.MultiplicativeStrategy, typeof(SmeltingSkill), Localizer.DoStr("repair cost"), DynamicValueType.Efficiency);
    }
}