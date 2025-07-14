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
    public partial class ElectricStampingPressInvention: InventionRecipe
    {
        public ElectricStampingPressInvention() 
        {
            this.InventionKits = new Item[]
            {
                Item.Get(typeof(SteamMaterialKitItem)),
            };
        
            this.InventionLabor         = 240f;
            this.InventionTime          = 8f;
            this.InventionExperience    = 20f;
            this.InventionTable = typeof(LaboratoryItem);

            this.InventionSkills = new RequiredSkill[]
            { 
                new(typeof(IndustrySkill), 1), 
            };

            this.FabricationIngredients = new FabricationElement[]
            {
                new(typeof(SteelBarItem), 18), new(typeof(IronPlateItem), 4), new(typeof(PistonItem), 2), new(typeof(CopperWiringItem), 6), new(typeof(GearboxItem), 2, true), 
            };

            this.FabricationProducts = new FabricationElement[]
            {
                new(typeof(ElectricStampingPressItem), 1, true), 
            };

            this.FabricationLabor       = 240f;
            this.FabricationTime        = 8f;
            this.FabricationExperience  = 20f;
            this.FabricationTable = typeof(ElectricMachinistTableItem);

            this.FabricationSkills = new RequiredSkill[]
            { 
                new(typeof(IndustrySkill), 1), 
            };

            
            this.Initialize(displayText: Localizer.DoStr("Electric Stamping Press"),
                            referencedDrawing:  typeof(ElectricStampingPressDrawingItem));
        }
    }

    [Serialized]
    [Weight(100)]
    [LocDisplayName("Electric Stamping Press Technical Drawing")]
    [Tag("Technical Drawing")]
    public partial class ElectricStampingPressDrawingItem: DrawingItem {}
}
