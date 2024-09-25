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
    public partial class FrothFloatationCellInvention: InventionRecipe
    {
        public FrothFloatationCellInvention() 
        {
            this.FabricationIngredients = new FabricationElement[]
            {
                new(typeof(SteelPlateItem), 15), new(typeof(SteelPipeItem), 20), new(typeof(AdvancedCircuitItem), 10), new(typeof(ElectricMotorItem), 1, true), 
            };

            this.FabricationProducts = new FabricationElement[]
            {
                new(typeof(FrothFloatationCellItem), 1, true), 
            };

            this.RequiredKits = new List<Item>()
            {
                
            }.ToArray();

            this.InventionLabor     = 120f;
            this.InventionTime      = 5f;

            this.RequiredSkills = new RequiredSkill[]
            { 
                new(typeof(ElectronicsSkill), 2), 
            };

            this.FabricationTable = typeof(ElectronicsAssemblyItem);
            this.Initialize(displayText: Localizer.DoStr("Froth Floatation Cell"),
                            referencedRecipeFamilyType: typeof(FrothFloatationCellRecipe),
                            referencedDrawing:  typeof(FrothFloatationCellDrawingItem));
        }
    }

    [Serialized]
    [Weight(100)]
    [LocDisplayName("Froth Floatation Cell Technical Drawing")]
    [Tag("Technical Drawing")]
    public partial class FrothFloatationCellDrawingItem: DrawingItem {}
}
