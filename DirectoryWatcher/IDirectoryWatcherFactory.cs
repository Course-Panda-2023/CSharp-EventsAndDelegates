using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryWatcher
{
    internal interface IDirectoryWatcherFactory
    {
        IDirectoryWatcher Create(string path);
        IDirectoryWatcher Create(string path, string filter);
    }

    public class DirectoryWatcherFactory : IDirectoryWatcherFactory
    {
        private readonly GetFilesList _filesList;
        private string _filter;

        public DirectoryWatcherFactory(GetFilesList filesList)
        {
            _filesList = filesList;
        }

        public IDirectoryWatcher Create(string path)
        {
            return new DirectoryWatcher(path, _filesList);
        }

        public IDirectoryWatcher Create(string path, string filter)
        {
            return new DirectoryWatcher(path, _filesList, filter);
        }
    }
}
