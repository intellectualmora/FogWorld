using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExtendedXmlSerializer.Core.Sources;

namespace Backend
{
    [System.Serializable]
    public abstract class Sub:Obj
    {
        public double Weight { get; set; }
        public double Size { get; set; }
        public Sub(string objName, string imgPath, string brief, int nodeId, Type selfType, Type childType,Type fatherType,int fatherObjId, List<int> childObjIdList,double weight,double size) : base(objName, imgPath, brief,nodeId, selfType,childType,fatherType,fatherObjId, childObjIdList)
        {
            Weight = weight;
            Size = size;
        }
        public Sub()
        {

        }


    }

}
