using System;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwaitDemo
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var startTime = DateTime.Now;

            await Task.Run(DoWork1);
            await Task.Run(DoWork2);
            await Task.Run(DoWork3);

            // Takes approx. 12 seconds
            Console.WriteLine($"Total time taken: { DateTime.Now.Subtract(startTime).TotalSeconds }");
        }

        static string DoWork1()
        {
            Console.WriteLine("{0} runs on worker thread {1}",
                nameof(DoWork1), Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(3_000);
            return "Done with work!";
        }

        static bool DoWork2()
        {
            Console.WriteLine("{0} runs on worker thread {1}",
                nameof(DoWork2), Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(4_000);
            return true;
        }

        static void DoWork3()
        {
            Console.WriteLine("{0} runs on worker thread {1}",
                nameof(DoWork3), Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(5_000);
        }
    }
}