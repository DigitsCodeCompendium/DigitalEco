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
    public partial class ElectricPlanerInvention: InventionRecipe
    {
        public ElectricPlanerInvention() 
        {
            this.FabricationIngredients = new FabricationElement[]
            {
                new(typeof(SteelPlateItem), 12), new(typeof(RivetItem), 12), new(typeof(GearboxItem), 2), 
            };

            this.FabricationProducts = new FabricationElement[]
            {
                new(typeof(ElectricPlanerItem), 1, true), 
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
            this.Initialize(displayText: Localizer.DoStr("Electric Planer"),
                            referencedRecipeFamilyType: typeof(ElectricPlanerRecipe),
                            referencedDrawing:  typeof(ElectricPlanerDrawingItem));
        }
    }

    [Serialized]
    [Weight(100)]
    [LocDisplayName("Electric Planer Technical Drawing")]
    [Tag("Technical Drawing")]
    public partial class ElectricPlanerDrawingItem: DrawingItem {}
}
