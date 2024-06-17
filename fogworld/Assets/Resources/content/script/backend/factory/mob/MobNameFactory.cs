using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    public class MobNameFactory:Factory
    {
        public static string Generate(string mobNodeName)
        {
            Registry reg = Registry.GetRegistry();
            List<Node> NameNodeList = reg.GetNodeList(typeof(NameNode));
            foreach (var nameNode in NameNodeList)
            {
                if (nameNode.NodeName == mobNodeName)
                {
                    List<string> nameList = ((NameNode)nameNode).NameList;
                    return nameList[new Random().Next(nameList.Count)];
                }
            }

            return "无名";
        }
    }
}
