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
    public partial class ModernStreetLightInvention: InventionRecipe
    {
        public ModernStreetLightInvention() 
        {
            this.InventionKits = new Item[]
            {
                Item.Get(typeof(SteamMaterialKitItem)),
            };
        
            this.InventionLabor         = 120f;
            this.InventionTime          = 6f;
            this.InventionExperience    = 5f;
            this.InventionTable = typeof(LaboratoryItem);

            this.InventionSkills = new RequiredSkill[]
            { 
                new(typeof(ElectronicsSkill), 5), 
            };

            this.FabricationIngredients = new FabricationElement[]
            {
                new(typeof(SteelPlateItem), 6), new(typeof(PlasticItem), 4), new(typeof(CopperWiringItem), 6), new(typeof(LightBulbItem), 1, true), 
            };

            this.FabricationProducts = new FabricationElement[]
            {
                new(typeof(ModernStreetLightItem), 1, true), 
            };

            this.FabricationLabor       = 120f;
            this.FabricationTime        = 6f;
            this.FabricationExperience  = 5f;
            this.FabricationTable = typeof(RoboticAssemblyLineItem);

            this.FabricationSkills = new RequiredSkill[]
            { 
                new(typeof(ElectronicsSkill), 5), 
            };

            
            this.Initialize(displayText: Localizer.DoStr("Modern Street Light"),
                            referencedDrawing:  typeof(ModernStreetLightDrawingItem));
        }
    }

    [Serialized]
    [Weight(100)]
    [LocDisplayName("Modern Street Light Technical Drawing")]
    [Tag("Technical Drawing")]
    public partial class ModernStreetLightDrawingItem: DrawingItem {}
}
