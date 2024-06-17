using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;

namespace Backend
{
    [Serializable]

    public class Room : Obj
    {
        public int Capacity { get; set; }
        public int Size { get; set; }
        public double Visibility { get; set; }
        public List<int> ConnectionRoomIdList { get; set; }
        public int IsBaseRoom { get; set; }

        public Room(string objName, string imgPath, string brief, int nodeId, int fatherObjId, int capacity, int size, double visibility,int isBaseRoom) : base(objName,  imgPath, brief,nodeId, typeof(Room), null, typeof(Architecture), fatherObjId, new List<int>())
        {
            Registry reg = Registry.GetRegistry();
            Capacity = capacity;
            Size = size;
            Visibility = visibility;
            ConnectionRoomIdList = new List<int>();
            IsBaseRoom = isBaseRoom;
            if (IsBaseRoom == 1)
            {
                ImgPath = reg.GetObj(typeof(Architecture), FatherObjId).ImgPath;
            }
        }
        public void Connection(int roomId)
        {
            ConnectionRoomIdList.Add(roomId);
        }
    }
}
