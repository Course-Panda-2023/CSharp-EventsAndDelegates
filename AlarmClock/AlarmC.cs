using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;


namespace AlarmClock
{
    public delegate void AlarmClockDel();
    public class AlarmC
    {
        private System.Timers.Timer aTimer;
        public event AlarmClockDel Alarm;

        private AlarmClockDel func;
        private DateTime date;

        public AlarmC(AlarmClockDel func, DateTime date)
        {
            this.func = func;
            this.date = date;
            aTimer = new System.Timers.Timer();
            aTimer.Interval = 1000;
            Alarm += func;
            aTimer.Elapsed += StartProcess;
            aTimer.Start();
        }

        public void StartProcess(Object sender, ElapsedEventArgs e)
        {
            Console.WriteLine(DateTime.Now.ToString());
            if (date <= DateTime.Now)
            {
                Alarm?.Invoke();
                aTimer.Stop();

            }
        }

        public void StartFuncOnDate()
        {
            Console.WriteLine(date.ToString());
            Console.WriteLine(DateTime.Now.ToString());
          
        }
    }
}
