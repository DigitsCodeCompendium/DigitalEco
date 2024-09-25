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
    public partial class RefrigeratorInvention: InventionRecipe
    {
        public RefrigeratorInvention() 
        {
            this.FabricationIngredients = new FabricationElement[]
            {
                new(typeof(SteelPlateItem), 16), new(typeof(BasicCircuitItem), 8), new(typeof(RadiatorItem), 3), 
            };

            this.FabricationProducts = new FabricationElement[]
            {
                new(typeof(RefrigeratorItem), 1, true), 
            };

            this.RequiredKits = new List<Item>()
            {
                
            }.ToArray();

            this.InventionLabor     = 120f;
            this.InventionTime      = 10f;

            this.RequiredSkills = new RequiredSkill[]
            { 
                new(typeof(IndustrySkill), 4), 
            };

            this.FabricationTable = typeof(RoboticAssemblyLineItem);
            this.Initialize(displayText: Localizer.DoStr("Refrigerator"),
                            referencedRecipeFamilyType: typeof(RefrigeratorRecipe),
                            referencedDrawing:  typeof(RefrigeratorDrawingItem));
        }
    }

    [Serialized]
    [Weight(100)]
    [LocDisplayName("Refrigerator Technical Drawing")]
    [Tag("Technical Drawing")]
    public partial class RefrigeratorDrawingItem: DrawingItem {}
}
