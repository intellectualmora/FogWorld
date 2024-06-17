using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    [Serializable]

    public class District : Obj
    {
        public District(string objName, string imgPath, string brief,int nodeId, int fatherObjId) : base(objName, imgPath, brief, nodeId,typeof(District), typeof(Street), typeof(Region), fatherObjId, new List<int>())
        {

        }

    }
}
