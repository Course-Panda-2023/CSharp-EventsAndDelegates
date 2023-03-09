using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaultTolerant
{
    internal class Executer
    {
        public void ExecuteWithRetry<T>(Func<T> function, int maxAttempts, int delayMilliseconds)
        {
            int attempts = 0;

            while (attempts < maxAttempts) 
            {
                Console.WriteLine("Running...");
                try
                {
                    function();
                }
                catch (Exception)
                {

                }
                ++attempts;
            }

            throw new Exception($"Function failed after {maxAttempts} attempts.");
        }
    }
}
