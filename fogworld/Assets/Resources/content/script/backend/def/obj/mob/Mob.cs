using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    [Serializable]

    public class Mob:OrphanSub
    {
        private Agent _agent;
        public int Age { get; set; }
        public int PersonaId { get; set; }
        public List<(int, string,int)> RelationList { get; set; }
        public Queue<(int, string)> MemoryQueue { get; set; }
        public List<Ability> AbilityList { get; set; }
        public List<Demand> DemandList { get; set; }
        public List<Buff> BuffList { get; set; }
        public List<Talent> TalentList { get; set; }
        public List<Organ> OrganList { get; set; }
        public int CurrentRoomId { get; set; }
        public double STR { get; set; } //力量
        public double DEX { get; set; } //反应
        public double WIS { get; set; } //智力
        public double PCT { get; set; } //感知
        public double APL { get; set; } //魅力
        public double CSN { get; set; } // 意识
        public double FTY { get; set; } // 繁殖
        public double DIG { get; set; } // 消化
        public double RES { get; set; } // 恢复
        public double IMI { get; set; } // 免疫
        public string Apparel { get; set; } // 免疫


        public Mob(string objName, string imgPath, string brief, int nodeId, double size, double weight, int age, int personaId,  List<(int, string,int)> relationList, List<Ability> abilityList, List<Demand> demandList, Queue<(int, string)> memoryQueue, List<Talent> talentList, List<Organ> organList, int currentRoomId) : base(objName, imgPath, brief, nodeId, typeof(Mob), typeof(Organ), new List<int>(),weight,size)
        {
            Weight = weight;
            Size = size;
            Age = age;
            PersonaId = personaId;
            RelationList = relationList;
            MemoryQueue = memoryQueue;
            AbilityList = abilityList;
            DemandList = demandList;
            BuffList = new List<Buff>();
            TalentList = talentList;
            OrganList = organList;
            CurrentRoomId = currentRoomId;
            STR = 0;
            DEX = 0;
            WIS = 0;
            PCT = 0;
            APL = 0;
            CSN = 0;
            FTY = 0;
            DIG = 0;
            RES = 0;
            IMI = 0;
        }


    }
}
