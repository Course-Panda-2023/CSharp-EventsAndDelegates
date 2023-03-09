using assignmentAssaf.DirectoryWatcherFactories;
using System.Runtime.InteropServices;
using assignmentAssaf.DirectoryWatcherPackage;

namespace assignmentAssaf.DirectoryWatchersFactory
{
    internal class DirectoryWatchersFactory : IDirectoryWatchersFactory
    {
        private List<IDirectoryWatcher> directoriesWatcherList = new();

        public Dictionary<DirectoryWatchersTypes, IDirectoryWatcher> directoryWatcherFactoryCache = new();

        public DirectoryWatchersFactory()
        {
            directoriesWatcherList.Add(new DirectoryWatcher());
        }

        public IDirectoryWatcher GetDirectoryWatcher(DirectoryWatchersTypes directoryWatcherType)
        {
            if (directoryWatcherFactoryCache.TryGetValue(directoryWatcherType, out var result))
            {
                return result;
            }

            IDirectoryWatcher? directoryWatcherResult;

            FindDirectoryWatcher(directoryWatcherType, out directoryWatcherResult);

            if (directoryWatcherResult is null) throw new DirectoryNotFoundException();

            directoryWatcherFactoryCache.Add(directoryWatcherType, directoryWatcherResult);

            return directoryWatcherResult;
        }

        private void FindDirectoryWatcher(DirectoryWatchersTypes directoryWatcherType, out IDirectoryWatcher? directoryWatcherResult)
        {
            foreach (var directoryWatcher in CollectionsMarshal.AsSpan(directoriesWatcherList))
            {
                if (!directoryWatcher.FindType(directoryWatcherType)) continue;
                
                directoryWatcherResult = directoryWatcher;
                return;
            }

            directoryWatcherResult = null;
        }
    }
}
