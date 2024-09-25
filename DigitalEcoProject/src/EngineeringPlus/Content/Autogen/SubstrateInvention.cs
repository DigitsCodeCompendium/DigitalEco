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
    public partial class SubstrateInvention: InventionRecipe
    {
        public SubstrateInvention() 
        {
            this.FabricationIngredients = new FabricationElement[]
            {
                new(typeof(FiberglassItem), 4), new(typeof(EpoxyItem), 4), 
            };

            this.FabricationProducts = new FabricationElement[]
            {
                new(typeof(SubstrateItem), 1, true), 
            };

            this.RequiredKits = new List<Item>()
            {
                
            }.ToArray();

            this.InventionLabor     = 60f;
            this.InventionTime      = 2f;

            this.RequiredSkills = new RequiredSkill[]
            { 
                new(typeof(ElectronicsSkill), 1), 
            };

            this.FabricationTable = typeof(ElectronicsAssemblyItem);
            this.Initialize(displayText: Localizer.DoStr("Substrate"),
                            referencedRecipeFamilyType: typeof(SubstrateRecipe),
                            referencedDrawing:  typeof(SubstrateDrawingItem));
        }
    }

    [Serialized]
    [Weight(100)]
    [LocDisplayName("Substrate Technical Drawing")]
    [Tag("Technical Drawing")]
    public partial class SubstrateDrawingItem: DrawingItem {}
}
