namespace EventsAndDelegatesEx2;

public class Helper
{
    static void WriteHello()
    {
        Console.WriteLine("Hello!");
    }

    public static void RunAlarmTimer()
    {
        AlarmTimer timer = new AlarmTimer();

        DateTime alarmTime = DateTime.Now.AddSeconds(1);

        timer.MyAlarmEventDelegate += Func1;
        timer.SetAlarm(alarmTime);
        Console.ReadLine();
    }
    public static void Func1(object sender, AlarmEventArgs e)
    {
        Console.WriteLine("Func1 executed at {0}", e.Time);
    }
}