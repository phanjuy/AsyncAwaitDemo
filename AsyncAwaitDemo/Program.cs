using System;
using System.Threading;

namespace AsyncAwaitDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var startTime = DateTime.Now;

            DoWork1();
            DoWork2();
            DoWork3();

            // Takes approx. 12 seconds
            Console.WriteLine($"Total time taken: { DateTime.Now.Subtract(startTime).TotalSeconds }");
        }

        static string DoWork1()
        {
            Console.WriteLine("{0} runs on main thread {1}",
                nameof(DoWork1), Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(3_000);
            return "Done with work!";
        }

        static bool DoWork2()
        {
            Console.WriteLine("{0} runs on main thread {1}",
                nameof(DoWork2), Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(4_000);
            return true;
        }

        static void DoWork3()
        {
            Console.WriteLine("{0} runs on main thread {1}",
                nameof(DoWork3), Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(5_000);
        }
    }
}