
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Eco.Gameplay.Components;
using Eco.Gameplay.Items;
using Eco.Gameplay.Skills;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;
using Eco.Core.Items;
using Eco.Gameplay.Items.Recipes;
using Eco.Mods.TechTree;

namespace Eco.Mods.TechTree
{
    [Serialized]
    [LocDisplayName("Sodium Hydroxide")]
    [LocDescription("Sodium Hydroxide")]
    [Weight(100)]
    [Category("Hidden")]
    [Tag("Chemical")]                                               
    public partial class SodiumHydroxideItem : Item
    {
    }
}