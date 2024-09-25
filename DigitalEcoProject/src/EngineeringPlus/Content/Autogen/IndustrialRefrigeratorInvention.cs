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
    public partial class IndustrialRefrigeratorInvention: InventionRecipe
    {
        public IndustrialRefrigeratorInvention() 
        {
            this.FabricationIngredients = new FabricationElement[]
            {
                new(typeof(SteelPlateItem), 32), new(typeof(AdvancedCircuitItem), 12), new(typeof(RadiatorItem), 10), new(typeof(GlassItem), 4), 
            };

            this.FabricationProducts = new FabricationElement[]
            {
                new(typeof(IndustrialRefrigeratorItem), 1, true), 
            };

            this.RequiredKits = new List<Item>()
            {
                
            }.ToArray();

            this.InventionLabor     = 240f;
            this.InventionTime      = 10f;

            this.RequiredSkills = new RequiredSkill[]
            { 
                new(typeof(IndustrySkill), 6), 
            };

            this.FabricationTable = typeof(RoboticAssemblyLineItem);
            this.Initialize(displayText: Localizer.DoStr("Industrial Refrigerator"),
                            referencedRecipeFamilyType: typeof(IndustrialRefrigeratorRecipe),
                            referencedDrawing:  typeof(IndustrialRefrigeratorDrawingItem));
        }
    }

    [Serialized]
    [Weight(100)]
    [LocDisplayName("Industrial Refrigerator Technical Drawing")]
    [Tag("Technical Drawing")]
    public partial class IndustrialRefrigeratorDrawingItem: DrawingItem {}
}
