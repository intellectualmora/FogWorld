using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    [Serializable]
    public class MeleeAttackAbility : Ability
    {
        public MeleeAttackAbility(Mob mob):base(mob,Common.SubTimeCost)
        {

        }
    }
}
