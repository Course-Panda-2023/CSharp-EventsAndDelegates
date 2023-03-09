using assignmentAssaf.DirectoryWatcherFactories;

namespace assignmentAssaf.DirectoryWatcherPackage
{
    internal interface IDirectoryWatcher
    {
        void Start();
        void Stop();

        bool FindType(DirectoryWatchersTypes directoryWatcher);

        void SetDirectoryPath(string directoryPath);
    }
}
