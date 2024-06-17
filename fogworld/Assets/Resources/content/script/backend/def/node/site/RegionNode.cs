using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    [Serializable]
    public class RegionNode:Node
    {
        public List<int> DistrictNodeIdList { get; set; }

        public RegionNode(string nodeName, int nodeId, string imgPath, string brief, List<int> districtNodeIdList) : base(nodeName, nodeId, imgPath, brief)
        {
            DistrictNodeIdList = districtNodeIdList;
        }

        public RegionNode()
        {

        }
    }
}
