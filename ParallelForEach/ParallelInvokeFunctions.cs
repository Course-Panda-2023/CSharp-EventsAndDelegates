using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelForEach
{
    internal static class ParallelInvokeFunctions
    {
        public static void ParallelInvokeListOfFunctions<T>(List<Func<T>> listOfFunction)
        {
            var primeNumbers = new ConcurrentBag<int>();

            Parallel.ForEach(listOfFunction, function =>
            {
                function.Invoke();
            });
        }
    }
}
