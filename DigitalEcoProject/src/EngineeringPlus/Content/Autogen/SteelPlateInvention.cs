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
    public partial class SteelPlateInvention: InventionRecipe
    {
        public SteelPlateInvention() 
        {
            this.FabricationIngredients = new FabricationElement[]
            {
                new(typeof(SteelBarItem), 3), 
            };

            this.FabricationProducts = new FabricationElement[]
            {
                new(typeof(SteelPlateItem), 1, true), 
            };

            this.RequiredKits = new List<Item>()
            {
                
            }.ToArray();

            this.InventionLabor     = 120f;
            this.InventionTime      = 1.5f;

            this.RequiredSkills = new RequiredSkill[]
            { 
                new(typeof(IndustrySkill), 1), 
            };

            this.FabricationTable = typeof(ElectricStampingPressItem);
            this.Initialize(displayText: Localizer.DoStr("Steel Plate"),
                            referencedRecipeFamilyType: typeof(SteelPlateRecipe),
                            referencedDrawing:  typeof(SteelPlateDrawingItem));
        }
    }

    [Serialized]
    [Weight(100)]
    [LocDisplayName("Steel Plate Technical Drawing")]
    [Tag("Technical Drawing")]
    public partial class SteelPlateDrawingItem: DrawingItem {}
}
