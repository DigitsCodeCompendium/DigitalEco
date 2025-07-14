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
    public partial class PortableSteamEngineInvention: InventionRecipe
    {
        public PortableSteamEngineInvention() 
        {
            this.InventionKits = new Item[]
            {
                Item.Get(typeof(SteamPowerKitItem)), 
            };
        
            this.InventionLabor         = 1200f;
            this.InventionTime          = 8f;
            this.InventionExperience    = 10f;
            this.InventionTable = typeof(ResearchTableItem);

            this.InventionSkills = new RequiredSkill[]
            { 
                new(typeof(MechanicsSkill), 1), 
            };

            this.FabricationIngredients = new FabricationElement[]
            {
                new(typeof(PistonItem), 8), new(typeof(ScrewsItem), 18), new(typeof(IronPlateItem), 12), new(typeof(BoilerItem), 3), new(typeof(IronGearItem), 12), new(typeof(CopperPipeItem), 6), 
            };

            this.FabricationProducts = new FabricationElement[]
            {
                new(typeof(PortableSteamEngineItem), 1, true), 
            };

            this.FabricationLabor       = 1200f;
            this.FabricationTime        = 8f;
            this.FabricationExperience  = 10f;
            this.FabricationTable = typeof(MachinistTableItem);

            this.FabricationSkills = new RequiredSkill[]
            { 
                new(typeof(MechanicsSkill), 1), 
            };

            
            this.Initialize(displayText: Localizer.DoStr("Portable Steam Engine"),
                            referencedDrawing:  typeof(PortableSteamEngineDrawingItem));
        }
    }

    [Serialized]
    [Weight(100)]
    [LocDisplayName("Portable Steam Engine Technical Drawing")]
    [Tag("Technical Drawing")]
    public partial class PortableSteamEngineDrawingItem: DrawingItem {}
}
