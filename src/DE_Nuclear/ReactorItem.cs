namespace Eco.Mods.TechTree
{
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

    [Serialized]
    //required components stolen from "steam engine.cs"
    [RequireComponent(typeof(AttachmentComponent))]
    [RequireComponent(typeof(OnOffComponent))]
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(MinimapComponent))]
    [RequireComponent(typeof(LinkComponent))]
    [RequireComponent(typeof(FuelSupplyComponent))]
    [RequireComponent(typeof(PluginModulesComponent))]
    [RequireComponent(typeof(FuelConsumptionComponent))]
    [RequireComponent(typeof(HousingComponent))]
    [RequireComponent(typeof(OccupancyRequirementComponent))]
    [RequireComponent(typeof(ReactorComponent))]
    [RequireComponent(typeof(ForSaleComponent))]
    [Tag("Usable")]

    public partial class ReactorObject : WorldObject, IRepresentsItem
    {
        public virtual Type RepresentedItemType => typeof(ReactorItem);
        public override LocString DisplayName => Localizer.DoStr("Nuclear Reactor");
        public override TableTextureMode TableTexture => TableTextureMode.Metal;

        private static string[] fuelTagList = new string[] { "Uranium Fuel" };

        protected override void Initialize()
        {
            this.ModsPreInitialize();
            this.GetComponent<MinimapComponent>().SetCategory(Localizer.DoStr("Power"));
            this.GetComponent<FuelSupplyComponent>().Initialize(2, fuelTagList);                            
            this.GetComponent<FuelConsumptionComponent>().Initialize(1000);                                         
            this.GetComponent<HousingComponent>().HomeValue = SteamEngineItem.homeValue;
            this.GetComponent<ReactorComponent>().Initialize(900, 400, 1);
            this.ModsPostInitialize();
        }

        static ReactorObject()
        {
            WorldObject.AddOccupancy<ReactorObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 0, 0)),
                //new BlockOccupancy(new Vector3i(1, 0, 0)),
                new BlockOccupancy(new Vector3i(1, 0, -1)),
                //new BlockOccupancy(new Vector3i(0, 0, -1)),

                new BlockOccupancy(new Vector3i(0, 1, 0)),
                new BlockOccupancy(new Vector3i(1, 1, 0)),
                new BlockOccupancy(new Vector3i(1, 1, -1)),
                new BlockOccupancy(new Vector3i(0, 1, -1)),

                new BlockOccupancy(new Vector3i(0, 2, 0)),
                new BlockOccupancy(new Vector3i(1, 2, 0)),
                new BlockOccupancy(new Vector3i(1, 2, -1)),
                new BlockOccupancy(new Vector3i(0, 2, -1)),

                new BlockOccupancy(new Vector3i(1, 0, 0), typeof(PipeSlotBlock), new Quaternion(0f, -0.7071068f, 0f, -0.7071068f), BlockOccupancyType.InputPort),
                new BlockOccupancy(new Vector3i(0, 0, -1), typeof(PipeSlotBlock), new Quaternion(0f, -0.7071068f, 0f, 0.7071068f), BlockOccupancyType.OutputPort)
            });
        }        

        partial void ModsPreInitialize();
        partial void ModsPostInitialize();
    }

    [Serialized]
    [LocDisplayName("Nuclear Reactor")]
    [LocDescription("We're all pretty sure the engineer just took a propane tank, stuffed it full of 'engineering' and pocketed the rest of the materials. Although he's promised us this baby can produce {Text.Info(10000)}w in steam power for a turbine.")]
    [IconGroup("World Object Minimap")]
    [AllowPluginModules(Tags = new[] {"AdvancedUpgrade"})]
    //[Ecopedia("Crafted Objects", "Power Generation", subPageName: "Nuclear Reactor Item")]
    [Weight(10000)]
    public partial class ReactorItem : WorldObjectItem<ReactorObject>, IPersistentData
    {
        protected override OccupancyContext GetOccupancyContext => new SideAttachedContext( 0  | DirectionAxisFlags.Down , WorldObject.GetOccupancyInfo(this.WorldObjectType));
        public override HomeFurnishingValue HomeValue => homeValue;
        public static readonly HomeFurnishingValue homeValue = new HomeFurnishingValue()
        {
            ObjectName          = typeof(ReactorObject).UILink(),
            Category            = HousingConfig.GetRoomCategory("Industrial"),
            TypeForRoomLimit    = Localizer.DoStr(""),
        };

        [NewTooltip(CacheAs.SubType, 7)] public static LocString PowerConsumptionTooltip() => Localizer.Do($"Consumes: {Text.Info(1000)}w of {new HeatPower().Name} power from fuel.");
        [Serialized, SyncToView, NewTooltipChildren(CacheAs.Instance, flags: TTFlags.AllowNonControllerTypeForChildren)] public object PersistentData { get; set; }
    }

    [RequiresSkill(typeof(MechanicsSkill), 5)]
    public partial class ReactorRecipe : RecipeFamily
    {
        public ReactorRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                name: "Reactor",  //noloc
                displayName: Localizer.DoStr("Reactor"),

                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(RadiatorItem), 5*2),              
                    new IngredientElement(typeof(ServoItem), 10*2),
                    new IngredientElement(typeof(RivetItem), 20*2),
                    new IngredientElement(typeof(AdvancedCircuitItem), 10*2),
                    new IngredientElement(typeof(SteelPipeItem), 30*2),
                    new IngredientElement(typeof(SteelPlateItem), 30*2),
                    new IngredientElement(typeof(CementItem), 50*2),
                },

                items: new List<CraftingElement>
                {
                    new CraftingElement<ReactorItem>()
                }
            );
            this.Recipes =  new List<Recipe> { recipe };
            this.ExperienceOnCraft = 20f;  
            this.LaborInCalories = CreateLaborInCaloriesValue(3000, typeof(MechanicsSkill));
            this.CraftMinutes = CreateCraftTimeValue(60f);

            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Reactor"), typeof(ReactorRecipe));
            this.ModsPostInitialize();

            CraftingComponent.AddRecipe(tableType: typeof(RoboticAssemblyLineObject), recipe: this);
        }
        partial void ModsPreInitialize();
        partial void ModsPostInitialize();
    }
}