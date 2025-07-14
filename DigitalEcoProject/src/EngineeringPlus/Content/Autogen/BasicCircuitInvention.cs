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
    public partial class BasicCircuitInvention: InventionRecipe
    {
        public BasicCircuitInvention() 
        {
            this.InventionKits = new Item[]
            {
                Item.Get(typeof(SteamMaterialKitItem)),
            };
        
            this.InventionLabor         = 45f;
            this.InventionTime          = 0.8f;
            this.InventionExperience    = 4f;
            this.InventionTable = typeof(LaboratoryItem);

            this.InventionSkills = new RequiredSkill[]
            { 
                new(typeof(ElectronicsSkill), 1), 
            };

            this.FabricationIngredients = new FabricationElement[]
            {
                new(typeof(CopperWiringItem), 6), new(typeof(GoldFlakesItem), 10), new(typeof(SubstrateItem), 2), 
            };

            this.FabricationProducts = new FabricationElement[]
            {
                new(typeof(BasicCircuitItem), 1, true), 
            };

            this.FabricationLabor       = 45f;
            this.FabricationTime        = 0.8f;
            this.FabricationExperience  = 4f;
            this.FabricationTable = typeof(ElectronicsAssemblyItem);

            this.FabricationSkills = new RequiredSkill[]
            { 
                new(typeof(ElectronicsSkill), 1), 
            };

            
            this.Initialize(displayText: Localizer.DoStr("Basic Circuit"),
                            referencedDrawing:  typeof(BasicCircuitDrawingItem));
        }
    }

    [Serialized]
    [Weight(100)]
    [LocDisplayName("Basic Circuit Technical Drawing")]
    [Tag("Technical Drawing")]
    public partial class BasicCircuitDrawingItem: DrawingItem {}
}
