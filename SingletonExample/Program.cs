using System;
using System.Threading;

namespace SingletonExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread[] threads = new Thread[5];

            for (int i = 0; i < threads.Length; i++)
            {
                threads[i] = new Thread(() =>
                {
                    var singleton = Singleton.GetInstance();
                    singleton.IncrementRequestCount();
                    Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId}: Request Count = {singleton.GetRequestCount()}");
                });
                threads[i].Start();
            }

            foreach (var thread in threads)
            {
                thread.Join();
            }

            Console.WriteLine("All threads completed.");
        }
    }
}