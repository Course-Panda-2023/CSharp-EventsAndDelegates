using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using static CSharp_Delegates.HelperFunctions;

namespace CSharp_Delegates
{
    public class HelperFunctions
    {
        public delegate void ThrowException();
        // Ex 1.
        public static void FaultTolerant(ThrowException function, int numberOfTries)
        {
            bool isPass = false;
            int index = 0;
            while(!isPass && index < numberOfTries) 
            {
                Exception ex = null;
                try
                {
                    function();
                }
                catch (Exception e)
                {
                    index++;
                    ex = e;
                }
                finally
                {
                    if (ex == null)
                        isPass = true;
                }
            }
        }

        // Ex 2.
        public delegate void Function();
        public static event Function Alarm;
        public static void AlarmClock(DateTime time, Function function)
        {
            if (time < DateTime.Now)
            {
                Console.WriteLine("Timeover!");
                return;
            }
            Console.WriteLine("Time: " + time);
            Alarm += function;
            while (DateTime.Compare(time, DateTime.Now) > 0)
            {
                Console.WriteLine("Still waiting...");
                Console.WriteLine("Current time: " + DateTime.Now);
            }
            Console.WriteLine("Starting the alarm");
            Alarm?.Invoke();
        }


        // Ex 3.
        public delegate void CollectionFunction(string str);
        public static void ProbabilisticForEach(List<string> collection, List<CollectionFunction> functions)
        {
            Random random= new Random();
            foreach (var collectionVar in collection)
            {
                int randomNumber = random.Next(functions.Count);
                functions[randomNumber](collectionVar);                
            }
        }

    
        // Ex 4.

        public static void ParallelForEach(List<string> collection, CollectionFunction function)
        {
            Console.WriteLine("Parallel For Each");
            Parallel.ForEach(collection, str => new Thread(() => function(str)).Start());
        }

    }
}
