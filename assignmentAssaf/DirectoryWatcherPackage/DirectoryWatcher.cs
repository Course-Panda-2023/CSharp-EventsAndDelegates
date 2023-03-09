using assignmentAssaf.DirectoryWatcherPackage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignmentAssaf.DirectoryWatcherPackage
{
    internal class DirectoryWatcher : ParentDirectoryWatcher
    {
        private FileSystemWatcher FileSystemWatcherfileSystemWatcher = new();

        public override void Start()
        {
            
        }

        public override void Stop()
        {

        }
    }
}
