using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    [Serializable]

    public class MobImageNode : Node
    {
        public int MobNodeId { get; set; }
        public int AgeStage { get; set; }
        public string Apparel { get; set; }
        public MobImageNode(string nodeName, int nodeId, string imgPath, string brief, int mobNodeId, int ageStage, string apparel) : base(nodeName, nodeId, imgPath, brief)
        {
            MobNodeId = mobNodeId;
            AgeStage = ageStage;
            Apparel = apparel;

        }

        public MobImageNode()
        {

        }

    }
}
