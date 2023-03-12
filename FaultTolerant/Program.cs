
class Program
{
    static void faultyFunction()
    {
        Random rnd = new Random();
        int num = rnd.Next(4);
        if (num == 0)
        {
            Console.WriteLine("function worked");
        }
        else
        {
            Console.WriteLine("function failed");
            throw new Exception();
        }

    }
    public static void Main(string[] args)
    {
        FaultTolerant.TryFunctionUntilGiveUp(faultyFunction, 40);
    }
}
