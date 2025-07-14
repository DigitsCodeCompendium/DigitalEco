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
    public partial class InjectionMoldMachineInvention: InventionRecipe
    {
        public InjectionMoldMachineInvention() 
        {
            this.InventionKits = new Item[]
            {
                Item.Get(typeof(SteamMaterialKitItem)),
            };
        
            this.InventionLabor         = 560f;
            this.InventionTime          = 5f;
            this.InventionExperience    = 1f;
            this.InventionTable = typeof(LaboratoryItem);

            this.InventionSkills = new RequiredSkill[]
            { 
                new(typeof(IndustrySkill), 3), 
            };

            this.FabricationIngredients = new FabricationElement[]
            {
                new(typeof(SteelPlateItem), 4), new(typeof(CopperWiringItem), 6), new(typeof(BasicCircuitItem), 4), new(typeof(ElectricMotorItem), 2, true), 
            };

            this.FabricationProducts = new FabricationElement[]
            {
                new(typeof(InjectionMoldMachineItem), 1, true), 
            };

            this.FabricationLabor       = 560f;
            this.FabricationTime        = 5f;
            this.FabricationExperience  = 1f;
            this.FabricationTable = typeof(ElectricMachinistTableItem);

            this.FabricationSkills = new RequiredSkill[]
            { 
                new(typeof(IndustrySkill), 3), 
            };

            
            this.Initialize(displayText: Localizer.DoStr("Injection Mold Machine"),
                            referencedDrawing:  typeof(InjectionMoldMachineDrawingItem));
        }
    }

    [Serialized]
    [Weight(100)]
    [LocDisplayName("Injection Mold Machine Technical Drawing")]
    [Tag("Technical Drawing")]
    public partial class InjectionMoldMachineDrawingItem: DrawingItem {}
}
