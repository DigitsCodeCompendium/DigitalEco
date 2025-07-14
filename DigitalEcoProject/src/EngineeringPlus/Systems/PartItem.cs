using Eco.Gameplay.Items;
using Eco.Gameplay.Players;
using Eco.Gameplay.Systems.NewTooltip;
using Eco.Shared.Items;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digits.src.EngineeringPlus.Systems
{
    public class EngineeringPartItem : Item
    {
        [Serialized] public int PartNumber { get; set; } = 420;

        [NewTooltip(CacheAs.Instance | CacheAs.User, 11, TTCat.Details, flags: TTFlags.ClearCacheForAllUsers)]
        public LocString Tooltip(User user)
        {
            var res = new LocStringBuilder();

            res.AppendLineLoc($"<b><color=#0092f8>Part Number:</color></b> {this.PartNumber:00000}");

            return res.ToLocString().Trim();
        }
    }
}
