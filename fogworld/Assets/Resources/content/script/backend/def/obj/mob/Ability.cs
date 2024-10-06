using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    [Serializable]
    public class Ability : Obj
    {


        public Ability(string objName, string imgPath, string brief, int nodeId, int fatherObjId) : base(objName, imgPath, brief, nodeId, typeof(Ability), null, typeof(Mob), fatherObjId, new List<int>())
        {

        }

    }
}
