using Eco.Core.Controller;
using Eco.Core.Systems;
using Eco.Gameplay.Items;
using Eco.Gameplay.Systems.TextLinks;
using Eco.Shared.Localization;
using Eco.Shared.Networking;
using Eco.Shared.Serialization;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digits.src.EngineeringPlus
{
    [Serialized]
    public class IngredientReqView : IController, INotifyPropertyChanged
    {
        [Serialized] public Item DisplayItem { get; set; }

        public IngredientReqView() { }

        public IngredientReqView(Item item)
        {
            this.DisplayItem = item;
            this.InfoString = Localizer.DoStr($"{this.DisplayItem.UILink()} Satisfied 0 / 0 Required - 0 Available");
        }

        public IngredientReqView(string TypeName)
        {
            this.DisplayItem = Item.Get(TypeName);
            this.InfoString = Localizer.DoStr($"{this.DisplayItem.UILink()} Satisfied 0 / 0 Required - 0 Available");
        }

        [Eco, PropReadOnly, UITypeName("StringDisplay")]
        public string InfoString { get; set; } = string.Empty;

        public void Update(int required, int satisfied, int available)
        {
            this.InfoString = Localizer.DoStr($"{this.DisplayItem.UILink()} Satisfied {satisfied}/{required} Required - {available} Available");
        }

        #region IController
        private int controllerID;
        ref int IHasUniversalID.ControllerID => ref this.controllerID;

        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
    }
}
