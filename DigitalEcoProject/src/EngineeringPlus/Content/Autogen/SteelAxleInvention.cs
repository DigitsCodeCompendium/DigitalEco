using Digits.src.EngineeringPlus;
using Eco.Core.Items;
using Eco.Core.Serialization.Serializers;
using Eco.Gameplay.Skills;
using Eco.Mods.TechTree;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eco.Gameplay.Items.Recipes
{
    //Source: DigitalEco_EngineeringPP
    public partial class SteelAxleInvention: InventionRecipe
    {
        public SteelAxleInvention() 
        {
            this.FabricationIngredients = new FabricationElement[]
            {
                new(typeof(SteelBarItem), 4), new(typeof(EpoxyItem), 3), 
            };

            this.FabricationProducts = new FabricationElement[]
            {
                new(typeof(SteelAxleItem), 1, true), 
            };

            this.RequiredKits = new List<Item>()
            {
                
            }.ToArray();

            this.InventionLabor     = 60f;
            this.InventionTime      = 1.5f;

            this.RequiredSkills = new RequiredSkill[]
            { 
                new(typeof(IndustrySkill), 1), 
            };

            this.FabricationTable = typeof(ElectricLatheItem);
            this.Initialize(displayText: Localizer.DoStr("Steel Axle"),
                            referencedRecipeFamilyType: typeof(SteelAxleRecipe),
                            referencedDrawing:  typeof(SteelAxleDrawingItem));
        }
    }

    [Serialized]
    [Weight(100)]
    [LocDisplayName("Steel Axle Technical Drawing")]
    [Tag("Technical Drawing")]
    public partial class SteelAxleDrawingItem: DrawingItem {}
}
