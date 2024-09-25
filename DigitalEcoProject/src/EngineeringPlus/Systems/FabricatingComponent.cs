using Digits.src.EngineeringPlus;
using Eco.Core.Controller;
using Eco.Core.Utils;
using Eco.Gameplay.Items;
using Eco.Gameplay.Items.Recipes;
using Eco.Gameplay.Objects;
using Eco.Gameplay.Players;
using Eco.Gameplay.Systems.TextLinks;
using Eco.Gameplay.UI;
using Eco.Gameplay.Utils;
using Eco.ModKit.Internal;
using Eco.Mods.TechTree;
using Eco.Shared.Localization;
using Eco.Shared.Networking;
using Eco.Shared.Serialization;
using Eco.Shared.UI;
using Eco.Shared.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eco.Gameplay.Components
{
    [Serialized, LocDescription("MyNewComponent Description")]
    [Priority(-150)]
    [NoIcon]
    [Eco, AutogenClass, LocDisplayName("Fabricating Component")]
    public class FabricatingComponent : WorldObjectComponent, IController, IHasClientControlledContainers
    {
        //Button Autogen
        [RPC, Autogen]
        public virtual void AddLabor(Player player)
        {
            Boolean result = player.User.Stomach.BurnCalories(100, false);
            if(result)
            {
                player.InfoBoxLoc($"Performed {Text.StyledInt(100)} units of labor on {this.UILink()}.");
            }
            else
            {
                player.InfoBoxLoc($"Not enough calories to perform labor.");
            }
        }

        //Button Autogen
        [RPC, Autogen]
        public virtual void Fabricate(Player player)
        {
            /*
            if (!Inventory.IsEmpty)
            {
                ItemStack? itemStack = Inventory.Stacks.FirstOrDefault();

                if (itemStack != null)
                {
                    var drawing = (DrawingItem)itemStack.Item;
                    var recipe = drawing.GetRecipe();

                    player.User.Inventory.TryAddItem(recipe.Products.FirstOrDefault().Item);
                }
            }*/

            /*
            this.IngredientsRequired.Clear();
            foreach (IngredientElement ingredient in this.LoadedRecipe.Ingredients)
            {
                this.IngredientsRequired.Add(new IngredientReqView(ingredient.Item));
            }
            this.Changed(nameof(IngredientsRequired));*/
        }

        public FabricatingComponent()
        {
            Inventory ??= new LimitedInventory(1);
            this.insertDrawingString = "Insert Drawing";
            this.RecipeName = "re";
            this.IngredientsRequired ??= new ControllerList<IngredientReqView>(this, nameof(IngredientsRequired));
        }

        public override void Tick()
        {
            
        }

        /// 
        /// UI STUFF BEYOND HERE
        /// 

        public string insertDrawingString { get; set; }
        [Eco, ClientInterfaceProperty, PropReadOnly, UITypeName("StringDisplay")]
        public string InsertDrawingString
        {
            get => this.insertDrawingString;
            set
            {
                if (value == this.insertDrawingString) return;
                this.insertDrawingString = value;
                this.Changed(nameof(this.InsertDrawingString));
            }
        }

        [Eco, UITypeName("ItemInput")] public LimitedInventory Inventory {  get; set; }

        public string recipeName { get; set; }
        [Eco, ClientInterfaceProperty, PropReadOnly, UITypeName("StringDisplay")]
        public string RecipeName
        {
            get => this.recipeName;
            set
            {
                if (value == this.recipeName) return;
                this.recipeName = value;
                this.Changed(nameof(this.RecipeName));
            }
        }

        ControllerList<IngredientReqView> ingredientsRequired { get; set; }
        [Eco, ClientInterfaceProperty, GuestHidden, PropReadOnly, LocDisplayName("Required Ingredients"), UIListTypeName("IEnumerableHeader"), HideRootListEntry, Sort(204)]
        public ControllerList<IngredientReqView> IngredientsRequired
        {
            get => ingredientsRequired;
            set
            {
                if (value == ingredientsRequired) return;
                ingredientsRequired = value;
                this.Changed(nameof(IngredientsRequired));
            }
        }
    }
}
