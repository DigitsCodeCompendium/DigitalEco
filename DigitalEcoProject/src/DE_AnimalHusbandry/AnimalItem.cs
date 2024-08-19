// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.

namespace Digits.AnimalHusbandry
{
    using System;
    using Eco.Core.Items;
    using Eco.Gameplay.Players;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Networking;
    using Eco.Core.Controller;
    using Eco.Gameplay.Interactions.Interactors;
    using Eco.Shared.Items;
    using Eco.Shared.SharedTypes;
    using Eco.Gameplay.Utils;
    using Eco.Gameplay.Items;

    [Serialized]
    [ItemGroup("Live Animal")]
    [Tag("Live Animal")]
    public abstract partial class AnimalItem : FoodItem
    {
        [SyncToView] public abstract float Frame { get; }
        [SyncToView] public abstract float Fittness { get; }
        [SyncToView] public abstract float Fertility { get; }

        public override LocString Label => Localizer.DoStr("Vitality"); // Override the label to display in the store

        public new bool CanStack(Item stackingOntoItem) => false;

        public override string OnUsed(Player player, ItemStack itemStack)
        {
            return "You can't eat a live animal!";
        }
    }
}
