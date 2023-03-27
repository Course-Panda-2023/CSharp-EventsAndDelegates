namespace EventsAndDelegates;

public static class IDirectoryWatcherFactory
{
    public static IDirectoryWatcher GetDirectoryWatcher(string path, string filter = "*")
    {
        return new DirectoryWatcher(
            path: path, 
            listPathFiles: delegate(string s)
            {
                DirectoryInfo d = new DirectoryInfo(s); 
                FileSystemInfo[] nodes = d.GetFileSystemInfos(filter);

                List<string> result = new List<string>();
                foreach (FileSystemInfo node in nodes)
                {
                    result.Add(node.Name);
                }

                return result;
            }, 
            filter: filter
        );
    }
}