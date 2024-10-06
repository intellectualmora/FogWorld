using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    [Serializable]
    public class Demand : Obj
    {
        public double Maximum { get; set; }
        public double Decay { get; set; }
        public double Threshold { get; set; }
        public double Current { get; set; }


        public Demand(string objName, string imgPath, string brief, int nodeId, int fatherObjId, double maximum, double decay, double threshold) : base(objName, imgPath, brief, nodeId, typeof(Demand), null, typeof(Mob), fatherObjId, new List<int>())
        {
            Maximum = maximum;
            Decay = decay;
            Threshold = threshold;
            Current = maximum;
        }

    }
}
