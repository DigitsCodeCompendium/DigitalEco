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
    public partial class IronGearInvention: InventionRecipe
    {
        public IronGearInvention() 
        {
            this.FabricationIngredients = new FabricationElement[]
            {
                new(typeof(IronBarItem), 1), 
            };

            this.FabricationProducts = new FabricationElement[]
            {
                new(typeof(IronGearItem), 1, true), 
            };

            this.RequiredKits = new List<Item>()
            {
                Item.Get(typeof(SteamMaterialKitItem)), 
            }.ToArray();

            this.InventionLabor     = 75f;
            this.InventionTime      = 0.4f;

            this.RequiredSkills = new RequiredSkill[]
            { 
                new(typeof(MechanicsSkill), 1), 
            };

            this.FabricationTable = typeof(ShaperItem);
            this.Initialize(displayText: Localizer.DoStr("Iron Gear"),
                            referencedRecipeFamilyType: typeof(IronGearRecipe),
                            referencedDrawing:  typeof(IronGearDrawingItem));
        }
    }

    [Serialized]
    [Weight(100)]
    [LocDisplayName("Iron Gear Technical Drawing")]
    [Tag("Technical Drawing")]
    public partial class IronGearDrawingItem: DrawingItem {}
}
