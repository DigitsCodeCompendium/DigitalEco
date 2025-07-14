using Digits.src.EngineeringPlus;
using Eco.Core.Controller;
using Eco.Core.Items;
using Eco.Core.Utils;
using Eco.Gameplay.Components.Storage;
using Eco.Gameplay.Items;
using Eco.Gameplay.Items.Recipes;
using Eco.Gameplay.Objects;
using Eco.Gameplay.Players;
using Eco.Gameplay.Skills;
using Eco.Gameplay.Systems.TextLinks;
using Eco.Gameplay.UI;
using Eco.Gameplay.Utils;
using Eco.ModKit.Internal;
using Eco.Mods.TechTree;
using Eco.Mods.TextUI;
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
using User = Eco.Gameplay.Players.User;

namespace Eco.Gameplay.Components
{
    [Serialized, LocDescription("Take technical drawings and turn them into real things")]
    [Priority(-150)]
    [RequireComponent(typeof(StatusComponent))]
    [RequireComponent(typeof(LinkComponent))]
    [RequireComponent(typeof(InOutLinkedInventoriesComponent))]
    [RequireComponent(typeof(ClockInComponent))]
    [NoIcon]
    [Eco, AutogenClass, LocDisplayName("Fabricating")]
    public class FabricatingComponent : WorldObjectComponent, IController, IHasClientControlledContainers
    {
        [Serialized] public double                  StoredLabor             { get; private set; }
        [Serialized] public double                  ContributedLabor        { get; private set; }
        [Serialized] public int                     QueuedItterations       { get; private set; }
        [Serialized] public int                     CompletedItterations    { get; private set; }

        [Serialized] public bool                    IsFabricationRunning    { get; private set; }
        [Serialized] public bool                    IsItterationRunning     { get; private set; }
        [Serialized] public ImmutableCountdown      ContributedFabTime      { get; private set; }
        [Serialized] public ImmutableCountdown      ContributedIttTime      { get; private set; }

        [Serialized] private FabricationElement[]   OutputBuffer            { get; set; }
        [Serialized] private FabricationElement[]   ConsumedIngredients     { get; set; }
        [Serialized] private FabricationScrap[]     IngredientScrap         { get; set; }

        private LinkComponent                       Link                    { get; set; }
        private StatusElement                       Status                  { get; set; }
        private ClockInComponent                    ClockIn                 { get; set; }

        private bool                                IsOutputBufferEmpty => this.OutputBuffer.Length <= 0;
        private bool                                IsDrawingInserted => !this.Inventory.IsEmpty;
        public double?                              RequiredLabor => this.IsDrawingInserted ? this.GetLoadedDrawing()!.FabricationLabor * this.QueuedItterations : null;

        public FabricatingComponent()
        {
            this.Inventory = new LimitedInventory(1);
            this.Inventory.AddInvRestriction(new TagRestriction("Technical Drawing"));
            this.OutputBuffer = new List<FabricationElement>().ToArray();
            this.ContributedFabTime = ImmutableCountdown.CreatePaused(10);

            this.insertDrawingString = "Insert Drawing";
            this.RecipeName = "No Recipe Selected";
            this.IngredientsRequired ??= new ControllerList<IngredientReqView>(this, nameof(IngredientsRequired));
        }

        void UpdateRecipeName(User user) { this.RecipeName = this.Inventory.IsEmpty ? "No Recipe Selected" : this.Inventory.Stacks.First().UILink(); }
        public void PauseFabrication() {    this.ContributedFabTime = this.ContributedFabTime.Pause(true);
                                            this.ContributedIttTime = this.ContributedIttTime.Pause(true); }
        public void UnpauseFabrication() {  this.ContributedFabTime = this.ContributedFabTime.Pause(false);
                                            this.ContributedIttTime = this.ContributedIttTime.Pause(false); }
        

        public override void Initialize()
        {
            this.Link = this.Parent.GetComponent<LinkComponent>();
            this.Status = this.Parent.GetComponent<StatusComponent>().CreateStatusElement();
            this.ClockIn = this.Parent.GetComponent<ClockInComponent>();

            this.Parent.OnEnableChange.Add(() => { if (!this.Parent.Enabled) this.PauseFabrication(); });
            this.Inventory.OnChanged.Add(this.UpdateRecipeName);
        }

