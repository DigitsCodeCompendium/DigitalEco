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
    public partial class CementKilnInvention: InventionRecipe
    {
        public CementKilnInvention() 
        {
            this.InventionKits = new Item[]
            {
                Item.Get(typeof(SteamMachineKitItem)), Item.Get(typeof(IndustrialMaterialKitItem)), 
            };
        
            this.InventionLabor         = 600f;
            this.InventionTime          = 100f;
            this.InventionExperience    = 20f;
            this.InventionTable = typeof(ResearchTableItem);

            this.InventionSkills = new RequiredSkill[]
            { 
                new(typeof(MechanicsSkill), 4), 
            };

            this.FabricationIngredients = new FabricationElement[]
            {
                new(typeof(GearboxItem), 8), new(typeof(PistonItem), 4), new(typeof(IronPlateItem), 16), 
            };

            this.FabricationProducts = new FabricationElement[]
            {
                new(typeof(CementKilnItem), 1, true), 
            };

            this.FabricationLabor       = 600f;
            this.FabricationTime        = 100f;
            this.FabricationExperience  = 20f;
            this.FabricationTable = typeof(AssemblyLineItem);

            this.FabricationSkills = new RequiredSkill[]
            { 
                new(typeof(MechanicsSkill), 4), 
            };

            
            this.Initialize(displayText: Localizer.DoStr("Cement Kiln"),
                            referencedDrawing:  typeof(CementKilnDrawingItem));
        }
    }

    [Serialized]
    [Weight(100)]
    [LocDisplayName("Cement Kiln Technical Drawing")]
    [Tag("Technical Drawing")]
    public partial class CementKilnDrawingItem: DrawingItem {}
}
