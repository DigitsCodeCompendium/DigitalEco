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
    public partial class FuseInvention: InventionRecipe
    {
        public FuseInvention() 
        {
            this.FabricationIngredients = new FabricationElement[]
            {
                new(typeof(GlassItem), 1), new(typeof(CopperWiringItem), 2), 
            };

            this.FabricationProducts = new FabricationElement[]
            {
                new(typeof(FuseItem), 4, true), 
            };

            this.RequiredKits = new List<Item>()
            {
                
            }.ToArray();

            this.InventionLabor     = 80f;
            this.InventionTime      = 0.2f;

            this.RequiredSkills = new RequiredSkill[]
            { 
                new(typeof(ElectronicsSkill), 1), 
            };

            this.FabricationTable = typeof(ElectronicsAssemblyItem);
            this.Initialize(displayText: Localizer.DoStr("Fuse"),
                            referencedRecipeFamilyType: typeof(FuseRecipe),
                            referencedDrawing:  typeof(FuseDrawingItem));
        }
    }

    [Serialized]
    [Weight(100)]
    [LocDisplayName("Fuse Technical Drawing")]
    [Tag("Technical Drawing")]
    public partial class FuseDrawingItem: DrawingItem {}
}
