// See https://aka.ms/new-console-template for more information

using CSharp_EventsAndDelegates;

Console.WriteLine("Hello, World!");


//Helper.GetFileNamesInFolder(@"D:\folder");

DirectoryWatcherFactory factory = new DirectoryWatcherFactory(Helper.GetFileNamesInFolder);
IDirectoryWatcher watcher = factory.Create(@"D:\folder");
//watcher.DirectoryChanged += (sender, args) => Console.WriteLine("Directory changed");
watcher.Start();
Console.ReadLine();
watcher.Stop();

