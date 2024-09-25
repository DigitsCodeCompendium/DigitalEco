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
    public partial class SteelSearchlightInvention: InventionRecipe
    {
        public SteelSearchlightInvention() 
        {
            this.FabricationIngredients = new FabricationElement[]
            {
                new(typeof(SteelPlateItem), 8), new(typeof(RivetItem), 8), new(typeof(CopperWiringItem), 10), new(typeof(LightBulbItem), 4, true), 
            };

            this.FabricationProducts = new FabricationElement[]
            {
                new(typeof(SteelSearchlightItem), 1, true), 
            };

            this.RequiredKits = new List<Item>()
            {
                
            }.ToArray();

            this.InventionLabor     = 120f;
            this.InventionTime      = 4f;

            this.RequiredSkills = new RequiredSkill[]
            { 
                new(typeof(ElectronicsSkill), 3), 
            };

            this.FabricationTable = typeof(RoboticAssemblyLineItem);
            this.Initialize(displayText: Localizer.DoStr("Steel Searchlight"),
                            referencedRecipeFamilyType: typeof(SteelSearchlightRecipe),
                            referencedDrawing:  typeof(SteelSearchlightDrawingItem));
        }
    }

    [Serialized]
    [Weight(100)]
    [LocDisplayName("Steel Searchlight Technical Drawing")]
    [Tag("Technical Drawing")]
    public partial class SteelSearchlightDrawingItem: DrawingItem {}
}
