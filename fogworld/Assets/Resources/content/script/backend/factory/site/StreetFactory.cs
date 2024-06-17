using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace Backend
{
    public class StreetFactory: Factory
    {
        public static void Generate(StreetNode streetNode, int fatherObjId)
        {
            Registry reg = Registry.GetRegistry();
            BlockNode blockNode = (BlockNode) reg.GetNode(typeof(BlockNode), streetNode.BlockNodeId);
            Street street =  new Street(streetNode.NodeName, streetNode.ImgPath, streetNode.Brief,streetNode.NodeId, fatherObjId, blockNode.NodeName, blockNode.Danger, blockNode.Size, streetNode.BlockNodeId); ;
        }
        public static void Construct(District district)
        {
            Registry reg = Registry.GetRegistry();
            DistrictNode districtNode = (DistrictNode) reg.GetNode(typeof(DistrictNode), district.NodeId);
            
            foreach (int nodeId in districtNode.StreetNodeIdList)
            {
                StreetNode streetNode = (StreetNode)reg.GetNode(typeof(StreetNode), nodeId);
                Generate(streetNode, district.ObjId);
            }
        }

        public static void Connection(Street street)
        {
            Registry reg = Registry.GetRegistry();
            StreetNode streetNode = (StreetNode) reg.GetNode(typeof(StreetNode), street.NodeId);
            foreach (Obj connectObj in reg.GetObjList(typeof(Street)))
            {
                Street connectStreet = (Street)connectObj;
                if(streetNode.ConnectionNodeIdList.Contains(connectStreet.NodeId))
                {
                    street.Connection(connectStreet.ObjId);
                }
            }
        }
    }
}
