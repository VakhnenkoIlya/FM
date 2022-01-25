using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IVFileManeger
{
    class CreateCommand : IFMCommand
    {
        public string path;
        public IFMEntity entity;

        public CreateCommand(string path, IFMEntity entity)
        {
            this.path = path;
            this.entity = entity;
        }

        public bool Execute()
        {
            return entity.Create(path);
        }
    }
}
