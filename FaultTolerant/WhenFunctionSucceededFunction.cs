namespace FaultTolerant
{
    internal class WhenFunctionSucceededFunction
    {
        public void FunctionSucceeded<T>(Func<T> function, T input, int numberOfAttempts)
        {
            for (int i = 1; i <= numberOfAttempts; i++)
            {
                try
                {
                    T result = function();
                    Console.WriteLine($"Attempt {i}: Function succeeded for input {input} with result {result}");
                    return;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Attempt {i}: Function failed with exception {ex.Message}");
                }
            }

            Console.WriteLine($"Function failed for input {input} after {numberOfAttempts} attempts");
        }
    }
}
