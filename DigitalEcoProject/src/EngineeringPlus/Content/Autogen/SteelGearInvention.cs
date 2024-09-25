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
    public partial class SteelGearInvention: InventionRecipe
    {
        public SteelGearInvention() 
        {
            this.FabricationIngredients = new FabricationElement[]
            {
                new(typeof(SteelBarItem), 2), new(typeof(EpoxyItem), 1), 
            };

            this.FabricationProducts = new FabricationElement[]
            {
                new(typeof(SteelGearItem), 1, true), 
            };

            this.RequiredKits = new List<Item>()
            {
                
            }.ToArray();

            this.InventionLabor     = 60f;
            this.InventionTime      = 0.4f;

            this.RequiredSkills = new RequiredSkill[]
            { 
                new(typeof(IndustrySkill), 1), 
            };

            this.FabricationTable = typeof(ElectricPlanerItem);
            this.Initialize(displayText: Localizer.DoStr("Steel Gear"),
                            referencedRecipeFamilyType: typeof(SteelGearRecipe),
                            referencedDrawing:  typeof(SteelGearDrawingItem));
        }
    }

    [Serialized]
    [Weight(100)]
    [LocDisplayName("Steel Gear Technical Drawing")]
    [Tag("Technical Drawing")]
    public partial class SteelGearDrawingItem: DrawingItem {}
}
