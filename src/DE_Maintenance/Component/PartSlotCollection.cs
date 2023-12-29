using Eco.Core.Controller;
using Eco.Core.Systems;
using Eco.Gameplay.Items;
using Eco.Shared.Networking;
using Eco.Shared.Serialization;
using System.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Linq;
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
using Eco.Gameplay.Utils;
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

namespace Digits.DE_Maintenance
{
    [Serialized]
    public class PartSlotCollection
    {
        public List<PartSlot> partSlots;

        public PartSlotCollection() 
        { 
            this.partSlots = new List<PartSlot>();
        }

        public void CreatePartSlot(string name, TagCollection tagCollection, Dictionary<string, float> slotDegradation)
        {
            this.partSlots.Add(new PartSlot(name, tagCollection, slotDegradation));
        }
    }

    //! Keep this here for reference of how to define
    // mComp.CreatePartSlot("Machine Frame", 
    //                      new TagCollection("Machine Frame", new string[] {"Tier 1", "Tier 2", "Tier 3"}),
    //                      new Dictionary<string, float>(){'onTick' = 0.1, 'onCraft' = 1, 'onTickWhileOn' = 1});
    //! End reference

    [Serialized]
    public class PartSlot
    {
        public string name {get;}
        public TagCollection tagCollection {get;}
        public Dictionary<string, float> slotDegadation {get;}

        public PartSlot(string name, TagCollection tagCollection, Dictionary<string, float> slotDegradation)
        {
            this.name = name;
            this.tagCollection = tagCollection;
            this.slotDegadation = slotDegadation;
        }
    }

    [Serialized]
    public class TagCollection
    {
        public Tag genericTag;
        public List<Tag> tierTags;

        public TagCollection(string genericTag_in, string[] tierTags_in)
        {
            this.tierTags = new List<Tag>();

            this.genericTag = TagManager.Tag(genericTag_in);
            foreach(string tierTag in tierTags_in)
            {
                this.tierTags.Add(TagManager.Tag(tierTag));
            }
        }
    }
}