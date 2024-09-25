using Eco.Core.Controller;
using Eco.Core.Utils;
using Eco.Gameplay.Items.Recipes;
using Eco.Gameplay.Items;
using Eco.Gameplay.Objects;
using Eco.Gameplay.Players;
using Eco.Gameplay.Systems.TextLinks;
using Eco.Gameplay.Utils;
using Eco.Mods.TechTree;
using Eco.Shared.Localization;
using Eco.Shared.Networking;
using Eco.Shared.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eco.Shared.Utils;
using System.ComponentModel;
using Eco.Gameplay.UI;
using Eco.Gameplay.Skills;
using static Eco.Gameplay.UI.PlayerPopups;
using Eco.Mods.TextUI;
using Eco.Gameplay.Components.Storage;
using Eco.Core.Items;
using Eco.Gameplay.Systems.EnvVars;
using Eco.Core.Properties;
using Eco.Shared.Time;
using Eco.Gameplay.Components.Store;
using Digits.src.EngineeringPlus;

namespace Eco.Gameplay.Components
{
    [Eco, AutogenClass, LocDisplayName("Engineering Component")]
    [Serialized, LocDescription("MyNewComponent Description")]
    [Priority(-150)]
    [RequireComponent(typeof(CreditComponent))]
    [RequireComponent(typeof(StatusComponent))]
    [RequireComponent(typeof(InOutLinkedInventoriesComponent))]
    [NoIcon]
    [Tag("Crafting Table")]
    //[Ecopedia]
    public class EngineeringComponent : WorldObjectComponent, INotifyPropertyChanged
    {
        [Serialized, Notify] public bool BottleNecked { get; private set; }
        public InventionRecipe? SelectedInventionRecipe => SelectedInvenRecipeType is null ? null : InventionRecipeManager.GetRecipeByRecipeType(SelectedInvenRecipeType);
        [Serialized] public Type? SelectedInvenRecipeType { get; private set; }

        [Serialized] public double StoredLabor { get; private set; }
        [Serialized] public double ContributedLabor { get; private set; }
        [Serialized] public User? OwningUser { get; private set; }
        [Serialized] public bool IsInventionRunning { get; private set; }
        [Serialized] public ImmutableCountdown ContributedCraftTime { get; private set; }
        [SyncToView] public IEnumerable<string> ValidTalents { get; set; } = new List<string>();
        public double TimeLeft => this.ContributedCraftTime.TimeLeft();
        public bool IsRecipeLoaded => this.SelectedInvenRecipeType is not null;
        private const double MaxLabor = 10000;
        private double BaseMean;
        private double BaseStd;

        public EngineeringComponent()
        {
            this.IsInventionRunning = false;
            this.RecipeName = "";
            this.recipeName = "";
            this.infoBox = "";
            this.ContributedCraftTime = ImmutableCountdown.CreatePaused(10);
            this.SelectedInvenRecipeType ??= null;
        }

        public void Initialize(double baseMean =-0.1f, double baseStd = 0.1f)
        {
            this.BaseMean = baseMean;
            this.BaseStd = baseStd;
            // check all nearby tables and recheck for talents.
            //if (this.Parent.HasComponent<RoomRequirementsComponent>())
            //this.Parent.GetComponent<RoomRequirementsComponent>().OnRoomCheck.Add(this.GetValidTalents);

            //this.Parent.Auth?.OwnerChanged.Add(_ => this.GetValidTalents());

            //When enable status changes, tick the work orders to make the timers pause.
            this.Parent.OnEnableChange.Add(() => { if (!this.Parent.Enabled) this.PauseInvention(); });

            this.WatchProp(this, nameof(this.BottleNecked), (_, _) => this.UpdateTotalCraftingTimer()); // Update the crafting timer depending if the work orders are halted or not.
        }

