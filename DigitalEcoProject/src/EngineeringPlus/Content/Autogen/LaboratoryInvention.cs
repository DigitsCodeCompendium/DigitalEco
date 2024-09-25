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
    public partial class LaboratoryInvention: InventionRecipe
    {
        public LaboratoryInvention() 
        {
            this.FabricationIngredients = new FabricationElement[]
            {
                new(typeof(IronBarItem), 20), new(typeof(GlassItem), 15), new(typeof(PaperItem), 20), new("Lumber", 8), 
            };

            this.FabricationProducts = new FabricationElement[]
            {
                new(typeof(LaboratoryItem), 1, true), 
            };

            this.RequiredKits = new List<Item>()
            {
                Item.Get(typeof(SteamMachineKitItem)), Item.Get(typeof(SteamMaterialKitItem)), 
            }.ToArray();

            this.InventionLabor     = 120f;
            this.InventionTime      = 15f;

            this.RequiredSkills = new RequiredSkill[]
            { 
                new(typeof(MechanicsSkill), 1), 
            };

            this.FabricationTable = typeof(MachinistTableItem);
            this.Initialize(displayText: Localizer.DoStr("Laboratory"),
                            referencedRecipeFamilyType: typeof(LaboratoryRecipe),
                            referencedDrawing:  typeof(LaboratoryDrawingItem));
        }
    }

    [Serialized]
    [Weight(100)]
    [LocDisplayName("Laboratory Technical Drawing")]
    [Tag("Technical Drawing")]
    public partial class LaboratoryDrawingItem: DrawingItem {}
}
