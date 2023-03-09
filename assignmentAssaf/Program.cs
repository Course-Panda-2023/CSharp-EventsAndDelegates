using assignmentAssaf.DirectoryWatcherFactories;
using assignmentAssaf.DirectoryWatcherPackage;
using assignmentAssaf.DirectoryWatchersFactory;

IDirectoryWatchersFactory factory = new DirectoryWatchersFactory();

IDirectoryWatcher directoryWatcher = factory.GetDirectoryWatcher(DirectoryWatchersTypes.DirectoryWatcher);

directoryWatcher.SetDirectoryPath("C:\\Users\\AssafHillel\\Desktop\\txt");

directoryWatcher.Start();

Console.ReadLine();