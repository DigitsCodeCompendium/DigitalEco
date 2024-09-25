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
    public partial class WasteFilterInvention: InventionRecipe
    {
        public WasteFilterInvention() 
        {
            this.FabricationIngredients = new FabricationElement[]
            {
                new(typeof(SteelBarItem), 12), new(typeof(CementItem), 8), new(typeof(GearboxItem), 4), new(typeof(PistonItem), 2), 
            };

            this.FabricationProducts = new FabricationElement[]
            {
                new(typeof(WasteFilterItem), 1, true), 
            };

            this.RequiredKits = new List<Item>()
            {
                Item.Get(typeof(IndustrialMachineKitItem)), 
            }.ToArray();

            this.InventionLabor     = 480f;
            this.InventionTime      = 20f;

            this.RequiredSkills = new RequiredSkill[]
            { 
                new(typeof(MechanicsSkill), 4), 
            };

            this.FabricationTable = typeof(AssemblyLineItem);
            this.Initialize(displayText: Localizer.DoStr("Waste Filter"),
                            referencedRecipeFamilyType: typeof(WasteFilterRecipe),
                            referencedDrawing:  typeof(WasteFilterDrawingItem));
        }
    }

    [Serialized]
    [Weight(100)]
    [LocDisplayName("Waste Filter Technical Drawing")]
    [Tag("Technical Drawing")]
    public partial class WasteFilterDrawingItem: DrawingItem {}
}
