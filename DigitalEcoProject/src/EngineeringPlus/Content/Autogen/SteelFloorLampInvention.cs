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
    public partial class SteelFloorLampInvention: InventionRecipe
    {
        public SteelFloorLampInvention() 
        {
            this.InventionKits = new Item[]
            {
                Item.Get(typeof(SteamMaterialKitItem)),
            };
        
            this.InventionLabor         = 120f;
            this.InventionTime          = 4f;
            this.InventionExperience    = 5f;
            this.InventionTable = typeof(LaboratoryItem);

            this.InventionSkills = new RequiredSkill[]
            { 
                new(typeof(ElectronicsSkill), 2), 
            };

            this.FabricationIngredients = new FabricationElement[]
            {
                new(typeof(SteelBarItem), 8), new(typeof(PlasticItem), 6), new(typeof(CopperWiringItem), 5), new(typeof(LightBulbItem), 1, true), 
            };

            this.FabricationProducts = new FabricationElement[]
            {
                new(typeof(SteelFloorLampItem), 1, true), 
            };

            this.FabricationLabor       = 120f;
            this.FabricationTime        = 4f;
            this.FabricationExperience  = 5f;
            this.FabricationTable = typeof(RoboticAssemblyLineItem);

            this.FabricationSkills = new RequiredSkill[]
            { 
                new(typeof(ElectronicsSkill), 2), 
            };

            
            this.Initialize(displayText: Localizer.DoStr("Steel Floor Lamp"),
                            referencedDrawing:  typeof(SteelFloorLampDrawingItem));
        }
    }

    [Serialized]
    [Weight(100)]
    [LocDisplayName("Steel Floor Lamp Technical Drawing")]
    [Tag("Technical Drawing")]
    public partial class SteelFloorLampDrawingItem: DrawingItem {}
}
