using Eco.Gameplay.Items;
using Eco.Shared.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digits.src.EngineeringPlus
{
    [Serialized]
    public struct FabricationScrap
    {
        [Serialized] public string  Typename        { get; private set; }
        [Serialized] public float   Amount          { get; set; }
        [Serialized] public bool    IsSpecificItem  { get; private set; }

        public readonly bool IsFullItemAvailible => Amount >= 1;


        public FabricationScrap(ItemRepresentation stackable, float amount = 0f)
        {
            IsSpecificItem = false;
            if (stackable is Item)
            {
                Typename = stackable.GetType().Name;
                IsSpecificItem = true;
            }
            else Typename = stackable.Name;
            Amount = amount;
        }

        public FabricationScrap(FabricationElement fabricationElement) : this(fabricationElement.GetStackable(), 0) { }
        public FabricationScrap(string tag, float count = 0f)    : this(TagManager.Tag(tag), count) { }
        public FabricationScrap(Type itemType, float count = 0f) : this(Item.Get(itemType), count) { }

        public readonly ItemRepresentation GetStackable()
        {
            if (IsSpecificItem) return Item.Get(Typename);
            else                return TagManager.Tag(Typename);
        }

        public readonly float GetNumFullItems()
        {
            return MathF.Truncate(Amount);
        }
    }
}
