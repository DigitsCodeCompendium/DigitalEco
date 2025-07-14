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
    public partial class SmallPaperMachineInvention: InventionRecipe
    {
        public SmallPaperMachineInvention() 
        {
            this.InventionKits = new Item[]
            {
                Item.Get(typeof(SteamMachineKitItem)), 
            };
        
            this.InventionLabor         = 240f;
            this.InventionTime          = 1f;
            this.InventionExperience    = 1f;
            this.InventionTable = typeof(ResearchTableItem);

            this.InventionSkills = new RequiredSkill[]
            { 
                new(typeof(MechanicsSkill), 1), 
            };

            this.FabricationIngredients = new FabricationElement[]
            {
                new(typeof(IronGearItem), 6), new(typeof(IronPlateItem), 8), 
            };

            this.FabricationProducts = new FabricationElement[]
            {
                new(typeof(SmallPaperMachineItem), 1, true), 
            };

            this.FabricationLabor       = 240f;
            this.FabricationTime        = 1f;
            this.FabricationExperience  = 1f;
            this.FabricationTable = typeof(MachinistTableItem);

            this.FabricationSkills = new RequiredSkill[]
            { 
                new(typeof(MechanicsSkill), 1), 
            };

            
            this.Initialize(displayText: Localizer.DoStr("Small Paper Machine"),
                            referencedDrawing:  typeof(SmallPaperMachineDrawingItem));
        }
    }

    [Serialized]
    [Weight(100)]
    [LocDisplayName("Small Paper Machine Technical Drawing")]
    [Tag("Technical Drawing")]
    public partial class SmallPaperMachineDrawingItem: DrawingItem {}
}
