using Eco.Core.Controller;
using Eco.Gameplay.Components;
using Eco.Gameplay.Components.Auth;
using Eco.Gameplay.Components.Storage;
using Eco.Gameplay.Items;
using Eco.Gameplay.Objects;
using Eco.Gameplay.Occupancy;
using Eco.Gameplay.Systems.NewTooltip;
using Eco.Mods.TechTree;
using Eco.Shared.Items;
using Eco.Shared.Math;
using Eco.Shared.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eco.Mods.TechTree
{
    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(LinkComponent))]
    [RequireComponent(typeof(OnOffComponent))]
    //[RequireComponent(typeof(FabricatingComponent))]
    [RequireComponent(typeof(EngineeringComponent))]
    [RequireComponent(typeof(PublicStorageComponent))]
    public class TestBenchObject : WorldObject, IRepresentsItem
    {
        public virtual Type RepresentedItemType => typeof(TestBenchItem);

        protected override void Initialize()
        {
            //this.GetComponent<FabricatingComponent>().Initialize();
            //this.GetComponent<EngineeringComponent>().Initialize();
            var storage = this.GetComponent<PublicStorageComponent>();
            storage.Initialize(16);
            storage.Storage.AddInvRestriction(new NotCarriedRestriction()); // can't store block or large items
            this.GetComponent<EngineeringComponent>().Initialize(-0.1, 0.1);
        }

        static TestBenchObject()
        {
            WorldObject.AddOccupancy<TestBenchObject>(new List<BlockOccupancy>(){
            new BlockOccupancy(new Vector3i(0, 0, 0))
            });
        }
    }

    [Serialized]
    [Weight(1000)] // Defines how heavy Maintenance Bench is.
    public partial class TestBenchItem : WorldObjectItem<TestBenchObject>, IPersistentData
    {
        protected override OccupancyContext GetOccupancyContext => new SideAttachedContext(0 | DirectionAxisFlags.Down, WorldObject.GetOccupancyInfo(this.WorldObjectType));

        [Serialized, SyncToView, NewTooltipChildren(CacheAs.Instance, flags: TTFlags.AllowNonControllerTypeForChildren)] public object PersistentData { get; set; }
    }
}