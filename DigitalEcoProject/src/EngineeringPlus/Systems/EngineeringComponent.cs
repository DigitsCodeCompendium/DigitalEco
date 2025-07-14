using Eco.Core.Controller;
using Eco.Core.Utils;
using Eco.Gameplay.Items.Recipes;
using Eco.Gameplay.Items;
using Eco.Gameplay.Objects;
using Eco.Gameplay.Players;
using Eco.Gameplay.Systems.TextLinks;
using Eco.Gameplay.Utils;
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
using Eco.Core.Properties;
using Digits.src.EngineeringPlus;
using Eco.Mods.TechTree;

namespace Eco.Gameplay.Components
{
    [Eco, AutogenClass, LocDisplayName("Engineering")]
    [Serialized, LocDescription("Invent new designs and capture them in technical drawings for fabricators to bring to life")]
    [Priority(-150)]
    [RequireComponent(typeof(LinkComponent))]
    [RequireComponent(typeof(StatusComponent))]
    [RequireComponent(typeof(InOutLinkedInventoriesComponent))]
    [RequireComponent(typeof(ClockInComponent))]
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
        [Serialized] public bool IsInventionRunning { get; private set; }
        [Serialized] public ImmutableCountdown ContributedCraftTime { get; private set; }
        public double TimeLeft => this.ContributedCraftTime.TimeLeft();
        public bool IsRecipeLoaded => this.SelectedInvenRecipeType is not null;
        private const double MaxLabor = 10000;
        private double BaseMean;
        private double BaseStd;
        private bool OutputBlocked;
        private LinkComponent link;
        private StatusElement status;

        public EngineeringComponent()
        {
            this.IsInventionRunning = false;
            this.RecipeName = "";
            this.recipeName = "";
            this.infoBox = "";
            this.ContributedCraftTime = ImmutableCountdown.CreatePaused(10);
            //this.SelectedInvenRecipeType ??= null;
            this.OutputBlocked = false;
        }

