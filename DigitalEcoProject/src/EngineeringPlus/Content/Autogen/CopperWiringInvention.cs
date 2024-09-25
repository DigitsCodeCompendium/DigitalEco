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
    public partial class CopperWiringInvention: InventionRecipe
    {
        public CopperWiringInvention() 
        {
            this.FabricationIngredients = new FabricationElement[]
            {
                new(typeof(CopperBarItem), 4), 
            };

            this.FabricationProducts = new FabricationElement[]
            {
                new(typeof(CopperWiringItem), 2, true), 
            };

            this.RequiredKits = new List<Item>()
            {
                Item.Get(typeof(SteamMaterialKitItem)), 
            }.ToArray();

            this.InventionLabor     = 60f;
            this.InventionTime      = 0.4f;

            this.RequiredSkills = new RequiredSkill[]
            { 
                new(typeof(MechanicsSkill), 1), 
            };

            this.FabricationTable = typeof(MachinistTableItem);
            this.Initialize(displayText: Localizer.DoStr("Copper Wiring"),
                            referencedRecipeFamilyType: typeof(CopperWiringRecipe),
                            referencedDrawing:  typeof(CopperWiringDrawingItem));
        }
    }

    [Serialized]
    [Weight(100)]
    [LocDisplayName("Copper Wiring Technical Drawing")]
    [Tag("Technical Drawing")]
    public partial class CopperWiringDrawingItem: DrawingItem {}
}
