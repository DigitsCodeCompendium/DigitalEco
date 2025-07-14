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
    public partial class CopperPlateInvention: InventionRecipe
    {
        public CopperPlateInvention() 
        {
            this.InventionKits = new Item[]
            {
                Item.Get(typeof(SteamMaterialKitItem)), 
            };
        
            this.InventionLabor         = 60f;
            this.InventionTime          = 2f;
            this.InventionExperience    = 1f;
            this.InventionTable = typeof(ResearchTableItem);

            this.InventionSkills = new RequiredSkill[]
            { 
                new(typeof(MechanicsSkill), 1), 
            };

            this.FabricationIngredients = new FabricationElement[]
            {
                new(typeof(CopperBarItem), 1), 
            };

            this.FabricationProducts = new FabricationElement[]
            {
                new(typeof(CopperPlateItem), 1, true), 
            };

            this.FabricationLabor       = 60f;
            this.FabricationTime        = 2f;
            this.FabricationExperience  = 1f;
            this.FabricationTable = typeof(ScrewPressItem);

            this.FabricationSkills = new RequiredSkill[]
            { 
                new(typeof(MechanicsSkill), 1), 
            };

            
            this.Initialize(displayText: Localizer.DoStr("Copper Plate"),
                            referencedDrawing:  typeof(CopperPlateDrawingItem));
        }
    }

    [Serialized]
    [Weight(100)]
    [LocDisplayName("Copper Plate Technical Drawing")]
    [Tag("Technical Drawing")]
    public partial class CopperPlateDrawingItem: DrawingItem {}
}
