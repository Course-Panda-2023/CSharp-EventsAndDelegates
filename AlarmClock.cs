
public delegate void Action<T>(T arg);



class AlarmClock
{
    public static void PrintYearsFrom2000(DateTime time)
    {
        Console.WriteLine($"Total years from 2000 passed: {(time - Convert.ToDateTime("01-01-2000")).TotalDays/365}");
    } 


    public event TimeReachedEventHandler TimeArrived; // event
    static void TimeReached(object sender, TimeReachedEventArgs e)
    {
        e.func(e.time);
    }
    
    
    protected virtual bool OnTimeReached(TimeReachedEventArgs e, Action<DateTime> func)
    {
        if (DateTime.Compare(e.time, DateTime.Now) < 0)
        {
            TimeArrived?.Invoke(this, e);
            return false;
        }
        return true;
    }

    
    public class TimeReachedEventArgs : EventArgs
    {
        public DateTime time { get; set; }
        public Action<DateTime> func {get; set;}
    }
    public delegate void TimeReachedEventHandler(object sender, TimeReachedEventArgs e);



    public void EX2(DateTime time, Action<DateTime> func)
    {
        Console.WriteLine(DateTime.Now);
        Console.WriteLine(time);
        TimeReachedEventArgs TRE = new TimeReachedEventArgs();
        TRE.time = time;
        TRE.func = func;
        TimeArrived += TimeReached;
        bool cont = true;
        while(cont)
        {
            Thread.Sleep(1000);
            cont = this.OnTimeReached(TRE, func);
        }
    }
}
