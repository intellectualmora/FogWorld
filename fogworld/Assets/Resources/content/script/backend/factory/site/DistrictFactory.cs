using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    public class DistrictFactory: Factory
    {
        public static void Generate(DistrictNode districtNode, int fatherObjId)
        {

            District district =  new District(districtNode.NodeName, districtNode.ImgPath, districtNode.Brief,districtNode.NodeId, fatherObjId); ;
        }

        public static void Construct(Region region)
        {
            Registry reg = Registry.GetRegistry();
            RegionNode regionNode = (RegionNode) reg.GetNode(typeof(RegionNode), region.NodeId);
            foreach (int nodeId in regionNode.DistrictNodeIdList)
            {
                DistrictNode districtNode = (DistrictNode) reg.GetNode(typeof(DistrictNode), nodeId);
                Generate(districtNode,region.ObjId);
            }
        }


    }
}
