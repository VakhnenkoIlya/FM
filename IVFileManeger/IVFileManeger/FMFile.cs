using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IVFileManeger
{
    class FMFile : IFMEntity
    {
        public FMFile(string path)
        {
            Path = path;
        }
        public FMFile(string path, string name)
        {
            Path = path;
            Name = name;
        }

        public string Path { get; set; }
        public string Name { get; set ; }
        Form2 textBox = new();

        public bool Create(string path)
        {
            if (!File.Exists(path))
            {
                File.Create(path);
                return true;
            }
            else return false;
        }

        public bool Delete(string path)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
                return true;
            }
            else return false;
        }

        public bool ReName(string path, string name)
        {
            throw new NotImplementedException();
        }
    }
}
