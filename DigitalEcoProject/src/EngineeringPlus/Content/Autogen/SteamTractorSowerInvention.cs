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
    public partial class SteamTractorSowerInvention: InventionRecipe
    {
        public SteamTractorSowerInvention() 
        {
            this.FabricationIngredients = new FabricationElement[]
            {
                new(typeof(IronPlateItem), 8), new(typeof(ScrewsItem), 18), new(typeof(IronPipeItem), 8), 
            };

            this.FabricationProducts = new FabricationElement[]
            {
                new(typeof(SteamTractorSowerItem), 1, true), 
            };

            this.RequiredKits = new List<Item>()
            {
                Item.Get(typeof(SteamVehicleKitItem)), Item.Get(typeof(SteamMachineKitItem)), 
            }.ToArray();

            this.InventionLabor     = 120f;
            this.InventionTime      = 2f;

            this.RequiredSkills = new RequiredSkill[]
            { 
                new(typeof(MechanicsSkill), 2), 
            };

            this.FabricationTable = typeof(AssemblyLineItem);
            this.Initialize(displayText: Localizer.DoStr("Steam Tractor Sower"),
                            referencedRecipeFamilyType: typeof(SteamTractorSowerRecipe),
                            referencedDrawing:  typeof(SteamTractorSowerDrawingItem));
        }
    }

    [Serialized]
    [Weight(100)]
    [LocDisplayName("Steam Tractor Sower Technical Drawing")]
    [Tag("Technical Drawing")]
    public partial class SteamTractorSowerDrawingItem: DrawingItem {}
}
