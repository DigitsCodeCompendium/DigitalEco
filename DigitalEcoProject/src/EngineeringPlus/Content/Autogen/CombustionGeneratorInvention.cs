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
    public partial class CombustionGeneratorInvention: InventionRecipe
    {
        public CombustionGeneratorInvention() 
        {
            this.FabricationIngredients = new FabricationElement[]
            {
                new(typeof(PistonItem), 4), new(typeof(IronBarItem), 12), new(typeof(CombustionEngineItem), 1, true), 
            };

            this.FabricationProducts = new FabricationElement[]
            {
                new(typeof(CombustionGeneratorItem), 1, true), 
            };

            this.RequiredKits = new List<Item>()
            {
                Item.Get(typeof(IndustrialMachineKitItem)), Item.Get(typeof(IndustrialPowerKitItem)), 
            }.ToArray();

            this.InventionLabor     = 600f;
            this.InventionTime      = 15f;

            this.RequiredSkills = new RequiredSkill[]
            { 
                new(typeof(MechanicsSkill), 3), 
            };

            this.FabricationTable = typeof(AssemblyLineItem);
            this.Initialize(displayText: Localizer.DoStr("Combustion Generator"),
                            referencedRecipeFamilyType: typeof(CombustionGeneratorRecipe),
                            referencedDrawing:  typeof(CombustionGeneratorDrawingItem));
        }
    }

    [Serialized]
    [Weight(100)]
    [LocDisplayName("Combustion Generator Technical Drawing")]
    [Tag("Technical Drawing")]
    public partial class CombustionGeneratorDrawingItem: DrawingItem {}
}
