﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    [Serializable]
    public class RemoteAttackAbility : Ability
    {
        public RemoteAttackAbility(Mob mob):base(mob,Common.SubTimeCost)
        {

        }
    }
}