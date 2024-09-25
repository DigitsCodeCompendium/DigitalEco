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
    public partial class GearboxInvention: InventionRecipe
    {
        public GearboxInvention() 
        {
            this.FabricationIngredients = new FabricationElement[]
            {
                new(typeof(IronBarItem), 2), new(typeof(IronGearItem), 4), 
            };

            this.FabricationProducts = new FabricationElement[]
            {
                new(typeof(GearboxItem), 1, true), 
            };

            this.RequiredKits = new List<Item>()
            {
                Item.Get(typeof(SteamMaterialKitItem)), 
            }.ToArray();

            this.InventionLabor     = 45f;
            this.InventionTime      = 1.5f;

            this.RequiredSkills = new RequiredSkill[]
            { 
                new(typeof(MechanicsSkill), 1), 
            };

            this.FabricationTable = typeof(ShaperItem);
            this.Initialize(displayText: Localizer.DoStr("Gearbox"),
                            referencedRecipeFamilyType: typeof(GearboxRecipe),
                            referencedDrawing:  typeof(GearboxDrawingItem));
        }
    }

    [Serialized]
    [Weight(100)]
    [LocDisplayName("Gearbox Technical Drawing")]
    [Tag("Technical Drawing")]
    public partial class GearboxDrawingItem: DrawingItem {}
}
