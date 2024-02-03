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
    [BecomesRubble(typeof(BlueschistRubbleSet1Chunk1Object), typeof(BlueschistRubbleSet1Chunk2Object), typeof(BlueschistRubbleSet1Chunk3Object))]
    [BecomesRubble(typeof(BlueschistRubbleSet2Chunk1Object), typeof(BlueschistRubbleSet2Chunk2Object), typeof(BlueschistRubbleSet2Chunk3Object), typeof(BlueschistRubbleSet2Chunk4Object))]
    [BecomesRubble(typeof(BlueschistRubbleSet3Chunk1Object), typeof(BlueschistRubbleSet3Chunk2Object), typeof(BlueschistRubbleSet3Chunk3Object))]
    [BecomesRubble(typeof(BlueschistRubbleSet4Chunk1Object), typeof(BlueschistRubbleSet4Chunk2Object), typeof(BlueschistRubbleSet4Chunk3Object))]
    [Tag("Minable")]
    public partial class BlueschistBlock : Block { }

    [Serialized, Tag("FastPickupable")] public partial class BlueschistRubbleSet1Chunk1Object : RubbleObject<BlueschistItem> { }
    [Serialized, Tag("FastPickupable")] public partial class BlueschistRubbleSet1Chunk2Object : RubbleObject<BlueschistItem> { }

    [BecomesRubble(typeof(BlueschistRubbleSet1Chunk3Split1Object), typeof(BlueschistRubbleSet1Chunk3Split2Object)), Tag("MinableRubble")]
    [Serialized] public partial class BlueschistRubbleSet1Chunk3Object : RubbleObject<BlueschistItem> { }
    [Serialized, Tag("FastPickupable"), Tag("Pickupable")] public partial class BlueschistRubbleSet1Chunk3Split1Object : RubbleObject<BlueschistItem> { }
    [Serialized, Tag("FastPickupable"), Tag("Pickupable")] public partial class BlueschistRubbleSet1Chunk3Split2Object : RubbleObject<BlueschistItem> { }

    [Serialized, Tag("FastPickupable"), Tag("Pickupable")] public partial class BlueschistRubbleSet2Chunk1Object : RubbleObject<BlueschistItem> { }
    [Serialized, Tag("FastPickupable"), Tag("Pickupable")] public partial class BlueschistRubbleSet2Chunk2Object : RubbleObject<BlueschistItem> { }
    [Serialized, Tag("FastPickupable"), Tag("Pickupable")] public partial class BlueschistRubbleSet2Chunk3Object : RubbleObject<BlueschistItem> { }
    [Serialized, Tag("FastPickupable"), Tag("Pickupable")] public partial class BlueschistRubbleSet2Chunk4Object : RubbleObject<BlueschistItem> { }

    [Serialized, Tag("FastPickupable"), Tag("Pickupable")] public partial class BlueschistRubbleSet3Chunk1Object : RubbleObject<BlueschistItem> { }
    [Serialized, Tag("FastPickupable"), Tag("Pickupable")] public partial class BlueschistRubbleSet3Chunk2Object : RubbleObject<BlueschistItem> { }
    [BecomesRubble(typeof(BlueschistRubbleSet3Chunk3Split1Object), typeof(BlueschistRubbleSet3Chunk3Split2Object))]
    [Serialized, Tag("MinableRubble")] public partial class BlueschistRubbleSet3Chunk3Object : RubbleObject<BlueschistItem> { }
    [Serialized, Tag("FastPickupable"), Tag("Pickupable")] public partial class BlueschistRubbleSet3Chunk3Split1Object : RubbleObject<BlueschistItem> { }
    [Serialized, Tag("FastPickupable"), Tag("Pickupable")] public partial class BlueschistRubbleSet3Chunk3Split2Object : RubbleObject<BlueschistItem> { }

    [BecomesRubble(typeof(BlueschistRubbleSet4Chunk1Split1Object), typeof(BlueschistRubbleSet4Chunk1Split2Object))]
    [Serialized, Tag("MinableRubble")] public partial class BlueschistRubbleSet4Chunk1Object : RubbleObject<BlueschistItem> { }
    [Serialized, Tag("FastPickupable"), Tag("Pickupable")] public partial class BlueschistRubbleSet4Chunk1Split1Object : RubbleObject<BlueschistItem> { }
    [Serialized, Tag("FastPickupable"), Tag("Pickupable")] public partial class BlueschistRubbleSet4Chunk1Split2Object : RubbleObject<BlueschistItem> { }
    [Serialized, Tag("FastPickupable"), Tag("Pickupable")] public partial class BlueschistRubbleSet4Chunk2Object : RubbleObject<BlueschistItem> { }
    [Serialized, Tag("FastPickupable"), Tag("Pickupable")] public partial class BlueschistRubbleSet4Chunk3Object : RubbleObject<BlueschistItem> { }
}
