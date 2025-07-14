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
    public partial class AdvancedCircuitInvention: InventionRecipe
    {
        public AdvancedCircuitInvention() 
        {
            this.InventionKits = new Item[]
            {
                Item.Get(typeof(SteamMaterialKitItem)),
            };
        
            this.InventionLabor         = 85f;
            this.InventionTime          = 0.8f;
            this.InventionExperience    = 4f;
            this.InventionTable = typeof(LaboratoryItem);

            this.InventionSkills = new RequiredSkill[]
            { 
                new(typeof(ElectronicsSkill), 2), 
            };

            this.FabricationIngredients = new FabricationElement[]
            {
                new(typeof(CopperWiringItem), 4), new(typeof(GoldWiringItem), 4), new(typeof(GoldFlakesItem), 10), new(typeof(SubstrateItem), 2), 
            };

            this.FabricationProducts = new FabricationElement[]
            {
                new(typeof(AdvancedCircuitItem), 1, true), 
            };

            this.FabricationLabor       = 85f;
            this.FabricationTime        = 0.8f;
            this.FabricationExperience  = 4f;
            this.FabricationTable = typeof(ElectronicsAssemblyItem);

            this.FabricationSkills = new RequiredSkill[]
            { 
                new(typeof(ElectronicsSkill), 2), 
            };

            
            this.Initialize(displayText: Localizer.DoStr("Advanced Circuit"),
                            referencedDrawing:  typeof(AdvancedCircuitDrawingItem));
        }
    }

    [Serialized]
    [Weight(100)]
    [LocDisplayName("Advanced Circuit Technical Drawing")]
    [Tag("Technical Drawing")]
    public partial class AdvancedCircuitDrawingItem: DrawingItem {}
}
