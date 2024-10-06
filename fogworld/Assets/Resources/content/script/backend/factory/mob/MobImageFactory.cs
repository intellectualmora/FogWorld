using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Random = System.Random;

namespace Backend
{
    public class MobImageFactory:Factory
    {
        public static void Generate(Mob mob,int ageStage, double BMI)
        {
            Registry reg = Registry.GetRegistry();
            List<Node> mobImageNodes = reg.GetNodeList(typeof(MobImageNode));
            foreach (var node in mobImageNodes)
            {
                MobImageNode imageNode = (MobImageNode) node;
                if (ageStage == imageNode.AgeStage && mob.NodeId == imageNode.MobNodeId)
                {
                    mob.Apparel = imageNode.Apparel;
                    DirectoryInfo currentDirectoryInfo = new DirectoryInfo(Path.Combine(Common.ResourcePath,imageNode.ImgPath));
                    FileInfo[] currentFileInfos = currentDirectoryInfo.GetFiles();
                    string path = Path.Combine(imageNode.ImgPath, currentFileInfos[new Random().Next(currentFileInfos.Length)].Name);
                    bool isContains = path.IndexOf(".meta", StringComparison.OrdinalIgnoreCase) >= 0;
                    if (isContains)
                    {
                        path = path.Substring(0, path.Length - 5);
                    }
                    currentDirectoryInfo = new DirectoryInfo(Path.Combine(Common.ResourcePath, path));
                    currentFileInfos = currentDirectoryInfo.GetFiles();
                    foreach (var f in currentFileInfos)
                    {
                        string[] words = f.Name.Split('_');
                        if (words.Length == 4)
                        {
                            mob.ImgPath = Path.Combine(path, f.Name);
                            isContains = mob.ImgPath.IndexOf(".meta", StringComparison.OrdinalIgnoreCase) >= 0;
                            if (isContains)
                            {
                                mob.ImgPath = mob.ImgPath.Substring(0, mob.ImgPath.Length - 9);
                            }
                            else
                            {
                                mob.ImgPath = mob.ImgPath.Substring(0, mob.ImgPath.Length - 4);
                            }
                            break;
                        }
                    }
                    break;
                }
                
            }
        }
    }
}
