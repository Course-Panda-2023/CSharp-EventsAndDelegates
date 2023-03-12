using ParallelForEach;
using System.Diagnostics;

static bool IsPrime(int number)
{
    if (number < 2)
    {
        return false;
    }

    for (var divisor = 2; divisor <= Math.Sqrt(number); divisor++)
    {
        if (number % divisor == 0)
        {
            return false;
        }
    }
    return true;
}

static bool IsBiggerthanZero(int number)
{
    return number > 0;
}

static bool IsEven(int number)
{
    return number % 2 == 0;
}



var watch = Stopwatch.StartNew();
List<Func<int, bool>> predicates = new()
{
    x => IsPrime(100),
    IsBiggerthanZero,
    IsEven
};

// Example usage:
int myNumber = 42;
foreach (var predicate in predicates)
{
    bool result = predicate(myNumber);
    Console.WriteLine($"{predicate.Method.Name}({myNumber}) = {result}");
}

watch.Stop();
Console.WriteLine($"Elapsed time: {watch.ElapsedMilliseconds} ms");

Console.ReadLine();