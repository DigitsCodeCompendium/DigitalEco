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
    public partial class ExcavatorInvention: InventionRecipe
    {
        public ExcavatorInvention() 
        {
            this.FabricationIngredients = new FabricationElement[]
            {
                new(typeof(GearboxItem), 4), new(typeof(SteelPlateItem), 20), new(typeof(NylonFabricItem), 20), new(typeof(SteelSpringItem), 6), new(typeof(AdvancedCombustionEngineItem), 1, true), new(typeof(RubberWheelItem), 4, true), new(typeof(RadiatorItem), 2, true), new(typeof(SteelAxleItem), 2, true), new(typeof(LightBulbItem), 4, true), new(typeof(LubricantItem), 2, true), 
            };

            this.FabricationProducts = new FabricationElement[]
            {
                new(typeof(ExcavatorItem), 1, true), 
            };

            this.RequiredKits = new List<Item>()
            {
                
            }.ToArray();

            this.InventionLabor     = 3000f;
            this.InventionTime      = 20f;

            this.RequiredSkills = new RequiredSkill[]
            { 
                new(typeof(IndustrySkill), 2), 
            };

            this.FabricationTable = typeof(RoboticAssemblyLineItem);
            this.Initialize(displayText: Localizer.DoStr("Excavator"),
                            referencedRecipeFamilyType: typeof(ExcavatorRecipe),
                            referencedDrawing:  typeof(ExcavatorDrawingItem));
        }
    }

    [Serialized]
    [Weight(100)]
    [LocDisplayName("Excavator Technical Drawing")]
    [Tag("Technical Drawing")]
    public partial class ExcavatorDrawingItem: DrawingItem {}
}
