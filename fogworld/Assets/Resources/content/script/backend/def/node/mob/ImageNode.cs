using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    [Serializable]

    public class ImageNode: Node
    {

        public List<string> ImagePathList { get; set; } // ageStage,hair_length,hair_color {0 white, 1 black, 2 red, 3 brown, 4 green 5 pink 6 },imagePath

        public ImageNode(string nodeName, int nodeId, string imgPath, string brief, List<string> imagePathList) : base(nodeName, nodeId, imgPath, brief)
        {
            ImagePathList = imagePathList;

        }

        public ImageNode()
        {

        }

    }
}
