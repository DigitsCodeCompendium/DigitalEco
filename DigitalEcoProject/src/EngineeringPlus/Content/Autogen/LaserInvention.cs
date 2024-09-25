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
    public partial class LaserInvention: InventionRecipe
    {
        public LaserInvention() 
        {
            this.FabricationIngredients = new FabricationElement[]
            {
                new(typeof(GoldBarItem), 80), new(typeof(SteelBarItem), 80), new(typeof(FramedGlassItem), 80), new(typeof(AdvancedCircuitItem), 40), new(typeof(ElectricMotorItem), 2, true), new(typeof(RadiatorItem), 10, true), 
            };

            this.FabricationProducts = new FabricationElement[]
            {
                new(typeof(LaserItem), 1, true), 
            };

            this.RequiredKits = new List<Item>()
            {
                
            }.ToArray();

            this.InventionLabor     = 900f;
            this.InventionTime      = 100f;

            this.RequiredSkills = new RequiredSkill[]
            { 
                new(typeof(ElectronicsSkill), 6), 
            };

            this.FabricationTable = typeof(RoboticAssemblyLineItem);
            this.Initialize(displayText: Localizer.DoStr("Laser"),
                            referencedRecipeFamilyType: typeof(LaserRecipe),
                            referencedDrawing:  typeof(LaserDrawingItem));
        }
    }

    [Serialized]
    [Weight(100)]
    [LocDisplayName("Laser Technical Drawing")]
    [Tag("Technical Drawing")]
    public partial class LaserDrawingItem: DrawingItem {}
}
