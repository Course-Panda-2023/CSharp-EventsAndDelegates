using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;

class IDirectoryWatcherFactory
{
    public delegate string[] GetFiles(string path);
    static IDirectoryWatcher CreateWatcher(string path, GetFiles func)
    {
        return new IDirectoryWatcher(path, func);
    }
    static void Main(string[] args)
    {
        string path = "C:\\tmp";
        IDirectoryWatcher watcher = CreateWatcher(path,Directory.GetFiles);
        watcher.start();
        Console.ReadLine();
    }
}
class IDirectoryWatcher : FileSystemWatcher
{
    //new FileSystemWatcher()
    IDirectoryWatcherFactory.GetFiles func;
    public IDirectoryWatcher(string _path, IDirectoryWatcherFactory.GetFiles _func) : base(_path)
    {
        func = _func;
        Changed += HandleEverything;
        Deleted += HandleEverything;
        Created += HandleEverything;
    }
    public void start()
    {
        this.EnableRaisingEvents= true;
    }
    public void stop()
    {
        this.EnableRaisingEvents= false;
    }
    private void HandleEverything(object sender, FileSystemEventArgs e)
    {
        WatcherChangeTypes type = e.ChangeType;
        Console.WriteLine(type.ToString() + "   " + e.FullPath);
        Console.WriteLine("Current Directory state:\n" + String.Concat( func(Path)));//func(Path).ToList().Select(x=>x.ToString().Concat());
    }
}
