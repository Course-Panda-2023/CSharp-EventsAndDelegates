using System.Net;

public delegate void ExceptionFunc(double probabilty);


class FaultTolerant
{
    public static void ExceptionThrower(double probabilty)
    {
        Random rand = new Random();
        if (rand.NextDouble() > probabilty)
            throw new Exception("Kobe");
    }
    public static void EX1(ExceptionFunc f, double probabilty, int max_times)
    {
        for (int i=0; i<max_times; i++)
        {
            Console.WriteLine($"Attempt {i+1}");
            try
            {
                f(probabilty);
                Console.WriteLine("SUCCESS");
                return;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception {e} thrown");
            }
        }
            
        Console.WriteLine("Failed.");
    }
}
