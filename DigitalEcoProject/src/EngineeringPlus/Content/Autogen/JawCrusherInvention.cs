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
    public partial class JawCrusherInvention: InventionRecipe
    {
        public JawCrusherInvention() 
        {
            this.InventionKits = new Item[]
            {
                Item.Get(typeof(SteamMaterialKitItem)),
            };
        
            this.InventionLabor         = 1200f;
            this.InventionTime          = 5f;
            this.InventionExperience    = 5f;
            this.InventionTable = typeof(LaboratoryItem);

            this.InventionSkills = new RequiredSkill[]
            { 
                new(typeof(ElectronicsSkill), 2), 
            };

            this.FabricationIngredients = new FabricationElement[]
            {
                new(typeof(SteelBarItem), 25), new(typeof(SyntheticRubberItem), 25), new(typeof(SteelGearItem), 20), new(typeof(ElectricMotorItem), 2, true), 
            };

            this.FabricationProducts = new FabricationElement[]
            {
                new(typeof(JawCrusherItem), 1, true), 
            };

            this.FabricationLabor       = 1200f;
            this.FabricationTime        = 5f;
            this.FabricationExperience  = 5f;
            this.FabricationTable = typeof(RoboticAssemblyLineItem);

            this.FabricationSkills = new RequiredSkill[]
            { 
                new(typeof(ElectronicsSkill), 2), 
            };

            
            this.Initialize(displayText: Localizer.DoStr("Jaw Crusher"),
                            referencedDrawing:  typeof(JawCrusherDrawingItem));
        }
    }

    [Serialized]
    [Weight(100)]
    [LocDisplayName("Jaw Crusher Technical Drawing")]
    [Tag("Technical Drawing")]
    public partial class JawCrusherDrawingItem: DrawingItem {}
}
