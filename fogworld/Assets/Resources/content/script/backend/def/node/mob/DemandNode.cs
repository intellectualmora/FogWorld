using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Backend
{
    [Serializable]

    public class DemandNode : Node
    {
        /*
         * 需求：
         * double 需求上限条
         * double 基础衰减值
         * 
         */
        public double Maximum { get; set; }
        public double Decay { get; set; }
        public double Threshold { get; set; }

        public DemandNode(string nodeName, int nodeId, string imgPath, string brief, double maximum, double decay, double threshold) : base(nodeName, nodeId, imgPath, brief)
        {
            Maximum = maximum;
            Decay = decay;
            Threshold = threshold;

        }

        public DemandNode()
        {

        }

    }
}
