using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    [Serializable]
    public class SocialAbility:Ability
    {
        public string Status { get; set; }
        public SocialAbility(Mob mob):base(mob,Common.SubTimeCost)
        {

        }

        public void Chat(Mob mob)
        {

        }
        public void Ask(Mob mob,Obj obj)
        {

        }
        public void Trade(Mob mob)
        {

        }
        public void Flirt(Mob mob)
        {

        }
        public void Insult(Mob mob)
        {

        }
        public void Threaten(Mob mob)
        {

        }
        public void Comfort(Mob mob)
        {

        }
        public void Enslave(Mob mob)
        {

        }
        public void ChatCallBack(Mob mob)
        {

        }
        public void AskCallBack(Mob mob, Obj obj)
        {

        }
        public void TradeCallBack(Mob mob)
        {

        }
        public void FlirtCallBack(Mob mob)
        {

        }
        public void InsultCallBack(Mob mob)
        {

        }
        public void ThreatenCallBack(Mob mob)
        {

        }
        public void ComfortCallBack(Mob mob)
        {

        }
        public void EnslaveCallBack(Mob mob)
        {

        }
    }
}
