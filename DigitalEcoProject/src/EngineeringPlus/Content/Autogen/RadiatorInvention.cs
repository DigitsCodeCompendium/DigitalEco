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
    public partial class RadiatorInvention: InventionRecipe
    {
        public RadiatorInvention() 
        {
            this.InventionKits = new Item[]
            {
                Item.Get(typeof(SteamMaterialKitItem)),
            };
        
            this.InventionLabor         = 35f;
            this.InventionTime          = 1.5f;
            this.InventionExperience    = 3f;
            this.InventionTable = typeof(LaboratoryItem);

            this.InventionSkills = new RequiredSkill[]
            { 
                new(typeof(IndustrySkill), 1), 
            };

            this.FabricationIngredients = new FabricationElement[]
            {
                new(typeof(HeatSinkItem), 4), new(typeof(CopperWiringItem), 8), 
            };

            this.FabricationProducts = new FabricationElement[]
            {
                new(typeof(RadiatorItem), 1, true), 
            };

            this.FabricationLabor       = 35f;
            this.FabricationTime        = 1.5f;
            this.FabricationExperience  = 3f;
            this.FabricationTable = typeof(ElectricStampingPressItem);

            this.FabricationSkills = new RequiredSkill[]
            { 
                new(typeof(IndustrySkill), 1), 
            };

            
            this.Initialize(displayText: Localizer.DoStr("Radiator"),
                            referencedDrawing:  typeof(RadiatorDrawingItem));
        }
    }

    [Serialized]
    [Weight(100)]
    [LocDisplayName("Radiator Technical Drawing")]
    [Tag("Technical Drawing")]
    public partial class RadiatorDrawingItem: DrawingItem {}
}
