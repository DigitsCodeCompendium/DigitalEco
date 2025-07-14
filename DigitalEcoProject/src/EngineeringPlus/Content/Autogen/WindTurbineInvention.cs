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
    public partial class WindTurbineInvention: InventionRecipe
    {
        public WindTurbineInvention() 
        {
            this.InventionKits = new Item[]
            {
                Item.Get(typeof(SteamMaterialKitItem)),
            };
        
            this.InventionLabor         = 1200f;
            this.InventionTime          = 20f;
            this.InventionExperience    = 15f;
            this.InventionTable = typeof(LaboratoryItem);

            this.InventionSkills = new RequiredSkill[]
            { 
                new(typeof(ElectronicsSkill), 5), 
            };

            this.FabricationIngredients = new FabricationElement[]
            {
                new(typeof(SteelBarItem), 8), new(typeof(GearboxItem), 4), new(typeof(AdvancedCircuitItem), 4), new(typeof(ServoItem), 8), 
            };

            this.FabricationProducts = new FabricationElement[]
            {
                new(typeof(WindTurbineItem), 1, true), 
            };

            this.FabricationLabor       = 1200f;
            this.FabricationTime        = 20f;
            this.FabricationExperience  = 15f;
            this.FabricationTable = typeof(RoboticAssemblyLineItem);

            this.FabricationSkills = new RequiredSkill[]
            { 
                new(typeof(ElectronicsSkill), 5), 
            };

            
            this.Initialize(displayText: Localizer.DoStr("Wind Turbine"),
                            referencedDrawing:  typeof(WindTurbineDrawingItem));
        }
    }

    [Serialized]
    [Weight(100)]
    [LocDisplayName("Wind Turbine Technical Drawing")]
    [Tag("Technical Drawing")]
    public partial class WindTurbineDrawingItem: DrawingItem {}
}
