using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    [Serializable]
    public class RoomPoolManager : PoolManager
    {
        public List<RoomNode> Pool { get; set; }

        public RoomPoolManager() : base(Common.RoomPool)
        {
            Pool = new List<RoomNode>();
        }
        public override void LoadPool()
        {
            Pool = XmlSerialization.Deserialize<List<RoomNode>>(PoolFilePath);
            Registry reg = Registry.GetRegistry();
            reg.RegisterNodeList<RoomNode>(Pool.Cast<Node>().ToList());
        }

        public override void SavePool()
        {
            XmlSerialization.SerializeWithSaved(PoolFilePath, Pool);
        }

        public void Add(RoomNode roomNode)
        {
            Pool.Add(roomNode);
        }

        public void Remove(RoomNode roomNode)
        {
            Pool.Remove(roomNode);
        }

    }
}
