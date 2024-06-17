using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend { 
    [Serializable]
    public class ArchitectureNode:Node
    {
        public int Size { get; set; }
        public int Capacity { get; set; }
        public List<(int, int)> CareerNodeIdNumList { get; set; }
        public List<(int, int)> RoomNodeIdNumList { get; set; }

        public int IsBaseArchitecture { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nodeName"></param>
        /// <param name="nodeId"></param>
        /// <param name="imgPath"></param>
        /// <param name="size"></param> 建筑占地大小
        /// <param name="capacity"></param> 最大容纳人数
        /// <param name="careerNodeIdNumList"></param> 工作人员(类型, 数量)表
        /// <param name="roomNodeIdNumList"></param> 房间(类型, 数量)表
        public ArchitectureNode(string nodeName, int nodeId, string imgPath, string brief, int size, int capacity, List<(int, int)> careerNodeIdNumList, List<(int, int)> roomNodeIdNumList, int isBaseArchitecture) : base(nodeName, nodeId, imgPath, brief)
        {
            Size = size;
            Capacity = capacity;
            CareerNodeIdNumList = careerNodeIdNumList;
            RoomNodeIdNumList = roomNodeIdNumList;
            IsBaseArchitecture = isBaseArchitecture;
        }

        public ArchitectureNode()
        {

        }
    }
}
