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
    public partial class SteelKitchenLampInvention: InventionRecipe
    {
        public SteelKitchenLampInvention() 
        {
            this.FabricationIngredients = new FabricationElement[]
            {
                new(typeof(SteelBarItem), 6), new(typeof(PlasticItem), 4), new(typeof(CopperWiringItem), 5), new(typeof(LightBulbItem), 1, true), 
            };

            this.FabricationProducts = new FabricationElement[]
            {
                new(typeof(SteelKitchenLampItem), 1, true), 
            };

            this.RequiredKits = new List<Item>()
            {
                
            }.ToArray();

            this.InventionLabor     = 120f;
            this.InventionTime      = 3f;

            this.RequiredSkills = new RequiredSkill[]
            { 
                new(typeof(ElectronicsSkill), 3), 
            };

            this.FabricationTable = typeof(RoboticAssemblyLineItem);
            this.Initialize(displayText: Localizer.DoStr("Steel Kitchen Lamp"),
                            referencedRecipeFamilyType: typeof(SteelKitchenLampRecipe),
                            referencedDrawing:  typeof(SteelKitchenLampDrawingItem));
        }
    }

    [Serialized]
    [Weight(100)]
    [LocDisplayName("Steel Kitchen Lamp Technical Drawing")]
    [Tag("Technical Drawing")]
    public partial class SteelKitchenLampDrawingItem: DrawingItem {}
}
