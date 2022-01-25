using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IVFileManeger
{
    class ReNameCommand : IFMCommand
    {
        string path;
        string name;
        IFMEntity entity;

        public ReNameCommand(string path, string name, IFMEntity entity)
        {
            this.path = path;
            this.name = name;
            this.entity = entity;
        }

        public bool Execute()
        {
            return entity.ReName(path, name);
        }
    }
}
