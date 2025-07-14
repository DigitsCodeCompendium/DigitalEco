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
    public partial class SteelGearboxInvention: InventionRecipe
    {
        public SteelGearboxInvention() 
        {
            this.InventionKits = new Item[]
            {
                Item.Get(typeof(SteamMaterialKitItem)),
            };
        
            this.InventionLabor         = 100f;
            this.InventionTime          = 2f;
            this.InventionExperience    = 2.5f;
            this.InventionTable = typeof(LaboratoryItem);

            this.InventionSkills = new RequiredSkill[]
            { 
                new(typeof(IndustrySkill), 2), 
            };

            this.FabricationIngredients = new FabricationElement[]
            {
                new(typeof(SteelBarItem), 8), new(typeof(SteelGearItem), 4), 
            };

            this.FabricationProducts = new FabricationElement[]
            {
                new(typeof(SteelGearboxItem), 1, true), 
            };

            this.FabricationLabor       = 100f;
            this.FabricationTime        = 2f;
            this.FabricationExperience  = 2.5f;
            this.FabricationTable = typeof(ElectricPlanerItem);

            this.FabricationSkills = new RequiredSkill[]
            { 
                new(typeof(IndustrySkill), 2), 
            };

            
            this.Initialize(displayText: Localizer.DoStr("Steel Gearbox"),
                            referencedDrawing:  typeof(SteelGearboxDrawingItem));
        }
    }

    [Serialized]
    [Weight(100)]
    [LocDisplayName("Steel Gearbox Technical Drawing")]
    [Tag("Technical Drawing")]
    public partial class SteelGearboxDrawingItem: DrawingItem {}
}
