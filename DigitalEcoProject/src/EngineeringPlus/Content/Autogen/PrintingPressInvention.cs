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
    public partial class PrintingPressInvention: InventionRecipe
    {
        public PrintingPressInvention() 
        {
            this.InventionKits = new Item[]
            {
                Item.Get(typeof(SteamMachineKitItem)), 
            };
        
            this.InventionLabor         = 240f;
            this.InventionTime          = 2f;
            this.InventionExperience    = 1f;
            this.InventionTable = typeof(ResearchTableItem);

            this.InventionSkills = new RequiredSkill[]
            { 
                new(typeof(MechanicsSkill), 3), 
            };

            this.FabricationIngredients = new FabricationElement[]
            {
                new(typeof(GearboxItem), 2), new(typeof(PistonItem), 4), new(typeof(IronPlateItem), 12), 
            };

            this.FabricationProducts = new FabricationElement[]
            {
                new(typeof(PrintingPressItem), 1, true), 
            };

            this.FabricationLabor       = 240f;
            this.FabricationTime        = 2f;
            this.FabricationExperience  = 1f;
            this.FabricationTable = typeof(MachinistTableItem);

            this.FabricationSkills = new RequiredSkill[]
            { 
                new(typeof(MechanicsSkill), 3), 
            };

            
            this.Initialize(displayText: Localizer.DoStr("Printing Press"),
                            referencedDrawing:  typeof(PrintingPressDrawingItem));
        }
    }

    [Serialized]
    [Weight(100)]
    [LocDisplayName("Printing Press Technical Drawing")]
    [Tag("Technical Drawing")]
    public partial class PrintingPressDrawingItem: DrawingItem {}
}
