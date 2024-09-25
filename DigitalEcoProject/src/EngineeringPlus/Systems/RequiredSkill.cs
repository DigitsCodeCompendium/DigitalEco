using Eco.Core.Controller;
using Eco.Gameplay.Items;
using Eco.Gameplay.Players;
using Eco.Gameplay.Skills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eco.Gameplay.Skills
{
    public class RequiredSkill
    {
        public Skill SkillItem => Item.Get(this.SkillType) as Skill;

        [SyncToView] public Type SkillType { get; private set; }
        [SyncToView] public int SkillTypeID => Item.Get(this.SkillType).TypeID;
        [SyncToView] public int Level { get; private set; }

        public RequiredSkill(Type requiredSkillType, int requiredSkillLevel)
        {
            if (requiredSkillType == null)
                throw new ArgumentNullException("Cannot require a null skill");

            this.SkillType = requiredSkillType;
            this.Level = requiredSkillLevel;
        }

        public bool IsMet(Player player) => this.IsMet(player.User);
        public bool IsMet(User user) => user.Skillset[this.SkillType]?.Level >= this.Level;
        public bool IsValid => this.SkillItem.MaxLevel >= this.Level;
    }
}
