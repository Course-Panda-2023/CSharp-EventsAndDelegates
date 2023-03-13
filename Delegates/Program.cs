using Delegates;

string path1 = "C:\\Users\\User\\Desktop\\C#\\CSharp-EventsAndDelegates\\Delegates\\listening\\";


static List<string> GetFilesInPath(string path)
{
    List<string> result = new List<string>();
    string[] files = Directory.GetFiles(path);

    result.AddRange(files);
    return result;
}

DirectoryWatcher dWatcher = new DirectoryWatcher(path1, GetFilesInPath);
dWatcher.start();
Console.ReadLine();
dWatcher.stop();
Console.ReadLine();
