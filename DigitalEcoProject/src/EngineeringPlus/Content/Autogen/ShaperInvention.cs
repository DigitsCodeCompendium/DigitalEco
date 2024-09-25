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
    public partial class ShaperInvention: InventionRecipe
    {
        public ShaperInvention() 
        {
            this.FabricationIngredients = new FabricationElement[]
            {
                new(typeof(IronPlateItem), 16), new(typeof(PistonItem), 16), 
            };

            this.FabricationProducts = new FabricationElement[]
            {
                new(typeof(ShaperItem), 1, true), 
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
            this.Initialize(displayText: Localizer.DoStr("Shaper"),
                            referencedRecipeFamilyType: typeof(ShaperRecipe),
                            referencedDrawing:  typeof(ShaperDrawingItem));
        }
    }

    [Serialized]
    [Weight(100)]
    [LocDisplayName("Shaper Technical Drawing")]
    [Tag("Technical Drawing")]
    public partial class ShaperDrawingItem: DrawingItem {}
}
