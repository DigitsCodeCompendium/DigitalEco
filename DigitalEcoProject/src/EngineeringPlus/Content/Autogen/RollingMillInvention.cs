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
    public partial class RollingMillInvention: InventionRecipe
    {
        public RollingMillInvention() 
        {
            this.InventionKits = new Item[]
            {
                Item.Get(typeof(SteamMachineKitItem)), Item.Get(typeof(IndustrialMaterialKitItem)), 
            };
        
            this.InventionLabor         = 360f;
            this.InventionTime          = 20f;
            this.InventionExperience    = 5f;
            this.InventionTable = typeof(ResearchTableItem);

            this.InventionSkills = new RequiredSkill[]
            { 
                new(typeof(MechanicsSkill), 4), 
            };

            this.FabricationIngredients = new FabricationElement[]
            {
                new(typeof(SteelBarItem), 8), new(typeof(GearboxItem), 4), 
            };

            this.FabricationProducts = new FabricationElement[]
            {
                new(typeof(RollingMillItem), 1, true), 
            };

            this.FabricationLabor       = 360f;
            this.FabricationTime        = 20f;
            this.FabricationExperience  = 5f;
            this.FabricationTable = typeof(AssemblyLineItem);

            this.FabricationSkills = new RequiredSkill[]
            { 
                new(typeof(MechanicsSkill), 4), 
            };

            
            this.Initialize(displayText: Localizer.DoStr("Rolling Mill"),
                            referencedDrawing:  typeof(RollingMillDrawingItem));
        }
    }

    [Serialized]
    [Weight(100)]
    [LocDisplayName("Rolling Mill Technical Drawing")]
    [Tag("Technical Drawing")]
    public partial class RollingMillDrawingItem: DrawingItem {}
}
