using Eco.Core.Controller;
using Eco.Core.Systems;
using Eco.Gameplay.Items;
using Eco.Shared.Serialization;
using System.Collections;
using System.Collections.Generic;


namespace Digits.PartSlotting
{
    [Serialized]
    public class PartSlotCollection
    {
        public List<PartSlot> partSlots;

        public PartSlotCollection()
        {
            this.partSlots = new List<PartSlot>();
        }

        public void CreatePartSlot(string name, TagCollection tagCollection)
        {
            this.partSlots.Add(new PartSlot(name, tagCollection));
        }
    }

    //! Keep this here for reference of how to define
    // mComp.CreatePartSlot("Machine Frame", 
    //                      new TagCollection("Machine Frame", new string[] {"Tier 1", "Tier 2", "Tier 3"}));


    //                      new Dictionary<string, float>(){'onTick' = 0.1, 'onCraft' = 1, 'onTickWhileOn' = 1}
    //! End reference

    [Serialized]
    public class PartSlot
    {
        public string name { get; }
        public TagCollection tagCollection { get; }

        public PartSlot(string name, TagCollection tagCollection)
        {
            this.name = name;
            this.tagCollection = tagCollection;
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
            foreach (string tierTag in tierTags_in)
            {
                this.tierTags.Add(TagManager.Tag(tierTag));
            }
        }
    }
}