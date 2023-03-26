using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdditionalAssignmentsDelegates
{
    delegate void ExceptionFunc();
    delegate void DateFunc(DateTime date);
    delegate void voidfunc(object o);



    internal class Assignments
    {
        public static void stam()
        {
            Random r = new Random();
            if (r.Next(3) != 0)
                throw new Exception();
            Console.WriteLine("success");
        }



        public static void func1(int giveUp, ExceptionFunc func)
        {
            for (int i=0;i< giveUp; i++) 
            {
                try
                {
                    func();
                    Console.WriteLine($"finished after {i} attempts");
                    break;
                }
                catch {
                    continue;
                }
            }
        }

        public static void getAge(DateTime date)
        {
            Console.WriteLine("Your age: " +(int)((DateTime.Now - date).TotalDays / 365.242199));
        }

        public static void func2(DateTime date, DateFunc func)
        {
            func(date);

        }

        public static void func4(List<object> list,voidfunc myFunc)
        {
            list.ForEach(x => new Thread(() => myFunc(x)).Start());
        }







    }
}

