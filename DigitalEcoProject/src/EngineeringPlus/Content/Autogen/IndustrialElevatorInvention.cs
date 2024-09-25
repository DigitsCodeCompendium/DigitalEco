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
    public partial class IndustrialElevatorInvention: InventionRecipe
    {
        public IndustrialElevatorInvention() 
        {
            this.FabricationIngredients = new FabricationElement[]
            {
                new(typeof(FlatSteelItem), 30), new(typeof(SteelGearboxItem), 4), new(typeof(CopperWiringItem), 20), new(typeof(ElectricMotorItem), 2, true), new(typeof(LubricantItem), 2, true), 
            };

            this.FabricationProducts = new FabricationElement[]
            {
                new(typeof(IndustrialElevatorItem), 1, true), 
            };

            this.RequiredKits = new List<Item>()
            {
                
            }.ToArray();

            this.InventionLabor     = 2500f;
            this.InventionTime      = 10f;

            this.RequiredSkills = new RequiredSkill[]
            { 
                new(typeof(IndustrySkill), 2), 
            };

            this.FabricationTable = typeof(RoboticAssemblyLineItem);
            this.Initialize(displayText: Localizer.DoStr("Industrial Elevator"),
                            referencedRecipeFamilyType: typeof(IndustrialElevatorRecipe),
                            referencedDrawing:  typeof(IndustrialElevatorDrawingItem));
        }
    }

    [Serialized]
    [Weight(100)]
    [LocDisplayName("Industrial Elevator Technical Drawing")]
    [Tag("Technical Drawing")]
    public partial class IndustrialElevatorDrawingItem: DrawingItem {}
}
