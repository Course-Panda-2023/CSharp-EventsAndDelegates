using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryWatcher
{
    interface IDirectoryWatcherFactory
    {
        public DirectoryWatcher Create(string path);
    }
    class DirectoryWatcherFactory : IDirectoryWatcherFactory
    {
        allFiles files;
        public DirectoryWatcherFactory(allFiles files)
        {
            this.files = files;
        }
        public DirectoryWatcher Create(string path)
        {
            return new DirectoryWatcher(path, this.files);
        }
    }
}
