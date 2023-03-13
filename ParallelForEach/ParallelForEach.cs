using System.Collections.ObjectModel;

delegate void func(string str);
class ParallelForEach
{
    public static void RunParallelFunctions(Collection<string> strings, func function)
    {
        foreach (string str in strings)
        {
            string tmp = str;
            Thread myThread = new Thread(() => function(tmp));
            myThread.Start();
        }

    }
}