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
    public partial class ElectricWallLampInvention: InventionRecipe
    {
        public ElectricWallLampInvention() 
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
                new(typeof(ElectronicsSkill), 1), 
            };

            this.FabricationIngredients = new FabricationElement[]
            {
                new(typeof(SteelBarItem), 5), new(typeof(CopperWiringItem), 5), new(typeof(LightBulbItem), 1, true), 
            };

            this.FabricationProducts = new FabricationElement[]
            {
                new(typeof(ElectricWallLampItem), 1, true), 
            };

            this.FabricationLabor       = 120f;
            this.FabricationTime        = 4f;
            this.FabricationExperience  = 5f;
            this.FabricationTable = typeof(ElectronicsAssemblyItem);

            this.FabricationSkills = new RequiredSkill[]
            { 
                new(typeof(ElectronicsSkill), 1), 
            };

            
            this.Initialize(displayText: Localizer.DoStr("Electric Wall Lamp"),
                            referencedDrawing:  typeof(ElectricWallLampDrawingItem));
        }
    }

    [Serialized]
    [Weight(100)]
    [LocDisplayName("Electric Wall Lamp Technical Drawing")]
    [Tag("Technical Drawing")]
    public partial class ElectricWallLampDrawingItem: DrawingItem {}
}
