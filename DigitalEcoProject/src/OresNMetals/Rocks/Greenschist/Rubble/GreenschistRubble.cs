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
    [BecomesRubble(typeof(GreenschistRubbleSet1Chunk1Object), typeof(GreenschistRubbleSet1Chunk2Object), typeof(GreenschistRubbleSet1Chunk3Object))]
    [BecomesRubble(typeof(GreenschistRubbleSet2Chunk1Object), typeof(GreenschistRubbleSet2Chunk2Object), typeof(GreenschistRubbleSet2Chunk3Object), typeof(GreenschistRubbleSet2Chunk4Object))]
    [BecomesRubble(typeof(GreenschistRubbleSet3Chunk1Object), typeof(GreenschistRubbleSet3Chunk2Object), typeof(GreenschistRubbleSet3Chunk3Object))]
    [BecomesRubble(typeof(GreenschistRubbleSet4Chunk1Object), typeof(GreenschistRubbleSet4Chunk2Object), typeof(GreenschistRubbleSet4Chunk3Object))]
    [Tag("Minable")]
    public partial class GreenschistBlock : Block { }

    [Serialized, Tag("FastPickupable")] public partial class GreenschistRubbleSet1Chunk1Object : RubbleObject<GreenschistItem> { }
    [Serialized, Tag("FastPickupable")] public partial class GreenschistRubbleSet1Chunk2Object : RubbleObject<GreenschistItem> { }

    [BecomesRubble(typeof(GreenschistRubbleSet1Chunk3Split1Object), typeof(GreenschistRubbleSet1Chunk3Split2Object)), Tag("MinableRubble")]
    [Serialized] public partial class GreenschistRubbleSet1Chunk3Object : RubbleObject<GreenschistItem> { }
    [Serialized, Tag("FastPickupable"), Tag("Pickupable")] public partial class GreenschistRubbleSet1Chunk3Split1Object : RubbleObject<GreenschistItem> { }
    [Serialized, Tag("FastPickupable"), Tag("Pickupable")] public partial class GreenschistRubbleSet1Chunk3Split2Object : RubbleObject<GreenschistItem> { }

    [Serialized, Tag("FastPickupable"), Tag("Pickupable")] public partial class GreenschistRubbleSet2Chunk1Object : RubbleObject<GreenschistItem> { }
    [Serialized, Tag("FastPickupable"), Tag("Pickupable")] public partial class GreenschistRubbleSet2Chunk2Object : RubbleObject<GreenschistItem> { }
    [Serialized, Tag("FastPickupable"), Tag("Pickupable")] public partial class GreenschistRubbleSet2Chunk3Object : RubbleObject<GreenschistItem> { }
    [Serialized, Tag("FastPickupable"), Tag("Pickupable")] public partial class GreenschistRubbleSet2Chunk4Object : RubbleObject<GreenschistItem> { }

    [Serialized, Tag("FastPickupable"), Tag("Pickupable")] public partial class GreenschistRubbleSet3Chunk1Object : RubbleObject<GreenschistItem> { }
    [Serialized, Tag("FastPickupable"), Tag("Pickupable")] public partial class GreenschistRubbleSet3Chunk2Object : RubbleObject<GreenschistItem> { }
    [BecomesRubble(typeof(GreenschistRubbleSet3Chunk3Split1Object), typeof(GreenschistRubbleSet3Chunk3Split2Object))]
    [Serialized, Tag("MinableRubble")] public partial class GreenschistRubbleSet3Chunk3Object : RubbleObject<GreenschistItem> { }
    [Serialized, Tag("FastPickupable"), Tag("Pickupable")] public partial class GreenschistRubbleSet3Chunk3Split1Object : RubbleObject<GreenschistItem> { }
    [Serialized, Tag("FastPickupable"), Tag("Pickupable")] public partial class GreenschistRubbleSet3Chunk3Split2Object : RubbleObject<GreenschistItem> { }

    [BecomesRubble(typeof(GreenschistRubbleSet4Chunk1Split1Object), typeof(GreenschistRubbleSet4Chunk1Split2Object))]
    [Serialized, Tag("MinableRubble")] public partial class GreenschistRubbleSet4Chunk1Object : RubbleObject<GreenschistItem> { }
    [Serialized, Tag("FastPickupable"), Tag("Pickupable")] public partial class GreenschistRubbleSet4Chunk1Split1Object : RubbleObject<GreenschistItem> { }
    [Serialized, Tag("FastPickupable"), Tag("Pickupable")] public partial class GreenschistRubbleSet4Chunk1Split2Object : RubbleObject<GreenschistItem> { }
    [Serialized, Tag("FastPickupable"), Tag("Pickupable")] public partial class GreenschistRubbleSet4Chunk2Object : RubbleObject<GreenschistItem> { }
    [Serialized, Tag("FastPickupable"), Tag("Pickupable")] public partial class GreenschistRubbleSet4Chunk3Object : RubbleObject<GreenschistItem> { }
}
