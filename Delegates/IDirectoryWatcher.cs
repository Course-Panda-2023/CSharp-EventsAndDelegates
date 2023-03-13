using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    public delegate List<string> filesInPath(string path);
    public interface IDirectoryWatcher
    {
        public void start();
        public void stop();
    }


    public class DirectoryWatcher : IDirectoryWatcher
    {
        private filesInPath files;
        private string path;
        private FileSystemWatcher watcher;

        public DirectoryWatcher(string path, filesInPath files)
        {
            this.path = path;
            this.files = files;
            watcher = new FileSystemWatcher(path);
        }

        static void OnChanged(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine("{0} has been {1}", e.Name, e.ChangeType);
        }

        public void start()
        {
            watcher.Path = path;
            watcher.Changed += new FileSystemEventHandler(OnChanged);
            watcher.Created += new FileSystemEventHandler(OnChanged);
            watcher.Deleted += new FileSystemEventHandler(OnChanged);
            watcher.Filter = "*.txt";

            watcher.EnableRaisingEvents = true;
        }

        public void stop()
        {
            watcher.Changed -= new FileSystemEventHandler(OnChanged);
            watcher.Created -= new FileSystemEventHandler(OnChanged);
            watcher.Deleted -= new FileSystemEventHandler(OnChanged);

            watcher.EnableRaisingEvents = false;
        }
    }
}
