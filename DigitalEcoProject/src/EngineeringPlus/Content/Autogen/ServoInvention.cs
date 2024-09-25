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
    public partial class ServoInvention: InventionRecipe
    {
        public ServoInvention() 
        {
            this.FabricationIngredients = new FabricationElement[]
            {
                new(typeof(BasicCircuitItem), 2), new(typeof(FiberglassItem), 5), 
            };

            this.FabricationProducts = new FabricationElement[]
            {
                new(typeof(ServoItem), 1, true), 
            };

            this.RequiredKits = new List<Item>()
            {
                Item.Get(typeof(IndustrialMaterialKitItem)), 
            }.ToArray();

            this.InventionLabor     = 60f;
            this.InventionTime      = 3f;

            this.RequiredSkills = new RequiredSkill[]
            { 
                new(typeof(MechanicsSkill), 2), 
            };

            this.FabricationTable = typeof(ElectricMachinistTableItem);
            this.Initialize(displayText: Localizer.DoStr("Servo"),
                            referencedRecipeFamilyType: typeof(ServoRecipe),
                            referencedDrawing:  typeof(ServoDrawingItem));
        }
    }

    [Serialized]
    [Weight(100)]
    [LocDisplayName("Servo Technical Drawing")]
    [Tag("Technical Drawing")]
    public partial class ServoDrawingItem: DrawingItem {}
}