        public DrawingItem? GetLoadedDrawing()
        {
            if(this.Inventory.IsEmpty) return null;
            return (DrawingItem)this.Inventory.Stacks.First().Item;
        }

        public override void Tick()
        {
            if (!IsOutputBufferEmpty) TryEmptyBuffer();

            //update bars
            if (IsFabricationRunning)
            {
                this.ProccessFabrication();
                this.FabricatingBar.Update(0.1, (double)(this.StoredLabor / 100), this.ContributedFabTime.PercentComplete());
            }

        } 

        private void StartItteration()
        {
            this.IsItterationRunning = true;

            var drawing = this.GetLoadedDrawing();

            var consumedIngredient = drawing!.Ingredients.ToList();
            consumedIngredient.ForEach(x => x.Count = 0);
            this.ConsumedIngredients = consumedIngredient.ToArray();

            this.ContributedIttTime = ImmutableCountdown.CreateRunning(drawing.FabricationTime, drawing.FabricationTime);
        }

        private void ProccessItteration()
        {
            this.TryConsumeIngredients();

            if (!this.IsFabricationBlocked())
            {
                this.UnpauseFabrication();
                this.ConsumeLabor();

                if (this.ContributedIttTime.Expired())
                {
                    this.FinishItteration();
                }
            }
            else this.PauseFabrication();
        }

        private void FinishItteration()
        {
            this.IsItterationRunning = false;
            this.OutputItems(GetLoadedDrawing()!.Products);
        }

        private void OutputItems(FabricationElement[] outputItems)
        {
            //dont have to check if its a tag because products should never be a tag (theres no way to know which item from the tag group its supposed to be!)
            var user = this.Parent.GetComponent<ClockInComponent>().ClaimedUser;
            var invCol = new InventoryCollection(this.Link.GetSortedLinkedComponents(user, false, true).Select(component => component.Inventory));
            foreach (var output in outputItems)
            {
                var result = invCol.TryAddItem(Item.Get(output.Typename));
                if (!result) OutputBuffer = OutputBuffer.Append(output).ToArray();
            }
        }

        private void TryConsumeIngredients()
        {

        }

        private Result StartFabrication()
        {
            if (!this.IsDrawingInserted)
            {
                return new Result($"Can't start invention task, no recipe is selected!", false);
            }

            this.ContributedLabor = 0;
            this.CompletedItterations = 0;

            this.IsFabricationRunning = true;

            this.IngredientScrap = this.GetLoadedDrawing()!.Ingredients.Select(x => new FabricationScrap(x)).ToArray();

            var inventionTime = this.GetLoadedDrawing()!.FabricationTime;
            this.ContributedFabTime = ImmutableCountdown.CreateRunning(inventionTime, inventionTime);

            this.StartItteration();

            return Result.Succeeded;
        }

        private void ProccessFabrication()
        {
            if (this.IsItterationRunning)
            {
                this.ProccessItteration();
            }
            else if (this.CompletedItterations < this.QueuedItterations)
            {
                this.StartItteration();
            }
            else
            {
                this.FinishFabrication();
            }
        }

        private void FinishFabrication()
        {
            if (!this.IsDrawingInserted) return;
            if (!this.IsOutputBufferEmpty) return;

            ItemStack? itemStack = Inventory.Stacks.FirstOrDefault();
            if (itemStack == null) return;

            if (itemStack.Item is DrawingItem drawing)
            {
                OutputItems(drawing.Products);

                this.IngredientsRequired.Clear();
                foreach (FabricationElement ingredient in drawing.Ingredients)
                {
                    this.IngredientsRequired.Add(new IngredientReqView(ingredient.Typename));
                }
                this.Changed(nameof(IngredientsRequired));
            }
        }

        public Result CancelFabrication()
        {
            return new Result("Not implemented", false);
        }

        private void ConsumeLabor()
        {
            if (this.IsFabricationRunning & !this.IsFabricationBlocked() & this.IsDrawingInserted)
            {
                var laborLeft = this.GetLoadedDrawing()!.FabricationLabor - this.ContributedLabor;
                var timeLeft = this.ContributedFabTime.TimeLeft();
                var laborToConsume = laborLeft / timeLeft;

                this.ContributedLabor += laborToConsume;
                this.StoredLabor -= laborToConsume;
                if (this.StoredLabor < 0) { this.StoredLabor = 0; }
            }
        }

