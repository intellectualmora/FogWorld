using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.Distributions;
namespace Backend
{
    public class AbilityFactory:Factory
    {
        public static void Generate(Mob mob)
        {
            Registry reg = Registry.GetRegistry();
            foreach (Organ organ in mob.OrganList)
            {
                OrganNode organNode = (OrganNode) reg.GetNode(typeof(OrganNode), organ.NodeId);
                foreach (int abilityNodeId in organNode.AbilityNodeIdList)
                {
                    AbilityNode abilityNode = (AbilityNode)reg.GetNode(typeof(AbilityNode), abilityNodeId);
                    bool flag = true;
                    foreach (var ab in mob.AbilityList)
                    {
                        if (ab.NodeId == abilityNode.NodeId)
                        {
                            flag = false;
                        }
                    }

                    if (flag)
                    {
                        Ability ability = new Ability(abilityNode.NodeName, abilityNode.ImgPath, abilityNode.Brief,
                            abilityNodeId, mob.ObjId);
                        mob.AbilityList.Add(ability);
                    }
                }
            }
        }
    }
}
