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
    public partial class MetalKeelInvention: InventionRecipe
    {
        public MetalKeelInvention() 
        {
            this.FabricationIngredients = new FabricationElement[]
            {
                new(typeof(IronBarItem), 8), 
            };

            this.FabricationProducts = new FabricationElement[]
            {
                new(typeof(MetalKeelItem), 1, true), 
            };

            this.RequiredKits = new List<Item>()
            {
                Item.Get(typeof(SteamMaterialKitItem)), 
            }.ToArray();

            this.InventionLabor     = 120f;
            this.InventionTime      = 2f;

            this.RequiredSkills = new RequiredSkill[]
            { 
                new(typeof(MechanicsSkill), 4), 
            };

            this.FabricationTable = typeof(ShaperItem);
            this.Initialize(displayText: Localizer.DoStr("Metal Keel"),
                            referencedRecipeFamilyType: typeof(MetalKeelRecipe),
                            referencedDrawing:  typeof(MetalKeelDrawingItem));
        }
    }

    [Serialized]
    [Weight(100)]
    [LocDisplayName("Metal Keel Technical Drawing")]
    [Tag("Technical Drawing")]
    public partial class MetalKeelDrawingItem: DrawingItem {}
}
