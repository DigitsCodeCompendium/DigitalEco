using Eco.Gameplay.Items;
using Eco.Gameplay.Systems.TextLinks;
using Eco.Shared.Localization;
using Eco.Shared.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digits.Maintenance
{
    public class MaintenanceTypesRestriction : InventoryRestriction
    {
        private string genericType;
        private List<string> tierTags;

        public override LocString Message => Localizer.Do($"Inventory only accepts {TagManager.Tag(this.genericType).MarkedUpName} of tier {this.tierTags.Select(x => TagManager.Tag(x).MarkedUpName).CommaList()}.");

        public MaintenanceTypesRestriction(string genericType, string[] tierTags)
        {
            this.genericType = genericType;
            this.tierTags = new List<string>(tierTags);
        }

        public override int MaxAccepted(Item item, int currentQuantity) => (item.Tags().Any(x => this.tierTags.Contains(x.Name)) &&
                                                                            item.Tags().Any(x => this.genericType == x.Name)) ? -1 : 0;
    }
}
