using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using static Eco.Gameplay.Housing.PropertyValues.HomeFurnishingValue;
using Eco.Gameplay.Items.Recipes;
using Eco.Mods.TechTree;

namespace Digits.Nuclear
{
    [Serialized]
    [RequireComponent(typeof(AttachmentComponent))]
    //[RequireComponent(typeof(OnOffComponent))]
    [RequireComponent(typeof(PropertyAuthComponent))]    
    [RequireComponent(typeof(HousingComponent))]   
    [RequireComponent(typeof(OccupancyRequirementComponent))]
    [RequireComponent(typeof(TurbineComponent))]
    [RequireComponent(typeof(ForSaleComponent))]
    [PowerGenerator(typeof(ElectricPower))]   
    [Tag("Usable")]
    public partial class SteamTurbineObject : WorldObject, IRepresentsItem
    {
        public virtual Type RepresentedItemType => typeof(SteamTurbineItem);
        public override LocString DisplayName => Localizer.DoStr("Steam Turbine");
        public override TableTextureMode TableTexture => TableTextureMode.Metal;

        protected override void Initialize()
        {                                      
            this.GetComponent<TurbineComponent>().Initialize(1000, 1, 0.5f);
        }  
        
        static SteamTurbineObject()
        {
            WorldObject.AddOccupancy<SteamTurbineObject>(new List<BlockOccupancy>(){
            //new BlockOccupancy(new Vector3i(0, 0, 0)),
            new BlockOccupancy(new Vector3i(0, 0, -1)),
            new BlockOccupancy(new Vector3i(1, 0, 0)),
            new BlockOccupancy(new Vector3i(1, 0, -1)),
            new BlockOccupancy(new Vector3i(2, 0, 0)),
            new BlockOccupancy(new Vector3i(2, 0, -1)),
            //new BlockOccupancy(new Vector3i(3, 0, 0)),
            new BlockOccupancy(new Vector3i(3, 0, -1)),

            new BlockOccupancy(new Vector3i(0, 1, 0)),
            new BlockOccupancy(new Vector3i(0, 1, -1)),
            new BlockOccupancy(new Vector3i(1, 1, 0)),
            new BlockOccupancy(new Vector3i(1, 1, -1)),
            new BlockOccupancy(new Vector3i(2, 1, 0)),
            new BlockOccupancy(new Vector3i(2, 1, -1)),
            new BlockOccupancy(new Vector3i(3, 1, 0)),
            new BlockOccupancy(new Vector3i(3, 1, -1)),

            new BlockOccupancy(new Vector3i(0, 0, 0), typeof(PipeSlotBlock), new Quaternion(0f, 0f, 0f, 1f), BlockOccupancyType.WaterInputPort),
            new BlockOccupancy(new Vector3i(3, 0, 0), typeof(PipeSlotBlock), new Quaternion(0f, 0f, 0f, 1f), BlockOccupancyType.OutputPort),
            });

        }

        partial void ModsPreInitialize();
        partial void ModsPostInitialize();
    }

    [Serialized]
    [LocDisplayName("Steam Turbine")]
    [LocDescription("A complicated piece of machinery made to turn steam power into {new ElectricPower().Name}. This unit can handle up to {Text.Info(10000)}w, the amount produced by a small nuclear reactor.")]
    //[Ecopedia("Crafted Objects", "Power Generation", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    [Weight(100)]
    public partial class SteamTurbineItem : WorldObjectItem<SteamTurbineObject>
    {
        protected override OccupancyContext GetOccupancyContext => new SideAttachedContext( 0  | DirectionAxisFlags.Down , WorldObject.GetOccupancyInfo(this.WorldObjectType));
        public override HomeFurnishingValue HomeValue => homeValue;
        public static readonly HomeFurnishingValue homeValue = new HomeFurnishingValue()
        {
            ObjectName               = typeof(SteamTurbineObject).UILink(),
            Category                 = HousingConfig.GetRoomCategory("Industrial"),
            TypeForRoomLimit         = Localizer.DoStr(""),
        };

        [NewTooltip(CacheAs.SubType, 7)] public static LocString PowerConsumptionTooltip() => Localizer.Do($"Consumes: {Text.Info(10000)}w of steam power");
        [NewTooltip(CacheAs.SubType, 8)] public static LocString PowerProductionTooltip()  => Localizer.Do($"Produces: {Text.Info(10000)}w of {new ElectricPower().Name} power (electricity)");          
    }

    [RequiresSkill(typeof(MechanicsSkill), 1)]
    public partial class SteamTurbineRecipe : RecipeFamily
    {
        public SteamTurbineRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                name: "SteamTurbine",
                displayName: Localizer.DoStr("Steam Turbine"),

                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(SteelAxleItem), 5*2), 
                    new IngredientElement(typeof(SteelGearboxItem), 5*2),                 
                    new IngredientElement(typeof(SteelPipeItem), 10*2),
                    new IngredientElement(typeof(RadiatorItem), 10*2),
                    new IngredientElement(typeof(AdvancedCircuitItem), 10*2),
                    new IngredientElement(typeof(SteelPlateItem), 30*2),
                    new IngredientElement(typeof(CementItem), 50*2),
                },

                items: new List<CraftingElement>
                {
                    new CraftingElement<SteamTurbineItem>()
                }
            );
            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 20f;  
            this.LaborInCalories = CreateLaborInCaloriesValue(3000);
            this.CraftMinutes = CreateCraftTimeValue(60f);

            this.ModsPreInitialize();
            this.Initialize(displayText: Localizer.DoStr("Steam Turbine"), recipeType: typeof(SteamTurbineRecipe));
            this.ModsPostInitialize();

        this.Initialize(Localizer.DoStr("SteamTurbine"), typeof(SteamTurbineRecipe));

        CraftingComponent.AddRecipe(typeof(RoboticAssemblyLineObject), this);
        }
        partial void ModsPreInitialize();
        partial void ModsPostInitialize();
    }
}