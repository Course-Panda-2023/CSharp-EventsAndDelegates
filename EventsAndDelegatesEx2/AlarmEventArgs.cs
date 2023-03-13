namespace EventsAndDelegatesEx2
{
    public class AlarmEventArgs
    {
        public DateTime Time { get; set; }
        public AlarmEventArgs(DateTime time)
        {
            Time = time;
        }
    }
}