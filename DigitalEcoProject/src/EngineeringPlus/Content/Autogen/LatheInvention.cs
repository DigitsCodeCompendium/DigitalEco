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
    public partial class LatheInvention: InventionRecipe
    {
        public LatheInvention() 
        {
            this.InventionKits = new Item[]
            {
                Item.Get(typeof(SteamMaterialKitItem)), 
            };
        
            this.InventionLabor         = 150f;
            this.InventionTime          = 5f;
            this.InventionExperience    = 20f;
            this.InventionTable = typeof(ResearchTableItem);

            this.InventionSkills = new RequiredSkill[]
            { 
                new(typeof(MechanicsSkill), 1), 
            };

            this.FabricationIngredients = new FabricationElement[]
            {
                new(typeof(IronWheelItem), 4), new(typeof(IronPlateItem), 12), 
            };

            this.FabricationProducts = new FabricationElement[]
            {
                new(typeof(LatheItem), 1, true), 
            };

            this.FabricationLabor       = 150f;
            this.FabricationTime        = 5f;
            this.FabricationExperience  = 20f;
            this.FabricationTable = typeof(MachinistTableItem);

            this.FabricationSkills = new RequiredSkill[]
            { 
                new(typeof(MechanicsSkill), 1), 
            };

            
            this.Initialize(displayText: Localizer.DoStr("Lathe"),
                            referencedDrawing:  typeof(LatheDrawingItem));
        }
    }

    [Serialized]
    [Weight(100)]
    [LocDisplayName("Lathe Technical Drawing")]
    [Tag("Technical Drawing")]
    public partial class LatheDrawingItem: DrawingItem {}
}
