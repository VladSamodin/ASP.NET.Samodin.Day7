using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1.CountdownClock;

namespace Task1.ConsoleApplication
{
    class Subscriber1
    {
        public void TimeOutEventHandle(object sender, EventArgs e)
        {
            Console.WriteLine("Subscriber1 handler");
        }
    }

    class Subscriber2
    {
        public void TimeOutEventHandle(object sender, EventArgs e)
        {
            Console.WriteLine("Subscriber2 handler");
        }
    }

    class Subscriber3
    {
        public void TimeOutEventHandle(object sender, EventArgs e)
        {
            Console.WriteLine("Subscriber3 handler");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Subscriber1 s1 = new Subscriber1();
            Subscriber2 s2 = new Subscriber2();
            Subscriber3 s3 = new Subscriber3();

            CountdownClock.CountdownClock cc = new CountdownClock.CountdownClock(1);

            cc.TimeOut += s1.TimeOutEventHandle;
            cc.TimeOut += s2.TimeOutEventHandle;
            cc.TimeOut += s3.TimeOutEventHandle;

            Console.WriteLine();
            cc.Start();

            cc.TimeOut -= s2.TimeOutEventHandle;
            cc.IntervalInSeconds = 2;

            Console.WriteLine();
            cc.Start();

            cc.TimeOut += s1.TimeOutEventHandle;
            cc.TimeOut += s2.TimeOutEventHandle;

            Console.WriteLine();
            cc.Start();
            Console.ReadKey();
        }
    }
}
