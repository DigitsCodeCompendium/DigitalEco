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
    public partial class ElectricLatheInvention: InventionRecipe
    {
        public ElectricLatheInvention() 
        {
            this.FabricationIngredients = new FabricationElement[]
            {
                new(typeof(IronWheelItem), 4), new(typeof(SteelPlateItem), 12), 
            };

            this.FabricationProducts = new FabricationElement[]
            {
                new(typeof(ElectricLatheItem), 1, true), 
            };

            this.RequiredKits = new List<Item>()
            {
                
            }.ToArray();

            this.InventionLabor     = 240f;
            this.InventionTime      = 8f;

            this.RequiredSkills = new RequiredSkill[]
            { 
                new(typeof(IndustrySkill), 1), 
            };

            this.FabricationTable = typeof(ElectricMachinistTableItem);
            this.Initialize(displayText: Localizer.DoStr("Electric Lathe"),
                            referencedRecipeFamilyType: typeof(ElectricLatheRecipe),
                            referencedDrawing:  typeof(ElectricLatheDrawingItem));
        }
    }

    [Serialized]
    [Weight(100)]
    [LocDisplayName("Electric Lathe Technical Drawing")]
    [Tag("Technical Drawing")]
    public partial class ElectricLatheDrawingItem: DrawingItem {}
}
