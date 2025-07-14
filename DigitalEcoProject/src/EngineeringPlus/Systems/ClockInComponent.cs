using Eco.Core.Controller;
using Eco.Core.Items;
using Eco.Core.Utils;
using Eco.Gameplay.Components;
using Eco.Gameplay.Objects;
using Eco.Shared.Localization;
using Eco.Shared.Networking;
using Eco.Shared.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eco.Gameplay.Players;
using Eco.Gameplay.Components.Auth;
using Eco.Gameplay.Systems.TextLinks;

namespace Eco.Gameplay.Components
{
    [Eco, AutogenClass, LocDisplayName("Clock-In")]
    [Serialized, LocDescription("This component allows a user to claim a workstation as their own and record the amount of time and labor supplied to the object.")]
    [Priority(-150)]
    [RequireComponent(typeof(CreditComponent))]
    [RequireComponent(typeof(PropertyAuthComponent))]
    [NoIcon]
    public class ClockInComponent : WorldObjectComponent
    {
        [Serialized] public User? ClaimedUser {  get; set; }
        public bool IsSomeoneClockedIn => ClaimedUser is not null;
        public ClockInComponent() 
        {
        }

        [Eco, PropReadOnly, UITypeName("GeneralHeader")]
        public string ClockedInWorker { get; set; } = string.Empty;

        //Button Autogen
        [RPC, Autogen]
        public void ClockInOut(Player player)
        {
            if (IsSomeoneClockedIn) 
            {
                if (this.ClaimedUser == player.User)
                {
                    player.InfoBoxLoc($"You've clocked out!");
                    this.ClaimedUser = null;
                    this.ClockedInWorker = "Worker: Nobody";
                }
                else if(this.Parent.GetComponent<PropertyAuthComponent>().UsersWithFullAccess.Contains(player.User))
                {
                    player.InfoBoxLoc($"You clocked out {this.ClaimedUser.UILink()}");
                    this.ClaimedUser = null;
                    this.ClockedInWorker = "Worker: Nobody";
                }
                else
                {
                    player.InfoBoxLoc($"You can't clock another person out!");
                }
            }
            else 
            {
                player.InfoBoxLoc($"You've clocked in!");
                this.ClaimedUser = player.User;
                this.ClockedInWorker = $"Worker: {this.ClaimedUser.UILink()}";
            } 
        }
    }
}
