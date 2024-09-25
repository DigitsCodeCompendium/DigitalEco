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
    public partial class IndustrialGeneratorInvention: InventionRecipe
    {
        public IndustrialGeneratorInvention() 
        {
            this.FabricationIngredients = new FabricationElement[]
            {
                new(typeof(SteelPlateItem), 48), new(typeof(AdvancedCircuitItem), 32), new(typeof(SteelPipeItem), 32), new(typeof(RivetItem), 64), new(typeof(AdvancedCombustionEngineItem), 1, true), new(typeof(RadiatorItem), 24, true), new(typeof(SteelAxleItem), 1, true), 
            };

            this.FabricationProducts = new FabricationElement[]
            {
                new(typeof(IndustrialGeneratorItem), 1, true), 
            };

            this.RequiredKits = new List<Item>()
            {
                
            }.ToArray();

            this.InventionLabor     = 2400f;
            this.InventionTime      = 40f;

            this.RequiredSkills = new RequiredSkill[]
            { 
                new(typeof(IndustrySkill), 4), 
            };

            this.FabricationTable = typeof(RoboticAssemblyLineItem);
            this.Initialize(displayText: Localizer.DoStr("Industrial Generator"),
                            referencedRecipeFamilyType: typeof(IndustrialGeneratorRecipe),
                            referencedDrawing:  typeof(IndustrialGeneratorDrawingItem));
        }
    }

    [Serialized]
    [Weight(100)]
    [LocDisplayName("Industrial Generator Technical Drawing")]
    [Tag("Technical Drawing")]
    public partial class IndustrialGeneratorDrawingItem: DrawingItem {}
}
