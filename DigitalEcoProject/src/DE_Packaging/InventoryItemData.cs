using System.ComponentModel;
using Eco.Core.Controller;
using Eco.Core.Systems;
using Eco.Core.Utils;
using Eco.Gameplay.Economy;
using Eco.Gameplay.Players;
using Eco.Gameplay.Systems.Messaging.Chat;
using Eco.Gameplay.Systems.TextLinks;
using Eco.Gameplay.Utils;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;
using Eco.Gameplay.Items.PersistentData;
using Eco.Gameplay.Items;

namespace Digits.Packing
{
    [Serialized]
    public class InventoryItemData : IController
    {
        [Serialized] public Inventory Inventory { get; set; }

        #region IController
        int controllerID;
        public ref int ControllerID => ref this.controllerID;
        #endregion
    }
}
