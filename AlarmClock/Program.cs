using AlarmClock;

static void Func()
{
    Console.WriteLine("This is the function :)");
}

DateTime d = DateTime.Now.AddSeconds(10);
AlarmC a = new AlarmC(Func, d);
Console.ReadLine();
