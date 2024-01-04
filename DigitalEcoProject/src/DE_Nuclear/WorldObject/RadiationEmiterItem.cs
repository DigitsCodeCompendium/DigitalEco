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
using Eco.Gameplay.Items.Recipes;
using Eco.Mods.TechTree;

namespace Digits.Nuclear
{
    [Serialized]
    [RequireComponent(typeof(OnOffComponent))]
    [RequireComponent(typeof(RadiationEmitterComponent))]
    [Tag("Usable")]

    public partial class RadiationEmiterObject : WorldObject, IRepresentsItem
    {
        public virtual Type RepresentedItemType => typeof(ReactorItem);
        public override TableTextureMode TableTexture => TableTextureMode.Metal;


        protected override void Initialize()
        {
            this.ModsPreInitialize();
            this.GetComponent<RadiationEmitterComponent>().Initialize();
            this.ModsPostInitialize();
        }

        static RadiationEmiterObject()
        {
            WorldObject.AddOccupancy<ReactorObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 0, 0))
            });
        }        

        partial void ModsPreInitialize();
        partial void ModsPostInitialize();
    }

    [Serialized]
    public partial class RadiationEmiterItem : WorldObjectItem<RadiationEmiterObject>
    {
        protected override OccupancyContext GetOccupancyContext => new SideAttachedContext( 0  | DirectionAxisFlags.Down , WorldObject.GetOccupancyInfo(this.WorldObjectType));
    }
}