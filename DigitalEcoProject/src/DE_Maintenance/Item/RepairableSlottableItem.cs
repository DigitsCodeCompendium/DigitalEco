using Eco.Gameplay.Items;
using Eco.Shared.Serialization;
using Digits.PartSlotting;

namespace Digits.DE_Maintenance
{
    [Serialized]
    [MaxStackSize(1)]
    public abstract class RepairableSlottableItem : RepairableItem, ISlottableItem { }
}