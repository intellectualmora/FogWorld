using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    [Serializable]

    public class RelationNode: Node
    {
        public string MobNodeName { get; set; }
        public int AgeGap { get; set; }
        public double Prob { get; set; }
        public List<(int, string)> RelationPairNameList { get; set; }

        public int Affection { get; set; }

        public RelationNode(string nodeName, int nodeId, string imgPath, string brief, string mobNodeName, int ageGap, int affection,List<(int, string)> relationPairNameList,double prob) : base(nodeName, nodeId, imgPath, brief)
        {
            MobNodeName = mobNodeName;
            AgeGap = ageGap;
            RelationPairNameList = relationPairNameList;
            Prob = prob;
            Affection = affection;
        }

        public RelationNode()
        {

        }

    }
}
