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
    public partial class AdvancedTailoringTableInvention: InventionRecipe
    {
        public AdvancedTailoringTableInvention() 
        {
            this.InventionKits = new Item[]
            {
                Item.Get(typeof(SteamMaterialKitItem)),
            };
        
            this.InventionLabor         = 600f;
            this.InventionTime          = 15f;
            this.InventionExperience    = 5f;
            this.InventionTable = typeof(LaboratoryItem);

            this.InventionSkills = new RequiredSkill[]
            { 
                new(typeof(IndustrySkill), 1), 
            };

            this.FabricationIngredients = new FabricationElement[]
            {
                new(typeof(SteelPlateItem), 20), new(typeof(BasicCircuitItem), 10), 
            };

            this.FabricationProducts = new FabricationElement[]
            {
                new(typeof(AdvancedTailoringTableItem), 1, true), 
            };

            this.FabricationLabor       = 600f;
            this.FabricationTime        = 15f;
            this.FabricationExperience  = 5f;
            this.FabricationTable = typeof(ElectricMachinistTableItem);

            this.FabricationSkills = new RequiredSkill[]
            { 
                new(typeof(IndustrySkill), 1), 
            };

            
            this.Initialize(displayText: Localizer.DoStr("Advanced Tailoring Table"),
                            referencedDrawing:  typeof(AdvancedTailoringTableDrawingItem));
        }
    }

    [Serialized]
    [Weight(100)]
    [LocDisplayName("Advanced Tailoring Table Technical Drawing")]
    [Tag("Technical Drawing")]
    public partial class AdvancedTailoringTableDrawingItem: DrawingItem {}
}
