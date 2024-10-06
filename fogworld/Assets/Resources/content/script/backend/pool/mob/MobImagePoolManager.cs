using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    [Serializable]
    public class MobImagePoolManager : PoolManager
    {
        public List<MobImageNode> Pool { get; set; }

        public MobImagePoolManager() : base(Common.MobImagePool)
        {
            Pool = new List<MobImageNode>();
        }
        public override void LoadPool()
        {
            Pool = XmlSerialization.Deserialize<List<MobImageNode>>(PoolFilePath);
            Registry reg = Registry.GetRegistry();
            reg.RegisterNodeList<MobImageNode>(Pool.Cast<Node>().ToList()); 
        }

        public override void SavePool()
        {
            XmlSerialization.SerializeWithSaved(PoolFilePath, Pool);
        }

        public void Add(MobImageNode mobImageNode)
        {
            Pool.Add(mobImageNode);
        }

        public void Remove(MobImageNode mobImageNode)
        {
            Pool.Remove(mobImageNode);
        }


    }
}
