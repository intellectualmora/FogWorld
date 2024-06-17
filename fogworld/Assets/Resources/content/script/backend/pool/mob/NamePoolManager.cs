using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    [Serializable]
    public class NamePoolManager : PoolManager
    {
        public List<NameNode> Pool { get; set; }

        public NamePoolManager() : base(Common.NamePool)
        {
            Pool = new List<NameNode>();
        }
        public override void LoadPool()
        {
            Pool = XmlSerialization.Deserialize<List<NameNode>>(PoolFilePath);
            Registry reg = Registry.GetRegistry();
            reg.RegisterNodeList<NameNode>(Pool.Cast<Node>().ToList()); 
        }

        public override void SavePool()
        {
            XmlSerialization.SerializeWithSaved(PoolFilePath, Pool);
        }

        public void Add(NameNode nameNode)
        {
            Pool.Add(nameNode);
        }

        public void Remove(NameNode nameNode)
        {
            Pool.Remove(nameNode);
        }


    }
}
