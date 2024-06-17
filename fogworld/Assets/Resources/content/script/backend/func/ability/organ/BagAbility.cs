using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    [Serializable]
    public class BagAbility:Ability
    {
    
        private double _capacity;
        private double _burden;
        public BagAbility(Mob mob):base(mob,0)
        {
            _capacity = Self.STR * Common.CapcityRate;
            _burden = 0;
        }
        public double Pick(Sub sub)
        {
            _burden += sub.Weight;
            return _capacity - _burden;
        }
        public double Drop(Sub sub)
        {
            _burden -= sub.Weight;
            return _capacity - _burden;
        }
    }
}
