using Eco.Core.Plugins.Interfaces;
using Eco.Gameplay.Items;
using Eco.Gameplay.Items.Recipes;
using Eco.Mods.TechTree;
using Eco.Shared.Serialization;
using Eco.Shared.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digits.src.EngineeringPlus
{
    public class ModInit: IModInit
    {
        public static void PostInitialize()
        {
            InventionRecipeManager.Initialize();

        }

        public static ModRegistration Register() => new()
        {
            ModName = "EngineeringPP",
            ModDescription = "Mod description",
            ModDisplayName = "Engineering++",
        };

    }
}
