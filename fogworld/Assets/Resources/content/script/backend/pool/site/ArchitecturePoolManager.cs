using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    [Serializable]
    public class ArchitecturePoolManager : PoolManager
    {
        public List<ArchitectureNode> Pool { get; set; }

        public ArchitecturePoolManager() : base(Common.ArchitecturePool)
        {
            Pool = new List<ArchitectureNode>();
        }
        public override void LoadPool()
        {
            Pool = XmlSerialization.Deserialize<List<ArchitectureNode>>(PoolFilePath);
            Registry reg = Registry.GetRegistry();
            reg.RegisterNodeList<ArchitectureNode>(Pool.Cast<Node>().ToList()); 
        }

        public override void SavePool()
        {
            XmlSerialization.SerializeWithSaved(PoolFilePath, Pool);
        }

        public void Add(ArchitectureNode architectureNode)
        {
            Pool.Add(architectureNode);
        }

        public void Remove(ArchitectureNode architectureNode)
        {
            Pool.Remove(architectureNode);
        }


    }
}
