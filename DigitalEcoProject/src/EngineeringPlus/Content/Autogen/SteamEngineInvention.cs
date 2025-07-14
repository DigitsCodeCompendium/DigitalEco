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
    public partial class SteamEngineInvention: InventionRecipe
    {
        public SteamEngineInvention() 
        {
            this.InventionKits = new Item[]
            {
                Item.Get(typeof(SteamMachineKitItem)), Item.Get(typeof(SteamPowerKitItem)), 
            };
        
            this.InventionLabor         = 450f;
            this.InventionTime          = 10f;
            this.InventionExperience    = 25f;
            this.InventionTable = typeof(ResearchTableItem);

            this.InventionSkills = new RequiredSkill[]
            { 
                new(typeof(MechanicsSkill), 1), 
            };

            this.FabricationIngredients = new FabricationElement[]
            {
                new(typeof(IronBarItem), 24), new(typeof(IronPipeItem), 12), new(typeof(LubricantItem), 1, true), 
            };

            this.FabricationProducts = new FabricationElement[]
            {
                new(typeof(SteamEngineItem), 1, true), 
            };

            this.FabricationLabor       = 450f;
            this.FabricationTime        = 10f;
            this.FabricationExperience  = 25f;
            this.FabricationTable = typeof(MachinistTableItem);

            this.FabricationSkills = new RequiredSkill[]
            { 
                new(typeof(MechanicsSkill), 1), 
            };

            
            this.Initialize(displayText: Localizer.DoStr("Steam Engine"),
                            referencedDrawing:  typeof(SteamEngineDrawingItem));
        }
    }

    [Serialized]
    [Weight(100)]
    [LocDisplayName("Steam Engine Technical Drawing")]
    [Tag("Technical Drawing")]
    public partial class SteamEngineDrawingItem: DrawingItem {}
}
