using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Backend
{
    public class RoomFactory: Factory
    {
        public static void Generate(RoomNode roomNode, int fatherObjId)
        {
            Room room =  new Room(roomNode.NodeName, roomNode.ImgPath, roomNode.Brief,roomNode.NodeId, fatherObjId, roomNode.Capacity, roomNode.Size, roomNode.Visibility,roomNode.IsBaseRoom); ;
        }
        public static void Construct(Architecture architecture)
        {
            Registry reg = Registry.GetRegistry();
            ArchitectureNode architectureNode = (ArchitectureNode)reg.GetNode(typeof(ArchitectureNode), architecture.NodeId);
            foreach (var idNum in architectureNode.RoomNodeIdNumList)
            {
                RoomNode roomNode = (RoomNode) reg.GetNode(typeof(RoomNode), idNum.Item1);
                for (int i = 0; i < idNum.Item2; i++)
                {
                    Generate(roomNode,architecture.ObjId);
                }
            }
        }

        public static void Connection(Architecture architecture)
        {
            Registry reg = Registry.GetRegistry();
            foreach (var roomId in architecture.ChildObjIdList)
            {
                Room room = (Room) reg.GetObj(typeof(Room), roomId);
                RoomNode roomNode = (RoomNode)reg.GetNode(typeof(RoomNode), room.NodeId);
                foreach (var connectRoomId in architecture.ChildObjIdList)
                {
                    Room connectRoom = (Room)reg.GetObj(typeof(Room), connectRoomId);
                    if(roomNode.ConnectionNodeIdList.Contains(connectRoom.NodeId))
                    {
                        room.Connection(connectRoom.ObjId);
                    }
                }
            }
        }
    }
}
