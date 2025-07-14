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
    public partial class ShaperInvention: InventionRecipe
    {
        public ShaperInvention() 
        {
            this.InventionKits = new Item[]
            {
                Item.Get(typeof(SteamMaterialKitItem)), 
            };
        
            this.InventionLabor         = 300f;
            this.InventionTime          = 5f;
            this.InventionExperience    = 5f;
            this.InventionTable = typeof(ResearchTableItem);

            this.InventionSkills = new RequiredSkill[]
            { 
                new(typeof(MechanicsSkill), 1), 
            };

            this.FabricationIngredients = new FabricationElement[]
            {
                new(typeof(IronPlateItem), 16), new(typeof(PistonItem), 16), 
            };

            this.FabricationProducts = new FabricationElement[]
            {
                new(typeof(ShaperItem), 1, true), 
            };

            this.FabricationLabor       = 300f;
            this.FabricationTime        = 5f;
            this.FabricationExperience  = 5f;
            this.FabricationTable = typeof(MachinistTableItem);

            this.FabricationSkills = new RequiredSkill[]
            { 
                new(typeof(MechanicsSkill), 1), 
            };

            
            this.Initialize(displayText: Localizer.DoStr("Shaper"),
                            referencedDrawing:  typeof(ShaperDrawingItem));
        }
    }

    [Serialized]
    [Weight(100)]
    [LocDisplayName("Shaper Technical Drawing")]
    [Tag("Technical Drawing")]
    public partial class ShaperDrawingItem: DrawingItem {}
}
