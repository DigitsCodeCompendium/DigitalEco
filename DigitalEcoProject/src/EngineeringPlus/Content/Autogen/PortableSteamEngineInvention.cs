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
            this.FabricationIngredients = new FabricationElement[]
            {
                new(typeof(PistonItem), 8), new(typeof(ScrewsItem), 18), new(typeof(IronPlateItem), 12), new(typeof(BoilerItem), 3), new(typeof(IronGearItem), 12), new(typeof(CopperPipeItem), 6), 
            };

            this.FabricationProducts = new FabricationElement[]
            {
                new(typeof(PortableSteamEngineItem), 1, true), 
            };

            this.RequiredKits = new List<Item>()
            {
                Item.Get(typeof(SteamPowerKitItem)), 
            }.ToArray();

            this.InventionLabor     = 1200f;
            this.InventionTime      = 8f;

            this.RequiredSkills = new RequiredSkill[]
            { 
                new(typeof(MechanicsSkill), 1), 
            };

            this.FabricationTable = typeof(MachinistTableItem);
            this.Initialize(displayText: Localizer.DoStr("Portable Steam Engine"),
                            referencedRecipeFamilyType: typeof(PortableSteamEngineRecipe),
                            referencedDrawing:  typeof(PortableSteamEngineDrawingItem));
        }
    }

    [Serialized]
    [Weight(100)]
    [LocDisplayName("Portable Steam Engine Technical Drawing")]
    [Tag("Technical Drawing")]
    public partial class PortableSteamEngineDrawingItem: DrawingItem {}
}
