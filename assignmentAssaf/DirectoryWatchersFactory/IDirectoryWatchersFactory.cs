using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using assignmentAssaf.DirectoryWatcherPackage;

namespace assignmentAssaf.DirectoryWatcherFactories
{
    internal interface IDirectoryWatchersFactory
    {
        IDirectoryWatcher GetDirectoryWatcher(DirectoryWatchersTypes directoryWatcherType);
    }
}
