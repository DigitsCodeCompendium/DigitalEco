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
    public partial class ElectronicsAssemblyInvention: InventionRecipe
    {
        public ElectronicsAssemblyInvention() 
        {
            this.InventionKits = new Item[]
            {
                Item.Get(typeof(SteamMaterialKitItem)),
            };
        
            this.InventionLabor         = 300f;
            this.InventionTime          = 25f;
            this.InventionExperience    = 20f;
            this.InventionTable = typeof(LaboratoryItem);

            this.InventionSkills = new RequiredSkill[]
            { 
                new(typeof(ElectronicsSkill), 1), 
            };

            this.FabricationIngredients = new FabricationElement[]
            {
                new(typeof(CorrugatedSteelItem), 8), new(typeof(RivetItem), 20), new(typeof(CopperWiringItem), 25), new(typeof(PlasticItem), 12), 
            };

            this.FabricationProducts = new FabricationElement[]
            {
                new(typeof(ElectronicsAssemblyItem), 1, true), 
            };

            this.FabricationLabor       = 300f;
            this.FabricationTime        = 25f;
            this.FabricationExperience  = 20f;
            this.FabricationTable = typeof(ElectricMachinistTableItem);

            this.FabricationSkills = new RequiredSkill[]
            { 
                new(typeof(ElectronicsSkill), 1), 
            };

            
            this.Initialize(displayText: Localizer.DoStr("Electronics Assembly"),
                            referencedDrawing:  typeof(ElectronicsAssemblyDrawingItem));
        }
    }

    [Serialized]
    [Weight(100)]
    [LocDisplayName("Electronics Assembly Technical Drawing")]
    [Tag("Technical Drawing")]
    public partial class ElectronicsAssemblyDrawingItem: DrawingItem {}
}
