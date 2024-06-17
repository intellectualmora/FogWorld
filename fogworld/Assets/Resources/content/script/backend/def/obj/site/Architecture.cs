using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    [Serializable]

    public class Architecture : Obj
    {
        public int Capacity { get; set; }
        public int IsBaseArchitecture { get; set; }

        public Architecture(string objName, string imgPath, string brief, int nodeId, int fatherObjId, int capacity, int isBaseArchitecture) : base(objName, imgPath, brief,nodeId, typeof(Architecture), typeof(Room), typeof(Street), fatherObjId, new List<int>())
        {
            Registry reg = Registry.GetRegistry();
            Capacity = capacity;
            IsBaseArchitecture = isBaseArchitecture;
            if (IsBaseArchitecture == 1)
            {
                ImgPath = reg.GetObj(typeof(Street), FatherObjId).ImgPath;
            }
        }

    }
}
