using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IVFileManeger
{
    class FMDirectory : IFMEntity
    {
        public FMDirectory(string path)
        {
            Path = path;
        }

        public string Path { get; set; }
        public string Name { get; set; }

        public bool Create(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
                return true;
            }
            else return false;
        }

        public bool Delete(string path)
        {
            if (Directory.Exists(path))
            {
                Directory.Delete(path, true);
                return true;
            }
            else return false;
        }

        public bool ReName(string path, string name)
        {
            Directory.Move(path, name);
            return true;
        }
    }
}
