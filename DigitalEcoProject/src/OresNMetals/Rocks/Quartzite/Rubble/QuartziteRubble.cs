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
    [BecomesRubble(typeof(QuartziteRubbleSet1Chunk1Object), typeof(QuartziteRubbleSet1Chunk2Object), typeof(QuartziteRubbleSet1Chunk3Object))]
    [BecomesRubble(typeof(QuartziteRubbleSet2Chunk1Object), typeof(QuartziteRubbleSet2Chunk2Object), typeof(QuartziteRubbleSet2Chunk3Object), typeof(QuartziteRubbleSet2Chunk4Object))]
    [BecomesRubble(typeof(QuartziteRubbleSet3Chunk1Object), typeof(QuartziteRubbleSet3Chunk2Object), typeof(QuartziteRubbleSet3Chunk3Object))]
    [BecomesRubble(typeof(QuartziteRubbleSet4Chunk1Object), typeof(QuartziteRubbleSet4Chunk2Object), typeof(QuartziteRubbleSet4Chunk3Object))]
    [Tag("Minable")]
    public partial class QuartziteBlock : Block { }

    [Serialized, Tag("FastPickupable")] public partial class QuartziteRubbleSet1Chunk1Object : RubbleObject<QuartziteItem> { }
    [Serialized, Tag("FastPickupable")] public partial class QuartziteRubbleSet1Chunk2Object : RubbleObject<QuartziteItem> { }

    [BecomesRubble(typeof(QuartziteRubbleSet1Chunk3Split1Object), typeof(QuartziteRubbleSet1Chunk3Split2Object)), Tag("MinableRubble")]
    [Serialized] public partial class QuartziteRubbleSet1Chunk3Object : RubbleObject<QuartziteItem> { }
    [Serialized, Tag("FastPickupable"), Tag("Pickupable")] public partial class QuartziteRubbleSet1Chunk3Split1Object : RubbleObject<QuartziteItem> { }
    [Serialized, Tag("FastPickupable"), Tag("Pickupable")] public partial class QuartziteRubbleSet1Chunk3Split2Object : RubbleObject<QuartziteItem> { }

    [Serialized, Tag("FastPickupable"), Tag("Pickupable")] public partial class QuartziteRubbleSet2Chunk1Object : RubbleObject<QuartziteItem> { }
    [Serialized, Tag("FastPickupable"), Tag("Pickupable")] public partial class QuartziteRubbleSet2Chunk2Object : RubbleObject<QuartziteItem> { }
    [Serialized, Tag("FastPickupable"), Tag("Pickupable")] public partial class QuartziteRubbleSet2Chunk3Object : RubbleObject<QuartziteItem> { }
    [Serialized, Tag("FastPickupable"), Tag("Pickupable")] public partial class QuartziteRubbleSet2Chunk4Object : RubbleObject<QuartziteItem> { }

    [Serialized, Tag("FastPickupable"), Tag("Pickupable")] public partial class QuartziteRubbleSet3Chunk1Object : RubbleObject<QuartziteItem> { }
    [Serialized, Tag("FastPickupable"), Tag("Pickupable")] public partial class QuartziteRubbleSet3Chunk2Object : RubbleObject<QuartziteItem> { }
    [BecomesRubble(typeof(QuartziteRubbleSet3Chunk3Split1Object), typeof(QuartziteRubbleSet3Chunk3Split2Object))]
    [Serialized, Tag("MinableRubble")] public partial class QuartziteRubbleSet3Chunk3Object : RubbleObject<QuartziteItem> { }
    [Serialized, Tag("FastPickupable"), Tag("Pickupable")] public partial class QuartziteRubbleSet3Chunk3Split1Object : RubbleObject<QuartziteItem> { }
    [Serialized, Tag("FastPickupable"), Tag("Pickupable")] public partial class QuartziteRubbleSet3Chunk3Split2Object : RubbleObject<QuartziteItem> { }

    [BecomesRubble(typeof(QuartziteRubbleSet4Chunk1Split1Object), typeof(QuartziteRubbleSet4Chunk1Split2Object))]
    [Serialized, Tag("MinableRubble")] public partial class QuartziteRubbleSet4Chunk1Object : RubbleObject<QuartziteItem> { }
    [Serialized, Tag("FastPickupable"), Tag("Pickupable")] public partial class QuartziteRubbleSet4Chunk1Split1Object : RubbleObject<QuartziteItem> { }
    [Serialized, Tag("FastPickupable"), Tag("Pickupable")] public partial class QuartziteRubbleSet4Chunk1Split2Object : RubbleObject<QuartziteItem> { }
    [Serialized, Tag("FastPickupable"), Tag("Pickupable")] public partial class QuartziteRubbleSet4Chunk2Object : RubbleObject<QuartziteItem> { }
    [Serialized, Tag("FastPickupable"), Tag("Pickupable")] public partial class QuartziteRubbleSet4Chunk3Object : RubbleObject<QuartziteItem> { }
}
