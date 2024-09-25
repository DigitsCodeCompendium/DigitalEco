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
            this.FabricationIngredients = new FabricationElement[]
            {
                new(typeof(SyntheticRubberItem), 8), new(typeof(SteelBarItem), 4), 
            };

            this.FabricationProducts = new FabricationElement[]
            {
                new(typeof(RubberWheelItem), 1, true), 
            };

            this.RequiredKits = new List<Item>()
            {
                
            }.ToArray();

            this.InventionLabor     = 60f;
            this.InventionTime      = 2f;

            this.RequiredSkills = new RequiredSkill[]
            { 
                new(typeof(IndustrySkill), 1), 
            };

            this.FabricationTable = typeof(ElectricLatheItem);
            this.Initialize(displayText: Localizer.DoStr("Rubber Wheel"),
                            referencedRecipeFamilyType: typeof(RubberWheelRecipe),
                            referencedDrawing:  typeof(RubberWheelDrawingItem));
        }
    }

    [Serialized]
    [Weight(100)]
    [LocDisplayName("Rubber Wheel Technical Drawing")]
    [Tag("Technical Drawing")]
    public partial class RubberWheelDrawingItem: DrawingItem {}
}
