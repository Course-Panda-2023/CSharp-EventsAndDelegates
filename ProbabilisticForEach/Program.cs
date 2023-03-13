using System.Collections.ObjectModel;

class program
{
    public static void Main(string[] args)
    {
        string[] strings = { "Oh", "My", "Gosh", "Antidisestablishmentarianism" };
        Collection<string> collection = new Collection<string>(strings);
        List<randFunction> functions = new List<randFunction>();
        functions.Add(func1);
        functions.Add(func2);
        functions.Add(func3);
        ProbabilisticForEach.RunRandomFunctions(functions, collection);
    }
    public static void func1(string str)
    {
        Console.WriteLine("this is func1 and i say " + str);
    }
    public static void func2(string str)
    {
        Console.WriteLine("this is func2 and i say " + str + " " + str);
    }
    public static void func3(string str)
    {
        Console.WriteLine("this is func3 and i say " + str + " " + str + " " + str);
    }
}