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
    public partial class ElectricMotorInvention: InventionRecipe
    {
        public ElectricMotorInvention() 
        {
            this.InventionKits = new Item[]
            {
                Item.Get(typeof(SteamMaterialKitItem)),
            };
        
            this.InventionLabor         = 360f;
            this.InventionTime          = 2f;
            this.InventionExperience    = 10f;
            this.InventionTable = typeof(LaboratoryItem);

            this.InventionSkills = new RequiredSkill[]
            { 
                new(typeof(ElectronicsSkill), 1), 
            };

            this.FabricationIngredients = new FabricationElement[]
            {
                new(typeof(BasicCircuitItem), 4), new(typeof(CopperWiringItem), 10), new(typeof(SteelBarItem), 8), 
            };

            this.FabricationProducts = new FabricationElement[]
            {
                new(typeof(ElectricMotorItem), 1, true), 
            };

            this.FabricationLabor       = 360f;
            this.FabricationTime        = 2f;
            this.FabricationExperience  = 10f;
            this.FabricationTable = typeof(ElectronicsAssemblyItem);

            this.FabricationSkills = new RequiredSkill[]
            { 
                new(typeof(ElectronicsSkill), 1), 
            };

            
            this.Initialize(displayText: Localizer.DoStr("Electric Motor"),
                            referencedDrawing:  typeof(ElectricMotorDrawingItem));
        }
    }

    [Serialized]
    [Weight(100)]
    [LocDisplayName("Electric Motor Technical Drawing")]
    [Tag("Technical Drawing")]
    public partial class ElectricMotorDrawingItem: DrawingItem {}
}
