using assignmentAssaf.DirectoryWatcherFactories;
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

        public override void SetDirectoryPath(string directoryPath)
        {
            FileSystemWatcherfileSystemWatcher.Path = directoryPath;
        }

        public void SetDirectoryWatchersTypes(DirectoryWatchersTypes type)
        {
            this.DirectoryWatchersTypes = type;
        }

        private static void OnChanged(object sender, FileSystemEventArgs e)
        {
            if (e.ChangeType != WatcherChangeTypes.Changed) return;
            Console.WriteLine($"Changed: {e.FullPath}");
        }

        private static void OnCreated(object sender, FileSystemEventArgs e)
        {
            string value = $"Created: {e.FullPath}";
            Console.WriteLine(value);
        }

        private static void OnDeleted(object sender, FileSystemEventArgs e) =>
            Console.WriteLine($"Deleted: {e.FullPath}");


        public override void Start()
        {
            FileSystemWatcherfileSystemWatcher.NotifyFilter =
                                 NotifyFilters.LastWrite 
                                 | NotifyFilters.FileName;

            FileSystemWatcherfileSystemWatcher.Changed += OnChanged;
            FileSystemWatcherfileSystemWatcher.Created += OnCreated;
            FileSystemWatcherfileSystemWatcher.Deleted += OnDeleted;

            FileSystemWatcherfileSystemWatcher.Filter = "*.txt";
            FileSystemWatcherfileSystemWatcher.EnableRaisingEvents = true;
        }

        public override void Stop()
        {
            FileSystemWatcherfileSystemWatcher.Dispose();
            FileSystemWatcherfileSystemWatcher.EnableRaisingEvents = false;
        }
    }
}
