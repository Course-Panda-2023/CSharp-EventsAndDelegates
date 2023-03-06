using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static assignmentAssaf.CustomDelegates;

namespace assignmentAssaf
{
    internal abstract class IDirectoryWatcher
    {
        protected string pathOfWatchedDirectory;
        public IDirectoryWatcher(string pathOfADirectory, DirectoryFilesNames directoryFilesNames)
        {
            this.pathOfWatchedDirectory = pathOfADirectory;
            directoryFilesNames?.Invoke(pathOfADirectory);
        }

        public abstract void Start();
        public abstract void Stop();
    }
}
