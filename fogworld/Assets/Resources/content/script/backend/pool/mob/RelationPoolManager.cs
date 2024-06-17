using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    [Serializable]
    public class RelationPoolManager : PoolManager
    {
        public List<RelationNode> Pool { get; set; }

        public RelationPoolManager() : base(Common.RelationPool)
        {
            Pool = new List<RelationNode>();
        }
        public override void LoadPool()
        {
            Pool = XmlSerialization.Deserialize<List<RelationNode>>(PoolFilePath);
            Registry reg = Registry.GetRegistry();
            reg.RegisterNodeList<RelationNode>(Pool.Cast<Node>().ToList()); 
        }

        public override void SavePool()
        {
            XmlSerialization.SerializeWithSaved(PoolFilePath, Pool);
        }

        public void Add(RelationNode relationNode)
        {
            Pool.Add(relationNode);
        }

        public void Remove(RelationNode relationNode)
        {
            Pool.Remove(relationNode);
        }


    }
}
