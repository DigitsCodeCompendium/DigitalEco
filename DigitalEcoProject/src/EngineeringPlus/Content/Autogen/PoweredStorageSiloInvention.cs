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
    public partial class PoweredStorageSiloInvention: InventionRecipe
    {
        public PoweredStorageSiloInvention() 
        {
            this.FabricationIngredients = new FabricationElement[]
            {
                new(typeof(SteelPlateItem), 18), new(typeof(AdvancedCircuitItem), 8), new(typeof(RadiatorItem), 4), new(typeof(SteelPipeItem), 8), 
            };

            this.FabricationProducts = new FabricationElement[]
            {
                new(typeof(PoweredStorageSiloItem), 1, true), 
            };

            this.RequiredKits = new List<Item>()
            {
                
            }.ToArray();

            this.InventionLabor     = 800f;
            this.InventionTime      = 10f;

            this.RequiredSkills = new RequiredSkill[]
            { 
                new(typeof(IndustrySkill), 3), 
            };

            this.FabricationTable = typeof(RoboticAssemblyLineItem);
            this.Initialize(displayText: Localizer.DoStr("Powered Storage Silo"),
                            referencedRecipeFamilyType: typeof(PoweredStorageSiloRecipe),
                            referencedDrawing:  typeof(PoweredStorageSiloDrawingItem));
        }
    }

    [Serialized]
    [Weight(100)]
    [LocDisplayName("Powered Storage Silo Technical Drawing")]
    [Tag("Technical Drawing")]
    public partial class PoweredStorageSiloDrawingItem: DrawingItem {}
}
