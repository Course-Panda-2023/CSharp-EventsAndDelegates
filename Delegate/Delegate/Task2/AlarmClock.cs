using System;

namespace Task2
{
    class Alarm
    {
        delegate void FunctionDel(); // Define a delegate for functions that takes a DateTime parameter

        static async Task Main(string[] args)
        {
            // Create an instance of the delegate and specify the function to be executed
            FunctionDel exampleFunction = new FunctionDel(Function1);

            Console.WriteLine(DateTime.Now.ToString());
            // Set the time at which the function should be executed
            DateTime timeToExecute = DateTime.Now.AddSeconds(5);

            while (DateTime.Now < timeToExecute)
            {
                await Task.Delay(5);
            }
            exampleFunction.Invoke();
        }

        static void Function1()
        {
            Console.WriteLine($"Hello panda! The time is {DateTime.Now}");
        }
    }
}