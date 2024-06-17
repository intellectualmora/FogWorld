using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    [Serializable]
    public class MobPoolManager : PoolManager
    {
        public List<MobNode> Pool { get; set; }

        public MobPoolManager() : base(Common.MobPool)
        {
            Pool = new List<MobNode>();
        }
        public override void LoadPool()
        {
            Pool = XmlSerialization.Deserialize<List<MobNode>>(PoolFilePath);
            Registry reg = Registry.GetRegistry();
            reg.RegisterNodeList<MobNode>(Pool.Cast<Node>().ToList()); 
        }

        public override void SavePool()
        {
            XmlSerialization.SerializeWithSaved(PoolFilePath, Pool);
        }

        public void Add(MobNode mobNode)
        {
            Pool.Add(mobNode);
        }

        public void Remove(MobNode mobNode)
        {
            Pool.Remove(mobNode);
        }


    }
}
