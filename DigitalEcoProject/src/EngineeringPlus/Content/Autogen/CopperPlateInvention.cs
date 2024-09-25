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
    public partial class CopperPlateInvention: InventionRecipe
    {
        public CopperPlateInvention() 
        {
            this.FabricationIngredients = new FabricationElement[]
            {
                new(typeof(CopperBarItem), 1), 
            };

            this.FabricationProducts = new FabricationElement[]
            {
                new(typeof(CopperPlateItem), 1, true), 
            };

            this.RequiredKits = new List<Item>()
            {
                Item.Get(typeof(SteamMaterialKitItem)), 
            }.ToArray();

            this.InventionLabor     = 60f;
            this.InventionTime      = 2f;

            this.RequiredSkills = new RequiredSkill[]
            { 
                new(typeof(MechanicsSkill), 1), 
            };

            this.FabricationTable = typeof(ScrewPressItem);
            this.Initialize(displayText: Localizer.DoStr("Copper Plate"),
                            referencedRecipeFamilyType: typeof(CopperPlateRecipe),
                            referencedDrawing:  typeof(CopperPlateDrawingItem));
        }
    }

    [Serialized]
    [Weight(100)]
    [LocDisplayName("Copper Plate Technical Drawing")]
    [Tag("Technical Drawing")]
    public partial class CopperPlateDrawingItem: DrawingItem {}
}
