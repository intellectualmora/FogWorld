using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    [Serializable]
    public class SkillAbility:Ability
    {
        public int PotentialPoint { get; set; }
        public double MeleeAttackLevel { get; set; }
        public double RemoteAttackLevel { get; set; }
        public double MedicalLevel { get; set; }
        public double ScoutLevel { get; set; }
        public double TradeLevel { get; set; }
        public double ChatLevel { get; set; }
        public double ThreatLevel { get; set; }
        public double HandLevel { get; set; }
        public double FootLevel { get; set; }
        public double SexLevel { get; set; }
        public double ServeLevel { get; set; }


        public SkillAbility(Mob mob):base(mob, Common.SubTimeCost)
        {

        }
        public void Learn()
        {

        }
    }
}
