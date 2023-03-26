using System;
using System.Collections.Generic;
using System.IO;

public delegate List<string> GetFilesFromDirectory(string path);

public interface IDirectoryWatcher
{
    string? Path { get; set; }
    string? Filtertype { get; }

    GetFilesFromDirectory? GetFilesDelegate { get; set; }

    void SetupWatcher();
    void OnChanged(object source, FileSystemEventArgs e);
    void OnCreated(object source, FileSystemEventArgs e);
    void OnDeleted(object source, FileSystemEventArgs e);
    void OnRenamed(object source, RenamedEventArgs e);

    void StopWatching();
}


public class DirectoryWatcher : IDirectoryWatcher
{
    public string? Path { get; set; }
    public string? Filtertype { get; }
    GetFilesFromDirectory? IDirectoryWatcher.GetFilesDelegate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public GetFilesFromDirectory? GetFilesDelegate;
    private FileSystemWatcher? watcher;

    public DirectoryWatcher(string? path, string? filtertype = "", GetFilesFromDirectory? getFilesDelegate = null)
    {
        Path = path;
        Filtertype = filtertype;
        GetFilesDelegate = getFilesDelegate ?? delegate (string path)
        {
            return Directory.GetFiles(path, ".", SearchOption.TopDirectoryOnly).ToList();
        };
        SetupWatcher();
    }

    public void SetupWatcher()
    {
        if (Path == null)
        {
            return;
        }
        watcher = new FileSystemWatcher(Path)
        {
            Filter = $"*.{Filtertype}",
            IncludeSubdirectories = true,
            NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName
        };
        watcher.Changed += new FileSystemEventHandler(OnChanged);
        watcher.Created += new FileSystemEventHandler(OnCreated);
        watcher.Deleted += new FileSystemEventHandler(OnDeleted);
        watcher.Renamed += new RenamedEventHandler(OnRenamed);
        watcher.EnableRaisingEvents = true;
    }

    private void OnChanged(object source, FileSystemEventArgs e)
    {
        Console.WriteLine($"File {e.Name} has been changed.");
        GetFilesDelegate?.Invoke(Path);
    }
    private void OnCreated(object source, FileSystemEventArgs e)
    {
        Console.WriteLine($"File {e.Name} has been created.");
        GetFilesDelegate?.Invoke(Path);
    }
    private void OnDeleted(object source, FileSystemEventArgs e)
    {
        Console.WriteLine($"File {e.Name} has been deleted.");
        GetFilesDelegate?.Invoke(Path);
    }
    private void OnRenamed(object source, RenamedEventArgs e)
    {
        Console.WriteLine($"File {e.OldName} has been renamed to {e.Name}.");
        GetFilesDelegate?.Invoke(Path);
    }
    public void StopWatching()
    {
        watcher.EnableRaisingEvents = false;
        watcher?.Dispose();
    }

    void IDirectoryWatcher.OnChanged(object source, FileSystemEventArgs e)
    {
        throw new NotImplementedException();
    }

    void IDirectoryWatcher.OnCreated(object source, FileSystemEventArgs e)
    {
        throw new NotImplementedException();
    }

    void IDirectoryWatcher.OnDeleted(object source, FileSystemEventArgs e)
    {
        throw new NotImplementedException();
    }

    void IDirectoryWatcher.OnRenamed(object source, RenamedEventArgs e)
    {
        throw new NotImplementedException();
    }
}

class Program
{
    static void Main(string[] args)
    {
        string path = @"C:\Users\guyal.DESKTOP-S2VGE0F\Desktop\scriptstuff\test_folder";
        IDirectoryWatcher directoryWatcher = new DirectoryWatcher(path, "txt");
        Console.WriteLine($"Watching directory {path}. Press any key to stop watching.");
        // Wait for user input to stop watching
        Console.ReadKey();
        // Stop watching
        directoryWatcher.StopWatching();
    }
}