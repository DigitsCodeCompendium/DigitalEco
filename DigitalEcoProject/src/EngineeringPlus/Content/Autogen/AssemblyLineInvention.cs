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
    public partial class AssemblyLineInvention: InventionRecipe
    {
        public AssemblyLineInvention() 
        {
            this.FabricationIngredients = new FabricationElement[]
            {
                new(typeof(ScrewsItem), 8), new(typeof(IronBarItem), 8), new(typeof(IronGearItem), 8), new(typeof(PortableSteamEngineItem), 1, true), 
            };

            this.FabricationProducts = new FabricationElement[]
            {
                new(typeof(AssemblyLineItem), 1, true), 
            };

            this.RequiredKits = new List<Item>()
            {
                Item.Get(typeof(SteamMachineKitItem)), Item.Get(typeof(SteamMaterialKitItem)), 
            }.ToArray();

            this.InventionLabor     = 240f;
            this.InventionTime      = 40f;

            this.RequiredSkills = new RequiredSkill[]
            { 
                new(typeof(MechanicsSkill), 1), 
            };

            this.FabricationTable = typeof(MachinistTableItem);
            this.Initialize(displayText: Localizer.DoStr("Assembly Line"),
                            referencedRecipeFamilyType: typeof(AssemblyLineRecipe),
                            referencedDrawing:  typeof(AssemblyLineDrawingItem));
        }
    }

    [Serialized]
    [Weight(100)]
    [LocDisplayName("Assembly Line Technical Drawing")]
    [Tag("Technical Drawing")]
    public partial class AssemblyLineDrawingItem: DrawingItem {}
}
