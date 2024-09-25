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
    public partial class AdvancedMasonryTableInvention: InventionRecipe
    {
        public AdvancedMasonryTableInvention() 
        {
            this.FabricationIngredients = new FabricationElement[]
            {
                new(typeof(SteelPlateItem), 10), new(typeof(SteelSawBladeItem), 10), 
            };

            this.FabricationProducts = new FabricationElement[]
            {
                new(typeof(AdvancedMasonryTableItem), 1, true), 
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
            this.Initialize(displayText: Localizer.DoStr("Advanced Masonry Table"),
                            referencedRecipeFamilyType: typeof(AdvancedMasonryTableRecipe),
                            referencedDrawing:  typeof(AdvancedMasonryTableDrawingItem));
        }
    }

    [Serialized]
    [Weight(100)]
    [LocDisplayName("Advanced Masonry Table Technical Drawing")]
    [Tag("Technical Drawing")]
    public partial class AdvancedMasonryTableDrawingItem: DrawingItem {}
}
