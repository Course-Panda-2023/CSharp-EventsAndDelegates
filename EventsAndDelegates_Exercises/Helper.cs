namespace EventsAndDelegatesEx1;

public class Helper
{
    public static void RunFaultTolerant(Action func, int maxAttempts)
    {
        int attempts = 0;
        while (attempts < maxAttempts)
        {
            try
            {
                func();
                return; // success
            }
            catch (Exception ex)
            {
                attempts++;
                Console.WriteLine($"Attempt {attempts} failed with exception: {ex.Message}");
            }
        }

        throw new Exception($"Failed after {maxAttempts} attempts.");
    }

   
    public static void ThrowOcasionallyException()
    {
        Random random = new Random();
        const double someProbability = 0.3;
        if (random.NextDouble() < 0.3)
        {
            throw new Exception("Exception thrown");
        }
    }
}