using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IVFileManeger
{
    interface IFMEntity
    {
        public string Path { get; set;}
        public string Name { get; set;}

        public bool Delete(string path);

        public bool Create(string path);
        public bool ReName(string path, string name);

    }
}
