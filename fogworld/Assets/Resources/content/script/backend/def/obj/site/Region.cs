using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    [Serializable]
    public class Region:OrphanObj
    {
        public Region(string objName,  string imgPath, string brief, int nodeId) : base(objName,  imgPath, brief, nodeId,typeof(Region),typeof(District),new List<int>())
        {

        }

    }
}
