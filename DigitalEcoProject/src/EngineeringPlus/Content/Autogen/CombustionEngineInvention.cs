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
    public partial class CombustionEngineInvention: InventionRecipe
    {
        public CombustionEngineInvention() 
        {
            this.InventionKits = new Item[]
            {
                Item.Get(typeof(IndustrialMaterialKitItem)), 
            };
        
            this.InventionLabor         = 300f;
            this.InventionTime          = 8f;
            this.InventionExperience    = 15f;
            this.InventionTable = typeof(ResearchTableItem);

            this.InventionSkills = new RequiredSkill[]
            { 
                new(typeof(MechanicsSkill), 3), 
            };

            this.FabricationIngredients = new FabricationElement[]
            {
                new(typeof(PistonItem), 6), new(typeof(GearboxItem), 4), new(typeof(IronPlateItem), 12), new(typeof(RivetItem), 8), 
            };

            this.FabricationProducts = new FabricationElement[]
            {
                new(typeof(CombustionEngineItem), 1, true), 
            };

            this.FabricationLabor       = 300f;
            this.FabricationTime        = 8f;
            this.FabricationExperience  = 15f;
            this.FabricationTable = typeof(AssemblyLineItem);

            this.FabricationSkills = new RequiredSkill[]
            { 
                new(typeof(MechanicsSkill), 3), 
            };

            
            this.Initialize(displayText: Localizer.DoStr("Combustion Engine"),
                            referencedDrawing:  typeof(CombustionEngineDrawingItem));
        }
    }

    [Serialized]
    [Weight(100)]
    [LocDisplayName("Combustion Engine Technical Drawing")]
    [Tag("Technical Drawing")]
    public partial class CombustionEngineDrawingItem: DrawingItem {}
}
