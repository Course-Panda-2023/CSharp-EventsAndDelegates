using System.Collections.ObjectModel;

delegate void randFunction(string str);
class ProbabilisticForEach
{
    public static void RunRandomFunctions(List<randFunction> functions, Collection<string> strings)
    {
        Random rnd = new Random();

        foreach (string str in strings)
        {
            int funcNum = rnd.Next(functions.Count);
            functions[funcNum](str);
        }
    }
}