        private void UpdateTotalCraftingTimer()
        {
            var craftingTimeLeft = this.TimeLeft;
            // pause the timer if we got bottlenecked
            this.ContributedCraftTime = this.BottleNecked ? ImmutableCountdown.CreatePaused(craftingTimeLeft)
                                                          : ImmutableCountdown.CreateRunning(craftingTimeLeft, craftingTimeLeft);
        }

        public void PauseInvention() { this.ContributedCraftTime = this.ContributedCraftTime.Pause(true); }
        public void UnpauseInvention() { this.ContributedCraftTime = this.ContributedCraftTime.Pause(false); }

        [RPC]
        public void GetValidTalents()
        {
            List<string> talentStrings = new List<string>();
            foreach (var talent in TalentManager.AllTalents.Where(x => x.TalentType == typeof(CraftingTalent) && x.Base))
            {
                // check if talent is active on this
                if (talent.Active(this))
                    talentStrings.Add(talent.GetType().Name);
            }
            this.ValidTalents = talentStrings;
        }

        public override void Tick() => this.Tick(this.Parent.SimTickDelta());
        internal void Tick(float deltaTime)
        {
            if (IsRecipeLoaded)
            {
                var recipe = RecipeManager.GetRecipeFamily(this.SelectedInventionRecipe.ReferenceRecipeFamily);
                this.RecipeName = $"Recipe: {recipe.UILink()}";
            }
            else
            {
                this.RecipeName = "Recipe: None";
            }

            this.ConsumeLabor();

            if (this.IsInventionBlocked())                  this.PauseInvention();
            else if (this.ContributedCraftTime.Paused())    this.UnpauseInvention();

            double PercentLeft;
            if (IsInventionRunning) { PercentLeft = this.ContributedCraftTime.PercentComplete(); }
            else { PercentLeft = 0; }

            var time = FormatTime((int)this.ContributedCraftTime.TimeLeft());

            string displayString;

            if (this.IsInventionRunning)
            {
                displayString = $"Invention Time Remaining: {time}";
            }
            else
            {
                displayString = "Invention Not Running";
            }

            this.FabricatingBar.Update(PercentLeft, displayString);
            this.LaborBar.Update(this.StoredLabor / MaxLabor, $"Stored Labor {this.StoredLabor:0}/{MaxLabor}");


            if (IsRecipeLoaded & this.IsInventionRunning & (this.ContributedCraftTime.Paused() || this.ContributedCraftTime.Expired()))
            {
                FinishInvention();
                var inventionTime = this.SelectedInventionRecipe.InventionTime;
                if (IsInventionBlocked())   { this.ContributedCraftTime = ImmutableCountdown.CreatePaused(inventionTime, inventionTime); }
                else                        { this.ContributedCraftTime = ImmutableCountdown.CreateRunning(inventionTime, inventionTime); }
                this.ContributedLabor = 0;
            }

            //info box
            var bonusMean = this.GetBonusMean();
            var bonusMeanColor = DrawingItem.GetQualityColor(bonusMean);
            var qualityMean = this.GetQualityMean();
            var qualityMeanColor = DrawingItem.GetQualityColor(qualityMean);

            string ingredientInfo = "Required Kits: ";
            if (IsRecipeLoaded)
            {
                if (this.SelectedInventionRecipe.RequiredKits.Count() > 0)
                {
                    foreach (var kit in this.SelectedInventionRecipe.RequiredKits)
                    {
                        ingredientInfo += kit.UILink() + " ";
                    }
                }
                else
                {
                    ingredientInfo += "No kits required";
                }
            }
            else
            {
                ingredientInfo += "Select recipe first";
            }

            this.InfoBox = $"Kit Break Chance: <color=#99d047>{GetKitBreakChance():0%}</color>\n" +
                           $"Bonus Chance: <color=#99d047>{1 - this.GetNoBonusChance():0%}</color>\n" +
                           $"Average Bonus: {bonusMeanColor}{-bonusMean:0.0%}</color>\n" +
                           $"Average Quality: {qualityMeanColor}{qualityMean * 100:0.0}</color>\n" +
                           ingredientInfo;


        }

