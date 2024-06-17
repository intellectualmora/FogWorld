using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    [Serializable]
    public class OrganPoolManager : PoolManager
    {
        public List<OrganNode> Pool { get; set; }

        public OrganPoolManager() : base(Common.OrganPool)
        {
            Pool = new List<OrganNode>();
        }
        public override void LoadPool()
        {
            Pool = XmlSerialization.Deserialize<List<OrganNode>>(PoolFilePath);
            Registry reg = Registry.GetRegistry();
            reg.RegisterNodeList<OrganNode>(Pool.Cast<Node>().ToList()); 
        }

        public override void SavePool()
        {
            XmlSerialization.SerializeWithSaved(PoolFilePath, Pool);
        }

        public void Add(OrganNode organNode)
        {
            Pool.Add(organNode);
        }

        public void Remove(OrganNode organNode)
        {
            Pool.Remove(organNode);
        }


    }
}
