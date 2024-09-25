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
    public partial class StoveInvention: InventionRecipe
    {
        public StoveInvention() 
        {
            this.FabricationIngredients = new FabricationElement[]
            {
                new(typeof(SteelPlateItem), 16), new(typeof(RivetItem), 12), new(typeof(BasicCircuitItem), 2), 
            };

            this.FabricationProducts = new FabricationElement[]
            {
                new(typeof(StoveItem), 1, true), 
            };

            this.RequiredKits = new List<Item>()
            {
                Item.Get(typeof(IndustrialMachineKitItem)), Item.Get(typeof(IndustrialMaterialKitItem)), 
            }.ToArray();

            this.InventionLabor     = 900f;
            this.InventionTime      = 10f;

            this.RequiredSkills = new RequiredSkill[]
            { 
                new(typeof(MechanicsSkill), 5), 
            };

            this.FabricationTable = typeof(ElectricMachinistTableItem);
            this.Initialize(displayText: Localizer.DoStr("Stove"),
                            referencedRecipeFamilyType: typeof(StoveRecipe),
                            referencedDrawing:  typeof(StoveDrawingItem));
        }
    }

    [Serialized]
    [Weight(100)]
    [LocDisplayName("Stove Technical Drawing")]
    [Tag("Technical Drawing")]
    public partial class StoveDrawingItem: DrawingItem {}
}
