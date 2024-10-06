using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    [Serializable]
    public class AbilityPoolManager : PoolManager
    {
        public List<AbilityNode> Pool { get; set; }

        public AbilityPoolManager() : base(Common.AbilityPool)
        {
            Pool = new List<AbilityNode>();
        }
        public override void LoadPool()
        {
            Pool = XmlSerialization.Deserialize<List<AbilityNode>>(PoolFilePath);
            Registry reg = Registry.GetRegistry();
            reg.RegisterNodeList<AbilityNode>(Pool.Cast<Node>().ToList()); 
        }

        public override void SavePool()
        {
            XmlSerialization.SerializeWithSaved(PoolFilePath, Pool);
        }

        public void Add(AbilityNode abilityNode)
        {
            Pool.Add(abilityNode);
        }

        public void Remove(AbilityNode abilityNode)
        {
            Pool.Remove(abilityNode);
        }


    }
}
