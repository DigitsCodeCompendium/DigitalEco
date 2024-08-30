using System;
using System.Collections.Generic;
using System.ComponentModel;
using Eco.Gameplay.Components;
using Eco.Gameplay.Items;
using Eco.Gameplay.Objects;
using Eco.Gameplay.Skills;
using Eco.Core.Items;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;
using Eco.Shared.SharedTypes;
using Eco.World.Blocks;
using Eco.World.Water;
using Eco.Gameplay.Items.Recipes;

namespace Eco.Mods.TechTree
{
    [Serialized]
    [LocDisplayName("PigIron Bar")]
    [LocDescription("Bar of PigIron. It can be further proccesed into steel in a blast furnace or regular iron through work on an anvil.")]
    [MaxStackSize(20)]
    [Weight(15000)]
    [Ecopedia("Blocks", "Metals", createAsSubPage: true)]
    [Tag("Metal")]
    public partial class PigIronBarItem :Item { }
}
