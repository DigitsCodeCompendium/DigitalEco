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
    public partial class AdvancedCarpentryTableInvention: InventionRecipe
    {
        public AdvancedCarpentryTableInvention() 
        {
            this.FabricationIngredients = new FabricationElement[]
            {
                new(typeof(SteelPlateItem), 6), new(typeof(SteelSawBladeItem), 6), new("Lumber", 10), 
            };

            this.FabricationProducts = new FabricationElement[]
            {
                new(typeof(AdvancedCarpentryTableItem), 1, true), 
            };

            this.RequiredKits = new List<Item>()
            {
                
            }.ToArray();

            this.InventionLabor     = 600f;
            this.InventionTime      = 15f;

            this.RequiredSkills = new RequiredSkill[]
            { 
                new(typeof(IndustrySkill), 1), 
            };

            this.FabricationTable = typeof(ElectricMachinistTableItem);
            this.Initialize(displayText: Localizer.DoStr("Advanced Carpentry Table"),
                            referencedRecipeFamilyType: typeof(AdvancedCarpentryTableRecipe),
                            referencedDrawing:  typeof(AdvancedCarpentryTableDrawingItem));
        }
    }

    [Serialized]
    [Weight(100)]
    [LocDisplayName("Advanced Carpentry Table Technical Drawing")]
    [Tag("Technical Drawing")]
    public partial class AdvancedCarpentryTableDrawingItem: DrawingItem {}
}
