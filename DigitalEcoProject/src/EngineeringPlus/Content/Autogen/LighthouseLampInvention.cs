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
    public partial class LighthouseLampInvention: InventionRecipe
    {
        public LighthouseLampInvention() 
        {
            this.InventionKits = new Item[]
            {
                Item.Get(typeof(SteamMachineKitItem)), 
            };
        
            this.InventionLabor         = 480f;
            this.InventionTime          = 5f;
            this.InventionExperience    = 4f;
            this.InventionTable = typeof(ResearchTableItem);

            this.InventionSkills = new RequiredSkill[]
            { 
                new(typeof(MechanicsSkill), 4), 
            };

            this.FabricationIngredients = new FabricationElement[]
            {
                new(typeof(GlassItem), 12), new(typeof(CopperWiringItem), 6), new(typeof(IronPlateItem), 4), new(typeof(ElectricMotorItem), 1, true), 
            };

            this.FabricationProducts = new FabricationElement[]
            {
                new(typeof(LighthouseLampItem), 1, true), 
            };

            this.FabricationLabor       = 480f;
            this.FabricationTime        = 5f;
            this.FabricationExperience  = 4f;
            this.FabricationTable = typeof(MachinistTableItem);

            this.FabricationSkills = new RequiredSkill[]
            { 
                new(typeof(MechanicsSkill), 4), 
            };

            
            this.Initialize(displayText: Localizer.DoStr("Lighthouse Lamp"),
                            referencedDrawing:  typeof(LighthouseLampDrawingItem));
        }
    }

    [Serialized]
    [Weight(100)]
    [LocDisplayName("Lighthouse Lamp Technical Drawing")]
    [Tag("Technical Drawing")]
    public partial class LighthouseLampDrawingItem: DrawingItem {}
}
