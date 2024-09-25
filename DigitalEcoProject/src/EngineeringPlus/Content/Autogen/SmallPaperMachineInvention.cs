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
    public partial class SmallPaperMachineInvention: InventionRecipe
    {
        public SmallPaperMachineInvention() 
        {
            this.FabricationIngredients = new FabricationElement[]
            {
                new(typeof(IronGearItem), 6), new(typeof(IronPlateItem), 8), 
            };

            this.FabricationProducts = new FabricationElement[]
            {
                new(typeof(SmallPaperMachineItem), 1, true), 
            };

            this.RequiredKits = new List<Item>()
            {
                Item.Get(typeof(SteamMachineKitItem)), 
            }.ToArray();

            this.InventionLabor     = 240f;
            this.InventionTime      = 1f;

            this.RequiredSkills = new RequiredSkill[]
            { 
                new(typeof(MechanicsSkill), 1), 
            };

            this.FabricationTable = typeof(MachinistTableItem);
            this.Initialize(displayText: Localizer.DoStr("Small Paper Machine"),
                            referencedRecipeFamilyType: typeof(SmallPaperMachineRecipe),
                            referencedDrawing:  typeof(SmallPaperMachineDrawingItem));
        }
    }

    [Serialized]
    [Weight(100)]
    [LocDisplayName("Small Paper Machine Technical Drawing")]
    [Tag("Technical Drawing")]
    public partial class SmallPaperMachineDrawingItem: DrawingItem {}
}
