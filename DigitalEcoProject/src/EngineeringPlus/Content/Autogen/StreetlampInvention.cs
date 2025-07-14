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
    public partial class StreetlampInvention: InventionRecipe
    {
        public StreetlampInvention() 
        {
            this.InventionKits = new Item[]
            {
                Item.Get(typeof(SteamMaterialKitItem)),
            };
        
            this.InventionLabor         = 60f;
            this.InventionTime          = 6f;
            this.InventionExperience    = 5f;
            this.InventionTable = typeof(LaboratoryItem);

            this.InventionSkills = new RequiredSkill[]
            { 
                new(typeof(ElectronicsSkill), 5), 
            };

            this.FabricationIngredients = new FabricationElement[]
            {
                new(typeof(SteelBarItem), 12), new(typeof(GlassItem), 5), new(typeof(CopperWiringItem), 5), new(typeof(LightBulbItem), 1, true), 
            };

            this.FabricationProducts = new FabricationElement[]
            {
                new(typeof(StreetlampItem), 1, true), 
            };

            this.FabricationLabor       = 60f;
            this.FabricationTime        = 6f;
            this.FabricationExperience  = 5f;
            this.FabricationTable = typeof(RoboticAssemblyLineItem);

            this.FabricationSkills = new RequiredSkill[]
            { 
                new(typeof(ElectronicsSkill), 5), 
            };

            
            this.Initialize(displayText: Localizer.DoStr("Streetlamp"),
                            referencedDrawing:  typeof(StreetlampDrawingItem));
        }
    }

    [Serialized]
    [Weight(100)]
    [LocDisplayName("Streetlamp Technical Drawing")]
    [Tag("Technical Drawing")]
    public partial class StreetlampDrawingItem: DrawingItem {}
}
