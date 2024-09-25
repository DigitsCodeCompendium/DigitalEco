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
    public partial class BlastFurnaceInvention: InventionRecipe
    {
        public BlastFurnaceInvention() 
        {
            this.FabricationIngredients = new FabricationElement[]
            {
                new(typeof(ScrewsItem), 12), new(typeof(BrickItem), 8), new(typeof(IronPlateItem), 12), new(typeof(IronPipeItem), 8), 
            };

            this.FabricationProducts = new FabricationElement[]
            {
                new(typeof(BlastFurnaceItem), 1, true), 
            };

            this.RequiredKits = new List<Item>()
            {
                Item.Get(typeof(SteamMachineKitItem)), Item.Get(typeof(SteamMaterialKitItem)), 
            }.ToArray();

            this.InventionLabor     = 600f;
            this.InventionTime      = 25f;

            this.RequiredSkills = new RequiredSkill[]
            { 
                new(typeof(MechanicsSkill), 5), 
            };

            this.FabricationTable = typeof(AssemblyLineItem);
            this.Initialize(displayText: Localizer.DoStr("Blast Furnace"),
                            referencedRecipeFamilyType: typeof(BlastFurnaceRecipe),
                            referencedDrawing:  typeof(BlastFurnaceDrawingItem));
        }
    }

    [Serialized]
    [Weight(100)]
    [LocDisplayName("Blast Furnace Technical Drawing")]
    [Tag("Technical Drawing")]
    public partial class BlastFurnaceDrawingItem: DrawingItem {}
}
