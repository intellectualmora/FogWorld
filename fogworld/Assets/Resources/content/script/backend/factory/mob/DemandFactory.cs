using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.Distributions;
namespace Backend
{
    public class DemandFactory:Factory
    {
        public static void Generate(Mob mob, MobNode mobNode)
        {
            Registry reg = Registry.GetRegistry();
            foreach (int demandNodeId in mobNode.DemandNodeIdList)
            {
                DemandNode demandNode = (DemandNode)reg.GetNode(typeof(DemandNode), demandNodeId);
                Demand demand = new Demand(demandNode.NodeName, demandNode.ImgPath, demandNode.Brief, demandNodeId, mob.ObjId,demandNode.Maximum,demandNode.Decay,demandNode.Threshold);
            }
        }

    }
}
