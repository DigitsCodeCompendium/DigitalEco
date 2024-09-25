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
    public partial class CraneInvention: InventionRecipe
    {
        public CraneInvention() 
        {
            this.FabricationIngredients = new FabricationElement[]
            {
                new(typeof(GearboxItem), 4), new(typeof(IronPlateItem), 20), new(typeof(CottonFabricItem), 20), new(typeof(PortableSteamEngineItem), 1, true), new(typeof(IronWheelItem), 4, true), new(typeof(HeatSinkItem), 2, true), new(typeof(IronAxleItem), 2, true), new(typeof(LubricantItem), 2, true), 
            };

            this.FabricationProducts = new FabricationElement[]
            {
                new(typeof(CraneItem), 1, true), 
            };

            this.RequiredKits = new List<Item>()
            {
                Item.Get(typeof(SteamVehicleKitItem)), Item.Get(typeof(SteamPowerKitItem)), 
            }.ToArray();

            this.InventionLabor     = 3000f;
            this.InventionTime      = 10f;

            this.RequiredSkills = new RequiredSkill[]
            { 
                new(typeof(MechanicsSkill), 5), 
            };

            this.FabricationTable = typeof(AssemblyLineItem);
            this.Initialize(displayText: Localizer.DoStr("Crane"),
                            referencedRecipeFamilyType: typeof(CraneRecipe),
                            referencedDrawing:  typeof(CraneDrawingItem));
        }
    }

    [Serialized]
    [Weight(100)]
    [LocDisplayName("Crane Technical Drawing")]
    [Tag("Technical Drawing")]
    public partial class CraneDrawingItem: DrawingItem {}
}
