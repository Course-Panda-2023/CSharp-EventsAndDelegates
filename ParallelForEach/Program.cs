using System.Collections.ObjectModel;

class program
{
    public static void Main(string[] args)
    {
        string[] strings = { "a", "bbb", "ccccccc" };
        Collection<string> collection = new Collection<string>(strings);
        ParallelForEach.RunParallelFunctions(collection, ExampleMethod);      
    }
    public static void ExampleMethod(string str)
    {
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine(i.ToString() + " " + str);
            Thread.Sleep(1);
        }
    }
}