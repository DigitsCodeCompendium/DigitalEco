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
    public partial class IronPlateInvention: InventionRecipe
    {
        public IronPlateInvention() 
        {
            this.FabricationIngredients = new FabricationElement[]
            {
                new(typeof(IronBarItem), 1), 
            };

            this.FabricationProducts = new FabricationElement[]
            {
                new(typeof(IronPlateItem), 1, true), 
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
            this.Initialize(displayText: Localizer.DoStr("Iron Plate"),
                            referencedRecipeFamilyType: typeof(IronPlateRecipe),
                            referencedDrawing:  typeof(IronPlateDrawingItem));
        }
    }

    [Serialized]
    [Weight(100)]
    [LocDisplayName("Iron Plate Technical Drawing")]
    [Tag("Technical Drawing")]
    public partial class IronPlateDrawingItem: DrawingItem {}
}
