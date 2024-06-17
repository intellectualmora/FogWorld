using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    [Serializable]
    public class RegionPoolManager : PoolManager
    {
        public List<RegionNode> Pool { get; set; }

        public RegionPoolManager() : base(Common.RegionPool)
        {
            Pool = new List<RegionNode>();
        }
        public override void LoadPool()
        {
            Pool = XmlSerialization.Deserialize<List<RegionNode>>(PoolFilePath);
            Registry reg = Registry.GetRegistry();
            reg.RegisterNodeList<RegionNode>(Pool.Cast<Node>().ToList());
        }

        public override void SavePool()
        {
            XmlSerialization.SerializeWithSaved(PoolFilePath, Pool);
        }

        public void Add(RegionNode regionNode)
        {
            Pool.Add(regionNode);
        }

        public void Remove(RegionNode regionNode)
        {
            Pool.Remove(regionNode);
        }

    }
}
