using System;
using System.Collections.Generic;
using System.Threading.Tasks;

class ParallelForEach
{
    static void Main()
    {
        // Create a sample collection of integers
        List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };

        // Define the delegate for the function to be executed on each item
        Action<int> processItem = ProcessItemFunction;

        // Call the method that distributes the work between threads
        ProcessCollection(numbers, processItem);

        // Wait for all threads to complete before exiting
        Task.WaitAll();
    }

    static void ProcessItemFunction(int item)
    {
        // Perform the processing on the item
        Console.WriteLine($"Processing item: {item} on Thread {Task.CurrentId}");
        Thread.Sleep(2);
        Console.WriteLine($"{Task.CurrentId} done processing {item}");
    }

    static void ProcessCollection<T>(IEnumerable<T> collection, Action<T> processItem)
    {
        // Define the maximum number of threads to be used for processing
        int maxThreads = Environment.ProcessorCount;

        // Create a semaphore to limit the number of threads running concurrently
        SemaphoreSlim semaphore = new SemaphoreSlim(maxThreads);

        // Use Parallel.ForEach to distribute the work between threads
        Parallel.ForEach(collection, async (item) =>
        {
            // Wait for a semaphore slot to be available before running the task
            await semaphore.WaitAsync();

            try
            {
                // Call the processItem function on the item
                processItem(item);
            }
            finally
            {
                // Release the semaphore slot when the task is done
                semaphore.Release();
            }
        });
    }
}
