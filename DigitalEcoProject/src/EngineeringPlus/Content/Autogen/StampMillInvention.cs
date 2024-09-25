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
    public partial class StampMillInvention: InventionRecipe
    {
        public StampMillInvention() 
        {
            this.FabricationIngredients = new FabricationElement[]
            {
                new(typeof(IronBarItem), 5), new(typeof(ScrewsItem), 14), new(typeof(IronGearItem), 8), new("WoodBoard", 14), 
            };

            this.FabricationProducts = new FabricationElement[]
            {
                new(typeof(StampMillItem), 1, true), 
            };

            this.RequiredKits = new List<Item>()
            {
                Item.Get(typeof(SteamMachineKitItem)), Item.Get(typeof(SteamMaterialKitItem)), 
            }.ToArray();

            this.InventionLabor     = 120f;
            this.InventionTime      = 5f;

            this.RequiredSkills = new RequiredSkill[]
            { 
                new(typeof(MechanicsSkill), 2), 
            };

            this.FabricationTable = typeof(MachinistTableItem);
            this.Initialize(displayText: Localizer.DoStr("Stamp Mill"),
                            referencedRecipeFamilyType: typeof(StampMillRecipe),
                            referencedDrawing:  typeof(StampMillDrawingItem));
        }
    }

    [Serialized]
    [Weight(100)]
    [LocDisplayName("Stamp Mill Technical Drawing")]
    [Tag("Technical Drawing")]
    public partial class StampMillDrawingItem: DrawingItem {}
}
