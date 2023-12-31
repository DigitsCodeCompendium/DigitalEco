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
    [Ecopedia("Items", "Products", subPageName: "Machine Parts Item")]
    public partial class Tier1MachineFrameRecipe : RecipeFamily
    {
        public Tier1MachineFrameRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                name: "Tier1MachineFrame",  //noloc
                displayName: Localizer.DoStr("Tier 1 Machine Frame"),

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
                    new CraftingElement<Tier1MachineFrameItem>()
                });
            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 20f;
            this.LaborInCalories = CreateLaborInCaloriesValue(30, typeof(LoggingSkill));
            this.CraftMinutes = CreateCraftTimeValue(0.01f);

            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Tier 1 Machine Frame"), typeof(Tier1MachineFrameRecipe));
            this.ModsPostInitialize();

            CraftingComponent.AddRecipe(tableType: typeof(MaintenanceBenchObject), recipe: this);
        }


        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPreInitialize();
        partial void ModsPostInitialize();
    }
    
    /// <summary>
    /// <para>Server side item definition for the "Tier1MachineFrame" item.</para>
    /// <para>More information about Item objects can be found at https://docs.play.eco/api/server/eco.gameplay/Eco.Gameplay.Items.Item.html</para>
    /// </summary>
    [Serialized]
    [LocDisplayName("Tier 1 Machine Frame")]
    [LocDescription("Machine Parts used for repairing and maintaining machines and workbenches.")]
    [Tier(1)]
    [RepairRequiresSkill(typeof(SmeltingSkill), 0)]
    [Weight(500)]
    [Category("Machine Frames")]
    [Tag("Maintenance Machine Frame")]
    [Tag("Maintenance Tier 1")]
    [Ecopedia("Maintenance Items", "Machine Frames", createAsSubPage: true)]
    public partial class Tier1MachineFrameItem : RepairableMachinePartsItem
    {
        public override Item RepairItem                 => Item.Get<IronBarItem>();
        public override int FullRepairAmount            => 4;
        //set durability by changing the denominator below
        public override float DurabilityRate            => DurabilityMax / 500f;
        public override IDynamicValue SkilledRepairCost => new SkillModifiedValue(4, SmeltingSkill.MultiplicativeStrategy, typeof(SmeltingSkill), Localizer.DoStr("repair cost"), DynamicValueType.Efficiency);
    }
}