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
    public partial class SolarGeneratorInvention: InventionRecipe
    {
        public SolarGeneratorInvention() 
        {
            this.FabricationIngredients = new FabricationElement[]
            {
                new(typeof(SteelBarItem), 12), new(typeof(ServoItem), 8), new(typeof(BasicCircuitItem), 8), 
            };

            this.FabricationProducts = new FabricationElement[]
            {
                new(typeof(SolarGeneratorItem), 1, true), 
            };

            this.RequiredKits = new List<Item>()
            {
                
            }.ToArray();

            this.InventionLabor     = 600f;
            this.InventionTime      = 20f;

            this.RequiredSkills = new RequiredSkill[]
            { 
                new(typeof(ElectronicsSkill), 5), 
            };

            this.FabricationTable = typeof(ElectronicsAssemblyItem);
            this.Initialize(displayText: Localizer.DoStr("Solar Generator"),
                            referencedRecipeFamilyType: typeof(SolarGeneratorRecipe),
                            referencedDrawing:  typeof(SolarGeneratorDrawingItem));
        }
    }

    [Serialized]
    [Weight(100)]
    [LocDisplayName("Solar Generator Technical Drawing")]
    [Tag("Technical Drawing")]
    public partial class SolarGeneratorDrawingItem: DrawingItem {}
}
