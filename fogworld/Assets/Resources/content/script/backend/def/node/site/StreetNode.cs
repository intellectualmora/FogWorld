using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend {
    [Serializable]

    public class StreetNode:Node
    {
        public int BlockNodeId { get; set; }
        public List<int> ConnectionNodeIdList { get; set; }
        public StreetNode(string nodeName, int nodeId, string imgPath, string brief, int blockNodeId, List<int> connectionNodeIdList) : base(nodeName, nodeId, imgPath, brief)
        {
            BlockNodeId = blockNodeId;
            ConnectionNodeIdList = connectionNodeIdList;
        }

        public StreetNode()
        {

        }
    }
}