        public void TryEmptyBuffer()
        {
            var user = this.Parent.GetComponent<ClockInComponent>().ClaimedUser;
            var invCol = new InventoryCollection(this.Link.GetSortedLinkedComponents(user, false, true).Select(component => component.Inventory));
            if (!invCol.IsFull)
            {
                List<FabricationElement> toRemove = new List<FabricationElement>();
                foreach (var output in this.OutputBuffer)
                {
                    var result = invCol.AddItems(Item.Get(output.Typename), (int)output.Count);
                    if (result) toRemove.Add(output);
                }
                var tempList = this.OutputBuffer.ToList();
                toRemove.ForEach(x => tempList.Remove(x));
                this.OutputBuffer = tempList.ToArray();
            }
        }

        public bool IsFabricationBlocked()
        {
            if (this.Parent.GetComponent<OnOffComponent>() is not null ? !this.Parent.GetComponent<OnOffComponent>().On : false)
            {
                this.Status.SetStatusMessage(false, Localizer.DoStr($"Object is turned off"));
                return true;
            }

            if (!this.ClockIn.IsSomeoneClockedIn)
            {
                this.Status.SetStatusMessage(false, Localizer.DoStr($"Someone must be clocked in for fabrication to continue"));
                return true;
            }

            if (OutputBuffer.Count() > 0)
            {
                this.Status.SetStatusMessage(false, Localizer.DoStr($"No room to put output products"));
                return true;
            }




            this.Status.SetStatusMessage(true, Localizer.DoStr($"Everything running okay"));
            return false;
        }

        #region Autogen User Interface
        public string recipeName { get; set; }
        [Eco, ClientInterfaceProperty, PropReadOnly, UITypeName("GeneralHeader")]
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

        public int numberToFabricate { get; set; }
        [Eco, ClientInterfaceProperty]
        public int NumberToFabricate
        {
            get => this.numberToFabricate;
            set
            {
                if (value == this.numberToFabricate) return;
                this.numberToFabricate = value;
                this.Changed(nameof(this.NumberToFabricate));
            }
        }

        //Button Autogen
        [RPC, Autogen]
        public virtual void AddLabor(Player player)
        {
            Boolean result = player.User.Stomach.BurnCalories(100, false);
            if (result)
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
            if (this.IsOutputBufferEmpty)
            {
                if (this.IsDrawingInserted)
                {
                    ItemStack itemStack = Inventory.Stacks.First();
                    if (itemStack.Item is DrawingItem drawing)
                    {
                        //dont have to check if its a tag because products should never be a tag (theres no way to know which item from the tag group its supposed to be!)
                        var user = this.Parent.GetComponent<ClockInComponent>().ClaimedUser;
                        var invCol = new InventoryCollection(this.Link.GetSortedLinkedComponents(user, false, true).Select(component => component.Inventory));
                        foreach (var product in drawing.Products)
                        {
                            var result = invCol.TryAddItem(Item.Get(product.Typename));
                            if (!result)
                            {
                                OutputBuffer = OutputBuffer.Append(product).ToArray();
                            }
                        }

                        this.IngredientsRequired.Clear();
                        foreach (FabricationElement ingredient in drawing.Ingredients)
                        {
                            this.IngredientsRequired.Add(new IngredientReqView(ingredient.Typename));
                        }
                        this.Changed(nameof(IngredientsRequired));
                    }
                }
            }
            else
            {
                player.InfoBoxLoc($"Fabrication blocked, there is not enough room for products");
            }
            
        }

        [RPC, Autogen, UITypeName("BigButton"),]
        public void StartStopFabrication(Player player)
        {
            //stop fabrication if its running
            if (this.IsFabricationRunning)
            {
                this.IsFabricationRunning = false;
                CancelFabrication();
            }
            //if its not running, we need to start it
            else
            {
                var result = StartFabrication();
                player.InfoBox(result.Message);
            }
        }

        [SyncToView, Autogen, Sort(202), PropReadOnly, HideRoot]
        public TripleProgressBar FabricatingBar { get; set; } = new TripleProgressBar("Materials", "Labor", "Fabricating Progress", barLength: 60);

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
        #endregion
    }
}
