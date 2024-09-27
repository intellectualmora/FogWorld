using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    [Serializable]
    public class DemandPoolManager : PoolManager
    {
        public List<DemandNode> Pool { get; set; }

        public DemandPoolManager() : base(Common.DemandPool)
        {
            Pool = new List<DemandNode>();
        }
        public override void LoadPool()
        {
            Pool = XmlSerialization.Deserialize<List<DemandNode>>(PoolFilePath);
            Registry reg = Registry.GetRegistry();
            reg.RegisterNodeList<DemandNode>(Pool.Cast<Node>().ToList()); 
        }

        public override void SavePool()
        {
            XmlSerialization.SerializeWithSaved(PoolFilePath, Pool);
        }

        public void Add(DemandNode demandNode)
        {
            Pool.Add(demandNode);
        }

        public void Remove(DemandNode demandNode)
        {
            Pool.Remove(demandNode);
        }


    }
}
