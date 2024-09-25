using Eco.Core.Controller;
using Eco.Core.PropertyHandling;
using Eco.Gameplay.DynamicValues;
using Eco.Gameplay.Items;
using Eco.Gameplay.Items.Recipes;
using Eco.Gameplay.Systems.NewTooltip;
using Eco.Gameplay.Systems.TextLinks;
using Eco.Mods.TechTree;
using Eco.Shared.Items;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digits.src.EngineeringPlus
{
    [MaxStackSize(1)]
    public class DrawingItem : Item
    {
        [Serialized] public FabricationElement[]    Ingredients         { get; set; }
        [Serialized] public FabricationElement[]    Products            { get; set; }
        [Serialized] public int                     PartNumber          { get; set; }
        [Serialized] public Type                    FabricationTable    { get; set; }

        public DrawingItem() 
        {
            this.Ingredients =  Array.Empty<FabricationElement>();
            this.Products =     Array.Empty<FabricationElement>();
            this.PartNumber = 0;
        }

        [NewTooltip(CacheAs.Instance | CacheAs.User, 11, TTCat.Details, flags: TTFlags.ClearCacheForAllUsers)]
        public LocString Tooltip()
        {
            var res = new LocStringBuilder();

            res.AppendLineLoc($"<b><color=#0092f8>Part Number:<color=white></b> {this.PartNumber:00000}\n");
            res.AppendLineLoc($"<b><color=#0092f8>Fabricated At <color=white></b> {Item.Get(FabricationTable).UILink()}\n");

            var avgEff = this.Ingredients
                .Where(x => !x.IsStatic)
                .Select(x => x.Efficiency > 0 ? x.Efficiency : 0)
                .Average();

            var color = GetQualityColor(avgEff);
            res.AppendLineLoc($"<b><color=#0092f8>Quality:<color=white></b> {color}{avgEff*100:0.0}</color>\n");

            res.AppendLineLoc($"<b><color=#0092f8>Products<color=white></b>");
            for (var i = 0; i < Products.Length; i++)
            {
                if (Products[i].IsStatic)
                {
                    res.AppendLocStr($"   {Products[i].Count} ");
                }
                else
                {
                    color = GetQualityColor(Ingredients[i].Efficiency);
                    res.AppendLocStr($"   {Products[i].Count} {color}-{Products[i].Efficiency * 100:0.0}%</color> ({Products[i].Count * (1 - Products[i].Efficiency):0.00}) ");
                }
                res.AppendLine(Products[i].GetStackable().UILinkGeneric());
            }

            res.AppendLineLoc($"<b><color=#0092f8>Ingredients<color=white></b>");
            for ( var i = 0; i < Ingredients.Length; i++) 
            {
                if (Ingredients[i].IsStatic)
                {
                    res.AppendLocStr($"   {Ingredients[i].Count} (Static) ");
                }
                else
                {
                    if (Ingredients[i].Efficiency == 0)
                    {
                        res.AppendLocStr($"   {Ingredients[i].Count} (No Bonus) ");
                    }
                    else
                    {
                        color = GetQualityColor(Ingredients[i].Efficiency);
                        res.AppendLocStr($"   {Ingredients[i].Count} {color}-{Ingredients[i].Efficiency * 100:0.0}%</color> ({Ingredients[i].Count * (1 - Ingredients[i].Efficiency):0.00}) ");
                    }
                }
                res.AppendLine(Ingredients[i].GetStackable().UILink());
                    
            }

            return res.ToLocString().Trim();
        }

        public void Generate(InventionRecipe inventionRecipe, double mean = 0.1, double stdDev = 0.1)
        {
            this.PartNumber = InventionRecipeManager.GetNextPN();
            this.FabricationTable = inventionRecipe.FabricationTable;

            Random random = new();

            this.Ingredients = (FabricationElement[])inventionRecipe.FabricationIngredients.Clone();
            for (int i = 0; i < this.Ingredients.Length; i++)
            {
                if (Ingredients[i].IsStatic){ Ingredients[i].Efficiency = 0; }
                else                        { Ingredients[i].Efficiency = GenerateEffModifier(random, mean, stdDev); }

            }

            this.Products = (FabricationElement[])inventionRecipe.FabricationProducts.Clone();
            for (int i = 0; i < this.Products.Length; i++)
            {
                if (Products[i].IsStatic) { Products[i].Efficiency = 0; }
                else                      { Products[i].Efficiency = GenerateEffModifier(random, mean, stdDev); }
            }
        }

        private static double GenerateEffModifier(Random random, double mean, double stdDev)
        {
            double u1 = 1.0 - random.NextDouble();
            double u2 = 1.0 - random.NextDouble();
            double randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Sin(2.0 * Math.PI * u2);
            double Eff = mean + stdDev * randStdNormal;
            if      (Eff < 0)   { Eff = 0; } 
            else if (Eff > 0.9) { Eff = 0.9; }
            return Eff;
        }

        public static string GetQualityColor(double value)
        {
            var color = "<color=red>";
            if (value >= 0.4) { color = "<color=#B500BD>"; }
            else if (value >= 0.3) { color = "<color=green>"; }
            else if (value >= 0.2) { color = "<color=yellow>"; }
            else if (value >= 0.1) { color = "<color=#FF9900>"; }
            return color;
        }
    }
}
