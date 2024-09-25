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
    public struct FabricationElement
    {
        [Serialized] public double Efficiency {  get; set; }
        [Serialized] public string Typename { get; set; }
        [Serialized] public float Count { get; set; }
        [Serialized] public bool IsStatic { get; set; }
        [Serialized] public bool IsSpecificItem { get; set; }

        public FabricationElement(Stackable stackable, float count = 1, bool isStatic = false)
        {
            if (stackable is Item)
            {
                IsSpecificItem = true;
                Typename = stackable.GetType().Name;
            }
            else
            {
                IsSpecificItem = false;
                Typename = stackable.Name;
            }
            
            Count = count;
            IsStatic = isStatic;
            Efficiency = 0;
        }

        public FabricationElement(string tag, float count = 1f, bool isStatic = false)    : this(TagManager.Tag(tag), count, isStatic) { }
        public FabricationElement(Type itemType, float count = 1f, bool isStatic = false) : this(Item.Get(itemType), count, isStatic) { }

        public Stackable GetStackable()
        {
            if (IsSpecificItem) return Item.Get(Typename);
            else                return TagManager.Tag(Typename);
        }
    }
}
