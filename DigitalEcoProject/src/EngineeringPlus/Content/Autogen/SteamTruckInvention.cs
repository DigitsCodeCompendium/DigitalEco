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
    public partial class SteamTruckInvention: InventionRecipe
    {
        public SteamTruckInvention() 
        {
            this.InventionKits = new Item[]
            {
                Item.Get(typeof(SteamVehicleKitItem)), Item.Get(typeof(SteamPowerKitItem)), 
            };
        
            this.InventionLabor         = 1000f;
            this.InventionTime          = 10f;
            this.InventionExperience    = 25f;
            this.InventionTable = typeof(ResearchTableItem);

            this.InventionSkills = new RequiredSkill[]
            { 
                new(typeof(MechanicsSkill), 2), 
            };

            this.FabricationIngredients = new FabricationElement[]
            {
                new(typeof(IronPlateItem), 12), new(typeof(IronPipeItem), 8), new(typeof(ScrewsItem), 24), new(typeof(LeatherHideItem), 20), new("Lumber", 30), new(typeof(PortableSteamEngineItem), 1, true), new(typeof(IronWheelItem), 4, true), new(typeof(IronAxleItem), 2, true), new(typeof(LightBulbItem), 2, true), new(typeof(LubricantItem), 2, true), 
            };

            this.FabricationProducts = new FabricationElement[]
            {
                new(typeof(SteamTruckItem), 1, true), 
            };

            this.FabricationLabor       = 1000f;
            this.FabricationTime        = 10f;
            this.FabricationExperience  = 25f;
            this.FabricationTable = typeof(AssemblyLineItem);

            this.FabricationSkills = new RequiredSkill[]
            { 
                new(typeof(MechanicsSkill), 2), 
            };

            
            this.Initialize(displayText: Localizer.DoStr("Steam Truck"),
                            referencedDrawing:  typeof(SteamTruckDrawingItem));
        }
    }

    [Serialized]
    [Weight(100)]
    [LocDisplayName("Steam Truck Technical Drawing")]
    [Tag("Technical Drawing")]
    public partial class SteamTruckDrawingItem: DrawingItem {}
}
