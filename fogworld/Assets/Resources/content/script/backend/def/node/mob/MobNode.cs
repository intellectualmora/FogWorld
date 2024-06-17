using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    [Serializable]

    public class MobNode: Node
    {
        // 魅力, 防御,智力， 感知，反应，力量，免疫，消化，意识，繁殖力，恢复力。其他属性都是加法原则，意识繁殖力是取最小值，防御按部位单独结算。
        /* 平均人类： 魅力（男）20，（女）22；防御（按部位结算）；智力 20，感知 20，反应 20，力量 （男）20 （女）16，免疫 20，消化 20，意识 20，恢复力 20，繁殖力 20
         * 类人器官基本类型如下：
         * 1. 外部器官：眼睛（魅力+1，感知+8）*2，鼻子（魅力+2），舌（魅力+2），耳（魅力+1，感知+2）*2,头（魅力+4，防御+2），脊椎（防御+5，反应+10），胸（魅力+2，防御+4），腹（魅力+1，防御+3），臂（魅力+1，防御+4，力量+5/4，反应+2）*2，腿（魅力+1，防御+4，力量+5/4，反应+3）*2, （乳房（魅力+2），阴茎（魅力+1，繁殖力+20），睾丸（繁殖力+20），阴道（繁殖力+20））
         * 2. 内部器官：血液【任意位置】（意识 20，恢复力 10），脑【头】（智力+20，意识 20），心脏【胸】（意识 20，恢复力 6），肾【腹】（免疫+5）*2，肺【胸】（意识 20，恢复力 2），胃【腹】（消化+6），小肠【腹】(消化+10)，大肠【腹】(消化+4)，肝【腹】（免疫+10），（子宫【腹】（繁殖力+20））
         * 死亡判定：意识=0
         * 失能判定：0<意识<4（昏厥） ， 意识或智力或力量或反应<4 （无法行动）， 意识或力量或反应<6 (无法移动)，意识或智力<6 无法社交
         * 美丑判定：0不可接触者，1-5 奇丑无比，5-10 丑陋，10-15 略丑，15-20 寻常，20-25 端庄，25-30可爱，30-35 靓丽 35-39 倾国倾城，40 美若天仙
         * 繁殖能力：11>岁 繁殖能力=0，11-13岁 繁殖能力=10，14<岁 繁殖力=20。
         * 耐久值惩罚：属性加值 = 属性加值*(耐久/耐久值上限)
         * 年龄耐久上限惩罚：0-3岁 倍率0.5， 3-13岁 倍率0.5+0.05*年龄， 70岁-100岁 倍率1-0.02*年龄
         * 年龄属性加值惩罚（除魅力意识和繁殖力）：0-3岁 全属性=4，防御=0， 3-13岁 倍率0.5+0.05*年龄， 70岁-100岁 1-0.02*年龄
         * 基本能力：移动（潜行，奔跑），社交，进食, 治疗，搬运携带（装备），工作能力，攻击能力，专业技能，天赋能力。
         * 器官Node：均值重量，均值耐久上限，均值体积，内部器官对应外部器官NodeId(如果等于-1代表是外部器官),均值属性加值。
         * 器官报废：耐久=0时器官消失,当外部器官消失时对应内部器官也全部消失。
         * 物理伤害类型：（钝击，穿刺，劈砍）
         * 钝击：除头盔外无视装备防御加成，但是无法攻击到内部器官，无法流血，单次攻击承伤部位1至2
         * 穿刺：内衣防刺，造成流血+1,单次攻击承伤部位1
         * 劈砍：外衣防砍，造成流血层数+2，承伤部位1至2
         * 当判定攻击命中时，按照外部器官部位体积/全外部器官体积概率计算出受击部位，如果攻击伤害>防御且伤害类型为穿刺或劈砍，继续判定对应内部器官体积/外部器官体积判定内部器官是否受伤。
         * 外部器官id = -1代表该器官为外部器官
         * Node数据全为均值，实例产生参考均值，标准差为1的正浮点数
         */
        public List<int> OrganNodeIdList { get; set; }
        public List<int> PersonaIdList { get; set; }
        public double Size { get; set; }
        public double Weight { get; set; }
        public int Lifetime { get; set; }
        public List<int> DemandIdList { get; set; }
        public List<double> LifeDecayRateList { get; set; }

        public MobNode(string nodeName, int nodeId, string imgPath, string brief, List<int> organNodeIdList, List<int> personaIdList, double size, double weight, int lifetime, List<int> demandIdList, List<double> lifeDecayRateList) : base(nodeName, nodeId, imgPath, brief)
        {
            OrganNodeIdList = organNodeIdList;
            Size = size;
            Weight = weight;
            PersonaIdList = personaIdList;
            Lifetime = lifetime;
            DemandIdList = demandIdList;
            LifeDecayRateList = lifeDecayRateList;

        }

        public MobNode()
        {

        }

    }
}
