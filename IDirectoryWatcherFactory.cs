using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryWatcherNameSpace
{
    internal interface IDirectoryWatcherFactory
    {
        public DirectoryWatcher Create(string path, retFiles r);
        public DirectoryWatcher Create(string path, retFiles r, string filter);
    }
}
