using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    [Serializable]
    public class AbilityFunction
    {
        public int TimeConsume { get; set; }
        public Mob Self { get; set; }
        public AbilityFunction(Mob mob, int timeConsume)
        {
            Self = mob;
            TimeConsume = timeConsume;
        }

    }
}
