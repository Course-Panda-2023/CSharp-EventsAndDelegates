using ProbabilisticForEach;
using System.Collections.Generic;

static int RandomSumOfAList(int listCount)
{
    Random random = new();
    return Enumerable.Range(0, listCount).Select(x => random.Next(0, 100)).Sum();
}

static int RandomMaxOfAList(int listCount)
{
    Random random = new();
    return Enumerable.Range(0, listCount).Select(x => random.Next(0, 100)).Max();
}

static int RandomMinOfAList(int listCount)
{
    Random random = new();
    return Enumerable.Range(0, listCount).Select(x => random.Next(0, 100)).Sum();
}
List<Func<int>> functionsStack = new()
{
    () => RandomSumOfAList(100),
    () => RandomMinOfAList(100),
    () => RandomMaxOfAList(100),
};
    

ProbabilityExecuteFunction.RandomExecuteFunctionFromListOfFunctions(functionsStack);

Console.ReadLine();

