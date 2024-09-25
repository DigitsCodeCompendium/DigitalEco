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
    public partial class AdvancedCombustionEngineInvention: InventionRecipe
    {
        public AdvancedCombustionEngineInvention() 
        {
            this.FabricationIngredients = new FabricationElement[]
            {
                new(typeof(SteelPlateItem), 16), new(typeof(RivetItem), 12), new(typeof(PistonItem), 6), new(typeof(ValveItem), 6), new(typeof(ServoItem), 6), new(typeof(AdvancedCircuitItem), 6), new(typeof(RadiatorItem), 3), 
            };

            this.FabricationProducts = new FabricationElement[]
            {
                new(typeof(AdvancedCombustionEngineItem), 1, true), 
            };

            this.RequiredKits = new List<Item>()
            {
                
            }.ToArray();

            this.InventionLabor     = 600f;
            this.InventionTime      = 4f;

            this.RequiredSkills = new RequiredSkill[]
            { 
                new(typeof(IndustrySkill), 1), 
            };

            this.FabricationTable = typeof(RoboticAssemblyLineItem);
            this.Initialize(displayText: Localizer.DoStr("Advanced Combustion Engine"),
                            referencedRecipeFamilyType: typeof(AdvancedCombustionEngineRecipe),
                            referencedDrawing:  typeof(AdvancedCombustionEngineDrawingItem));
        }
    }

    [Serialized]
    [Weight(100)]
    [LocDisplayName("Advanced Combustion Engine Technical Drawing")]
    [Tag("Technical Drawing")]
    public partial class AdvancedCombustionEngineDrawingItem: DrawingItem {}
}
