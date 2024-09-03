using System;
using System.Collections.Generic;
using System.ComponentModel;
using Eco.Mods.TechTree;
using Eco.Core.Items;
using Eco.Gameplay.Components;
using Eco.Gameplay.Components.Auth;
using Eco.Gameplay.Items;
using Eco.Gameplay.Objects;
using Eco.Gameplay.Occupancy;
using Eco.Gameplay.Systems.TextLinks;
using Eco.Shared.Math;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;
using Eco.Shared.Items;
using Eco.Gameplay.Systems.NewTooltip;
using Eco.Core.Controller;
using Eco.Gameplay.Items.Recipes;
using Eco.Gameplay.Housing;
using Eco.Gameplay.Property;
using static Eco.Gameplay.Components.PartsComponent;
using Eco.Gameplay.Modules;
using Eco.Gameplay.Housing.PropertyValues;
using Eco.Shared.Utils;

namespace Eco.Mods.TechTree
{
    [Serialized]
    [RequireComponent(typeof(OnOffComponent))]
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(MinimapComponent))]
    [RequireComponent(typeof(LinkComponent))]
    [RequireComponent(typeof(CraftingComponent))]
    [RequireComponent(typeof(HousingComponent))]
    [RequireComponent(typeof(OccupancyRequirementComponent))]
    [RequireComponent(typeof(PluginModulesComponent))]
    [RequireComponent(typeof(ForSaleComponent))]
    [RequireComponent(typeof(RoomRequirementsComponent))]
    [RequireComponent(typeof(PartsComponent))]
    [RequireComponent(typeof(PowerGridComponent))]
    [RequireComponent(typeof(PowerConsumptionComponent))]
    [RequireRoomContainment]
    [RequireRoomVolume(120)]
    [RequireRoomMaterialTier(3.0f, typeof(AdvancedSmeltingFrugalReqTalent), typeof(AdvancedSmeltingLavishReqTalent))]
    [Tag("Usable")]
    [Ecopedia("Work Stations", "Craft Tables", subPageName: "Electrolyser Item")]
    public partial class ElectrolyserObject : WorldObject, IRepresentsItem
    {
        public virtual Type RepresentedItemType => typeof(ElectrolyserItem);
        public override LocString DisplayName => Localizer.DoStr("Electrolyser");
        public override TableTextureMode TableTexture => TableTextureMode.Metal;

        protected override void Initialize()
        {
            this.ModsPreInitialize();
            this.GetComponent<PartsComponent>().Config(() => this.GetComponent<CraftingComponent>().DecayDescription, new PartInfo[]
            {
                new() { TypeName = nameof(ServoItem), Quantity = 1},
            });
            this.GetComponent<MinimapComponent>().SetCategory(Localizer.DoStr("Crafting"));
            this.GetComponent<PowerConsumptionComponent>().Initialize(10000);
            this.GetComponent<PowerGridComponent>().Initialize(10, new ElectricPower());
            this.GetComponent<HousingComponent>().HomeValue = RoboticAssemblyLineItem.homeValue;
            this.ModsPostInitialize();
        }

        static ElectrolyserObject()
        {
            WorldObject.AddOccupancy<ElectrolyserObject>(new List<BlockOccupancy>(){
            new BlockOccupancy(new Vector3i(0, 0, 0))
            });
        }

        /// <summary>Hook for mods to customize WorldObject before initialization. You can change housing values here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize WorldObject after initialization.</summary>
        partial void ModsPostInitialize();
    }

    [Serialized]
    [LocDisplayName("Electrolyser")]
    [LocDescription("A machine that performs electrolysis")]
    [IconGroup("World Object Minimap")]
    [Ecopedia("Work Stations", "Craft Tables", createAsSubPage: true)]
    [Weight(10000)] // Defines how heavy Maintenance Bench is.
    [AllowPluginModules(Tags = new[] { "ModernUpgrade" }, ItemTypes = new[] { typeof(AdvancedSmeltingUpgradeItem) })] //noloc
    public partial class ElectrolyserItem : WorldObjectItem<ElectrolyserObject>, IPersistentData
    {
        protected override OccupancyContext GetOccupancyContext => new SideAttachedContext(0 | DirectionAxisFlags.Down, WorldObject.GetOccupancyInfo(this.WorldObjectType));
        public override HomeFurnishingValue HomeValue => homeValue;
        public static readonly HomeFurnishingValue homeValue = new HomeFurnishingValue()
        {
            ObjectName = typeof(RoboticAssemblyLineObject).UILink(),
            Category = HousingConfig.GetRoomCategory("Industrial"),
            TypeForRoomLimit = Localizer.DoStr(""),

        };

        [NewTooltip(CacheAs.SubType, 7)] public static LocString PowerConsumptionTooltip() => Localizer.Do($"Consumes: {Text.Info(6000)}w of {new ElectricPower().Name} power.");
        [Serialized, SyncToView, NewTooltipChildren(CacheAs.Instance, flags: TTFlags.AllowNonControllerTypeForChildren)] public object PersistentData { get; set; }
    }
}
