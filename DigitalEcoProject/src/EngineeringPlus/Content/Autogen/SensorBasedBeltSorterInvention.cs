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
    public partial class SensorBasedBeltSorterInvention: InventionRecipe
    {
        public SensorBasedBeltSorterInvention() 
        {
            this.InventionKits = new Item[]
            {
                Item.Get(typeof(SteamMaterialKitItem)),
            };
        
            this.InventionLabor         = 600f;
            this.InventionTime          = 5f;
            this.InventionExperience    = 6f;
            this.InventionTable = typeof(LaboratoryItem);

            this.InventionSkills = new RequiredSkill[]
            { 
                new(typeof(IndustrySkill), 4), 
            };

            this.FabricationIngredients = new FabricationElement[]
            {
                new(typeof(SteelPlateItem), 10), new(typeof(SteelGearboxItem), 5), new(typeof(RivetItem), 16), new(typeof(AdvancedCircuitItem), 5), new(typeof(BasicCircuitItem), 5), new(typeof(ElectricMotorItem), 1, true), 
            };

            this.FabricationProducts = new FabricationElement[]
            {
                new(typeof(SensorBasedBeltSorterItem), 1, true), 
            };

            this.FabricationLabor       = 600f;
            this.FabricationTime        = 5f;
            this.FabricationExperience  = 6f;
            this.FabricationTable = typeof(ElectronicsAssemblyItem);

            this.FabricationSkills = new RequiredSkill[]
            { 
                new(typeof(IndustrySkill), 4), 
            };

            
            this.Initialize(displayText: Localizer.DoStr("Sensor Based Belt Sorter"),
                            referencedDrawing:  typeof(SensorBasedBeltSorterDrawingItem));
        }
    }

    [Serialized]
    [Weight(100)]
    [LocDisplayName("Sensor Based Belt Sorter Technical Drawing")]
    [Tag("Technical Drawing")]
    public partial class SensorBasedBeltSorterDrawingItem: DrawingItem {}
}
