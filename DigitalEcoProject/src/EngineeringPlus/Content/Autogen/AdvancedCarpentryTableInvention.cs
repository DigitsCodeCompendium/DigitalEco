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
    public partial class AdvancedCarpentryTableInvention: InventionRecipe
    {
        public AdvancedCarpentryTableInvention() 
        {
            this.InventionKits = new Item[]
            {
                Item.Get(typeof(SteamMaterialKitItem)),
            };
        
            this.InventionLabor         = 600f;
            this.InventionTime          = 15f;
            this.InventionExperience    = 10f;
            this.InventionTable = typeof(LaboratoryItem);

            this.InventionSkills = new RequiredSkill[]
            { 
                new(typeof(IndustrySkill), 1), 
            };

            this.FabricationIngredients = new FabricationElement[]
            {
                new(typeof(SteelPlateItem), 6), new(typeof(SteelSawBladeItem), 6), new("Lumber", 10), 
            };

            this.FabricationProducts = new FabricationElement[]
            {
                new(typeof(AdvancedCarpentryTableItem), 1, true), 
            };

            this.FabricationLabor       = 600f;
            this.FabricationTime        = 15f;
            this.FabricationExperience  = 10f;
            this.FabricationTable = typeof(ElectricMachinistTableItem);

            this.FabricationSkills = new RequiredSkill[]
            { 
                new(typeof(IndustrySkill), 1), 
            };

            
            this.Initialize(displayText: Localizer.DoStr("Advanced Carpentry Table"),
                            referencedDrawing:  typeof(AdvancedCarpentryTableDrawingItem));
        }
    }

    [Serialized]
    [Weight(100)]
    [LocDisplayName("Advanced Carpentry Table Technical Drawing")]
    [Tag("Technical Drawing")]
    public partial class AdvancedCarpentryTableDrawingItem: DrawingItem {}
}
