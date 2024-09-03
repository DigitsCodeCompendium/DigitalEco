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
    [LocDisplayName("Impure Copper")]
    [LocDescription("This chunk of copper is ready to be smelted into copper bars, although it could be further proccesed to remove impurities.")]
    [Weight(100)]
    public partial class ImpureCopperItem : Item
    {
    }
}
