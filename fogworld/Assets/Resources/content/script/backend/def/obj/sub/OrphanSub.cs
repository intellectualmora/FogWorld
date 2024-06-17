using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExtendedXmlSerializer.Core.Sources;

namespace Backend
{
    [System.Serializable]
    public abstract class OrphanSub:Sub
    {

        public OrphanSub(string objName, string imgPath, string brief, int nodeId, Type selfType, Type childType, List<int> childObjIdList,double weight,double size) : base(objName, imgPath, brief,nodeId, selfType,childType,null,Common.RootObjId, childObjIdList,weight,size)
        {
     
        }
        public OrphanSub()
        {

        }


    }

}
