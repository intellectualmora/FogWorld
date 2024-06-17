using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    [Serializable]

    public class Street : Obj
    {
        public string BlockName { get; set; }
        public double Danger { get; set; }
        public int Size { get; set; }
        public int BlockNodeId { get; set; }
        public List<int> ConnectionStreetIdList { get; set; }

        public Street(string objName, string imgPath, string brief, int nodeId, int fatherObjId, string blockName, double danger, int size, int blockNodeId) : base(objName, imgPath, brief, nodeId, typeof(Street), typeof(Architecture), typeof(District), fatherObjId, new List<int>())
        {
            BlockName = blockName;
            Danger = danger;
            Size = size;
            BlockNodeId = blockNodeId;
            ConnectionStreetIdList = new List<int>();
        }

        public void Connection(int streetId)
        {
            ConnectionStreetIdList.Add(streetId);
        }

    }
}
