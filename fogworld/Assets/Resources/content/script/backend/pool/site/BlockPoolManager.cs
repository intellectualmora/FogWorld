using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    [Serializable]
    public class BlockPoolManager : PoolManager
    {
        public List<BlockNode> Pool { get; set; }

        public BlockPoolManager() : base(Common.BlockPool)
        {
            Pool = new List<BlockNode>();
        }
        public override void LoadPool()
        {
            Pool = XmlSerialization.Deserialize<List<BlockNode>>(PoolFilePath);
            Registry reg = Registry.GetRegistry();
            reg.RegisterNodeList<BlockNode>(Pool.Cast<Node>().ToList());
        }

        public override void SavePool()
        {
            XmlSerialization.SerializeWithSaved(PoolFilePath, Pool);
        }

        public void Add(BlockNode blockNode)
        {
            Pool.Add(blockNode);
        }

        public void Remove(BlockNode blockNode)
        {
            Pool.Remove(blockNode);
        }

    }
}
