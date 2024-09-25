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
    public partial class SteelGearboxInvention: InventionRecipe
    {
        public SteelGearboxInvention() 
        {
            this.FabricationIngredients = new FabricationElement[]
            {
                new(typeof(SteelBarItem), 8), new(typeof(SteelGearItem), 4), 
            };

            this.FabricationProducts = new FabricationElement[]
            {
                new(typeof(SteelGearboxItem), 1, true), 
            };

            this.RequiredKits = new List<Item>()
            {
                
            }.ToArray();

            this.InventionLabor     = 100f;
            this.InventionTime      = 2f;

            this.RequiredSkills = new RequiredSkill[]
            { 
                new(typeof(IndustrySkill), 2), 
            };

            this.FabricationTable = typeof(ElectricPlanerItem);
            this.Initialize(displayText: Localizer.DoStr("Steel Gearbox"),
                            referencedRecipeFamilyType: typeof(SteelGearboxRecipe),
                            referencedDrawing:  typeof(SteelGearboxDrawingItem));
        }
    }

    [Serialized]
    [Weight(100)]
    [LocDisplayName("Steel Gearbox Technical Drawing")]
    [Tag("Technical Drawing")]
    public partial class SteelGearboxDrawingItem: DrawingItem {}
}
