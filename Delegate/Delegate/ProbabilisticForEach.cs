using System;
using System.Collections.Generic;

namespace Task3
{
    class ProbabilisticForEach
    {
        delegate void FunctionDel(object item); // Define a delegate for functions

        static void Main(string[] args)
        {
            List<FunctionDel> functionLst = new List<FunctionDel>
        { Function1 , Function2 , Function3 , Function4 , Function5 }; // Create a list of functions

            List<object> items = new List<object>
        { "ExampleString" , 42 , true , 14.75 , Tuple.Create(10,"hello")}; // Create a items of items

            Random rand = new Random(); // genarate randomizer

            // Loop through each item in the items
            foreach (var item in items)
            {
                // Choose a random function from the function list
                int rand_Index = rand.Next(functionLst.Count);
                FunctionDel selected_function = functionLst[rand_Index];

                // Run the selected function on the item
                selected_function(item);
            }
            Console.WriteLine("Press enter to exit");
            Console.ReadLine();
        }

        #region Example functions
        static void Function1(object item)
        { Console.WriteLine("Function1 called with item: " + item.ToString()); }

        static void Function2(object item)
        { Console.WriteLine("Function2 called with item: " + item.ToString()); }

        static void Function3(object item)
        { Console.WriteLine("Function3 called with item: " + item.ToString()); }

        static void Function4(object item)
        { Console.WriteLine("Function4 called with item: " + item.ToString()); }

        static void Function5(object item)
        { Console.WriteLine("Function5 called with item: " + item.ToString()); }

        #endregion
    }
}