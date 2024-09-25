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
            this.FabricationIngredients = new FabricationElement[]
            {
                new(typeof(IronBarItem), 24), new(typeof(IronPipeItem), 12), new(typeof(LubricantItem), 1, true), 
            };

            this.FabricationProducts = new FabricationElement[]
            {
                new(typeof(SteamEngineItem), 1, true), 
            };

            this.RequiredKits = new List<Item>()
            {
                Item.Get(typeof(SteamMachineKitItem)), Item.Get(typeof(SteamPowerKitItem)), 
            }.ToArray();

            this.InventionLabor     = 450f;
            this.InventionTime      = 10f;

            this.RequiredSkills = new RequiredSkill[]
            { 
                new(typeof(MechanicsSkill), 1), 
            };

            this.FabricationTable = typeof(MachinistTableItem);
            this.Initialize(displayText: Localizer.DoStr("Steam Engine"),
                            referencedRecipeFamilyType: typeof(SteamEngineRecipe),
                            referencedDrawing:  typeof(SteamEngineDrawingItem));
        }
    }

    [Serialized]
    [Weight(100)]
    [LocDisplayName("Steam Engine Technical Drawing")]
    [Tag("Technical Drawing")]
    public partial class SteamEngineDrawingItem: DrawingItem {}
}
