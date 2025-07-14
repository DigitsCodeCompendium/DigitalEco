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
    public partial class RubberWheelInvention: InventionRecipe
    {
        public RubberWheelInvention() 
        {
            this.InventionKits = new Item[]
            {
                Item.Get(typeof(SteamMaterialKitItem)),
            };
        
            this.InventionLabor         = 60f;
            this.InventionTime          = 2f;
            this.InventionExperience    = 3.5f;
            this.InventionTable = typeof(LaboratoryItem);

            this.InventionSkills = new RequiredSkill[]
            { 
                new(typeof(IndustrySkill), 1), 
            };

            this.FabricationIngredients = new FabricationElement[]
            {
                new(typeof(SyntheticRubberItem), 8), new(typeof(SteelBarItem), 4), 
            };

            this.FabricationProducts = new FabricationElement[]
            {
                new(typeof(RubberWheelItem), 1, true), 
            };

            this.FabricationLabor       = 60f;
            this.FabricationTime        = 2f;
            this.FabricationExperience  = 3.5f;
            this.FabricationTable = typeof(ElectricLatheItem);

            this.FabricationSkills = new RequiredSkill[]
            { 
                new(typeof(IndustrySkill), 1), 
            };

            
            this.Initialize(displayText: Localizer.DoStr("Rubber Wheel"),
                            referencedDrawing:  typeof(RubberWheelDrawingItem));
        }
    }

    [Serialized]
    [Weight(100)]
    [LocDisplayName("Rubber Wheel Technical Drawing")]
    [Tag("Technical Drawing")]
    public partial class RubberWheelDrawingItem: DrawingItem {}
}
