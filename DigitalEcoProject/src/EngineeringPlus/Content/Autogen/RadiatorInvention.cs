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
    public partial class RadiatorInvention: InventionRecipe
    {
        public RadiatorInvention() 
        {
            this.FabricationIngredients = new FabricationElement[]
            {
                new(typeof(HeatSinkItem), 4), new(typeof(CopperWiringItem), 8), 
            };

            this.FabricationProducts = new FabricationElement[]
            {
                new(typeof(RadiatorItem), 1, true), 
            };

            this.RequiredKits = new List<Item>()
            {
                
            }.ToArray();

            this.InventionLabor     = 35f;
            this.InventionTime      = 1.5f;

            this.RequiredSkills = new RequiredSkill[]
            { 
                new(typeof(IndustrySkill), 1), 
            };

            this.FabricationTable = typeof(ElectricStampingPressItem);
            this.Initialize(displayText: Localizer.DoStr("Radiator"),
                            referencedRecipeFamilyType: typeof(RadiatorRecipe),
                            referencedDrawing:  typeof(RadiatorDrawingItem));
        }
    }

    [Serialized]
    [Weight(100)]
    [LocDisplayName("Radiator Technical Drawing")]
    [Tag("Technical Drawing")]
    public partial class RadiatorDrawingItem: DrawingItem {}
}
