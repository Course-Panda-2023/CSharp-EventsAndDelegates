
using System.Collections.Generic;
using static CSharp_Delegates.HelperFunctions;
Console.WriteLine("Start!");


static void Ex1()
{
    Random rnd = new Random();
    int randomNumber = rnd.Next(10);
    Console.WriteLine("The number: " + randomNumber);
    if(randomNumber % 2 == 0)
        throw new NotImplementedException();
}

static void Ex2()
{
    Console.WriteLine("Hello World!");
}


Console.WriteLine("Ex 1.");
FaultTolerant(Ex1, 14);
Console.WriteLine("Ex 2.");
DateTime datetime = DateTime.Now.AddSeconds(10);
Console.WriteLine(datetime);
AlarmClock(datetime, Ex2);

// Ex 3.

static void FunctionEx3_1(string str)
{
    Console.WriteLine("Ex3_1 " + str);
}

static void FunctionEx3_2(string str)
{
    Console.WriteLine("Ex3_2 " + str);
}

static void FunctionEx3_3(string str)
{
    Console.WriteLine("Ex3_3 " + str);
}

List<CollectionFunction> collectionFunctions = new List<CollectionFunction>()
{
    FunctionEx3_1, FunctionEx3_2, FunctionEx3_3
};

List<string> stringFunctions = new List<string>() { "A", "B", "C" };

ProbabilisticForEach(stringFunctions, collectionFunctions);

// Ex 4.

Console.WriteLine("Ex 4.");
ParallelForEach(stringFunctions, FunctionEx3_1);