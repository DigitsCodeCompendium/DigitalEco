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
    public partial class SteamTractorInvention: InventionRecipe
    {
        public SteamTractorInvention() 
        {
            this.FabricationIngredients = new FabricationElement[]
            {
                new(typeof(IronPlateItem), 12), new(typeof(IronPipeItem), 8), new(typeof(ScrewsItem), 24), new(typeof(LeatherHideItem), 20), new("Lumber", 30), new(typeof(PortableSteamEngineItem), 1, true), new(typeof(IronWheelItem), 4, true), new(typeof(IronAxleItem), 2, true), new(typeof(LightBulbItem), 2, true), new(typeof(LubricantItem), 2, true), 
            };

            this.FabricationProducts = new FabricationElement[]
            {
                new(typeof(SteamTractorItem), 1, true), 
            };

            this.RequiredKits = new List<Item>()
            {
                Item.Get(typeof(SteamVehicleKitItem)), Item.Get(typeof(SteamPowerKitItem)), 
            }.ToArray();

            this.InventionLabor     = 1000f;
            this.InventionTime      = 10f;

            this.RequiredSkills = new RequiredSkill[]
            { 
                new(typeof(MechanicsSkill), 2), 
            };

            this.FabricationTable = typeof(AssemblyLineItem);
            this.Initialize(displayText: Localizer.DoStr("Steam Tractor"),
                            referencedRecipeFamilyType: typeof(SteamTractorRecipe),
                            referencedDrawing:  typeof(SteamTractorDrawingItem));
        }
    }

    [Serialized]
    [Weight(100)]
    [LocDisplayName("Steam Tractor Technical Drawing")]
    [Tag("Technical Drawing")]
    public partial class SteamTractorDrawingItem: DrawingItem {}
}
