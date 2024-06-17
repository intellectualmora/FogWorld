using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend {
    [Serializable]

    public class RoomNode:Node
    {
        public int Capacity { get; set; }
        public int Size { get; set; }
        public double Visibility { get; set; }
        public int IsBaseRoom { get; set; }
        public List<int> FurnitureNodeIdList { get; set; }
        public List<int> ConnectionNodeIdList { get; set; }
        public RoomNode(string nodeName, int nodeId, string imgPath,string brief, int capacity, int size,double visibility ,List<int> furnitureNodeIdList, int isBaseRoom, List<int> connectionNodeIdList) : base(nodeName, nodeId, imgPath, brief)
        {
            Capacity = capacity;
            Size = size;
            FurnitureNodeIdList = furnitureNodeIdList;
            Visibility = visibility;
            IsBaseRoom = isBaseRoom;
            ConnectionNodeIdList = connectionNodeIdList;
        }

        public RoomNode()
        {

        }
    }
}
