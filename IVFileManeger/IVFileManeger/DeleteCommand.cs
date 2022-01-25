using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IVFileManeger
{
    class DeleteCommand : IFMCommand
    {
        public string path;
        public IFMEntity entity;

        public DeleteCommand(string path, IFMEntity entity)
        {
            this.path = path;
            this.entity = entity;
        }

        public bool Execute()
        {
           return entity.Delete(path); 
        }
    }
}
