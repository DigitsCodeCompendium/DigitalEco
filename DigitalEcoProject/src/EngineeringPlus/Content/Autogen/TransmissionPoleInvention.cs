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
    public partial class TransmissionPoleInvention: InventionRecipe
    {
        public TransmissionPoleInvention() 
        {
            this.InventionKits = new Item[]
            {
                Item.Get(typeof(IndustrialMachineKitItem)), 
            };
        
            this.InventionLabor         = 480f;
            this.InventionTime          = 4f;
            this.InventionExperience    = 2f;
            this.InventionTable = typeof(ResearchTableItem);

            this.InventionSkills = new RequiredSkill[]
            { 
                new(typeof(MechanicsSkill), 4), 
            };

            this.FabricationIngredients = new FabricationElement[]
            {
                new(typeof(IronBarItem), 8), new(typeof(CopperWiringItem), 14), new("Lumber", 10), 
            };

            this.FabricationProducts = new FabricationElement[]
            {
                new(typeof(TransmissionPoleItem), 1, true), 
            };

            this.FabricationLabor       = 480f;
            this.FabricationTime        = 4f;
            this.FabricationExperience  = 2f;
            this.FabricationTable = typeof(MachinistTableItem);

            this.FabricationSkills = new RequiredSkill[]
            { 
                new(typeof(MechanicsSkill), 4), 
            };

            
            this.Initialize(displayText: Localizer.DoStr("Transmission Pole"),
                            referencedDrawing:  typeof(TransmissionPoleDrawingItem));
        }
    }

    [Serialized]
    [Weight(100)]
    [LocDisplayName("Transmission Pole Technical Drawing")]
    [Tag("Technical Drawing")]
    public partial class TransmissionPoleDrawingItem: DrawingItem {}
}
