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
    public partial class SteelGearInvention: InventionRecipe
    {
        public SteelGearInvention() 
        {
            this.InventionKits = new Item[]
            {
                Item.Get(typeof(SteamMaterialKitItem)),
            };
        
            this.InventionLabor         = 60f;
            this.InventionTime          = 0.4f;
            this.InventionExperience    = 1f;
            this.InventionTable = typeof(LaboratoryItem);

            this.InventionSkills = new RequiredSkill[]
            { 
                new(typeof(IndustrySkill), 1), 
            };

            this.FabricationIngredients = new FabricationElement[]
            {
                new(typeof(SteelBarItem), 2), new(typeof(EpoxyItem), 1), 
            };

            this.FabricationProducts = new FabricationElement[]
            {
                new(typeof(SteelGearItem), 1, true), 
            };

            this.FabricationLabor       = 60f;
            this.FabricationTime        = 0.4f;
            this.FabricationExperience  = 1f;
            this.FabricationTable = typeof(ElectricPlanerItem);

            this.FabricationSkills = new RequiredSkill[]
            { 
                new(typeof(IndustrySkill), 1), 
            };

            
            this.Initialize(displayText: Localizer.DoStr("Steel Gear"),
                            referencedDrawing:  typeof(SteelGearDrawingItem));
        }
    }

    [Serialized]
    [Weight(100)]
    [LocDisplayName("Steel Gear Technical Drawing")]
    [Tag("Technical Drawing")]
    public partial class SteelGearDrawingItem: DrawingItem {}
}
