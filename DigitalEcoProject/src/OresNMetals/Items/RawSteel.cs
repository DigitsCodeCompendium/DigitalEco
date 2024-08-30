using Eco.Gameplay.Components;
using Eco.Gameplay.Items.Recipes;
using Eco.Gameplay.Items;
using Eco.Gameplay.Skills;
using Eco.Mods.TechTree;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eco.Mods.TechTree
{
    [Serialized]
    [LocDisplayName("Raw Steel")]
    [LocDescription("Raw Steel that needs to be shaped into bars")]
    [MaxStackSize(20)]
    [Weight(40000)]
    public partial class RawSteelItem : Item
    {
    }
}
