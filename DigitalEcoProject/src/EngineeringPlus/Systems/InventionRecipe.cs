using Digits.src.EngineeringPlus;
using Eco.Core.Controller;
using Eco.Gameplay.Players;
using Eco.Gameplay.Skills;
using Eco.Gameplay.Systems.NewTooltip;
using Eco.Gameplay.Systems.TextLinks;
using Eco.Mods.TechTree;
using Eco.Shared.Items;
using Eco.Shared.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eco.Gameplay.Items.Recipes
{
    [ForceCreateViewAllDerived]
    [ConstantView]
    public abstract class InventionRecipe : IController, ILinkable
    {
        //Fabrication variables
        [SyncToView] public FabricationElement[]    FabricationIngredients  { get; set; }
        [SyncToView] public FabricationElement[]    FabricationProducts     { get; set; }
        [SyncToView] public float                   FabricationTime         { get; set; }   //craft time in minutes
        [SyncToView] public float                   FabricationLabor        { get; set; }
        [SyncToView] public float                   FabricationExperience   { get; set; }
        [SyncToView] public RequiredSkill[]         FabricationSkills       { get; set; }
        [SyncToView] public Type                    FabricationTable        { get; set; }

        //Invention variables
        [SyncToView] public Item[]                  InventionKits           { get; set; }
        [SyncToView] public Type                    InventionDrawing        { get; set; }
        [SyncToView] public float                   InventionTime           { get; set; }   //craft time in minutes
        [SyncToView] public float                   InventionLabor          { get; set; }
        [SyncToView] public float                   InventionExperience     { get; set; }
        [SyncToView] public RequiredSkill[]         InventionSkills         { get; set; }
        [SyncToView] public Type                    InventionTable          { get; set; }

        //General variables
        [SyncToView] public string Name { get; set; }
        

        public InventionRecipe()
        {
            this.Name = "Default Name";

            this.InventionKits = Array.Empty<Item>();
            this.InventionDrawing = typeof(DrawingItem);
            this.InventionTime = 1f;
            this.InventionLabor = 1f;
            this.InventionExperience = 1f;
            this.InventionSkills = Array.Empty<RequiredSkill>();
            this.InventionTable = typeof(ResearchTableItem);

            this.FabricationIngredients = Array.Empty<FabricationElement>();
            this.FabricationProducts = Array.Empty<FabricationElement>();
            this.FabricationTime = 1f;
            this.FabricationLabor = 1f;
            this.FabricationExperience = 1f;
            this.FabricationSkills = Array.Empty<RequiredSkill>();
            this.FabricationTable = typeof(MachinistTableItem);
        }

        protected void Initialize(LocString displayText, Type referencedRecipeFamilyType, Type referencedDrawing)
        {
            this.Name = displayText.NotTranslated;
            this.InventionDrawing = referencedDrawing;
        }

        protected void Initialize(LocString displayText, Type referencedDrawing)
        {
            this.Name = displayText.NotTranslated;
            this.InventionDrawing = referencedDrawing;
        }

        public void OnLinkClicked(TooltipOrigin origin, TooltipClickContext clickContext, User user) { }

        public LocString UILinkContent() => Localizer.DoStr(this.Name);

        #region IController
        int controllerID;
        public ref int ControllerID => ref this.controllerID;
        #endregion
    }
}
