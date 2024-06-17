using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    [System.Serializable]
    public abstract class Node
    { 
        public string NodeName { get; set; }
        public int NodeId { get; set; }
        public string ImgPath { get; set; }

        public string Brief { get; set; }
        public Node(string nodeName, int nodeId, string imgPath, string brief)
        {
            NodeName = nodeName;
            NodeId = nodeId;
            ImgPath = imgPath;
            Brief = brief;
        }
        public Node()
        {

        }
    }

}
