using AlarmClock;
using System.Security.Cryptography;

DateTime date = DateTime.Now;
date.AddSeconds(30);

AlarmClock.AlarmClock clock = new AlarmClock.AlarmClock(date);

int RandomGenerator(int scalar)
{
    return new Random().Next(0, scalar) * scalar;
}


clock.Alarm += (sender, e) => Executer.FormatDateTime(date, () => RandomGenerator(30));

Console.ReadLine();
