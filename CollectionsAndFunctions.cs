
using System.Collections.ObjectModel;

public delegate double MathOp(int number);


class CollectionsAndFunctions
{
    public static double SquareNumber(int number)
    {
        return Math.Pow(number, 2);
    }

    public static double SqrtNumber(int number)
    {
        return Math.Sqrt(number);
    }
    public static double Sin(int number)
    {
        return Math.Sin(number);
    }
    public static double Cos(int number)
    {
        return Math.Cos(number);
    }

    public static void EX3(Collection<int> numbers, List<MathOp> funcs)
    {
        Random rand = new Random();
        Dictionary<int, string> indexToFuncName = new Dictionary<int, string> {{0, "Sqaure"}, {1, "Sqrt"}, {2, "Sin"}, {3, "Cos"}};        

        int number = numbers[rand.Next(numbers.Count)];
        int funcIndex = rand.Next(funcs.Count);
        MathOp f = funcs[funcIndex];
        string funcName = indexToFuncName[funcIndex];
        Console.WriteLine($"Number chosen: {number}");
        Console.WriteLine($"Function chosen: {funcName}");
        Console.WriteLine($"Result: {f(number)}");
    }
}
