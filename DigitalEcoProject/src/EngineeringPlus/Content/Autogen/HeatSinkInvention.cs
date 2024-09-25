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
    public partial class HeatSinkInvention: InventionRecipe
    {
        public HeatSinkInvention() 
        {
            this.FabricationIngredients = new FabricationElement[]
            {
                new(typeof(CopperPlateItem), 8), new(typeof(CopperWiringItem), 6), 
            };

            this.FabricationProducts = new FabricationElement[]
            {
                new(typeof(HeatSinkItem), 1, true), 
            };

            this.RequiredKits = new List<Item>()
            {
                Item.Get(typeof(SteamMaterialKitItem)), 
            }.ToArray();

            this.InventionLabor     = 60f;
            this.InventionTime      = 2f;

            this.RequiredSkills = new RequiredSkill[]
            { 
                new(typeof(MechanicsSkill), 2), 
            };

            this.FabricationTable = typeof(ShaperItem);
            this.Initialize(displayText: Localizer.DoStr("Heat Sink"),
                            referencedRecipeFamilyType: typeof(HeatSinkRecipe),
                            referencedDrawing:  typeof(HeatSinkDrawingItem));
        }
    }

    [Serialized]
    [Weight(100)]
    [LocDisplayName("Heat Sink Technical Drawing")]
    [Tag("Technical Drawing")]
    public partial class HeatSinkDrawingItem: DrawingItem {}
}
