using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.UIElements;

namespace Backend
{
    public class RelationFactory:Factory
    {
        public static void Generate(Mob mob)
        {
            Registry reg = Registry.GetRegistry();
            List<Node> relationNodeList = reg.GetNodeList(typeof(RelationNode));
            List<Obj> mobList = reg.GetObjList(typeof(Mob));
            foreach (Obj vmob in mobList)
            {
                Mob tempmob = (Mob) vmob; 
                foreach (Node relationNode in relationNodeList)
                {
                    RelationNode tempRelationNode = (RelationNode)relationNode;
                    if (new Random().NextDouble() < tempRelationNode.Prob)
                    {
                        if (tempRelationNode.AgeGap == 0 || tempmob.Age - mob.Age > tempRelationNode.AgeGap)
                        {
                            tempmob.RelationList.Add((mob.ObjId,tempRelationNode.NodeName,tempRelationNode.Affection));
                            foreach (var relationTuple in tempRelationNode.RelationPairNameList)
                            {
                                if (mob.NodeId == relationTuple.Item1)
                                {
                                    mob.RelationList.Add((tempmob.ObjId, relationTuple.Item2,tempRelationNode.Affection));
                                    break;
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
