using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    [Serializable]
    public class MoveAbility : AbilityFunction
    {

        public MoveAbility(Mob mob):base(mob, Common.MainTimeCost)
        {
        }

        public int Move(int roomId,int AP)
        {
            if (AP < TimeConsume)
            {
                return -1;
            }
            else
            {
                Self.CurrentRoomId = roomId;
                return AP - TimeConsume;
            }
        }
    }
}
