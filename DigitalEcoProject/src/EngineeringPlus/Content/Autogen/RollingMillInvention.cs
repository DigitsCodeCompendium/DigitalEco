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
    public partial class RollingMillInvention: InventionRecipe
    {
        public RollingMillInvention() 
        {
            this.FabricationIngredients = new FabricationElement[]
            {
                new(typeof(SteelBarItem), 8), new(typeof(GearboxItem), 4), 
            };

            this.FabricationProducts = new FabricationElement[]
            {
                new(typeof(RollingMillItem), 1, true), 
            };

            this.RequiredKits = new List<Item>()
            {
                Item.Get(typeof(SteamMachineKitItem)), Item.Get(typeof(IndustrialMaterialKitItem)), 
            }.ToArray();

            this.InventionLabor     = 360f;
            this.InventionTime      = 20f;

            this.RequiredSkills = new RequiredSkill[]
            { 
                new(typeof(MechanicsSkill), 4), 
            };

            this.FabricationTable = typeof(AssemblyLineItem);
            this.Initialize(displayText: Localizer.DoStr("Rolling Mill"),
                            referencedRecipeFamilyType: typeof(RollingMillRecipe),
                            referencedDrawing:  typeof(RollingMillDrawingItem));
        }
    }

    [Serialized]
    [Weight(100)]
    [LocDisplayName("Rolling Mill Technical Drawing")]
    [Tag("Technical Drawing")]
    public partial class RollingMillDrawingItem: DrawingItem {}
}
