namespace Digits.DE_Maintenance
{
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

        
    /// <summary>
    /// <para>Server side recipe definition for "MaintenanceKit".</para>
    /// <para>More information about RecipeFamily objects can be found at https://docs.play.eco/api/server/eco.gameplay/Eco.Gameplay.Items.RecipeFamily.html</para>
    /// </summary>
    /// <remarks>
    /// This is an auto-generated class. Don't modify it! All your changes will be wiped with next update! Use Mods* partial methods instead for customization. 
    /// If you wish to modify this class, please create a new partial class or follow the instructions in the "UserCode" folder to override the entire file.
    /// </remarks>
    [RequiresSkill(typeof(LoggingSkill), 1)]
    [ForceCreateView]
    [Ecopedia("Items", "Products", subPageName: "Maintenance Kit Item")]
    public partial class MaintenanceKitRecipe : RecipeFamily
    {
        public MaintenanceKitRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                name: "MaintenanceKit",  //noloc
                displayName: Localizer.DoStr("Maintenance Kit"),

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
                    new CraftingElement<MaintenanceKitItem>()
                });
            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 20f;
            this.LaborInCalories = CreateLaborInCaloriesValue(30, typeof(LoggingSkill));
            this.CraftMinutes = CreateCraftTimeValue(0.01f);

            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Maintenance Kit"), typeof(MaintenanceKitRecipe));
            this.ModsPostInitialize();

            CraftingComponent.AddRecipe(tableType: typeof(MaintenanceBenchObject), recipe: this);
        }


        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPreInitialize();
        partial void ModsPostInitialize();
    }
    
    /// <summary>
    /// <para>Server side item definition for the "MaintenanceKit" item.</para>
    /// <para>More information about Item objects can be found at https://docs.play.eco/api/server/eco.gameplay/Eco.Gameplay.Items.Item.html</para>
    /// </summary>
    /// <remarks>
    /// This is an auto-generated class. Don't modify it! All your changes will be wiped with next update! Use Mods* partial methods instead for customization. 
    /// If you wish to modify this class, please create a new partial class or follow the instructions in the "UserCode" folder to override the entire file.
    /// </remarks>
    [Serialized] // Tells the save/load system this object needs to be serialized. 
    [LocDisplayName("Maintenance Kit")] // Defines the localized name of the item.
    [Weight(500)] // Defines how heavy MaintenanceKit is.
    [Fuel(2000)][Tag("Fuel")] // Marks MaintenanceKit as fuel item.
    [Tag("Currency")][Currency] // Defines if this item can be used to back a currency
    [Ecopedia("Items", "Products", createAsSubPage: true)]
    [Tag("Maintenance Kit")]
    [Tag("Burnable Fuel")]
    [LocDescription("A higher quality Maintenance Kit used for long lasting furniture.")] //The tooltip description for the item.
    public partial class MaintenanceKitItem : Item
    {


    }
}