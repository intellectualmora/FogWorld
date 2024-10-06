using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Backend
{
    [Serializable]

    public class AbilityNode : Node
    {


        public AbilityNode(string nodeName, int nodeId, string imgPath, string brief) : base(nodeName, nodeId, imgPath, brief)
        {

        }

        public AbilityNode()
        {

        }

    }
}
