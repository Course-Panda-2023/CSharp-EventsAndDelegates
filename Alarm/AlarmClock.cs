
using System.Timers;

namespace alarm
{
    public delegate void FunctionToDo();
    public class AlarmClock
    {
        private System.Timers.Timer timer1;
        private FunctionToDo functionWillDo;
        private DateTime dt;
        public event FunctionToDo WhenAlarm;

        public AlarmClock(FunctionToDo func, DateTime dt)
        {
            this.functionWillDo = func;
            WhenAlarm += func;
            this.dt = dt;
            timer1 = new System.Timers.Timer();
            timer1.Interval = 1000;
            timer1.Elapsed += Start;
            timer1.Start();
        }
        public void Start(Object sender, ElapsedEventArgs e)
        {
            Console.WriteLine("check after 1 second");
            if (this.dt <= DateTime.Now)
            {
                WhenAlarm?.Invoke();
                timer1.Stop();
            }
        }
    }
}


