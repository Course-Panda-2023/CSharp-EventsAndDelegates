using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProbabilisticForEach
{
    internal static class ProbabilityExecuteFunction
    {
        private static Random random = new();
        public static void RandomExecuteFunctionFromListOfFunctions<T>(List<Func<T>> listOfFunction)
        {
            int randomNumber = random.Next(0, listOfFunction.Count);
            Console.Write($"The method {listOfFunction[randomNumber].Method.Name}");
            Console.Write("\t");
            Console.Write($"The output is {listOfFunction[randomNumber].Invoke()}");
        }
    }
}
