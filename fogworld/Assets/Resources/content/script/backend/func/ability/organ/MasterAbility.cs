﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    [Serializable]
    public class MasterAbility:Ability
    {
        public MasterAbility(Mob mob):base(mob,0)
        {
        }

    }
}