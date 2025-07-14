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
    public partial class OilRefineryInvention: InventionRecipe
    {
        public OilRefineryInvention() 
        {
            this.InventionKits = new Item[]
            {
                Item.Get(typeof(IndustrialMachineKitItem)), Item.Get(typeof(IndustrialMaterialKitItem)), 
            };
        
            this.InventionLabor         = 420f;
            this.InventionTime          = 20f;
            this.InventionExperience    = 40f;
            this.InventionTable = typeof(ResearchTableItem);

            this.InventionSkills = new RequiredSkill[]
            { 
                new(typeof(MechanicsSkill), 1), 
            };

            this.FabricationIngredients = new FabricationElement[]
            {
                new(typeof(ReinforcedConcreteItem), 12), new(typeof(IronPipeItem), 24), new(typeof(BoilerItem), 2), new(typeof(CopperPlateItem), 6), 
            };

            this.FabricationProducts = new FabricationElement[]
            {
                new(typeof(OilRefineryItem), 1, true), 
            };

            this.FabricationLabor       = 420f;
            this.FabricationTime        = 20f;
            this.FabricationExperience  = 40f;
            this.FabricationTable = typeof(AssemblyLineItem);

            this.FabricationSkills = new RequiredSkill[]
            { 
                new(typeof(MechanicsSkill), 1), 
            };

            
            this.Initialize(displayText: Localizer.DoStr("Oil Refinery"),
                            referencedDrawing:  typeof(OilRefineryDrawingItem));
        }
    }

    [Serialized]
    [Weight(100)]
    [LocDisplayName("Oil Refinery Technical Drawing")]
    [Tag("Technical Drawing")]
    public partial class OilRefineryDrawingItem: DrawingItem {}
}
