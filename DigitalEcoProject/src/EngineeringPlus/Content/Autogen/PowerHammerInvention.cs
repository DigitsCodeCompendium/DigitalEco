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
    public partial class PowerHammerInvention: InventionRecipe
    {
        public PowerHammerInvention() 
        {
            this.InventionKits = new Item[]
            {
                Item.Get(typeof(SteamMachineKitItem)), Item.Get(typeof(SteamMaterialKitItem)), 
            };
        
            this.InventionLabor         = 180f;
            this.InventionTime          = 8f;
            this.InventionExperience    = 10f;
            this.InventionTable = typeof(ResearchTableItem);

            this.InventionSkills = new RequiredSkill[]
            { 
                new(typeof(MechanicsSkill), 1), 
            };

            this.FabricationIngredients = new FabricationElement[]
            {
                new(typeof(IronPlateItem), 4), new(typeof(GearboxItem), 4), new(typeof(CopperPlateItem), 2), new("HewnLog", 10), 
            };

            this.FabricationProducts = new FabricationElement[]
            {
                new(typeof(PowerHammerItem), 1, true), 
            };

            this.FabricationLabor       = 180f;
            this.FabricationTime        = 8f;
            this.FabricationExperience  = 10f;
            this.FabricationTable = typeof(AssemblyLineItem);

            this.FabricationSkills = new RequiredSkill[]
            { 
                new(typeof(MechanicsSkill), 1), 
            };

            
            this.Initialize(displayText: Localizer.DoStr("Power Hammer"),
                            referencedDrawing:  typeof(PowerHammerDrawingItem));
        }
    }

    [Serialized]
    [Weight(100)]
    [LocDisplayName("Power Hammer Technical Drawing")]
    [Tag("Technical Drawing")]
    public partial class PowerHammerDrawingItem: DrawingItem {}
}