        private static string FormatTime(int totalSeconds)
        {
            int hours = totalSeconds / 3600;
            int minutes = (totalSeconds % 3600) / 60;
            int seconds = totalSeconds % 60;

            if (hours > 0)
                return $"{hours}h {minutes:D2}m {seconds:D2}s";
            else if (minutes > 0)
                return $"{minutes}m {seconds:D2}s";
            else
                return $"{seconds:D2}s";
        }

        public bool IsInventionBlocked()
        {
            if (!this.IsRecipeLoaded) return true;
            if (this.StoredLabor <= 0) return true;
            if (this.Parent.GetComponent(typeof(PublicStorageComponent)) is not PublicStorageComponent) return true;

            var requiredKits = this.SelectedInventionRecipe.RequiredKits;
            var storageComponent = this.Parent.GetComponent(typeof(PublicStorageComponent)) as PublicStorageComponent;
            if (!requiredKits.All(kit => storageComponent.Inventory.NonEmptyStacks.Select(x => x.Item.GetType()).ToList().Contains(kit.GetType())))
            { return true; }
            return false;
        }

        private bool FinishInvention()
        {
            if (this.IsInventionBlocked() || this.SelectedInvenRecipeType is null) { return false; }

            Random random = new();
            foreach (var kit in this.SelectedInventionRecipe.RequiredKits) 
            {
                if (random.Chance(this.GetKitBreakChance()))
                {
                    var storageComponent = this.Parent.GetComponent(typeof(PublicStorageComponent)) as PublicStorageComponent;
                    var items = storageComponent.Inventory.NonEmptyStacks.Where(stack => stack.Item.GetType() == kit.GetType());
                    items.First().Clear();
                }
            }

            CreateDrawing();

            return true;
        }

        private void ConsumeLabor()
        {
            if (this.IsInventionRunning & !this.IsInventionBlocked() & this.IsRecipeLoaded)
            {
                var laborLeft = this.SelectedInventionRecipe.InventionLabor - this.ContributedLabor;
                var timeLeft = this.ContributedCraftTime.TimeLeft();
                var laborToConsume = laborLeft / timeLeft;

                this.ContributedLabor += laborToConsume;
                this.StoredLabor -= laborToConsume;
                if (this.StoredLabor < 0) { this.StoredLabor = 0;}
            }
        }

        public void CreateDrawing()
        {
            if (this.SelectedInventionRecipe == null) return;

            var item = Item.Create(this.SelectedInventionRecipe.DrawingItem) as DrawingItem;

            item.Generate(this.SelectedInventionRecipe, this.GetInventionMean(), this.GetInventionStd());
            this.Parent.GetComponent<StorageComponent>().Inventory.TryAddItem(item);
        }

        public bool Operating => !this.ContributedCraftTime.Paused();
        private double GetInventionMean() => (this.InventionAggressiveness * 0.02) + this.BaseMean;
        private double GetInventionStd() => this.BaseStd;
        private double GetKitBreakChance() => Math.Pow(this.InventionAggressiveness, 2) * 0.01;
        private double GetNoBonusChance() => 1 / (1 + Math.Exp(-1.65451 * (-this.GetInventionMean()) * (1 / this.GetInventionStd())));
        private double GetBonusMean() => 0.60440 * this.GetInventionStd() * Math.Log(Math.Abs(1 / this.GetNoBonusChance()));
        private double GetQualityMean() => this.GetBonusMean() * (1 - this.GetNoBonusChance());
        /// ------------------------------------------
        ///            UI STUFF BEYOND HERE
        /// ------------------------------------------



