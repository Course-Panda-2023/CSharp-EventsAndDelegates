using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using assignmentAssaf.DirectoryWatcherFactories;
using assignmentAssaf.Utils;

namespace assignmentAssaf.DirectoryWatcherPackage
{
    internal abstract class ParentDirectoryWatcher : IDirectoryWatcher
    {
        protected DirectoryWatchersTypes DirectoryWatchersTypes { get; set; }
        public abstract void Start();

        public abstract void Stop();

        public bool FindType(DirectoryWatchersTypes directoryWatchersTypes)
        {
            return this.DirectoryWatchersTypes == directoryWatchersTypes;
        }
    }
}
