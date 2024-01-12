using Eco.Core.Controller;
using Eco.Core.Systems;
using Eco.Gameplay.Items;
using Eco.Shared.Networking;
using Eco.Shared.Serialization;
using System.ComponentModel;

namespace Digits.Maintenance
{
    [Serialized]
    public class MPartSlot : IController, INotifyPropertyChanged
    {
        public MPartSlot() { }

        public MPartSlot(string name)
        {
            this.PartName = name;
            Inventory ??= new LimitedInventory(1);
        }

        public string partName { get; set; }
        [Eco, ClientInterfaceProperty, PropReadOnly, UITypeName("StringTitle")]
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

        [Eco, UITypeName("ItemInput")] public LimitedInventory Inventory { get; set; }

        //controller stuff, DO NOT TOUCH
        #region IController
        private int controllerID;

        public event PropertyChangedEventHandler PropertyChanged;

        ref int IHasUniversalID.ControllerID => ref this.controllerID;
        #endregion
    }
}
