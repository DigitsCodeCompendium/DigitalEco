namespace Eco.Mods.TechTree
{
    using Eco.Core.Items;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Players;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    using Eco.Core.Controller;
    using Eco.Gameplay.Items.Recipes;
    using Digits.AnimalHusbandry;

    //using Eco.Mods.TechTree;

    [Serialized] // Tells the save/load system this object needs to be serialized. 
    [LocDisplayName("Live Turkey")] // Defines the localized name of the item.
    [Weight(300)] // Defines how heavy the BasicSalad is.
    [LocDescription("A live turkey! \"Don't eat me\" says the turkey.")] //The tooltip description for the food item.
    public partial class LiveTurkeyItem : AnimalItem
    {
        /// <summary>The amount of calories awarded for eating the food item.</summary>
        public override float Calories => 10;
        /// <summary>The nutritional value of the food item.</summary>
        public override Nutrients Nutrition => new Nutrients() { Carbs = 0, Fat = 0, Protein = 0, Vitamins = 0 };
        
        public override float Fertility => 1;
        public override float Fittness => 1;
        public override float Frame => 1;


        /// <summary>Defines the default time it takes for this item to spoil. This value can be modified by the inventory this item currently resides in.</summary>
        protected override float BaseShelfLife => (float)TimeUtil.HoursToSeconds(24);
    }

}