        public void Initialize(double baseMean =-0.1f, double baseStd = 0.1f)
        {
            this.BaseMean = baseMean;
            this.BaseStd = baseStd;
            this.link = this.Parent.GetComponent<LinkComponent>();
            this.status = this.Parent.GetComponent<StatusComponent>().CreateStatusElement();
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

        public override void Tick()
        {
            if (IsRecipeLoaded)
            {
                this.RecipeName = $"Recipe: {this.SelectedInventionRecipe.UILinkContent()}";
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

            this.InventionBar.Update(PercentLeft, displayString);

            string laborBarInfo;
            if (IsInventionRunning && IsRecipeLoaded)
            {
                laborBarInfo = $"Contributed Labor {this.StoredLabor:0}/{MaxLabor}.\nThere is enough labor for {this.StoredLabor / this.SelectedInventionRecipe.InventionLabor:0} invention itterations.";
            }
            else
            {
                laborBarInfo = $"Invention Not Running";
            }
            this.LaborBar.Update(this.StoredLabor / MaxLabor, laborBarInfo);


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
            string laborInfo = "Required Labor: ";
            if (IsRecipeLoaded)
            {
                if (this.SelectedInventionRecipe.InventionKits.Count() > 0)
                {
                    foreach (var kit in this.SelectedInventionRecipe.InventionKits)
                    {
                        ingredientInfo += kit.UILink() + " ";
                    }
                }
                else
                {
                    ingredientInfo += "No kits required";
                }
                laborInfo += this.SelectedInventionRecipe.InventionSkills.First().SkillItem.UILink();
            }
            else
            {
                ingredientInfo += "Select recipe first";
                laborInfo += "Select recipe first";
            }

            this.InfoBox = $"Kit Break Chance: <color=#99d047>{GetKitBreakChance():0%}</color>\n" +
                           $"Bonus Chance: <color=#99d047>{1 - this.GetNoBonusChance():0%}</color>\n" +
                           $"Average Bonus: {bonusMeanColor}{-bonusMean:0.0%}</color> \n" +
                           $"Average Quality: {qualityMeanColor}{qualityMean * 100:0.0}</color>\n" +
                           ingredientInfo + "\n" +
                           laborInfo;
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
            var user = (this.Parent.GetComponent(typeof(ClockInComponent)) as ClockInComponent).ClaimedUser;
            if (user is null)
            {
                this.status.SetStatusMessage(false, Localizer.DoStr($"Someone must be clocked in to perform invention"));
                return true;
            }

            if (!this.IsRecipeLoaded)
            {
                this.status.SetStatusMessage(false, Localizer.DoStr($"No invention recipe is selected"));
                return true;
            }

            var requiredKits = this.SelectedInventionRecipe.InventionKits;
            if (!requiredKits.All(kit => link.GetSortedLinkedInventories(user).NonEmptyStacks.Select(x => x.Item.GetType()).ToList().Contains(kit.GetType())))
            {
                this.status.SetStatusMessage(false, Localizer.DoStr($"The required kits for invention are not available in connected input inventories"));
                return true;
            }

            if (this.StoredLabor <= 0)
            {
                this.status.SetStatusMessage(false, Localizer.DoStr($"There is not enough labor to continue invention"));
                return true;
            }

            var invCol = new InventoryCollection(this.link.GetSortedLinkedComponents(this.Parent.GetComponent<ClockInComponent>().ClaimedUser, false, true).Select(component => component.Inventory));
            if (invCol.IsFull) {
                this.status.SetStatusMessage(false, Localizer.DoStr($"There is no valid output for {this.UILink()}"));
                return true; 
            } 

            this.status.SetStatusMessage(true, Localizer.DoStr($"No problems reported from {this.UILink()}"));
            return false;
        }

        private bool FinishInvention()
        {
            if (this.IsInventionBlocked() || this.SelectedInvenRecipeType is null) { return false; }

            CreateDrawing();

            if (this.OutputBlocked) { return false; }

            Random random = new();
            foreach (var kit in this.SelectedInventionRecipe.InventionKits) 
            {
                if (random.Chance(this.GetKitBreakChance()))
                {
                    var user = (this.Parent.GetComponent(typeof(ClockInComponent)) as ClockInComponent).ClaimedUser;
                    this.link.GetSortedLinkedInventories(user).TryRemoveItem(kit.GetType());
                }
            } 

            return true;
        }

        private void ConsumeLabor()
        {
            if (this.IsInventionRunning & !this.IsInventionBlocked() & this.IsRecipeLoaded)
            {
                var laborLeft = this.SelectedInventionRecipe!.InventionLabor - this.ContributedLabor;
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

            var item = Item.Create(this.SelectedInventionRecipe.InventionDrawing) as DrawingItem;
            item.Generate(  this.SelectedInventionRecipe, 
                            this.Parent.GetComponent<ClockInComponent>().ClaimedUser, 
                            this.GetInventionMean(), 
                            this.GetInventionStd());

            var user = this.Parent.GetComponent<ClockInComponent>().ClaimedUser;
            var invCol = new InventoryCollection(this.link.GetSortedLinkedComponents(user, false, true).Select(component => component.Inventory));
            var result = invCol.TryAddItem(item);
            
            if (result.Success) { this.OutputBlocked = false; }
            else { this.OutputBlocked = true; }
        }

        public bool Operating => !this.ContributedCraftTime.Paused();
        private double GetInventionMean()
        {
            double skillMod = 0;
            if (this.Parent.GetComponent(typeof(ClockInComponent)) is not null)
            {
                var user = (this.Parent.GetComponent<ClockInComponent>().ClaimedUser);
                if (user is not null && user.Skillset.HasSkill(typeof(MechanicsSkill)))
                {
                    skillMod = user.Skillset.GetSkill(typeof(MechanicsSkill)).Level * 0.03;
                }
            }
            return (this.InventionAggressiveness * 0.02) + this.BaseMean + skillMod;
        }
        private double GetInventionStd() => this.BaseStd;
        private double GetKitBreakChance() => Math.Pow(this.InventionAggressiveness, 2) * 0.01;
        private double GetNoBonusChance() => 1 / (1 + Math.Exp(-1.65451 * (-this.GetInventionMean()) * (1 / this.GetInventionStd())));
        private double GetBonusMean() => 0.60440 * this.GetInventionStd() * Math.Log(Math.Abs(1 / this.GetNoBonusChance()));
        private double GetQualityMean() => this.GetBonusMean() * (1 - this.GetNoBonusChance());
       
        /// ------------------------------------------
        ///            UI STUFF BEYOND HERE
        /// ------------------------------------------
        [RPC, Autogen, UITypeName("BigButton"), ]
        public void StartStopInvention(Player player)
        {
            if (IsInventionRunning)
            {
                this.IsInventionRunning = false;
            }
            else
            {
                if (!IsRecipeLoaded)
                {
                    player.InfoBoxLoc($"Can't start invention task, no recipe is selected!");
                    return;
                }

                foreach (var skillType in this.SelectedInventionRecipe.InventionSkills.Select(x => x.SkillType))
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

                if (IsInventionBlocked()) { this.ContributedCraftTime = ImmutableCountdown.CreatePaused(inventionTime, inventionTime); }
                else { this.ContributedCraftTime = ImmutableCountdown.CreateRunning(inventionTime, inventionTime); }

                player.InfoBoxLoc($"Success!");
            }
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
            if (IsInventionRunning)
            {
                player.InfoBoxLoc($"Please stop invention before changing the recipe!");
                return;
            }

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
        public ProgressBar InventionBar { get; set; } = new ProgressBar("Invention Progress", barLength:60);

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

        public int inventionFreedom { get; set; }
        [Eco, ClientInterfaceProperty]
        public int InventionFreedom
        {
            get => this.inventionFreedom;
            set
            {
                if (value == this.inventionFreedom) return;
                if (value > 10) return;
                this.inventionFreedom = value;
                this.Changed(nameof(this.InventionFreedom));
            }
        }

        public int inventionBudget { get; set; }
        [Eco, ClientInterfaceProperty]
        public int InventionBudget
        {
            get => this.inventionBudget;
            set
            {
                if (value == this.inventionBudget) return;
                if (value > 10) return;
                this.inventionBudget = value;
                this.Changed(nameof(this.InventionBudget));
            }
        }

        public int inventionComplexity { get; set; }
        [Eco, ClientInterfaceProperty]
        public int InventionComplexity
        {
            get => this.inventionComplexity;
            set
            {
                if (value == this.inventionComplexity) return;
                if (value > 10) return;
                this.inventionComplexity = value;
                this.Changed(nameof(this.InventionComplexity));
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
            if (!IsInventionRunning)
            {
                player.InfoBoxLoc($"You must start invention before contributing labor.");
                return;
            }

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
        public ProgressBar LaborBar { get; set; } = new ProgressBar("Contributed Labor", barLength: 60, fillColor:"blue");
    }
}