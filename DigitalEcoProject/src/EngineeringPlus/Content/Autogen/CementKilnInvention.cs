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
    public partial class CementKilnInvention: InventionRecipe
    {
        public CementKilnInvention() 
        {
            this.FabricationIngredients = new FabricationElement[]
            {
                new(typeof(GearboxItem), 8), new(typeof(PistonItem), 4), new(typeof(IronPlateItem), 16), 
            };

            this.FabricationProducts = new FabricationElement[]
            {
                new(typeof(CementKilnItem), 1, true), 
            };

            this.RequiredKits = new List<Item>()
            {
                Item.Get(typeof(SteamMachineKitItem)), Item.Get(typeof(IndustrialMaterialKitItem)), 
            }.ToArray();

            this.InventionLabor     = 600f;
            this.InventionTime      = 100f;

            this.RequiredSkills = new RequiredSkill[]
            { 
                new(typeof(MechanicsSkill), 4), 
            };

            this.FabricationTable = typeof(AssemblyLineItem);
            this.Initialize(displayText: Localizer.DoStr("Cement Kiln"),
                            referencedRecipeFamilyType: typeof(CementKilnRecipe),
                            referencedDrawing:  typeof(CementKilnDrawingItem));
        }
    }

    [Serialized]
    [Weight(100)]
    [LocDisplayName("Cement Kiln Technical Drawing")]
    [Tag("Technical Drawing")]
    public partial class CementKilnDrawingItem: DrawingItem {}
}
