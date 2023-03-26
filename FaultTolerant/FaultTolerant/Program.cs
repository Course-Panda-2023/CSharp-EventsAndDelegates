namespace FaultTolerant
{
    internal class Program
    {
        private static int Add10ToNum(int num)
        {
            Random random = new Random();
            if (random.Next(2) == 0)
            {
                throw new Exception("oops");
            }

            if (num < 10)
            {
                return num + 1;
            }

            return num;
        }   
        static void Main(string[] args)
        {
            int maxAttempts = 20;
            int attempts = 0;
            int num = 5;
            while (attempts < maxAttempts)
            {
                try
                {
                    num = Add10ToNum(num);
                    Console.WriteLine($"Result: {num}");
                    break; // exit loop if successful
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Attempt {attempts + 1} failed: {ex.Message}");
                    attempts++;
                }
            }
            if (attempts == maxAttempts)
            {
                Console.WriteLine("Giving up after too many failed attempts");
            }

        }
    }
}