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
    public partial class CameraFilmInvention: InventionRecipe
    {
        public CameraFilmInvention() 
        {
            this.FabricationIngredients = new FabricationElement[]
            {
                new(typeof(PaperItem), 10), new(typeof(LightBulbItem), 1), 
            };

            this.FabricationProducts = new FabricationElement[]
            {
                new(typeof(CameraFilmItem), 10, true), 
            };

            this.RequiredKits = new List<Item>()
            {
                Item.Get(typeof(SteamMaterialKitItem)), 
            }.ToArray();

            this.InventionLabor     = 45f;
            this.InventionTime      = 0.2f;

            this.RequiredSkills = new RequiredSkill[]
            { 
                new(typeof(MechanicsSkill), 1), 
            };

            this.FabricationTable = typeof(MachinistTableItem);
            this.Initialize(displayText: Localizer.DoStr("Camera Film"),
                            referencedRecipeFamilyType: typeof(CameraFilmRecipe),
                            referencedDrawing:  typeof(CameraFilmDrawingItem));
        }
    }

    [Serialized]
    [Weight(100)]
    [LocDisplayName("Camera Film Technical Drawing")]
    [Tag("Technical Drawing")]
    public partial class CameraFilmDrawingItem: DrawingItem {}
}
