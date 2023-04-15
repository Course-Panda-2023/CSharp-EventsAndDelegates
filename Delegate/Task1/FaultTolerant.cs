using System;

public class Retry
{
    static void Main(string[] args)
    {
        Func<string> myFunction = () =>
        {
            if (new Random().NextDouble() <= 0.99)
                throw new Exception("Random exception occurred.");
            else
                return "success";
        };
        string result = Retry.Execute(myFunction, 10, 0.5);

        Console.WriteLine($"Result: {result} tries");
    }

    public static string Execute(Func<string> func, int maxRetries, double exceptionProbability)
    {
        int retries = 0;
        Random random = new Random();

        while (retries < maxRetries)
        {
            try
            {
                string result = (func.Invoke()).ToString() + " after " + (retries + 1).ToString();
                return result;
            }
            catch (Exception ex)
            {
                // Check if the exception probability is met
                if (random.NextDouble() <= exceptionProbability)
                {
                    retries++;
                    if (retries >= maxRetries)
                        throw new Exception($"Function failed after {maxRetries} retries.", ex);
                }
                else
                {
                    // Continue with next retry
                }
            }
        }

        throw new Exception($"Function failed after {maxRetries} retries.");
    }
}
