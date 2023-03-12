namespace AlarmClock
{
    internal static class Executer
    {
        internal static void FormatDateTime<T>(DateTime dateTime, Func<T> function)
        {
            Console.WriteLine($"The given date is {dateTime.ToString()}");
            Console.WriteLine(function.Invoke());
        }
    }
}
