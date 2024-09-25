﻿using Eco.Core.Items;
using Eco.Gameplay.Items;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eco.Mods.TechTree
{
    [Serialized]
    [LocDisplayName("Industrial Machine Kit")]
    [LocDescription("A kit of items required to invent industrial age machines.")]
    [Weight(5000)]
    [MaxStackSize(1)]
    [Tag("Prototyping Kit")]
    public partial class IndustrialMachineKitItem : Item
    {
    }
}