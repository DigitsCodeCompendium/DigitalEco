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
    [BecomesRubble(typeof(BlackMarbleRubbleSet1Chunk1Object), typeof(BlackMarbleRubbleSet1Chunk2Object), typeof(BlackMarbleRubbleSet1Chunk3Object))]
    [BecomesRubble(typeof(BlackMarbleRubbleSet2Chunk1Object), typeof(BlackMarbleRubbleSet2Chunk2Object), typeof(BlackMarbleRubbleSet2Chunk3Object), typeof(BlackMarbleRubbleSet2Chunk4Object))]
    [BecomesRubble(typeof(BlackMarbleRubbleSet3Chunk1Object), typeof(BlackMarbleRubbleSet3Chunk2Object), typeof(BlackMarbleRubbleSet3Chunk3Object))]
    [BecomesRubble(typeof(BlackMarbleRubbleSet4Chunk1Object), typeof(BlackMarbleRubbleSet4Chunk2Object), typeof(BlackMarbleRubbleSet4Chunk3Object))]
    [Tag("Minable")]
    public partial class BlackMarbleBlock : Block { }

    [Serialized, Tag("FastPickupable")] public partial class BlackMarbleRubbleSet1Chunk1Object : RubbleObject<BlackMarbleItem> { }
    [Serialized, Tag("FastPickupable")] public partial class BlackMarbleRubbleSet1Chunk2Object : RubbleObject<BlackMarbleItem> { }

    [BecomesRubble(typeof(BlackMarbleRubbleSet1Chunk3Split1Object), typeof(BlackMarbleRubbleSet1Chunk3Split2Object)), Tag("MinableRubble")]
    [Serialized] public partial class BlackMarbleRubbleSet1Chunk3Object : RubbleObject<BlackMarbleItem> { }
    [Serialized, Tag("FastPickupable"), Tag("Pickupable")] public partial class BlackMarbleRubbleSet1Chunk3Split1Object : RubbleObject<BlackMarbleItem> { }
    [Serialized, Tag("FastPickupable"), Tag("Pickupable")] public partial class BlackMarbleRubbleSet1Chunk3Split2Object : RubbleObject<BlackMarbleItem> { }

    [Serialized, Tag("FastPickupable"), Tag("Pickupable")] public partial class BlackMarbleRubbleSet2Chunk1Object : RubbleObject<BlackMarbleItem> { }
    [Serialized, Tag("FastPickupable"), Tag("Pickupable")] public partial class BlackMarbleRubbleSet2Chunk2Object : RubbleObject<BlackMarbleItem> { }
    [Serialized, Tag("FastPickupable"), Tag("Pickupable")] public partial class BlackMarbleRubbleSet2Chunk3Object : RubbleObject<BlackMarbleItem> { }
    [Serialized, Tag("FastPickupable"), Tag("Pickupable")] public partial class BlackMarbleRubbleSet2Chunk4Object : RubbleObject<BlackMarbleItem> { }

    [Serialized, Tag("FastPickupable"), Tag("Pickupable")] public partial class BlackMarbleRubbleSet3Chunk1Object : RubbleObject<BlackMarbleItem> { }
    [Serialized, Tag("FastPickupable"), Tag("Pickupable")] public partial class BlackMarbleRubbleSet3Chunk2Object : RubbleObject<BlackMarbleItem> { }
    [BecomesRubble(typeof(BlackMarbleRubbleSet3Chunk3Split1Object), typeof(BlackMarbleRubbleSet3Chunk3Split2Object))]
    [Serialized, Tag("MinableRubble")] public partial class BlackMarbleRubbleSet3Chunk3Object : RubbleObject<BlackMarbleItem> { }
    [Serialized, Tag("FastPickupable"), Tag("Pickupable")] public partial class BlackMarbleRubbleSet3Chunk3Split1Object : RubbleObject<BlackMarbleItem> { }
    [Serialized, Tag("FastPickupable"), Tag("Pickupable")] public partial class BlackMarbleRubbleSet3Chunk3Split2Object : RubbleObject<BlackMarbleItem> { }

    [BecomesRubble(typeof(BlackMarbleRubbleSet4Chunk1Split1Object), typeof(BlackMarbleRubbleSet4Chunk1Split2Object))]
    [Serialized, Tag("MinableRubble")] public partial class BlackMarbleRubbleSet4Chunk1Object : RubbleObject<BlackMarbleItem> { }
    [Serialized, Tag("FastPickupable"), Tag("Pickupable")] public partial class BlackMarbleRubbleSet4Chunk1Split1Object : RubbleObject<BlackMarbleItem> { }
    [Serialized, Tag("FastPickupable"), Tag("Pickupable")] public partial class BlackMarbleRubbleSet4Chunk1Split2Object : RubbleObject<BlackMarbleItem> { }
    [Serialized, Tag("FastPickupable"), Tag("Pickupable")] public partial class BlackMarbleRubbleSet4Chunk2Object : RubbleObject<BlackMarbleItem> { }
    [Serialized, Tag("FastPickupable"), Tag("Pickupable")] public partial class BlackMarbleRubbleSet4Chunk3Object : RubbleObject<BlackMarbleItem> { }
}
