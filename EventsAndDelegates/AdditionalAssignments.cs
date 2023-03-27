using System.Collections.ObjectModel;

namespace EventsAndDelegates;

public static class AdditionalAssignments
{
    public static bool FaultTolerant<T>(Func<T> func, int tries = 100)
    {
        for (int i = 0; i < tries; i++)
        {
            try
            {
                func();
                return true;
            }
            catch (Exception e)
            {
            
            }
        }

        return false;
    }

    public static void AlarmClock<T>(Func<T> func, DateTime scheduledTime)
    {
        void TimerCallback(object? state)
        {
            func();
        }
        
        // Calculate the time span between now and the scheduled time
        TimeSpan timeToWait = scheduledTime - DateTime.Now;
        if (timeToWait < TimeSpan.Zero) // If the scheduled time has already passed
        {
            timeToWait = TimeSpan.Zero; // Set the time to wait to zero so the function executes immediately
        }

        // Create and start the timer
        Timer timer = new Timer(TimerCallback, null, timeToWait, Timeout.InfiniteTimeSpan);

        Console.WriteLine("Waiting for the function to execute...");
        Console.ReadLine();
    }

    public static void ProbabilisticForEach<T>(Collection<T> collection, List<Action<T>> actions)
    {
        Random random = new Random();

        foreach (T item in collection)
        {
            Action<T> appliedFunction = actions.ElementAt(random.Next(actions.Count));
            appliedFunction(item);
        }
    }

    public static void ParallelForEach<T>(Collection<T> collection, Action<T> action)
    {
        Parallel.ForEach(collection, action);
    }
}