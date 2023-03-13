using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryWatcher
{
    public delegate void GetFilesList(string path);
    public interface IDirectoryWatcher
    {
        //event EventHandler<EventArgs> DirectoryChanged;

        void Start();
        void Stop();
    }

    public class DirectoryWatcher : IDirectoryWatcher
    {
        private GetFilesList _filesList;
        private FileSystemWatcher _watcher;
        private string _path;
        //public event EventHandler<EventArgs> DirectoryChanged;

        public DirectoryWatcher(string path, GetFilesList filesList)
        {
            _watcher = new FileSystemWatcher(path);
            _watcher.Path = _path = path;
            _watcher.NotifyFilter = NotifyFilters.FileName | NotifyFilters.DirectoryName;
            _watcher.Created += OnFileSystemChanged;
            _watcher.Deleted += OnFileSystemChanged;
            _watcher.Renamed += OnFileSystemChanged;
            _filesList = filesList;
        }
        public DirectoryWatcher(string path, GetFilesList filesList, string filter)
        {
            _watcher = new FileSystemWatcher(path);
            _watcher.Path = _path = path;
            _watcher.NotifyFilter = NotifyFilters.FileName | NotifyFilters.DirectoryName;
            _watcher.Created += OnFileSystemChanged;
            _watcher.Deleted += OnFileSystemChanged;
            _watcher.Renamed += OnFileSystemChanged;
            _watcher.Filter = filter;
            _filesList = filesList;
        }

        public void OnFileSystemChanged(object sender, FileSystemEventArgs e)
        {
            /*if (DirectoryChanged != null)
            {
                DirectoryChanged(this, EventArgs.Empty);
            }*/
            
            Console.WriteLine($"The file {e.Name} has been {e.ChangeType} at {e.FullPath}");
            _filesList(_path);

        }

        public void Start()
        {
            Console.WriteLine("Started");
            _watcher.EnableRaisingEvents = true;
        }

        public void Stop()
        {
            Console.WriteLine("Stopped");
            _watcher.EnableRaisingEvents = false;
            _watcher.Dispose();
        }
    }
}
