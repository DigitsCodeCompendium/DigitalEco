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
    public partial class ScreeningMachineInvention: InventionRecipe
    {
        public ScreeningMachineInvention() 
        {
            this.FabricationIngredients = new FabricationElement[]
            {
                new(typeof(IronBarItem), 40), new(typeof(ScrewsItem), 15), new(typeof(IronGearItem), 10), 
            };

            this.FabricationProducts = new FabricationElement[]
            {
                new(typeof(ScreeningMachineItem), 1, true), 
            };

            this.RequiredKits = new List<Item>()
            {
                Item.Get(typeof(SteamMachineKitItem)), Item.Get(typeof(SteamMaterialKitItem)), 
            }.ToArray();

            this.InventionLabor     = 300f;
            this.InventionTime      = 5f;

            this.RequiredSkills = new RequiredSkill[]
            { 
                new(typeof(MechanicsSkill), 3), 
            };

            this.FabricationTable = typeof(MachinistTableItem);
            this.Initialize(displayText: Localizer.DoStr("Screening Machine"),
                            referencedRecipeFamilyType: typeof(ScreeningMachineRecipe),
                            referencedDrawing:  typeof(ScreeningMachineDrawingItem));
        }
    }

    [Serialized]
    [Weight(100)]
    [LocDisplayName("Screening Machine Technical Drawing")]
    [Tag("Technical Drawing")]
    public partial class ScreeningMachineDrawingItem: DrawingItem {}
}
