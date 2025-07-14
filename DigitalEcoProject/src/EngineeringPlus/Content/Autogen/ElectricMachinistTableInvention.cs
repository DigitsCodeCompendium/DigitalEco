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
    public partial class ElectricMachinistTableInvention: InventionRecipe
    {
        public ElectricMachinistTableInvention() 
        {
            this.InventionKits = new Item[]
            {
                Item.Get(typeof(SteamMaterialKitItem)),
            };
        
            this.InventionLabor         = 360f;
            this.InventionTime          = 8f;
            this.InventionExperience    = 20f;
            this.InventionTable = typeof(ResearchTableItem);

            this.InventionSkills = new RequiredSkill[]
            { 
                new(typeof(MechanicsSkill), 1), 
            };

            this.FabricationIngredients = new FabricationElement[]
            {
                new(typeof(SteelBarItem), 12), new(typeof(IronPlateItem), 12), new(typeof(IronGearItem), 8), 
            };

            this.FabricationProducts = new FabricationElement[]
            {
                new(typeof(ElectricMachinistTableItem), 1, true), 
            };

            this.FabricationLabor       = 360f;
            this.FabricationTime        = 8f;
            this.FabricationExperience  = 20f;
            this.FabricationTable = typeof(AssemblyLineItem);

            this.FabricationSkills = new RequiredSkill[]
            { 
                new(typeof(MechanicsSkill), 1), 
            };

            
            this.Initialize(displayText: Localizer.DoStr("Electric Machinist Table"),
                            referencedDrawing:  typeof(ElectricMachinistTableDrawingItem));
        }
    }

    [Serialized]
    [Weight(100)]
    [LocDisplayName("Electric Machinist Table Technical Drawing")]
    [Tag("Technical Drawing")]
    public partial class ElectricMachinistTableDrawingItem: DrawingItem {}
}
