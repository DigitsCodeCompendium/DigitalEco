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
    public partial class PistonInvention: InventionRecipe
    {
        public PistonInvention() 
        {
            this.InventionKits = new Item[]
            {
                Item.Get(typeof(SteamMaterialKitItem)), 
            };
        
            this.InventionLabor         = 60f;
            this.InventionTime          = 1.5f;
            this.InventionExperience    = 2f;
            this.InventionTable = typeof(ResearchTableItem);

            this.InventionSkills = new RequiredSkill[]
            { 
                new(typeof(MechanicsSkill), 1), 
            };

            this.FabricationIngredients = new FabricationElement[]
            {
                new(typeof(IronPipeItem), 2), new(typeof(IronBarItem), 2), 
            };

            this.FabricationProducts = new FabricationElement[]
            {
                new(typeof(PistonItem), 1, true), 
            };

            this.FabricationLabor       = 60f;
            this.FabricationTime        = 1.5f;
            this.FabricationExperience  = 2f;
            this.FabricationTable = typeof(ScrewPressItem);

            this.FabricationSkills = new RequiredSkill[]
            { 
                new(typeof(MechanicsSkill), 1), 
            };

            
            this.Initialize(displayText: Localizer.DoStr("Piston"),
                            referencedDrawing:  typeof(PistonDrawingItem));
        }
    }

    [Serialized]
    [Weight(100)]
    [LocDisplayName("Piston Technical Drawing")]
    [Tag("Technical Drawing")]
    public partial class PistonDrawingItem: DrawingItem {}
}
