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
    public partial class ModernDoubleStreetLightInvention: InventionRecipe
    {
        public ModernDoubleStreetLightInvention() 
        {
            this.FabricationIngredients = new FabricationElement[]
            {
                new(typeof(SteelPlateItem), 8), new(typeof(PlasticItem), 5), new(typeof(CopperWiringItem), 10), new(typeof(LightBulbItem), 2, true), 
            };

            this.FabricationProducts = new FabricationElement[]
            {
                new(typeof(ModernDoubleStreetLightItem), 1, true), 
            };

            this.RequiredKits = new List<Item>()
            {
                
            }.ToArray();

            this.InventionLabor     = 140f;
            this.InventionTime      = 6f;

            this.RequiredSkills = new RequiredSkill[]
            { 
                new(typeof(ElectronicsSkill), 5), 
            };

            this.FabricationTable = typeof(RoboticAssemblyLineItem);
            this.Initialize(displayText: Localizer.DoStr("Modern Double Street Light"),
                            referencedRecipeFamilyType: typeof(ModernDoubleStreetLightRecipe),
                            referencedDrawing:  typeof(ModernDoubleStreetLightDrawingItem));
        }
    }

    [Serialized]
    [Weight(100)]
    [LocDisplayName("Modern Double Street Light Technical Drawing")]
    [Tag("Technical Drawing")]
    public partial class ModernDoubleStreetLightDrawingItem: DrawingItem {}
}
