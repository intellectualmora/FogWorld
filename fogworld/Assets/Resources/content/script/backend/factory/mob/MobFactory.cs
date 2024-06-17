using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.Distributions;
namespace Backend
{
    public class MobFactory:Factory
    {
        public static void Generate(MobNode mobNode)
        {
            int age;
            List<int> organIdList;
            if (mobNode.Lifetime != -1){
                age = new Random().Next(4, mobNode.Lifetime);
            }
            else
            {
                age = -1;
            }
            string objName = MobNameFactory.Generate(mobNode.NodeName);
            int ageStage = AgeStage( age, mobNode.Lifetime);
            double size = LifeDecay(Math.Abs(new Normal(mobNode.Size, Common.Stddev).Sample()),mobNode.LifeDecayRateList, ageStage);
            double weight = Math.Abs(new Normal(mobNode.Weight, Common.Stddev).Sample());
            string imgPath = MobImageFactory.Generate(mobNode.NodeName, ageStage, weight / size);
            int personaId = mobNode.PersonaIdList[new Random().Next(mobNode.PersonaIdList.Count)];
            Mob mob =  new Mob(objName, imgPath, "", mobNode.NodeId, size, weight,age,personaId,new List<(int, string,int)>(),new List<Ability>(), new List <Demand>(),new Queue<(int, string)>(), new List<Talent>(),new List<int>(),0);
            OrganFactory.Generate(mob,mobNode,ageStage);
            RelationFactory.Generate(mob);
            AbilityFactory.Generate(mob);
            DemandFactory.Generate(mob);
            TalentListFactory.Generate(mob);

        }
        public static double LifeDecay(double value, List<double> decayRate,int ageStage)
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
        public static int AgeStage(int age, int lifetime)
        {

            if (age == -1)
            {
                return 3;
            }
            else if (age*1.0/lifetime < Common.BabyAgeRate)
            {
                return 0;
            }else if (age * 1.0 / lifetime < Common.ChildAgeRate)
            {
                return 1;
            }
            else if (age * 1.0 / lifetime > Common.OldAgeRate)
            {
                return 2;
            }
            else
            {
                return 3;
            }
        }
        public static void Construct(string nodeName)
        {
            Registry reg = Registry.GetRegistry();
            List<Node> mobNodeList = (List<Node>) reg.GetNodeList(typeof(MobNode));
            foreach (var mobNode in mobNodeList)
            {
                if (mobNode.NodeName == nodeName)
                {
                    Generate((MobNode)mobNode);
                }
            }
        }


    }
}
