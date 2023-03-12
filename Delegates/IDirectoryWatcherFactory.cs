using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    public interface IDirectoryWatcherFactory
    {
        public IDirectoryWatcher Create(string path);
    }

    public class DirectoryWatcherFactory : IDirectoryWatcherFactory
    {
        private filesInPath files;
        public DirectoryWatcherFactory(filesInPath files)
        {
            this.files = files;
        }
        public IDirectoryWatcher Create(string path)
        {
            return new DirectoryWatcher(path, files);
        }
    }
}
