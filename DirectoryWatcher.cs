
public delegate List<string> FilesInPaths(string dirPath);


public interface IDirectoryWatcherFactory
{
    void AddDirectoryWatcher(string dirPath);
}

public class DirectoryWatcherFactory : IDirectoryWatcherFactory
{
    List<DirectoryWatcher> directoryWatchers = new List<DirectoryWatcher>();
    FilesInPaths filesInPaths;
    public DirectoryWatcherFactory(FilesInPaths filesInPaths)
    {
        this.filesInPaths = filesInPaths;
    }
    
    public void AddDirectoryWatcher(string dirPath)
    {
        this.directoryWatchers.Add(new DirectoryWatcher(dirPath, this.filesInPaths));
    }
}




public interface IDirectoryWatcher
{
    void Start() {}
    
    void Stop() {}

}


public class DirectoryWatcher : IDirectoryWatcher
{
    
    string dirPath;
    FilesInPaths filesInPaths;
    FileSystemWatcher watcher; 
    
    public DirectoryWatcher(string dirPath, FilesInPaths filesInPaths)
    {
        this.dirPath = dirPath;
        this.filesInPaths = filesInPaths;
        this.watcher = new FileSystemWatcher(dirPath);

        this.watcher.NotifyFilter = NotifyFilters.Attributes
                                | NotifyFilters.CreationTime
                                | NotifyFilters.DirectoryName
                                | NotifyFilters.FileName
                                | NotifyFilters.LastAccess
                                | NotifyFilters.LastWrite
                                | NotifyFilters.Security
                                | NotifyFilters.Size;

        this.watcher.Changed += OnChanged;
        this.watcher.Created += OnCreated;
        this.watcher.Deleted += OnDeleted;
        this.watcher.Renamed += OnRenamed;
        this.watcher.Error += OnError;

        this.watcher.Filter = "*.txt";
        this.watcher.IncludeSubdirectories = true;
        
        this.HandleEventRaising();
        
        
    }

    private void HandleEventRaising()
    {
        Console.WriteLine("Press 'Enter' toggle event raising.");
        while(true)
        {
            this.Start();
            Console.WriteLine("Event raising toggled: On");
            Console.ReadLine();
            this.Stop();
            Console.WriteLine("Event raising toggled: Off");
            Console.ReadLine();

        }
    }
    public void Start()
    {
        this.watcher.EnableRaisingEvents = true;
    }
    
    public void Stop()
    {
        this.watcher.EnableRaisingEvents = false;
    }

    


    private void OnChanged(object sender, FileSystemEventArgs e)
    {
        if (e.ChangeType != WatcherChangeTypes.Changed)
        {
            return;
        }
        Console.WriteLine($"Changed: {e.FullPath}");
        this.filesInPaths(this.dirPath);
    }

    private void OnCreated(object sender, FileSystemEventArgs e)
    {
        string value = $"Created: {e.FullPath}";
        Console.WriteLine(value);
    }

    private void OnDeleted(object sender, FileSystemEventArgs e)
    {
        Console.WriteLine($"Deleted: {e.FullPath}");
        this.filesInPaths(this.dirPath);
    }

    private void OnRenamed(object sender, RenamedEventArgs e)
    {
        Console.WriteLine($"Renamed:");
        Console.WriteLine($"    Old: {e.OldFullPath}");
        Console.WriteLine($"    New: {e.FullPath}");
        this.filesInPaths(this.dirPath);
    }

    private static void OnError(object sender, ErrorEventArgs e)
    {
        PrintException(e.GetException());
    }

    private static void PrintException(Exception? ex)
    {
        if (ex != null)
        {
            Console.WriteLine($"Message: {ex.Message}");
            Console.WriteLine("Stacktrace:");
            Console.WriteLine(ex.StackTrace);
            Console.WriteLine();
            PrintException(ex.InnerException);
        }
    }


}

