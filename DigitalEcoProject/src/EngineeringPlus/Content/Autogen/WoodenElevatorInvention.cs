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
    public partial class WoodenElevatorInvention: InventionRecipe
    {
        public WoodenElevatorInvention() 
        {
            this.InventionKits = new Item[]
            {
                Item.Get(typeof(SteamVehicleKitItem)), Item.Get(typeof(SteamPowerKitItem)), 
            };
        
            this.InventionLabor         = 500f;
            this.InventionTime          = 10f;
            this.InventionExperience    = 15f;
            this.InventionTable = typeof(ResearchTableItem);

            this.InventionSkills = new RequiredSkill[]
            { 
                new(typeof(MechanicsSkill), 1), 
            };

            this.FabricationIngredients = new FabricationElement[]
            {
                new(typeof(GearboxItem), 4), new(typeof(CelluloseFiberItem), 4), new("Lumber", 30), new(typeof(PortableSteamEngineItem), 1, true), new(typeof(LubricantItem), 2, true), 
            };

            this.FabricationProducts = new FabricationElement[]
            {
                new(typeof(WoodenElevatorItem), 1, true), 
            };

            this.FabricationLabor       = 500f;
            this.FabricationTime        = 10f;
            this.FabricationExperience  = 15f;
            this.FabricationTable = typeof(AssemblyLineItem);

            this.FabricationSkills = new RequiredSkill[]
            { 
                new(typeof(MechanicsSkill), 1), 
            };

            
            this.Initialize(displayText: Localizer.DoStr("Wooden Elevator"),
                            referencedDrawing:  typeof(WoodenElevatorDrawingItem));
        }
    }

    [Serialized]
    [Weight(100)]
    [LocDisplayName("Wooden Elevator Technical Drawing")]
    [Tag("Technical Drawing")]
    public partial class WoodenElevatorDrawingItem: DrawingItem {}
}
