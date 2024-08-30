
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Eco.Gameplay.Components;
using Eco.Gameplay.Items;
using Eco.Gameplay.Skills;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;
using Eco.Gameplay.Items.Recipes;
using Eco.Mods.TechTree;

namespace Eco.Mods.TechTree
{
    [Serialized]
    [LocDisplayName("Iron Bloom")]
    [LocDescription("Iron Bloom")]
    [Weight(60000)]
    [MaxStackSize(10)]
    public partial class IronBloomItem : Item
    {
    }
}