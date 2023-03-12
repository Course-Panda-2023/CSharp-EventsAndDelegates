using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryWatcher
{
    public delegate List<string> allFiles(string path);
    public interface IDirectoryWatcher
    {
        public void start();
        public void stop();
    }

    public class DirectoryWatcher : IDirectoryWatcher
    {
        private string path;
        private allFiles files;
        FileSystemWatcher watcher;

        public DirectoryWatcher(string path, allFiles files)
        {
            this.path = path;
            this.files = files;
            this.watcher = new FileSystemWatcher();
        }

        public void start()
        {
            watcher.Path = path;
            watcher.Changed += new FileSystemEventHandler(OnChanged);
            watcher.Created += new FileSystemEventHandler(OnChanged);
            watcher.Deleted += new FileSystemEventHandler(OnChanged);
            watcher.EnableRaisingEvents = true;
            watcher.Filter = "*.txt";
        }

        public void stop()
        {
            watcher.Changed -= new FileSystemEventHandler(OnChanged);
            watcher.Created -= new FileSystemEventHandler(OnChanged);
            watcher.Deleted -= new FileSystemEventHandler(OnChanged);
            watcher.EnableRaisingEvents = false;
        }
        static void OnChanged(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine("{0} has been {1}", e.Name, e.ChangeType);
        }
    }
}
