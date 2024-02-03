using Eco.Core.Items;
using Eco.Gameplay.Objects;
using Eco.Shared.Serialization;
using Eco.World.Blocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Vector3 = System.Numerics.Vector3;

namespace Eco.Mods.TechTree
{
    [BecomesRubble(typeof(CryoliteOreRubbleSet1Chunk1Object), typeof(CryoliteOreRubbleSet1Chunk2Object), typeof(CryoliteOreRubbleSet1Chunk3Object))]
    [BecomesRubble(typeof(CryoliteOreRubbleSet2Chunk1Object), typeof(CryoliteOreRubbleSet2Chunk2Object), typeof(CryoliteOreRubbleSet2Chunk3Object), typeof(CryoliteOreRubbleSet2Chunk4Object))]
    [BecomesRubble(typeof(CryoliteOreRubbleSet3Chunk1Object), typeof(CryoliteOreRubbleSet3Chunk2Object), typeof(CryoliteOreRubbleSet3Chunk3Object))]
    [BecomesRubble(typeof(CryoliteOreRubbleSet4Chunk1Object), typeof(CryoliteOreRubbleSet4Chunk2Object), typeof(CryoliteOreRubbleSet4Chunk3Object))]
    [Tag("Minable")]
    public partial class CryoliteOreBlock : Block { }

    [Serialized, Tag("FastPickupable")] public partial class CryoliteOreRubbleSet1Chunk1Object : RubbleObject<CryoliteOreItem> { }
    [Serialized, Tag("FastPickupable")] public partial class CryoliteOreRubbleSet1Chunk2Object : RubbleObject<CryoliteOreItem> { }

    [BecomesRubble(typeof(CryoliteOreRubbleSet1Chunk3Split1Object), typeof(CryoliteOreRubbleSet1Chunk3Split2Object)), Tag("MinableRubble")]
    [Serialized] public partial class CryoliteOreRubbleSet1Chunk3Object : RubbleObject<CryoliteOreItem> { }
    [Serialized, Tag("FastPickupable"), Tag("Pickupable")] public partial class CryoliteOreRubbleSet1Chunk3Split1Object : RubbleObject<CryoliteOreItem> { }
    [Serialized, Tag("FastPickupable"), Tag("Pickupable")] public partial class CryoliteOreRubbleSet1Chunk3Split2Object : RubbleObject<CryoliteOreItem> { }

    [Serialized, Tag("FastPickupable"), Tag("Pickupable")] public partial class CryoliteOreRubbleSet2Chunk1Object : RubbleObject<CryoliteOreItem> { }
    [Serialized, Tag("FastPickupable"), Tag("Pickupable")] public partial class CryoliteOreRubbleSet2Chunk2Object : RubbleObject<CryoliteOreItem> { }
    [Serialized, Tag("FastPickupable"), Tag("Pickupable")] public partial class CryoliteOreRubbleSet2Chunk3Object : RubbleObject<CryoliteOreItem> { }
    [Serialized, Tag("FastPickupable"), Tag("Pickupable")] public partial class CryoliteOreRubbleSet2Chunk4Object : RubbleObject<CryoliteOreItem> { }

    [Serialized, Tag("FastPickupable"), Tag("Pickupable")] public partial class CryoliteOreRubbleSet3Chunk1Object : RubbleObject<CryoliteOreItem> { }
    [Serialized, Tag("FastPickupable"), Tag("Pickupable")] public partial class CryoliteOreRubbleSet3Chunk2Object : RubbleObject<CryoliteOreItem> { }
    [BecomesRubble(typeof(CryoliteOreRubbleSet3Chunk3Split1Object), typeof(CryoliteOreRubbleSet3Chunk3Split2Object))]
    [Serialized, Tag("MinableRubble")] public partial class CryoliteOreRubbleSet3Chunk3Object : RubbleObject<CryoliteOreItem> { }
    [Serialized, Tag("FastPickupable"), Tag("Pickupable")] public partial class CryoliteOreRubbleSet3Chunk3Split1Object : RubbleObject<CryoliteOreItem> { }
    [Serialized, Tag("FastPickupable"), Tag("Pickupable")] public partial class CryoliteOreRubbleSet3Chunk3Split2Object : RubbleObject<CryoliteOreItem> { }

    [BecomesRubble(typeof(CryoliteOreRubbleSet4Chunk1Split1Object), typeof(CryoliteOreRubbleSet4Chunk1Split2Object))]
    [Serialized, Tag("MinableRubble")] public partial class CryoliteOreRubbleSet4Chunk1Object : RubbleObject<CryoliteOreItem> { }
    [Serialized, Tag("FastPickupable"), Tag("Pickupable")] public partial class CryoliteOreRubbleSet4Chunk1Split1Object : RubbleObject<CryoliteOreItem> { }
    [Serialized, Tag("FastPickupable"), Tag("Pickupable")] public partial class CryoliteOreRubbleSet4Chunk1Split2Object : RubbleObject<CryoliteOreItem> { }
    [Serialized, Tag("FastPickupable"), Tag("Pickupable")] public partial class CryoliteOreRubbleSet4Chunk2Object : RubbleObject<CryoliteOreItem> { }
    [Serialized, Tag("FastPickupable"), Tag("Pickupable")] public partial class CryoliteOreRubbleSet4Chunk3Object : RubbleObject<CryoliteOreItem> { }

