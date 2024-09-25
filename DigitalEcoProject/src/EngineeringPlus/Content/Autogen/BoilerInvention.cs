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
    public partial class BoilerInvention: InventionRecipe
    {
        public BoilerInvention() 
        {
            this.FabricationIngredients = new FabricationElement[]
            {
                new(typeof(IronPlateItem), 15), new(typeof(ScrewsItem), 10), new(typeof(CopperPlateItem), 4), 
            };

            this.FabricationProducts = new FabricationElement[]
            {
                new(typeof(BoilerItem), 1, true), 
            };

            this.RequiredKits = new List<Item>()
            {
                Item.Get(typeof(SteamMaterialKitItem)), 
            }.ToArray();

            this.InventionLabor     = 180f;
            this.InventionTime      = 2f;

            this.RequiredSkills = new RequiredSkill[]
            { 
                new(typeof(MechanicsSkill), 1), 
            };

            this.FabricationTable = typeof(MachinistTableItem);
            this.Initialize(displayText: Localizer.DoStr("Boiler"),
                            referencedRecipeFamilyType: typeof(BoilerRecipe),
                            referencedDrawing:  typeof(BoilerDrawingItem));
        }
    }

    [Serialized]
    [Weight(100)]
    [LocDisplayName("Boiler Technical Drawing")]
    [Tag("Technical Drawing")]
    public partial class BoilerDrawingItem: DrawingItem {}
}
