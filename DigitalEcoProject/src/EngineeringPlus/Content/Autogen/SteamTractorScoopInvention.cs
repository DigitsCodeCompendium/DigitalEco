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
    public partial class SteamTractorScoopInvention: InventionRecipe
    {
        public SteamTractorScoopInvention() 
        {
            this.InventionKits = new Item[]
            {
                Item.Get(typeof(SteamVehicleKitItem)), Item.Get(typeof(SteamMachineKitItem)), 
            };
        
            this.InventionLabor         = 120f;
            this.InventionTime          = 2f;
            this.InventionExperience    = 10f;
            this.InventionTable = typeof(ResearchTableItem);

            this.InventionSkills = new RequiredSkill[]
            { 
                new(typeof(MechanicsSkill), 2), 
            };

            this.FabricationIngredients = new FabricationElement[]
            {
                new(typeof(IronPlateItem), 8), new(typeof(ScrewsItem), 18), 
            };

            this.FabricationProducts = new FabricationElement[]
            {
                new(typeof(SteamTractorScoopItem), 1, true), 
            };

            this.FabricationLabor       = 120f;
            this.FabricationTime        = 2f;
            this.FabricationExperience  = 10f;
            this.FabricationTable = typeof(AssemblyLineItem);

            this.FabricationSkills = new RequiredSkill[]
            { 
                new(typeof(MechanicsSkill), 2), 
            };

            
            this.Initialize(displayText: Localizer.DoStr("Steam Tractor Scoop"),
                            referencedDrawing:  typeof(SteamTractorScoopDrawingItem));
        }
    }

    [Serialized]
    [Weight(100)]
    [LocDisplayName("Steam Tractor Scoop Technical Drawing")]
    [Tag("Technical Drawing")]
    public partial class SteamTractorScoopDrawingItem: DrawingItem {}
}
