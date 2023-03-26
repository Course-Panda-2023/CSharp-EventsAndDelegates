using System;
using System.Threading;
using System.Timers;

internal class Program
{
    private static void Main(string[] args)
    {
        DateTime target = new DateTime(2023, 3, 9, 11, 2, 0);
        System.Timers.Timer t = new System.Timers.Timer(1000);
        t.Elapsed += (sender, e) => Timer_Elapsed(target);
        t.Elapsed += Timer_Elapsed_2;
        t.Enabled = true;

        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();

    }
    static void Timer_Elapsed(DateTime targetDateTime)
    {
        // check if the target datetime has passed
        DateTime now = DateTime.Now;
        int result = DateTime.Compare(now, targetDateTime);
        CheckIfTimeElapsed(result);
    }

    private static void CheckIfTimeElapsed(int result)
    {
        if (result >= 0)
        {
            Console.WriteLine("The target datetime has passed.");
        }
        else
        {
            Console.WriteLine("No");
        }
    }

    static void Timer_Elapsed_2(object sender, System.Timers.ElapsedEventArgs e)
    {
        Console.WriteLine($"The current time is {DateTime.Now}");
    }
}