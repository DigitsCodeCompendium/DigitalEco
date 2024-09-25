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
    public partial class TransmissionPoleInvention: InventionRecipe
    {
        public TransmissionPoleInvention() 
        {
            this.FabricationIngredients = new FabricationElement[]
            {
                new(typeof(IronBarItem), 8), new(typeof(CopperWiringItem), 14), new("Lumber", 10), 
            };

            this.FabricationProducts = new FabricationElement[]
            {
                new(typeof(TransmissionPoleItem), 1, true), 
            };

            this.RequiredKits = new List<Item>()
            {
                Item.Get(typeof(IndustrialMachineKitItem)), 
            }.ToArray();

            this.InventionLabor     = 480f;
            this.InventionTime      = 4f;

            this.RequiredSkills = new RequiredSkill[]
            { 
                new(typeof(MechanicsSkill), 4), 
            };

            this.FabricationTable = typeof(MachinistTableItem);
            this.Initialize(displayText: Localizer.DoStr("Transmission Pole"),
                            referencedRecipeFamilyType: typeof(TransmissionPoleRecipe),
                            referencedDrawing:  typeof(TransmissionPoleDrawingItem));
        }
    }

    [Serialized]
    [Weight(100)]
    [LocDisplayName("Transmission Pole Technical Drawing")]
    [Tag("Technical Drawing")]
    public partial class TransmissionPoleDrawingItem: DrawingItem {}
}
