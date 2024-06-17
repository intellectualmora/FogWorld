using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
namespace Backend
{
    public class ArchitectureFactory : Factory
    {
        public static void Generate(ArchitectureNode architectureNode, int fatherObjId)
        {
            Architecture architecture =  new Architecture(architectureNode.NodeName, architectureNode.ImgPath, architectureNode.Brief, architectureNode.NodeId, fatherObjId, architectureNode.Capacity,architectureNode.IsBaseArchitecture);
        }
        public static void Construct(Street street)
        {
            Registry reg = Registry.GetRegistry();
            StreetNode streetNode = (StreetNode)reg.GetNode(typeof(StreetNode), street.NodeId);
            BlockNode blockNode = (BlockNode)reg.GetNode(typeof(BlockNode), street.BlockNodeId);
            System.Random rd = new System.Random();
            int cur_size = 0;
            Generate((ArchitectureNode) reg.GetNode(typeof(ArchitectureNode), 0), street.ObjId); // base建筑
            while (true)
            {
                if (!(blockNode.ArchitectureNodeIdList.Count > 1))
                {
                    break;
                }
                int index = rd.Next(blockNode.ArchitectureNodeIdList.Count);
                int architectureNodeId = blockNode.ArchitectureNodeIdList[index];
                if (architectureNodeId == 0)
                {
                    continue;
                }
                ArchitectureNode architectureNode = (ArchitectureNode) reg.GetNode(typeof(ArchitectureNode), architectureNodeId);
                if (cur_size + architectureNode.Size > blockNode.Size) break;
                Generate(architectureNode,street.ObjId);
                cur_size += architectureNode.Size;
            }


        }
    }
}
