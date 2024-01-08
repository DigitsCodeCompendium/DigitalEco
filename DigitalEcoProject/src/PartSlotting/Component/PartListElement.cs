using Eco.Core.Controller;
using Eco.Core.Systems;
using Eco.Gameplay.Items;
using Eco.Shared.Networking;
using Eco.Shared.Serialization;
using System.ComponentModel;
using System.Xml.Linq;

namespace Digits.PartSlotting
{
    [Serialized]
    public class PartListElement : IController, INotifyPropertyChanged
    {
        public string partName { get; set; }
        [Eco, ClientInterfaceProperty, PropReadOnly]
        public string PartName
        {
            get => this.partName;
            set
            {
                if (value == this.partName) return;
                this.partName = value;
                this.Changed(nameof(this.PartName));
            }
        }

        public string status { get; set; }
        [Eco, ClientInterfaceProperty, PropReadOnly]
        public string Status
        {
            get => this.status;
            set
            {
                if (value == this.status) return;
                this.status = value;
                this.Changed(nameof(this.Status));
            }
        }

        [SyncToView, Autogen]
        [UITypeName("GeneralHeader")]
        public string PartNameDisplay => PartName;

        [Eco, UITypeName("ItemInput")] public LimitedInventory ItemSlot { get; set; } = new LimitedInventory(1);

        //controller stuff, DO NOT TOUCH
        #region IController
        private int controllerID;

        public event PropertyChangedEventHandler PropertyChanged;

        ref int IHasUniversalID.ControllerID => ref this.controllerID;
        #endregion
    }
}
