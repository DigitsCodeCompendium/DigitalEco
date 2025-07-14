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
    public partial class SinkInvention: InventionRecipe
    {
        public SinkInvention() 
        {
            this.InventionKits = new Item[]
            {
                Item.Get(typeof(SteamMachineKitItem)), 
            };
        
            this.InventionLabor         = 110f;
            this.InventionTime          = 8f;
            this.InventionExperience    = 5f;
            this.InventionTable = typeof(ResearchTableItem);

            this.InventionSkills = new RequiredSkill[]
            { 
                new(typeof(MechanicsSkill), 4), 
            };

            this.FabricationIngredients = new FabricationElement[]
            {
                new(typeof(SteelBarItem), 8), new(typeof(IronPlateItem), 8), 
            };

            this.FabricationProducts = new FabricationElement[]
            {
                new(typeof(SinkItem), 1, true), 
            };

            this.FabricationLabor       = 110f;
            this.FabricationTime        = 8f;
            this.FabricationExperience  = 5f;
            this.FabricationTable = typeof(AssemblyLineItem);

            this.FabricationSkills = new RequiredSkill[]
            { 
                new(typeof(MechanicsSkill), 4), 
            };

            
            this.Initialize(displayText: Localizer.DoStr("Sink"),
                            referencedDrawing:  typeof(SinkDrawingItem));
        }
    }

    [Serialized]
    [Weight(100)]
    [LocDisplayName("Sink Technical Drawing")]
    [Tag("Technical Drawing")]
    public partial class SinkDrawingItem: DrawingItem {}
}
