using Eco.Core.Items;
using Eco.Gameplay.Objects;
using Eco.Shared.Serialization;
using Eco.World.Blocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eco.Mods.TechTree
{
    [BecomesRubble(typeof(SlateRubbleSet1Chunk1Object), typeof(SlateRubbleSet1Chunk2Object), typeof(SlateRubbleSet1Chunk3Object))]
    [BecomesRubble(typeof(SlateRubbleSet2Chunk1Object), typeof(SlateRubbleSet2Chunk2Object), typeof(SlateRubbleSet2Chunk3Object), typeof(SlateRubbleSet2Chunk4Object))]
    [BecomesRubble(typeof(SlateRubbleSet3Chunk1Object), typeof(SlateRubbleSet3Chunk2Object), typeof(SlateRubbleSet3Chunk3Object))]
    [BecomesRubble(typeof(SlateRubbleSet4Chunk1Object), typeof(SlateRubbleSet4Chunk2Object), typeof(SlateRubbleSet4Chunk3Object))]
    [Tag("Minable")]
    public partial class SlateBlock : Block { }

    [Serialized, Tag("FastPickupable")] public partial class SlateRubbleSet1Chunk1Object : RubbleObject<SlateItem> { }
    [Serialized, Tag("FastPickupable")] public partial class SlateRubbleSet1Chunk2Object : RubbleObject<SlateItem> { }

    [BecomesRubble(typeof(SlateRubbleSet1Chunk3Split1Object), typeof(SlateRubbleSet1Chunk3Split2Object)), Tag("MinableRubble")]
    [Serialized] public partial class SlateRubbleSet1Chunk3Object : RubbleObject<SlateItem> { }
    [Serialized, Tag("FastPickupable"), Tag("Pickupable")] public partial class SlateRubbleSet1Chunk3Split1Object : RubbleObject<SlateItem> { }
    [Serialized, Tag("FastPickupable"), Tag("Pickupable")] public partial class SlateRubbleSet1Chunk3Split2Object : RubbleObject<SlateItem> { }

    [Serialized, Tag("FastPickupable"), Tag("Pickupable")] public partial class SlateRubbleSet2Chunk1Object : RubbleObject<SlateItem> { }
    [Serialized, Tag("FastPickupable"), Tag("Pickupable")] public partial class SlateRubbleSet2Chunk2Object : RubbleObject<SlateItem> { }
    [Serialized, Tag("FastPickupable"), Tag("Pickupable")] public partial class SlateRubbleSet2Chunk3Object : RubbleObject<SlateItem> { }
    [Serialized, Tag("FastPickupable"), Tag("Pickupable")] public partial class SlateRubbleSet2Chunk4Object : RubbleObject<SlateItem> { }

    [Serialized, Tag("FastPickupable"), Tag("Pickupable")] public partial class SlateRubbleSet3Chunk1Object : RubbleObject<SlateItem> { }
    [Serialized, Tag("FastPickupable"), Tag("Pickupable")] public partial class SlateRubbleSet3Chunk2Object : RubbleObject<SlateItem> { }
    [BecomesRubble(typeof(SlateRubbleSet3Chunk3Split1Object), typeof(SlateRubbleSet3Chunk3Split2Object))]
    [Serialized, Tag("MinableRubble")] public partial class SlateRubbleSet3Chunk3Object : RubbleObject<SlateItem> { }
    [Serialized, Tag("FastPickupable"), Tag("Pickupable")] public partial class SlateRubbleSet3Chunk3Split1Object : RubbleObject<SlateItem> { }
    [Serialized, Tag("FastPickupable"), Tag("Pickupable")] public partial class SlateRubbleSet3Chunk3Split2Object : RubbleObject<SlateItem> { }

    [BecomesRubble(typeof(SlateRubbleSet4Chunk1Split1Object), typeof(SlateRubbleSet4Chunk1Split2Object))]
    [Serialized, Tag("MinableRubble")] public partial class SlateRubbleSet4Chunk1Object : RubbleObject<SlateItem> { }
    [Serialized, Tag("FastPickupable"), Tag("Pickupable")] public partial class SlateRubbleSet4Chunk1Split1Object : RubbleObject<SlateItem> { }
    [Serialized, Tag("FastPickupable"), Tag("Pickupable")] public partial class SlateRubbleSet4Chunk1Split2Object : RubbleObject<SlateItem> { }
    [Serialized, Tag("FastPickupable"), Tag("Pickupable")] public partial class SlateRubbleSet4Chunk2Object : RubbleObject<SlateItem> { }
    [Serialized, Tag("FastPickupable"), Tag("Pickupable")] public partial class SlateRubbleSet4Chunk3Object : RubbleObject<SlateItem> { }
}
