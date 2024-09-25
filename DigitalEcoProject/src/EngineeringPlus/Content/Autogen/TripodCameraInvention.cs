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
    public partial class TripodCameraInvention: InventionRecipe
    {
        public TripodCameraInvention() 
        {
            this.FabricationIngredients = new FabricationElement[]
            {
                new(typeof(IronBarItem), 4), new(typeof(CopperBarItem), 8), new(typeof(LeatherHideItem), 8), new("WoodBoard", 16), new(typeof(GlassLensItem), 1, true), new(typeof(LightBulbItem), 1, true), 
            };

            this.FabricationProducts = new FabricationElement[]
            {
                new(typeof(TripodCameraItem), 1, true), 
            };

            this.RequiredKits = new List<Item>()
            {
                Item.Get(typeof(SteamMaterialKitItem)), 
            }.ToArray();

            this.InventionLabor     = 250f;
            this.InventionTime      = 0.5f;

            this.RequiredSkills = new RequiredSkill[]
            { 
                new(typeof(MechanicsSkill), 3), 
            };

            this.FabricationTable = typeof(MachinistTableItem);
            this.Initialize(displayText: Localizer.DoStr("Tripod Camera"),
                            referencedRecipeFamilyType: typeof(TripodCameraRecipe),
                            referencedDrawing:  typeof(TripodCameraDrawingItem));
        }
    }

    [Serialized]
    [Weight(100)]
    [LocDisplayName("Tripod Camera Technical Drawing")]
    [Tag("Technical Drawing")]
    public partial class TripodCameraDrawingItem: DrawingItem {}
}
