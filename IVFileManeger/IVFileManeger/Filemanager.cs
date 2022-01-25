using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IVFileManeger
{
    class Filemanager
    {
        IFMEntity[] entities;
        public bool Execute(IFMCommand command)
        {
            return command.Execute();
        }
    }
}