        [RPC, Autogen, UITypeName("BigButton")]
        public void StartInvention(Player player)
        {
            if (!IsRecipeLoaded)
            {
                player.InfoBoxLoc($"Can't start invention task, no recipe is selected!");
                return;
            }

            foreach (var skillType in this.SelectedInventionRecipe.RequiredSkills.Select(x => x.SkillType))
            {
                if (!player.User.Skillset.HasSkill(skillType))
                {
                    player.InfoBoxLoc($"You require {Skill.Get(skillType).UILink()} to invent this recipe!");
                    return;
                }
            }

            this.ContributedLabor = 0;

            this.IsInventionRunning = true;

            var inventionTime = this.SelectedInventionRecipe.InventionTime;

            if (IsInventionBlocked())   { this.ContributedCraftTime = ImmutableCountdown.CreatePaused(inventionTime, inventionTime); }
            else                        { this.ContributedCraftTime = ImmutableCountdown.CreateRunning(inventionTime, inventionTime); }

            player.InfoBoxLoc($"Success!");
        }

        [RPC, Autogen, UITypeName("BigButton")]
        public void CancelInvention(Player player)
        {
            this.IsInventionRunning = false;
        }

        //Button Autogen
        [RPC, Autogen]
        public virtual void CreateDrawing(Player player)
        {
            if (this.SelectedInventionRecipe == null)
            {
                player.InfoBoxLoc($"Please choose a recipe first!");
                return;
            }

            this.CreateDrawing();
        }

        //Button Autogen
        [RPC, Autogen]
        public virtual async void ChooseRecipe(Player player)
        {
            var inventionRecipes = InventionRecipeManager.AllRecipes;

            List<NamedSelection> items = new List<NamedSelection>();
            foreach (var inventionRecipe in inventionRecipes)
            {
                var selection = new NamedSelection
                {
                    Name = inventionRecipe.Name,
                    Entry = inventionRecipe
                };
                items.Add(selection);
            }
            var result = await player.PopupSelectFromIndexedOptions(Localizer.DoStr("Choose a Recipe"), Localizer.DoStr("Test thing"), LocString.Empty, items.ToArray());
            var temp = (InventionRecipe?)result.FirstOrDefault();
            this.SelectedInvenRecipeType = temp is null ? null : temp.GetType();
        }

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

        [SyncToView, Autogen, Sort(202), PropReadOnly, HideRoot]
        public ProgressBar FabricatingBar { get; set; } = new ProgressBar("Invention Progress", barLength:60);

        public int inventionAggressiveness { get; set; }
        [Eco, ClientInterfaceProperty]
        public int InventionAggressiveness
        {
            get => this.inventionAggressiveness;
            set
            {
                if (value == this.inventionAggressiveness) return;
                if (value > 10) return;
                this.inventionAggressiveness = value;
                this.Changed(nameof(this.InventionAggressiveness));
            }
        }

        public string infoBox { get; set; }
        [Eco, ClientInterfaceProperty, PropReadOnly, UITypeName("StringDisplay")]
        public string InfoBox
        {
            get => this.infoBox;
            set
            {
                if (value == this.infoBox) return;
                this.infoBox = value;
                this.Changed(nameof(this.InfoBox));
            }
        }

        //Button Autogen
        [RPC, Autogen, Sort(203)]
        public void AddLabor(Player player)
        {
            double laborToConsume = 500;
            double laborToAdd;
            if (this.StoredLabor + laborToConsume > MaxLabor)
                laborToAdd = MaxLabor - this.StoredLabor;
            else
                laborToAdd = laborToConsume;

            Boolean result = player.User.Stomach.BurnCalories((float)laborToAdd, false);
            if (result)
            {
                this.StoredLabor += laborToAdd;
                player.InfoBoxLoc($"Performed {Text.StyledInt((int)laborToAdd)} units of labor on {this.UILink()}.");
            }
            else
            {
                player.InfoBoxLoc($"Not enough calories to perform labor.");
            }
        }

        [SyncToView, Autogen, Sort(204), PropReadOnly, HideRoot]
        public ProgressBar LaborBar { get; set; } = new ProgressBar("Stored Labor", barLength: 60, fillColor:"blue");
    }
}