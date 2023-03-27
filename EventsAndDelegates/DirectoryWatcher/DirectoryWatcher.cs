namespace EventsAndDelegates;

public class DirectoryWatcher: IDirectoryWatcher
{
    private string _path;
    private string? _filter;
    private FileSystemWatcher _watcher;
    public DirectoryWatcher(string path, Func<string, List<string>> listPathFiles, string? filter = null)
    {
        _path = path;
        _filter = filter;
        _watcher = new FileSystemWatcher(_path);
        _watcher.NotifyFilter = NotifyFilters.Attributes
                                | NotifyFilters.CreationTime
                                | NotifyFilters.DirectoryName
                                | NotifyFilters.FileName
                                | NotifyFilters.LastAccess
                                | NotifyFilters.LastWrite
                                | NotifyFilters.Security
                                | NotifyFilters.Size;
        
        _watcher.EnableRaisingEvents = true;
        if (! (_filter is null))
        {
            _watcher.Filter = filter;
        }
        
        List<string> pathFiles = listPathFiles(_path);
        
        Console.WriteLine($"Watching the directory {_path}. Watched files:");
        foreach(string filename in pathFiles)
        {
            Console.WriteLine(filename);
        }
    }

    private static void OnCreated(object sender, FileSystemEventArgs e)
    {
        Console.WriteLine($"File {e.FullPath} was created");
    }
    
    private static void OnChanged(object sender, FileSystemEventArgs e)
    {
        Console.WriteLine($"File {e.FullPath} was changed");
    }

    private static void OnDeleted(object sender, FileSystemEventArgs e)
    {
        Console.WriteLine($"File {e.FullPath} was deleted");
    }

    public void Start()
    {
        _watcher.Created += OnCreated;
        _watcher.Changed += OnChanged;
        _watcher.Deleted += OnDeleted;
    }

    public void Stop()
    {
        _watcher.Created -= OnCreated;
        _watcher.Changed -= OnChanged;
        _watcher.Deleted -= OnDeleted;
    }
}