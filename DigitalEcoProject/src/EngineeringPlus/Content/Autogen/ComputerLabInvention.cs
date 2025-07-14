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
    public partial class ComputerLabInvention: InventionRecipe
    {
        public ComputerLabInvention() 
        {
            this.InventionKits = new Item[]
            {
                Item.Get(typeof(SteamMaterialKitItem)),
            };
        
            this.InventionLabor         = 3000f;
            this.InventionTime          = 120f;
            this.InventionExperience    = 40f;
            this.InventionTable = typeof(LaboratoryItem);

            this.InventionSkills = new RequiredSkill[]
            { 
                new(typeof(ElectronicsSkill), 6), 
            };

            this.FabricationIngredients = new FabricationElement[]
            {
                new(typeof(ReinforcedConcreteItem), 100), new(typeof(PlasticItem), 100), new(typeof(AdvancedCircuitItem), 50), new("CompositeLumber", 100), 
            };

            this.FabricationProducts = new FabricationElement[]
            {
                new(typeof(ComputerLabItem), 1, true), 
            };

            this.FabricationLabor       = 3000f;
            this.FabricationTime        = 120f;
            this.FabricationExperience  = 40f;
            this.FabricationTable = typeof(ElectronicsAssemblyItem);

            this.FabricationSkills = new RequiredSkill[]
            { 
                new(typeof(ElectronicsSkill), 6), 
            };

            
            this.Initialize(displayText: Localizer.DoStr("Computer Lab"),
                            referencedDrawing:  typeof(ComputerLabDrawingItem));
        }
    }

    [Serialized]
    [Weight(100)]
    [LocDisplayName("Computer Lab Technical Drawing")]
    [Tag("Technical Drawing")]
    public partial class ComputerLabDrawingItem: DrawingItem {}
}
