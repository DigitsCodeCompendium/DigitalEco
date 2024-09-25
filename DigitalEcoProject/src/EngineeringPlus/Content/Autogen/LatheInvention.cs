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
    public partial class LatheInvention: InventionRecipe
    {
        public LatheInvention() 
        {
            this.FabricationIngredients = new FabricationElement[]
            {
                new(typeof(IronWheelItem), 4), new(typeof(IronPlateItem), 12), 
            };

            this.FabricationProducts = new FabricationElement[]
            {
                new(typeof(LatheItem), 1, true), 
            };

            this.RequiredKits = new List<Item>()
            {
                Item.Get(typeof(SteamMaterialKitItem)), 
            }.ToArray();

            this.InventionLabor     = 150f;
            this.InventionTime      = 5f;

            this.RequiredSkills = new RequiredSkill[]
            { 
                new(typeof(MechanicsSkill), 1), 
            };

            this.FabricationTable = typeof(MachinistTableItem);
            this.Initialize(displayText: Localizer.DoStr("Lathe"),
                            referencedRecipeFamilyType: typeof(LatheRecipe),
                            referencedDrawing:  typeof(LatheDrawingItem));
        }
    }

    [Serialized]
    [Weight(100)]
    [LocDisplayName("Lathe Technical Drawing")]
    [Tag("Technical Drawing")]
    public partial class LatheDrawingItem: DrawingItem {}
}
