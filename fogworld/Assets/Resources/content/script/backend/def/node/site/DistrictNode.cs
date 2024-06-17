using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    [Serializable]

    public class DistrictNode:Node
    {
        public List<int> StreetNodeIdList { get; set; }
        public DistrictNode(string nodeName, int nodeId, string imgPath, string brief, List<int> streetNodeIdList) : base(nodeName, nodeId, imgPath, brief)
        {
            StreetNodeIdList = streetNodeIdList;
        }

        public DistrictNode()
        {

        }

    }
}
