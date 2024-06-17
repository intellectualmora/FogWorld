using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    public abstract class PoolManager
    {
        public string PoolFileName { get; set; }
        public string PoolPath { get; set; }
        public string PoolFilePath { get; set; }
        public PoolManager(string fileName)
        {
            PoolPath = Common.PoolPath;
            PoolFileName = fileName;
            PoolFilePath = Path.Combine(PoolPath, PoolFileName);
        }

        public abstract void LoadPool();

        public abstract void SavePool();
    }

}
