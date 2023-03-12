using assignmentAssaf.DirectoryWatcherFactories;

namespace assignmentAssaf.DirectoryWatcherPackage
{
    internal abstract class ParentDirectoryWatcher : IDirectoryWatcher
    {
        protected DirectoryWatchersTypes DirectoryWatchersTypes { get; set; }
        public abstract void Start();

        public abstract void Stop();

        public virtual void SetDirectoryPath(string directoryPath) { }

        public bool FindType(DirectoryWatchersTypes directoryWatchersTypes)
        {
            return this.DirectoryWatchersTypes == directoryWatchersTypes;
        }
    }
}
