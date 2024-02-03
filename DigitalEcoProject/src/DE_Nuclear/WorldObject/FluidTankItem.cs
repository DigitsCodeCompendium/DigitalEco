﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using Eco.Core.Items;
using Eco.Gameplay.Components;
using Eco.Gameplay.Components.Auth;
using Eco.Gameplay.Housing;
using Eco.Gameplay.Items;
using Eco.Gameplay.Objects;
using Eco.Gameplay.Occupancy;
using Eco.Gameplay.Skills;
using Eco.Gameplay.Systems.TextLinks;
using Eco.Shared.Math;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;
using Eco.Shared.Utils;
using Eco.Shared.Items;
using Eco.Gameplay.Housing.PropertyValues;
using Eco.Gameplay.Systems.NewTooltip;
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
    [RequireComponent(typeof(FluidTankComponent))]
    [RequireComponent(typeof(ForSaleComponent))] 
    [Tag("Usable")]
    public partial class FluidTankObject : WorldObject, IRepresentsItem
    {
        public virtual Type RepresentedItemType => typeof(FluidTankItem);
        public override LocString DisplayName => Localizer.DoStr("FluidTank");
        public override TableTextureMode TableTexture => TableTextureMode.Metal;

        protected override void Initialize()
        {                                      
            this.GetComponent<FluidTankComponent>().Initialize();
            this.GetComponent<FluidTankComponent>().Setup(typeof(WaterItem), BlockOccupancyType.WaterInputPort, BlockOccupancyType.OutputPort, 10f, 0f);

        }  
        
        static FluidTankObject()
        {
            WorldObject.AddOccupancy<FluidTankObject>(new List<BlockOccupancy>(){
            //new BlockOccupancy(new Vector3i(0, 0, 0)),
            new BlockOccupancy(new Vector3i(0, 0, 0), typeof(PipeSlotBlock), new Quaternion(0f, -0.7071068f, 0f, -0.7071068f), BlockOccupancyType.WaterInputPort),
            new BlockOccupancy(new Vector3i(0, 0, 0), typeof(PipeSlotBlock), new Quaternion(0f, -0.7071068f, 0f, 0.7071068f), BlockOccupancyType.OutputPort)
            });

        }

        partial void ModsPreInitialize();
        partial void ModsPostInitialize();
    }

    [Serialized]
    [LocDisplayName("FluidTank")]
    [LocDescription("")]
    //[Ecopedia("Crafted Objects", "Power Generation", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    [Weight(100)]
    public partial class FluidTankItem : WorldObjectItem<FluidTankObject>
    {
        protected override OccupancyContext GetOccupancyContext => new SideAttachedContext( 0  | DirectionAxisFlags.Down , WorldObject.GetOccupancyInfo(this.WorldObjectType));
        public override HomeFurnishingValue HomeValue => homeValue;
        public static readonly HomeFurnishingValue homeValue = new HomeFurnishingValue()
        {
            ObjectName               = typeof(FluidTankObject).UILink(),
            Category                 = HousingConfig.GetRoomCategory("Industrial"),
            TypeForRoomLimit         = Localizer.DoStr(""),
        };
    }

    [RequiresSkill(typeof(MechanicsSkill), 1)]
    public partial class FluidTankRecipe : RecipeFamily
    {
        public FluidTankRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                name: "FluidTank",
                displayName: Localizer.DoStr("FluidTank"),

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
                    new CraftingElement<FluidTankItem>()
                }
            );
            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 20f;  
            this.LaborInCalories = CreateLaborInCaloriesValue(3000);
            this.CraftMinutes = CreateCraftTimeValue(60f);

            this.ModsPreInitialize();
            this.Initialize(displayText: Localizer.DoStr("FluidTank"), recipeType: typeof(FluidTankRecipe));
            this.ModsPostInitialize();

        this.Initialize(Localizer.DoStr("FluidTank"), typeof(FluidTankRecipe));

        CraftingComponent.AddRecipe(typeof(RoboticAssemblyLineObject), this);
        }
        partial void ModsPreInitialize();
        partial void ModsPostInitialize();
    }
}