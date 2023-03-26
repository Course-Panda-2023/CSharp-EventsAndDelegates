using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;


namespace DirectoryWatcherNameSpace
{
    delegate void ALarmCLockFunc();

    internal class AlarmClock
    {
        private EventHandler alarmEvent;
        private System.Timers.Timer timer;
        private DateTime alarmTime;
        private bool enabled;

        public event ALarmCLockFunc Alarm;

        public AlarmClock(DateTime alarmTime, ALarmCLockFunc func)
        {
            this.alarmTime = alarmTime;

            Alarm += func;
            timer = new System.Timers.Timer();
            timer.Elapsed += timer_Elapsed;
            timer.Interval = 1000;
            timer.Start();

            enabled = true;
        }

        public void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine("tick");
            if (enabled && DateTime.Now >= alarmTime)
            {
                enabled = false;
                Alarm.Invoke();
                timer.Stop();
            }
        }

        public static void GoodMorning() { Console.WriteLine("GoodMorning"); }
        
    }
}
