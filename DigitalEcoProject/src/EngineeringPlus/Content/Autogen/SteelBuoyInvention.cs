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
    public partial class SteelBuoyInvention: InventionRecipe
    {
        public SteelBuoyInvention() 
        {
            this.FabricationIngredients = new FabricationElement[]
            {
                new(typeof(SteelBarItem), 4), 
            };

            this.FabricationProducts = new FabricationElement[]
            {
                new(typeof(SteelBuoyItem), 1, true), 
            };

            this.RequiredKits = new List<Item>()
            {
                Item.Get(typeof(IndustrialMaterialKitItem)), 
            }.ToArray();

            this.InventionLabor     = 240f;
            this.InventionTime      = 1f;

            this.RequiredSkills = new RequiredSkill[]
            { 
                new(typeof(MechanicsSkill), 4), 
            };

            this.FabricationTable = typeof(MachinistTableItem);
            this.Initialize(displayText: Localizer.DoStr("Steel Buoy"),
                            referencedRecipeFamilyType: typeof(SteelBuoyRecipe),
                            referencedDrawing:  typeof(SteelBuoyDrawingItem));
        }
    }

    [Serialized]
    [Weight(100)]
    [LocDisplayName("Steel Buoy Technical Drawing")]
    [Tag("Technical Drawing")]
    public partial class SteelBuoyDrawingItem: DrawingItem {}
}
