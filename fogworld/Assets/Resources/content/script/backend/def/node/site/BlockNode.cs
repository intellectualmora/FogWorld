using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    [System.Serializable]
    public class BlockNode : Node
    {

        public double Danger { get; set; }
        public int Size { get; set; }
        public List<int> ArchitectureNodeIdList { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nodeName"></param> 
        /// <param name="nodeId"></param>
        /// <param name="imgPath"></param>
        /// <param name="danger"></param> 危险系数
        /// <param name="size"></param> 建筑容纳量
        /// <param name="architectureNodeIdList"></param> 支持的建筑类型
        public BlockNode(string nodeName, int nodeId, string imgPath,string brief, double danger, int size, List<int> architectureNodeIdList) : base(nodeName, nodeId, imgPath, brief)
        {
            Danger = danger;
            Size = size;
            ArchitectureNodeIdList = architectureNodeIdList;
        }

        public BlockNode()
        {

        }


    }
}
