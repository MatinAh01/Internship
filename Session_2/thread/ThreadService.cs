using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace thread
{
    public class ThreadService
    {
        public static int Counter { get; set; } = 0;
        private static object lockObject = new object();
        public void PtintNumber()
        {
            Thread thread1 = new Thread(Print);
            Thread thread2 = new Thread(Print);

            thread1.Start();
            thread2.Start();

            thread1.Join();
            thread2.Join();

        }
        private void Print()
        {
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine(i);
                Thread.Sleep(100);
            }
        }
        public void ThreadSynchronization()
        {
            Thread thread1 = new Thread(IncrementCounter);
            Thread thread2 = new Thread(IncrementCounter);

            thread1.Start("thread 1");
            thread2.Start("thread 2");

            thread1.Join();
            thread2.Join();
        }
        private void IncrementCounter(object threadName)
        {
            while (true)
            {
                lock (lockObject)
                {
                    if (Counter >= 20) break;

                    Counter++;
                    Console.WriteLine($"{threadName}: {Counter}");

                }
                Thread.Sleep(1000);
            }
        }
    }
}