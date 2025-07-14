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
    public partial class TruckInvention: InventionRecipe
    {
        public TruckInvention() 
        {
            this.InventionKits = new Item[]
            {
                Item.Get(typeof(SteamMaterialKitItem)),
            };
        
            this.InventionLabor         = 2000f;
            this.InventionTime          = 10f;
            this.InventionExperience    = 18f;
            this.InventionTable = typeof(LaboratoryItem);

            this.InventionSkills = new RequiredSkill[]
            { 
                new(typeof(IndustrySkill), 2), 
            };

            this.FabricationIngredients = new FabricationElement[]
            {
                new(typeof(GearboxItem), 4), new(typeof(SteelPlateItem), 20), new(typeof(NylonFabricItem), 20), new(typeof(SteelSpringItem), 6), new(typeof(CombustionEngineItem), 1, true), new(typeof(RubberWheelItem), 6, true), new(typeof(RadiatorItem), 1, true), new(typeof(SteelAxleItem), 2, true), new(typeof(LightBulbItem), 4, true), new(typeof(LubricantItem), 2, true), 
            };

            this.FabricationProducts = new FabricationElement[]
            {
                new(typeof(TruckItem), 1, true), 
            };

            this.FabricationLabor       = 2000f;
            this.FabricationTime        = 10f;
            this.FabricationExperience  = 18f;
            this.FabricationTable = typeof(RoboticAssemblyLineItem);

            this.FabricationSkills = new RequiredSkill[]
            { 
                new(typeof(IndustrySkill), 2), 
            };

            
            this.Initialize(displayText: Localizer.DoStr("Truck"),
                            referencedDrawing:  typeof(TruckDrawingItem));
        }
    }

    [Serialized]
    [Weight(100)]
    [LocDisplayName("Truck Technical Drawing")]
    [Tag("Technical Drawing")]
    public partial class TruckDrawingItem: DrawingItem {}
}
