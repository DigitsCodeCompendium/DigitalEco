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
    public partial class SolarGeneratorInvention: InventionRecipe
    {
        public SolarGeneratorInvention() 
        {
            this.InventionKits = new Item[]
            {
                Item.Get(typeof(SteamMaterialKitItem)),
            };
        
            this.InventionLabor         = 600f;
            this.InventionTime          = 20f;
            this.InventionExperience    = 20f;
            this.InventionTable = typeof(LaboratoryItem);

            this.InventionSkills = new RequiredSkill[]
            { 
                new(typeof(ElectronicsSkill), 5), 
            };

            this.FabricationIngredients = new FabricationElement[]
            {
                new(typeof(SteelBarItem), 12), new(typeof(ServoItem), 8), new(typeof(BasicCircuitItem), 8), 
            };

            this.FabricationProducts = new FabricationElement[]
            {
                new(typeof(SolarGeneratorItem), 1, true), 
            };

            this.FabricationLabor       = 600f;
            this.FabricationTime        = 20f;
            this.FabricationExperience  = 20f;
            this.FabricationTable = typeof(ElectronicsAssemblyItem);

            this.FabricationSkills = new RequiredSkill[]
            { 
                new(typeof(ElectronicsSkill), 5), 
            };

            
            this.Initialize(displayText: Localizer.DoStr("Solar Generator"),
                            referencedDrawing:  typeof(SolarGeneratorDrawingItem));
        }
    }

    [Serialized]
    [Weight(100)]
    [LocDisplayName("Solar Generator Technical Drawing")]
    [Tag("Technical Drawing")]
    public partial class SolarGeneratorDrawingItem: DrawingItem {}
}
