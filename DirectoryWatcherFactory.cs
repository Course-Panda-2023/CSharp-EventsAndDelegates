using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryWatcherNameSpace
{
    internal class DirectoryWatcherFactory : IDirectoryWatcherFactory
    {
        public DirectoryWatcher Create(string path, retFiles r, string filter)
        {
            return new DirectoryWatcher(path, r, filter);
        }
 
            
        public DirectoryWatcher Create(string path, retFiles r)
        {
            return new DirectoryWatcher(path, r);
        }
    }
}
