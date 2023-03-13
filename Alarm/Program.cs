using alarm;

namespace Alarm
{
    class Program
    {
        public static void Cuckoo()
        {
            Console.WriteLine("cuckoo! cuckoo!");
        }
        public static void Main(string[] args)
        {
            DateTime dt = DateTime.Now.AddSeconds(3);
            AlarmClock al = new AlarmClock(Cuckoo, dt);
            Console.ReadLine();
        }
    }
}



