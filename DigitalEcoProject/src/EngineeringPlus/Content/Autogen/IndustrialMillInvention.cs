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
    public partial class IndustrialMillInvention: InventionRecipe
    {
        public IndustrialMillInvention() 
        {
            this.FabricationIngredients = new FabricationElement[]
            {
                new(typeof(SteelPlateItem), 8), new(typeof(GearboxItem), 4), new(typeof(CombustionEngineItem), 1, true), 
            };

            this.FabricationProducts = new FabricationElement[]
            {
                new(typeof(IndustrialMillItem), 1, true), 
            };

            this.RequiredKits = new List<Item>()
            {
                
            }.ToArray();

            this.InventionLabor     = 360f;
            this.InventionTime      = 8f;

            this.RequiredSkills = new RequiredSkill[]
            { 
                new(typeof(IndustrySkill), 1), 
            };

            this.FabricationTable = typeof(MasonryTableItem);
            this.Initialize(displayText: Localizer.DoStr("Industrial Mill"),
                            referencedRecipeFamilyType: typeof(IndustrialMillRecipe),
                            referencedDrawing:  typeof(IndustrialMillDrawingItem));
        }
    }

    [Serialized]
    [Weight(100)]
    [LocDisplayName("Industrial Mill Technical Drawing")]
    [Tag("Technical Drawing")]
    public partial class IndustrialMillDrawingItem: DrawingItem {}
}
