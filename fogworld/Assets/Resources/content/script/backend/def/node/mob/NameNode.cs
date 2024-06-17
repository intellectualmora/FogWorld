using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    [Serializable]

    public class NameNode: Node
    {
        public List<string> NameList { get; set; }
    

        public NameNode(string nodeName, int nodeId, string imgPath, string brief, List<string> nameList) : base(nodeName, nodeId, imgPath, brief)
        {
            NameList = nameList;

        }

        public NameNode()
        {

        }

    }
}
