namespace Digits.DE_Maintenance
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using Eco.Mods.TechTree;
    using Eco.Core.Items;
    using Eco.Gameplay.Blocks;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.Components.Auth;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Economy;
    using Eco.Gameplay.Housing;
    using Eco.Gameplay.Interactions;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Modules;
    using Eco.Gameplay.Minimap;
    using Eco.Gameplay.Objects;
    using Eco.Gameplay.Occupancy;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Property;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Gameplay.Pipes.LiquidComponents;
    using Eco.Gameplay.Pipes.Gases;
    using Eco.Shared;
    using Eco.Shared.Math;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    using Eco.Shared.View;
    using Eco.Shared.Items;
    using Eco.Shared.Networking;
    using Eco.Gameplay.Pipes;
    using Eco.World.Blocks;
    using Eco.Gameplay.Housing.PropertyValues;
    using Eco.Gameplay.Civics.Objects;
    using Eco.Gameplay.Settlements;
    using Eco.Gameplay.Systems.NewTooltip;
    using Eco.Core.Controller;
    using Eco.Core.Utils;
	using Eco.Gameplay.Components.Storage;
    using Eco.Gameplay.Items.Recipes;

    [Serialized]
    [RequireComponent(typeof(OnOffComponent))]
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(MinimapComponent))]
    [RequireComponent(typeof(LinkComponent))]
    [RequireComponent(typeof(CraftingComponent))]
    [RequireComponent(typeof(OccupancyRequirementComponent))]
    [RequireComponent(typeof(ForSaleComponent))]
    // [RequireComponent(typeof(EnumTestComponent))]
    [Tag("Usable")]
    [Ecopedia("Work Stations", "Craft Tables", subPageName: "Maintenance Bench Item")]
    public partial class MaintenanceBenchObject : WorldObject, IRepresentsItem
    {
        public virtual Type RepresentedItemType => typeof(MaintenanceBenchItem);
        public override LocString DisplayName => Localizer.DoStr("Maintenance Bench");
        public override TableTextureMode TableTexture => TableTextureMode.Wood;

        protected override void Initialize()
        {
            this.ModsPreInitialize();
            this.GetComponent<MinimapComponent>().SetCategory(Localizer.DoStr("Crafting"));
            this.ModsPostInitialize();
        }

        static MaintenanceBenchObject()
        {
            WorldObject.AddOccupancy<MaintenanceBenchObject>(new List<BlockOccupancy>(){
            new BlockOccupancy(new Vector3i(0, 0, 0))
            });
        }

        /// <summary>Hook for mods to customize WorldObject before initialization. You can change housing values here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize WorldObject after initialization.</summary>
        partial void ModsPostInitialize();
    }

    [Serialized]
    [LocDisplayName("Maintenance Bench")]
    [LocDescription("A bench for the basics and making even more benches.")]
    [IconGroup("World Object Minimap")]
    [Ecopedia("Work Stations", "Craft Tables", createAsSubPage: true)]
    [Weight(1000)] // Defines how heavy Maintenance Bench is.
    public partial class MaintenanceBenchItem : WorldObjectItem<MaintenanceBenchObject>, IPersistentData
    {
        protected override OccupancyContext GetOccupancyContext => new SideAttachedContext( 0  | DirectionAxisFlags.Down , WorldObject.GetOccupancyInfo(this.WorldObjectType));

        [Serialized, SyncToView, NewTooltipChildren(CacheAs.Instance, flags: TTFlags.AllowNonControllerTypeForChildren)] public object PersistentData { get; set; }
    }

    /// <summary>
    /// <para>Server side recipe definition for "Maintenance Bench".</para>
    /// <para>More information about RecipeFamily objects can be found at https://docs.play.eco/api/server/eco.gameplay/Eco.Gameplay.Items.RecipeFamily.html</para>
    /// </summary>
    /// <remarks>
    /// This is an auto-generated class. Don't modify it! All your changes will be wiped with next update! Use Mods* partial methods instead for customization. 
    /// If you wish to modify this class, please create a new partial class or follow the instructions in the "UserCode" folder to override the entire file.
    /// </remarks>
    [Ecopedia("Work Stations", "Craft Tables", subPageName: "Maintenance Bench Item")]
    public partial class MaintenanceBenchRecipe : RecipeFamily
    {
        public MaintenanceBenchRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                name: "MaintenanceBench",  //noloc
                displayName: Localizer.DoStr("Maintenance Bench"),

                // Defines the ingredients needed to craft this recipe. An ingredient items takes the following inputs
                // type of the item, the amount of the item, the skill required, and the talent used.
                ingredients: new List<IngredientElement>
                {
                    new IngredientElement("Wood", 10), //noloc
                },

                // Define our recipe output items.
                // For every output item there needs to be one CraftingElement entry with the type of the final item and the amount
                // to create.
                items: new List<CraftingElement>
                {
                    new CraftingElement<MaintenanceBenchItem>()
                });
            this.Recipes = new List<Recipe> { recipe };
            
            // Defines the amount of labor required and the required skill to add labor
            this.LaborInCalories = CreateLaborInCaloriesValue(30);

            // Defines our crafting time for the recipe
            this.CraftMinutes = CreateCraftTimeValue(0.5f);

            // Perform pre/post initialization for user mods and initialize our recipe instance with the display name "Maintenance Bench"
            this.ModsPreInitialize();
            this.Initialize(displayText: Localizer.DoStr("Maintenance Bench"), recipeType: typeof(MaintenanceBenchRecipe));
            this.ModsPostInitialize();

            // Register our RecipeFamily instance with the crafting system so it can be crafted.
            CraftingComponent.AddRecipe(tableType: typeof(WorkbenchObject), recipe: this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}
