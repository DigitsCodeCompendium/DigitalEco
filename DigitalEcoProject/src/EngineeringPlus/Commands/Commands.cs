using Eco.Gameplay.Players;
using Eco.Gameplay.Systems.Messaging.Chat.Commands;
using Eco.Shared.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eco.Gameplay.Components
{
    [ChatCommandHandler]
    public class AdminCommands
    {

        [ChatCommand(ChatAuthorizationLevel.User)]
        public static void Digi(User user) { }

        [ChatSubCommand("Digi", "test command", "g-cl", ChatAuthorizationLevel.User)]
        public static void Test(User user)
        {
            user.Player.OkBoxLocStr(Localizer.DoStr("TEST"));
        }


    }
}