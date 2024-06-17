using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    [Serializable]
    public class FistAttackAbility:Ability
    {
        public FistAttackAbility(Mob mob):base(mob,0)
        {

        }
    }
}
