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
    public partial class ScrewPressInvention: InventionRecipe
    {
        public ScrewPressInvention() 
        {
            this.FabricationIngredients = new FabricationElement[]
            {
                new(typeof(IronBarItem), 25), 
            };

            this.FabricationProducts = new FabricationElement[]
            {
                new(typeof(ScrewPressItem), 1, true), 
            };

            this.RequiredKits = new List<Item>()
            {
                Item.Get(typeof(SteamMaterialKitItem)), 
            }.ToArray();

            this.InventionLabor     = 300f;
            this.InventionTime      = 5f;

            this.RequiredSkills = new RequiredSkill[]
            { 
                new(typeof(MechanicsSkill), 1), 
            };

            this.FabricationTable = typeof(MachinistTableItem);
            this.Initialize(displayText: Localizer.DoStr("Screw Press"),
                            referencedRecipeFamilyType: typeof(ScrewPressRecipe),
                            referencedDrawing:  typeof(ScrewPressDrawingItem));
        }
    }

    [Serialized]
    [Weight(100)]
    [LocDisplayName("Screw Press Technical Drawing")]
    [Tag("Technical Drawing")]
    public partial class ScrewPressDrawingItem: DrawingItem {}
}
