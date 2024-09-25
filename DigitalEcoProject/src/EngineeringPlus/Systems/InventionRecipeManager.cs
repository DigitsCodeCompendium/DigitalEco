using Digits.src.EngineeringPlus.Systems;
using Eco.Core.Utils;
using Eco.Gameplay.Items.Recipes;
using Eco.Gameplay.Skills;
using Eco.Shared.Serialization;
using Eco.Shared.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eco.Gameplay.Items.Recipes
{
    internal class InventionRecipeManager
    {
        public static InventionRecipe[] AllRecipes { get; set; }

        public static InventionRecipe GetRecipeByRecipeType(Type t) => recipeTypeToRecipe[t];
        public static InventionRecipe GetRecipeByRecipeName(string t) => typenameToRecipe.GetOrDefault(t);
        public static IEnumerable<InventionRecipe> GetInventionRecipesBySkill(Type skill) => skillToInventionRecipes.GetOrDefault(skill) ?? Enumerable.Empty<InventionRecipe>();

        private static Dictionary<string, InventionRecipe> typenameToRecipe = new();
        private static Dictionary<Type, InventionRecipe> recipeTypeToRecipe = new();
        private static Dictionary<Type, List<InventionRecipe>> skillToInventionRecipes = new();

        public static void Initialize()
        {
            AllRecipes = typeof(InventionRecipe).InstancesOfCreatableTypesParallel<InventionRecipe>().ToArray();
            recipeTypeToRecipe = AllRecipes.ToDictionary(x => x.GetType(), x => x);
            typenameToRecipe = recipeTypeToRecipe.DistinctBy(x => x.Key.Name).ToDictionary(x => x.Key.Name, x => x.Value);

            skillToInventionRecipes = (from InventionRecipe recipe in AllRecipes
                                     from RequiredSkill skill in recipe.RequiredSkills
                                     group recipe by skill.SkillType)
                                           .ToDictionary(x => x.Key, x => x.ToList());
        }

        public static int GetNextPN()
        {
            return PartNumberManager.Obj.GetNextPartNumber();
        }
    }
}
