
static void FaultyFunc()
{
    Random r = new Random();
    int num = r.Next(100);
    if (num > 50)
    {
        throw new Exception("Exception: number is larger than 50.");
    }
    else
        Console.WriteLine("Worked!");
}

static void FaultTolerate(int tries, probabilityException func)
{
    for (int i = 0; i < tries; i++)
    {
        try
        {
            func();
            break;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}

FaultTolerate(10, FaultyFunc);

public delegate void probabilityException();



