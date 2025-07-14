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
    public partial class BoilerInvention: InventionRecipe
    {
        public BoilerInvention() 
        {
            this.InventionKits = new Item[]
            {
                Item.Get(typeof(SteamMaterialKitItem)), 
            };
        
            this.InventionLabor         = 180f;
            this.InventionTime          = 2f;
            this.InventionExperience    = 3f;
            this.InventionTable = typeof(ResearchTableItem);

            this.InventionSkills = new RequiredSkill[]
            { 
                new(typeof(MechanicsSkill), 1), 
            };

            this.FabricationIngredients = new FabricationElement[]
            {
                new(typeof(IronPlateItem), 15), new(typeof(ScrewsItem), 10), new(typeof(CopperPlateItem), 4), 
            };

            this.FabricationProducts = new FabricationElement[]
            {
                new(typeof(BoilerItem), 1, true), 
            };

            this.FabricationLabor       = 180f;
            this.FabricationTime        = 2f;
            this.FabricationExperience  = 3f;
            this.FabricationTable = typeof(MachinistTableItem);

            this.FabricationSkills = new RequiredSkill[]
            { 
                new(typeof(MechanicsSkill), 1), 
            };

            
            this.Initialize(displayText: Localizer.DoStr("Boiler"),
                            referencedDrawing:  typeof(BoilerDrawingItem));
        }
    }

    [Serialized]
    [Weight(100)]
    [LocDisplayName("Boiler Technical Drawing")]
    [Tag("Technical Drawing")]
    public partial class BoilerDrawingItem: DrawingItem {}
}
