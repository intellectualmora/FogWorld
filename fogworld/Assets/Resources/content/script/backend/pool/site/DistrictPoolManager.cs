using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    [Serializable]
    public class DistrictPoolManager : PoolManager
    {
        public List<DistrictNode> Pool { get; set; }

        public DistrictPoolManager() : base(Common.DistrictPool)
        {
            Pool = new List<DistrictNode>();
        }
        public override void LoadPool()
        {
            Pool = XmlSerialization.Deserialize<List<DistrictNode>>(PoolFilePath);
            Registry reg = Registry.GetRegistry();
            reg.RegisterNodeList<DistrictNode>(Pool.Cast<Node>().ToList());
        }

        public override void SavePool()
        {
            XmlSerialization.SerializeWithSaved(PoolFilePath, Pool);
        }

        public void Add(DistrictNode districtNode)
        {
            Pool.Add(districtNode);
        }

        public void Remove(DistrictNode districtNode)
        {
            Pool.Remove(districtNode);
        }

    }
}
