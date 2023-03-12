using assignmentAssaf.DirectoryWatcherPackage;

namespace assignmentAssaf.DirectoryWatcherFactories
{
    internal interface IDirectoryWatchersFactory
    {
        IDirectoryWatcher GetDirectoryWatcher(DirectoryWatchersTypes directoryWatcherType);
    }
}