    public partial class CryoliteOreRubbleSet1Chunk3Split1Object : RubbleObject<CryoliteOreItem> { public override Vector3 SpawnOffset { get { return new Vector3(-0.2252956f, 0.02010832f, 0.3399759f); } } }
    public partial class CryoliteOreRubbleSet1Chunk3Split2Object : RubbleObject<CryoliteOreItem> { public override Vector3 SpawnOffset { get { return new Vector3(0.2461708f, 0.007136832f, 0.2581451f); } } }
    public partial class CryoliteOreRubbleSet2Chunk1Object : RubbleObject<CryoliteOreItem> { public override Vector3 SpawnOffset { get { return new Vector3(-0.225453f, 0.07553469f, 0.2549825f); } } }
    public partial class CryoliteOreRubbleSet2Chunk2Object : RubbleObject<CryoliteOreItem> { public override Vector3 SpawnOffset { get { return new Vector3(0.2370333f, -0.006537015f, 0.2591352f); } } }
    public partial class CryoliteOreRubbleSet2Chunk3Object : RubbleObject<CryoliteOreItem> { public override Vector3 SpawnOffset { get { return new Vector3(-0.1973896f, 0.003423877f, -0.2509144f); } } }
    public partial class CryoliteOreRubbleSet2Chunk4Object : RubbleObject<CryoliteOreItem> { public override Vector3 SpawnOffset { get { return new Vector3(0.2655502f, 0.1081393f, -0.2471918f); } } }
    public partial class CryoliteOreRubbleSet3Chunk1Object : RubbleObject<CryoliteOreItem> { public override Vector3 SpawnOffset { get { return new Vector3(-0.2127425f, -0.1714192f, 0.004029765f); } } }
    public partial class CryoliteOreRubbleSet3Chunk2Object : RubbleObject<CryoliteOreItem> { public override Vector3 SpawnOffset { get { return new Vector3(0.2374093f, -0.1904848f, 0.03861935f); } } }
    public partial class CryoliteOreRubbleSet3Chunk3Object : RubbleObject<CryoliteOreItem> { public override Vector3 SpawnOffset { get { return new Vector3(0.01331704f, 0.268941f, 0.0161365f); } } }
    public partial class CryoliteOreRubbleSet3Chunk3Split1Object : RubbleObject<CryoliteOreItem> { public override Vector3 SpawnOffset { get { return new Vector3(-0.233251f, 0.2803903f, 0.04741814f); } } }
    public partial class CryoliteOreRubbleSet3Chunk3Split2Object : RubbleObject<CryoliteOreItem> { public override Vector3 SpawnOffset { get { return new Vector3(0.2505755f, 0.2547145f, 0.01751966f); } } }
    public partial class CryoliteOreRubbleSet4Chunk1Object : RubbleObject<CryoliteOreItem> { public override Vector3 SpawnOffset { get { return new Vector3(-0.2668995f, 0.008596374f, 0.01567351f); } } }
    public partial class CryoliteOreRubbleSet4Chunk1Split1Object : RubbleObject<CryoliteOreItem> { public override Vector3 SpawnOffset { get { return new Vector3(-0.2717379f, -0.02322261f, 0.2325664f); } } }
    public partial class CryoliteOreRubbleSet4Chunk1Split2Object : RubbleObject<CryoliteOreItem> { public override Vector3 SpawnOffset { get { return new Vector3(-0.2665882f, 0.03588935f, -0.2293553f); } } }
    public partial class CryoliteOreRubbleSet4Chunk2Object : RubbleObject<CryoliteOreItem> { public override Vector3 SpawnOffset { get { return new Vector3(0.1975083f, -0.03212927f, 0.2344819f); } } }
    public partial class CryoliteOreRubbleSet4Chunk3Object : RubbleObject<CryoliteOreItem> { public override Vector3 SpawnOffset { get { return new Vector3(0.2567693f, -0.01362941f, -0.2435579f); } } }
    public partial class CryoliteOreRubbleSet1Chunk2Object : RubbleObject<CryoliteOreItem> { public override Vector3 SpawnOffset { get { return new Vector3(0.272811f, 0.0937451f, -0.2339817f); } } }
    public partial class CryoliteOreRubbleSet1Chunk1Object : RubbleObject<CryoliteOreItem> { public override Vector3 SpawnOffset { get { return new Vector3(-0.1786726f, -0.01078895f, -0.1474392f); } } }
    public partial class CryoliteOreRubbleSet1Chunk3Object : RubbleObject<CryoliteOreItem> { public override Vector3 SpawnOffset { get { return new Vector3(0.05622241f, 0.01955315f, 0.2837533f); } } }

}
