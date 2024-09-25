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
    public partial class ElectricWaterPumpInvention: InventionRecipe
    {
        public ElectricWaterPumpInvention() 
        {
            this.FabricationIngredients = new FabricationElement[]
            {
                new(typeof(IronPipeItem), 12), new(typeof(IronBarItem), 8), 
            };

            this.FabricationProducts = new FabricationElement[]
            {
                new(typeof(ElectricWaterPumpItem), 1, true), 
            };

            this.RequiredKits = new List<Item>()
            {
                Item.Get(typeof(IndustrialMachineKitItem)), Item.Get(typeof(IndustrialMaterialKitItem)), 
            }.ToArray();

            this.InventionLabor     = 120f;
            this.InventionTime      = 8f;

            this.RequiredSkills = new RequiredSkill[]
            { 
                new(typeof(MechanicsSkill), 4), 
            };

            this.FabricationTable = typeof(ElectricMachinistTableItem);
            this.Initialize(displayText: Localizer.DoStr("Electric Water Pump"),
                            referencedRecipeFamilyType: typeof(ElectricWaterPumpRecipe),
                            referencedDrawing:  typeof(ElectricWaterPumpDrawingItem));
        }
    }

    [Serialized]
    [Weight(100)]
    [LocDisplayName("Electric Water Pump Technical Drawing")]
    [Tag("Technical Drawing")]
    public partial class ElectricWaterPumpDrawingItem: DrawingItem {}
}
