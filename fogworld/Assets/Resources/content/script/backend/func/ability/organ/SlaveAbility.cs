using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    [Serializable]
    public class SlaveAbility:Ability
    {
    
        private Mob _master;
        public double Loyalty { get; set; }
        public double Obedience { get; set; }
        public SlaveAbility(Mob mob,Mob master):base(mob,0)
        {
            _master = master;
        }
        public void ChangeMaster(Mob mob)
        {
            Loyalty = 0;
            Obedience = 0;
        }
        public void Rebel(Sub sub)
        {
            
        }
    }
}
