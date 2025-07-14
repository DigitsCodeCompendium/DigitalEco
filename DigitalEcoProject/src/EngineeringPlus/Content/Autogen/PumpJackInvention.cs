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
    public partial class PumpJackInvention: InventionRecipe
    {
        public PumpJackInvention() 
        {
            this.InventionKits = new Item[]
            {
                Item.Get(typeof(IndustrialMachineKitItem)), Item.Get(typeof(IndustrialMaterialKitItem)), 
            };
        
            this.InventionLabor         = 72f;
            this.InventionTime          = 20f;
            this.InventionExperience    = 25f;
            this.InventionTable = typeof(ResearchTableItem);

            this.InventionSkills = new RequiredSkill[]
            { 
                new(typeof(MechanicsSkill), 1), 
            };

            this.FabricationIngredients = new FabricationElement[]
            {
                new(typeof(ReinforcedConcreteItem), 12), new(typeof(GearboxItem), 4), new(typeof(PistonItem), 8), 
            };

            this.FabricationProducts = new FabricationElement[]
            {
                new(typeof(PumpJackItem), 1, true), 
            };

            this.FabricationLabor       = 72f;
            this.FabricationTime        = 20f;
            this.FabricationExperience  = 25f;
            this.FabricationTable = typeof(AssemblyLineItem);

            this.FabricationSkills = new RequiredSkill[]
            { 
                new(typeof(MechanicsSkill), 1), 
            };

            
            this.Initialize(displayText: Localizer.DoStr("Pump Jack"),
                            referencedDrawing:  typeof(PumpJackDrawingItem));
        }
    }

    [Serialized]
    [Weight(100)]
    [LocDisplayName("Pump Jack Technical Drawing")]
    [Tag("Technical Drawing")]
    public partial class PumpJackDrawingItem: DrawingItem {}
}
