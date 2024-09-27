using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.Distributions;
using UnityEngine;
namespace Backend
{
    public class OrganFactory : Factory
    {
        public static void Generate(Mob mob,MobNode mobNode,int ageStage)
        {
            Registry reg = Registry.GetRegistry();
            foreach (int organNodeId in mobNode.OrganNodeIdList)
            {
                OrganNode organNode = (OrganNode) reg.GetNode(typeof(OrganNode), organNodeId);
                double weight = LifeDecay(organNode.Weight, mobNode.LifeDecayRateList, ageStage);
                double durable = LifeDecay(organNode.Durable, mobNode.LifeDecayRateList, ageStage);
                List<double> attributeList = LifeDecayAttributeList(organNode.AttributeList, mobNode.LifeDecayRateList, ageStage);
                Organ organ = new Organ(organNode.NodeName, organNode.ImgPath, organNode.Brief, organNodeId, mob.ObjId, weight, durable,attributeList);
            }

            foreach (int organObjId in mob.ChildObjIdList)
            {
               Organ organ=  (Organ) reg.GetObj(typeof(Organ),organObjId);
               mob.STR += organ.AttributeList[Common.STRIndex];
               mob.APL += organ.AttributeList[Common.APLIndex];
               mob.CSN += organ.AttributeList[Common.CSNIndex];
               mob.DEX += organ.AttributeList[Common.DEXIndex];
               mob.DIG += organ.AttributeList[Common.DIGIndex];
               mob.RES += organ.AttributeList[Common.RESIndex];
               mob.FTY += organ.AttributeList[Common.FTYIndex];
               mob.IMI += organ.AttributeList[Common.IMIIndex];
               mob.WIS += organ.AttributeList[Common.WISIndex];
               mob.PCT += organ.AttributeList[Common.PCTIndex];
            }
        }
        public static double LifeDecay(double value, List<double> decayRate, int ageStage)
        {
            if (ageStage == 3)
            {
                return value;
            }
            else
            {
                return value * decayRate[ageStage];
            }
        }
        public static List<double> LifeDecayAttributeList(List<double> attributeList, List<double> decayRate, int ageStage)
        {
            List<double> newAttributeList = new List<double>();
            if (ageStage == 3)
            {
                foreach (var attribute in attributeList)
                {
                    newAttributeList.Add(Math.Abs(new Normal(attribute, Common.Stddev).Sample()));
                }
            }
            else
            {
                if (ageStage == 0)
                {
                    foreach (var attribute in attributeList)
                    {
                        newAttributeList.Add(Math.Abs(new Normal(attribute, Common.Stddev).Sample())*decayRate[ageStage]);
                    }
                    newAttributeList[Common.FTYIndex] = 0;

                }
                else
                {
                    foreach (var attribute in attributeList)
                    {
                        newAttributeList.Add(Math.Abs(new Normal(attribute, Common.Stddev).Sample()) * decayRate[ageStage]);
                    }
                }

            }
            return newAttributeList;
        }
    }
}
