using Digits.src.EngineeringPlus;
using Eco.Core.Controller;
using Eco.Gameplay.Skills;
using Eco.Mods.TechTree;
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
    public abstract class InventionRecipe : IController//, ILinkable
    {
        [SyncToView] public RequiredSkill[]         RequiredSkills          { get; set; }
        [SyncToView] public Type?                   ReferenceRecipeFamily   { get; set; }
        [SyncToView] public FabricationElement[]    FabricationIngredients  { get; set; }
        [SyncToView] public FabricationElement[]    FabricationProducts     { get; set; }
        [SyncToView] public Item[]                  RequiredKits            { get; set; }
        [SyncToView] public float                   InventionTime           { get; set; }   //craft time in minutes
        [SyncToView] public float                   InventionLabor          { get; set; }
        [SyncToView] public Type                    DrawingItem             { get; set; }
        [SyncToView] public string                  Name                    { get; set; }
        [SyncToView] public Type                    FabricationTable        { get; set; }


        public InventionRecipe()
        {
            this.RequiredKits = Array.Empty<Item>();
            this.RequiredSkills = Array.Empty<RequiredSkill>();
            this.ReferenceRecipeFamily = null;
            this.Name = "Default Name";
            this.InventionTime = 1f;
            this.InventionLabor = 1f;
            this.FabricationIngredients = Array.Empty<FabricationElement>();
            this.FabricationProducts = Array.Empty<FabricationElement>();
            this.FabricationTable = typeof(MachinistTableItem);
        }

        protected void Initialize(LocString displayText, Type referencedRecipeFamilyType, Type referencedDrawing)
        {
            this.ReferenceRecipeFamily = referencedRecipeFamilyType;
            this.Name = displayText.NotTranslated;
            this.DrawingItem = referencedDrawing;
        }

        public RecipeFamily GetRecipeFamily()
        {
            if (!(this.ReferenceRecipeFamily is null)) { return RecipeManager.GetRecipeFamily(this.ReferenceRecipeFamily); }
            else { throw new NullReferenceException(); }
        }

        #region IController
        int controllerID;
        public ref int ControllerID => ref this.controllerID;
        #endregion
    }
}
