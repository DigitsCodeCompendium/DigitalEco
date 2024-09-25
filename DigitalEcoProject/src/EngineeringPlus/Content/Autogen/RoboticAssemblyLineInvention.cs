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
    public partial class RoboticAssemblyLineInvention: InventionRecipe
    {
        public RoboticAssemblyLineInvention() 
        {
            this.FabricationIngredients = new FabricationElement[]
            {
                new(typeof(CementItem), 30), new(typeof(ElectricMotorItem), 5), new(typeof(ServoItem), 12), new(typeof(SteelBarItem), 30), 
            };

            this.FabricationProducts = new FabricationElement[]
            {
                new(typeof(RoboticAssemblyLineItem), 1, true), 
            };

            this.RequiredKits = new List<Item>()
            {
                
            }.ToArray();

            this.InventionLabor     = 1200f;
            this.InventionTime      = 75f;

            this.RequiredSkills = new RequiredSkill[]
            { 
                new(typeof(ElectronicsSkill), 2), 
            };

            this.FabricationTable = typeof(ElectronicsAssemblyItem);
            this.Initialize(displayText: Localizer.DoStr("Robotic Assembly Line"),
                            referencedRecipeFamilyType: typeof(RoboticAssemblyLineRecipe),
                            referencedDrawing:  typeof(RoboticAssemblyLineDrawingItem));
        }
    }

    [Serialized]
    [Weight(100)]
    [LocDisplayName("Robotic Assembly Line Technical Drawing")]
    [Tag("Technical Drawing")]
    public partial class RoboticAssemblyLineDrawingItem: DrawingItem {}
}
