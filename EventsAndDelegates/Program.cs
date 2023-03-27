namespace EventsAndDelegates
{
    class Program
    {
        static void Main()
        {
            DirectoryWatcherTester();
        }
        
        static void DirectoryWatcherTester()
        {
            IDirectoryWatcher dw =
                IDirectoryWatcherFactory.GetDirectoryWatcher(
                    path: @"/Users/ilanmotiei/Desktop/a/EventsAndDelegates/EventsAndDelegates",
                    filter: "*.txt"
                );

            dw.Start();
            Console.WriteLine("Started Listening. Press enter to stop listening.");
            Console.ReadLine();
            
            dw.Stop();
            Console.WriteLine("Stopped Listening. Press enter to quit the program.");
            Console.ReadLine();
        }
    }
}