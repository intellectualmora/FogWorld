using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    public class RegionFactory:Factory
    {
        public static void Generate(RegionNode regionNode)
        {
            Region region =  new Region(regionNode.NodeName,  regionNode.ImgPath, regionNode.Brief, regionNode.NodeId);
        }

        public static void Construct()
        {
            Registry reg = Registry.GetRegistry();
            List<Node> regionNodeList = (List<Node>) reg.GetNodeList(typeof(RegionNode));
            foreach (var regionNode in regionNodeList)
            {
                Generate((RegionNode) regionNode);
            }
        }


    }
}
