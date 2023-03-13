

using Microsoft.VisualBasic;

namespace EventsAndDelegatesEx2
{
    public delegate void AlarmEventDelegate(object sender, AlarmEventArgs e);
     
    public class AlarmTimer
    {
        AlarmEventDelegate myAlarmEventDelegate = null;
        private DateTime _alarmTime;
        private Action _alarmAction;

        
        public void SetAlarm(DateTime alarmTime)
        {
            _alarmTime = alarmTime;

            while (DateTime.Now < _alarmTime)
            {
                Thread.Sleep(100);
            }
            
            OnAlarmEvent(new AlarmEventArgs(_alarmTime));
        }
        public void Start(DateTime time)
        {
            while (true)
            {
                //Console.WriteLine(DateTime.Now.Second);
                if (DateTime.Now.Second == time.Second)
                {
                    OnAlarmEvent(new AlarmEventArgs(DateTime.Now));
                }
            }
        }
        public void Start()
        {

            while (true)
            {
                //Console.WriteLine(DateTime.Now.Second);
                if (DateTime.Now.Second == 0)
                {
                    OnAlarmEvent(new AlarmEventArgs(DateTime.Now));
                }
            }
        }

        protected virtual void OnAlarmEvent(AlarmEventArgs e)
        {
            myAlarmEventDelegate?.Invoke(this, e);
        }

        public event AlarmEventDelegate MyAlarmEventDelegate
        {
            add
            {
                myAlarmEventDelegate += value;
            }
            remove
            {
                myAlarmEventDelegate -= value;
            }
        }
    }

}

