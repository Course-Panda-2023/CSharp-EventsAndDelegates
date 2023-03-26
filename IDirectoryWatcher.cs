using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryWatcherNameSpace
{
    internal interface IDirectoryWatcher
    {
        public void OnFileChanged(object sender, FileSystemEventArgs e);
        public void OnError(object sender, ErrorEventArgs e);

        public void StopTracking();

        public void startTracking();
    }
}
