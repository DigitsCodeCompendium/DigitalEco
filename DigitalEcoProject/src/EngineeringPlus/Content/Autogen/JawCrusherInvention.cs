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
    public partial class JawCrusherInvention: InventionRecipe
    {
        public JawCrusherInvention() 
        {
            this.FabricationIngredients = new FabricationElement[]
            {
                new(typeof(SteelBarItem), 25), new(typeof(SyntheticRubberItem), 25), new(typeof(SteelGearItem), 20), new(typeof(ElectricMotorItem), 2, true), 
            };

            this.FabricationProducts = new FabricationElement[]
            {
                new(typeof(JawCrusherItem), 1, true), 
            };

            this.RequiredKits = new List<Item>()
            {
                
            }.ToArray();

            this.InventionLabor     = 1200f;
            this.InventionTime      = 5f;

            this.RequiredSkills = new RequiredSkill[]
            { 
                new(typeof(ElectronicsSkill), 2), 
            };

            this.FabricationTable = typeof(RoboticAssemblyLineItem);
            this.Initialize(displayText: Localizer.DoStr("Jaw Crusher"),
                            referencedRecipeFamilyType: typeof(JawCrusherRecipe),
                            referencedDrawing:  typeof(JawCrusherDrawingItem));
        }
    }

    [Serialized]
    [Weight(100)]
    [LocDisplayName("Jaw Crusher Technical Drawing")]
    [Tag("Technical Drawing")]
    public partial class JawCrusherDrawingItem: DrawingItem {}
}
