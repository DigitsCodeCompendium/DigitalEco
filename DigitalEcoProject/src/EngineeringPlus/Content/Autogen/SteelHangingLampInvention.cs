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
    public partial class SteelHangingLampInvention: InventionRecipe
    {
        public SteelHangingLampInvention() 
        {
            this.FabricationIngredients = new FabricationElement[]
            {
                new(typeof(SteelBarItem), 4), new(typeof(PlasticItem), 6), new(typeof(CopperWiringItem), 5), new("CompositeLumber", 6), new(typeof(LightBulbItem), 1, true), 
            };

            this.FabricationProducts = new FabricationElement[]
            {
                new(typeof(SteelHangingLampItem), 1, true), 
            };

            this.RequiredKits = new List<Item>()
            {
                
            }.ToArray();

            this.InventionLabor     = 120f;
            this.InventionTime      = 4f;

            this.RequiredSkills = new RequiredSkill[]
            { 
                new(typeof(ElectronicsSkill), 4), 
            };

            this.FabricationTable = typeof(RoboticAssemblyLineItem);
            this.Initialize(displayText: Localizer.DoStr("Steel Hanging Lamp"),
                            referencedRecipeFamilyType: typeof(SteelHangingLampRecipe),
                            referencedDrawing:  typeof(SteelHangingLampDrawingItem));
        }
    }

    [Serialized]
    [Weight(100)]
    [LocDisplayName("Steel Hanging Lamp Technical Drawing")]
    [Tag("Technical Drawing")]
    public partial class SteelHangingLampDrawingItem: DrawingItem {}
}
