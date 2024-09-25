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
    public partial class GoldFlakesInvention: InventionRecipe
    {
        public GoldFlakesInvention() 
        {
            this.FabricationIngredients = new FabricationElement[]
            {
                new(typeof(GoldBarItem), 2), 
            };

            this.FabricationProducts = new FabricationElement[]
            {
                new(typeof(GoldFlakesItem), 4, true), 
            };

            this.RequiredKits = new List<Item>()
            {
                
            }.ToArray();

            this.InventionLabor     = 75f;
            this.InventionTime      = 0.8f;

            this.RequiredSkills = new RequiredSkill[]
            { 
                new(typeof(ElectronicsSkill), 1), 
            };

            this.FabricationTable = typeof(ElectronicsAssemblyItem);
            this.Initialize(displayText: Localizer.DoStr("Gold Flakes"),
                            referencedRecipeFamilyType: typeof(GoldFlakesRecipe),
                            referencedDrawing:  typeof(GoldFlakesDrawingItem));
        }
    }

    [Serialized]
    [Weight(100)]
    [LocDisplayName("Gold Flakes Technical Drawing")]
    [Tag("Technical Drawing")]
    public partial class GoldFlakesDrawingItem: DrawingItem {}
}
