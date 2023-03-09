using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignmentAssaf.Utils.CustomExceptions
{
    internal class DirectoryWatcherTypeNotFound : Exception
    {
        public DirectoryWatcherTypeNotFound(string message) : base(message) 
        {
            
        }
    }
}
