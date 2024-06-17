using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    [Serializable]
    public class StreetPoolManager : PoolManager
    {
        public List<StreetNode> Pool { get; set; }

        public StreetPoolManager() : base(Common.StreetPool)
        {
            Pool = new List<StreetNode>();
        }
        public override void LoadPool()
        {
            Pool = XmlSerialization.Deserialize<List<StreetNode>>(PoolFilePath);
            Registry reg = Registry.GetRegistry();
            reg.RegisterNodeList<StreetNode>(Pool.Cast<Node>().ToList());
        }

        public override void SavePool()
        {
            XmlSerialization.SerializeWithSaved(PoolFilePath, Pool);
        }

        public void Add(StreetNode streetNode)
        {
            Pool.Add(streetNode);
        }

        public void Remove(StreetNode streetNode)
        {
            Pool.Remove(streetNode);
        }

    }
}
