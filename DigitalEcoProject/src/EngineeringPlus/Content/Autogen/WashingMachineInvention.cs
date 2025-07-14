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
    public partial class WashingMachineInvention: InventionRecipe
    {
        public WashingMachineInvention() 
        {
            this.InventionKits = new Item[]
            {
                Item.Get(typeof(SteamMaterialKitItem)),
            };
        
            this.InventionLabor         = 240f;
            this.InventionTime          = 10f;
            this.InventionExperience    = 2f;
            this.InventionTable = typeof(LaboratoryItem);

            this.InventionSkills = new RequiredSkill[]
            { 
                new(typeof(IndustrySkill), 3), 
            };

            this.FabricationIngredients = new FabricationElement[]
            {
                new(typeof(SteelBarItem), 12), new(typeof(BasicCircuitItem), 6), 
            };

            this.FabricationProducts = new FabricationElement[]
            {
                new(typeof(WashingMachineItem), 1, true), 
            };

            this.FabricationLabor       = 240f;
            this.FabricationTime        = 10f;
            this.FabricationExperience  = 2f;
            this.FabricationTable = typeof(RoboticAssemblyLineItem);

            this.FabricationSkills = new RequiredSkill[]
            { 
                new(typeof(IndustrySkill), 3), 
            };

            
            this.Initialize(displayText: Localizer.DoStr("Washing Machine"),
                            referencedDrawing:  typeof(WashingMachineDrawingItem));
        }
    }

    [Serialized]
    [Weight(100)]
    [LocDisplayName("Washing Machine Technical Drawing")]
    [Tag("Technical Drawing")]
    public partial class WashingMachineDrawingItem: DrawingItem {}
}
