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
    public partial class MediumShipyardInvention: InventionRecipe
    {
        public MediumShipyardInvention() 
        {
            this.FabricationIngredients = new FabricationElement[]
            {
                new(typeof(IronPlateItem), 6), new(typeof(PaperItem), 4), new(typeof(HempMooringRopeItem), 2), new("Lumber", 8), 
            };

            this.FabricationProducts = new FabricationElement[]
            {
                new(typeof(MediumShipyardItem), 1, true), 
            };

            this.RequiredKits = new List<Item>()
            {
                Item.Get(typeof(SteamMachineKitItem)), Item.Get(typeof(SteamMaterialKitItem)), 
            }.ToArray();

            this.InventionLabor     = 800f;
            this.InventionTime      = 10f;

            this.RequiredSkills = new RequiredSkill[]
            { 
                new(typeof(MechanicsSkill), 1), 
            };

            this.FabricationTable = typeof(MachinistTableItem);
            this.Initialize(displayText: Localizer.DoStr("Medium Shipyard"),
                            referencedRecipeFamilyType: typeof(MediumShipyardRecipe),
                            referencedDrawing:  typeof(MediumShipyardDrawingItem));
        }
    }

    [Serialized]
    [Weight(100)]
    [LocDisplayName("Medium Shipyard Technical Drawing")]
    [Tag("Technical Drawing")]
    public partial class MediumShipyardDrawingItem: DrawingItem {}
}
