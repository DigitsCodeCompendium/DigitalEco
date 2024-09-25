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
    public partial class GoldWiringInvention: InventionRecipe
    {
        public GoldWiringInvention() 
        {
            this.FabricationIngredients = new FabricationElement[]
            {
                new(typeof(GoldBarItem), 4), 
            };

            this.FabricationProducts = new FabricationElement[]
            {
                new(typeof(GoldWiringItem), 2, true), 
            };

            this.RequiredKits = new List<Item>()
            {
                Item.Get(typeof(IndustrialMaterialKitItem)), 
            }.ToArray();

            this.InventionLabor     = 120f;
            this.InventionTime      = 0.4f;

            this.RequiredSkills = new RequiredSkill[]
            { 
                new(typeof(MechanicsSkill), 4), 
            };

            this.FabricationTable = typeof(ElectricMachinistTableItem);
            this.Initialize(displayText: Localizer.DoStr("Gold Wiring"),
                            referencedRecipeFamilyType: typeof(GoldWiringRecipe),
                            referencedDrawing:  typeof(GoldWiringDrawingItem));
        }
    }

    [Serialized]
    [Weight(100)]
    [LocDisplayName("Gold Wiring Technical Drawing")]
    [Tag("Technical Drawing")]
    public partial class GoldWiringDrawingItem: DrawingItem {}
}
