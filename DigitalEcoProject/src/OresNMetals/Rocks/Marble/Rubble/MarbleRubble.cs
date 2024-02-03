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
    [BecomesRubble(typeof(MarbleRubbleSet1Chunk1Object), typeof(MarbleRubbleSet1Chunk2Object), typeof(MarbleRubbleSet1Chunk3Object))]
    [BecomesRubble(typeof(MarbleRubbleSet2Chunk1Object), typeof(MarbleRubbleSet2Chunk2Object), typeof(MarbleRubbleSet2Chunk3Object), typeof(MarbleRubbleSet2Chunk4Object))]
    [BecomesRubble(typeof(MarbleRubbleSet3Chunk1Object), typeof(MarbleRubbleSet3Chunk2Object), typeof(MarbleRubbleSet3Chunk3Object))]
    [BecomesRubble(typeof(MarbleRubbleSet4Chunk1Object), typeof(MarbleRubbleSet4Chunk2Object), typeof(MarbleRubbleSet4Chunk3Object))]
    [Tag("Minable")]
    public partial class MarbleBlock : Block { }

    [Serialized, Tag("FastPickupable")] public partial class MarbleRubbleSet1Chunk1Object : RubbleObject<MarbleItem> { }
    [Serialized, Tag("FastPickupable")] public partial class MarbleRubbleSet1Chunk2Object : RubbleObject<MarbleItem> { }

    [BecomesRubble(typeof(MarbleRubbleSet1Chunk3Split1Object), typeof(MarbleRubbleSet1Chunk3Split2Object)), Tag("MinableRubble")]
    [Serialized] public partial class MarbleRubbleSet1Chunk3Object : RubbleObject<MarbleItem> { }
    [Serialized, Tag("FastPickupable"), Tag("Pickupable")] public partial class MarbleRubbleSet1Chunk3Split1Object : RubbleObject<MarbleItem> { }
    [Serialized, Tag("FastPickupable"), Tag("Pickupable")] public partial class MarbleRubbleSet1Chunk3Split2Object : RubbleObject<MarbleItem> { }

    [Serialized, Tag("FastPickupable"), Tag("Pickupable")] public partial class MarbleRubbleSet2Chunk1Object : RubbleObject<MarbleItem> { }
    [Serialized, Tag("FastPickupable"), Tag("Pickupable")] public partial class MarbleRubbleSet2Chunk2Object : RubbleObject<MarbleItem> { }
    [Serialized, Tag("FastPickupable"), Tag("Pickupable")] public partial class MarbleRubbleSet2Chunk3Object : RubbleObject<MarbleItem> { }
    [Serialized, Tag("FastPickupable"), Tag("Pickupable")] public partial class MarbleRubbleSet2Chunk4Object : RubbleObject<MarbleItem> { }

    [Serialized, Tag("FastPickupable"), Tag("Pickupable")] public partial class MarbleRubbleSet3Chunk1Object : RubbleObject<MarbleItem> { }
    [Serialized, Tag("FastPickupable"), Tag("Pickupable")] public partial class MarbleRubbleSet3Chunk2Object : RubbleObject<MarbleItem> { }
    [BecomesRubble(typeof(MarbleRubbleSet3Chunk3Split1Object), typeof(MarbleRubbleSet3Chunk3Split2Object))]
    [Serialized, Tag("MinableRubble")] public partial class MarbleRubbleSet3Chunk3Object : RubbleObject<MarbleItem> { }
    [Serialized, Tag("FastPickupable"), Tag("Pickupable")] public partial class MarbleRubbleSet3Chunk3Split1Object : RubbleObject<MarbleItem> { }
    [Serialized, Tag("FastPickupable"), Tag("Pickupable")] public partial class MarbleRubbleSet3Chunk3Split2Object : RubbleObject<MarbleItem> { }

    [BecomesRubble(typeof(MarbleRubbleSet4Chunk1Split1Object), typeof(MarbleRubbleSet4Chunk1Split2Object))]
    [Serialized, Tag("MinableRubble")] public partial class MarbleRubbleSet4Chunk1Object : RubbleObject<MarbleItem> { }
    [Serialized, Tag("FastPickupable"), Tag("Pickupable")] public partial class MarbleRubbleSet4Chunk1Split1Object : RubbleObject<MarbleItem> { }
    [Serialized, Tag("FastPickupable"), Tag("Pickupable")] public partial class MarbleRubbleSet4Chunk1Split2Object : RubbleObject<MarbleItem> { }
    [Serialized, Tag("FastPickupable"), Tag("Pickupable")] public partial class MarbleRubbleSet4Chunk2Object : RubbleObject<MarbleItem> { }
    [Serialized, Tag("FastPickupable"), Tag("Pickupable")] public partial class MarbleRubbleSet4Chunk3Object : RubbleObject<MarbleItem> { }
}
