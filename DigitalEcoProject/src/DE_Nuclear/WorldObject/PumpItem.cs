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
    [RequireComponent(typeof(AdvancedPumpComponent))]
    [RequireComponent(typeof(ForSaleComponent))]  
    [Tag("Usable")]
    public partial class PumpObject : WorldObject, IRepresentsItem
    {
        public virtual Type RepresentedItemType => typeof(PumpItem);
        public override LocString DisplayName => Localizer.DoStr("Pump");
        public override TableTextureMode TableTexture => TableTextureMode.Metal;

        protected override void Initialize()
        {                                      
            this.GetComponent<AdvancedPumpComponent>().Initialize();
        }  
        
        static PumpObject()
        {
            WorldObject.AddOccupancy<PumpObject>(new List<BlockOccupancy>(){
            //new BlockOccupancy(new Vector3i(0, 0, 0)),
            new BlockOccupancy(new Vector3i(0, 0, 0), typeof(PipeSlotBlock), new Quaternion(0f, -0.7071068f, 0f, -0.7071068f), BlockOccupancyType.WaterInputPort),
            new BlockOccupancy(new Vector3i(0, 0, 0), typeof(PipeSlotBlock), new Quaternion(0f, -0.7071068f, 0f, 0.7071068f), BlockOccupancyType.OutputPort)
            });

        }

        partial void ModsPreInitialize();
        partial void ModsPostInitialize();
    }

    [Serialized]
    [LocDisplayName("Pump")]
    [LocDescription("")]
    //[Ecopedia("Crafted Objects", "Power Generation", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    [Weight(100)]
    public partial class PumpItem : WorldObjectItem<PumpObject>
    {
        protected override OccupancyContext GetOccupancyContext => new SideAttachedContext( 0  | DirectionAxisFlags.Down , WorldObject.GetOccupancyInfo(this.WorldObjectType));
        public override HomeFurnishingValue HomeValue => homeValue;
        public static readonly HomeFurnishingValue homeValue = new HomeFurnishingValue()
        {
            ObjectName               = typeof(PumpObject).UILink(),
            Category                 = HousingConfig.GetRoomCategory("Industrial"),
            TypeForRoomLimit         = Localizer.DoStr(""),
        };
    }

    [RequiresSkill(typeof(MechanicsSkill), 1)]
    public partial class PumpRecipe : RecipeFamily
    {
        public PumpRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                name: "Pump",
                displayName: Localizer.DoStr("Pump"),

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
                    new CraftingElement<PumpItem>()
                }
            );
            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 20f;  
            this.LaborInCalories = CreateLaborInCaloriesValue(3000);
            this.CraftMinutes = CreateCraftTimeValue(60f);

            this.ModsPreInitialize();
            this.Initialize(displayText: Localizer.DoStr("Pump"), recipeType: typeof(PumpRecipe));
            this.ModsPostInitialize();

        this.Initialize(Localizer.DoStr("Pump"), typeof(PumpRecipe));

        CraftingComponent.AddRecipe(typeof(RoboticAssemblyLineObject), this);
        }
        partial void ModsPreInitialize();
        partial void ModsPostInitialize();
    }
}