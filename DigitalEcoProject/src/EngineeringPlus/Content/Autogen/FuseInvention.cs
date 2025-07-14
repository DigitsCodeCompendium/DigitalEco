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
            this.InventionKits = new Item[]
            {
                Item.Get(typeof(SteamMaterialKitItem)),
            };
        
            this.InventionLabor         = 80f;
            this.InventionTime          = 0.2f;
            this.InventionExperience    = 1f;
            this.InventionTable = typeof(LaboratoryItem);

            this.InventionSkills = new RequiredSkill[]
            { 
                new(typeof(ElectronicsSkill), 1), 
            };

            this.FabricationIngredients = new FabricationElement[]
            {
                new(typeof(GlassItem), 1), new(typeof(CopperWiringItem), 2), 
            };

            this.FabricationProducts = new FabricationElement[]
            {
                new(typeof(FuseItem), 4, true), 
            };

            this.FabricationLabor       = 80f;
            this.FabricationTime        = 0.2f;
            this.FabricationExperience  = 1f;
            this.FabricationTable = typeof(ElectronicsAssemblyItem);

            this.FabricationSkills = new RequiredSkill[]
            { 
                new(typeof(ElectronicsSkill), 1), 
            };

            
            this.Initialize(displayText: Localizer.DoStr("Fuse"),
                            referencedDrawing:  typeof(FuseDrawingItem));
        }
    }

    [Serialized]
    [Weight(100)]
    [LocDisplayName("Fuse Technical Drawing")]
    [Tag("Technical Drawing")]
    public partial class FuseDrawingItem: DrawingItem {}
}
