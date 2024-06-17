using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    [Serializable]

    public class Organ:Sub
    {
        public double MaxDurable { get; set; }
        public double CurrentDurable { get; set; }
        public List<double> AttributeList { get; set; }


        public Organ(string objName, string imgPath, string brief, int nodeId,int fatherObjId,double weight,double durable, List<double> attributeList) : base(objName, imgPath, brief, nodeId, typeof(Organ), null, typeof(Mob), fatherObjId, new List<int>(),weight,0)
        {
            AttributeList = attributeList;
            MaxDurable = durable;
            CurrentDurable = MaxDurable;
        }


    }
}
