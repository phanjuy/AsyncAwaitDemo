using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwaitDemo
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var startTime = DateTime.Now;

            DoWorkInMainThread();

            var task1 = Task.Run(DoWork1);
            var task2 = Task.Run(DoWork2);
            var tasks = new List<Task> { task1, task2 };

            while (tasks.Count > 0)
            {
                var task = await Task.WhenAny(tasks);
                if (task == task2)
                    Console.WriteLine("Task2 completed!");
                else
                    Console.WriteLine("Task1 completed!");
                tasks.Remove(task);
            }

            if (task2.Result)
                await Task.Run(DoWork3);

            // Takes approx. 13 seconds
            Console.WriteLine($"Total time taken: { DateTime.Now.Subtract(startTime).TotalSeconds }");
        }

        private static void DoWorkInMainThread()
        {
            for (int i = 1; i <= 4; i++)
            {
                Console.WriteLine("{0} run on main thread {1}",
                    i, Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(1_000);
            }
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