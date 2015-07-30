using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task1.CountdownClock
{
    public class CountdownClock
    {
        private const int DefaultInterval = 1;
        public event EventHandler<EventArgs> TimeOut;
        private int intervalInSeconds;

        public int IntervalInSeconds
        {
            get
            {
                return intervalInSeconds;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Argument must be > 0");
                }
                intervalInSeconds = value;
            }
        }

        public CountdownClock(int intervalInSeconds = DefaultInterval)
        {
            IntervalInSeconds = intervalInSeconds;
            TimeOut += delegate { };
        }

        public void Start()
        {
            Console.WriteLine("Start with interval {0}s", IntervalInSeconds);
            System.Threading.Thread.Sleep(IntervalInSeconds * 1000);
            OnTimeOut();
        }

        protected virtual void OnTimeOut()
        {
            TimeOut(this, EventArgs.Empty);
        }
    }
}
