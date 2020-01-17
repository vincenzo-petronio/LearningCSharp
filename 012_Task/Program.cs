using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace _012_Task
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Start....");

            Stopwatch sw = Stopwatch.StartNew();

            Works.RunSequencial();
            sw.Stop();
            Console.WriteLine($"Time Elapsed: {sw.ElapsedMilliseconds} {Environment.NewLine}");

            sw.Restart();
            Works.RunWithThreads();
            sw.Stop();
            Console.WriteLine($"Time Elapsed: {sw.ElapsedMilliseconds} {Environment.NewLine}");

            sw.Restart();
            Works.RunWithPoolThreads();
            sw.Stop();
            Console.WriteLine($"Time Elapsed: {sw.ElapsedMilliseconds} {Environment.NewLine}");

            sw.Restart();
            Works.RunTasks();
            sw.Stop();
            Console.WriteLine($"Time Elapsed: {sw.ElapsedMilliseconds} {Environment.NewLine}");

            sw.Restart();
            Works.RunTasksAsync().GetAwaiter().GetResult();
            sw.Stop();
            Console.WriteLine($"Time Elapsed: {sw.ElapsedMilliseconds} {Environment.NewLine}");


            if (Debugger.IsAttached)
            {
                Console.WriteLine($"End....");
                Console.ReadKey(true);
            }
        }
    }
}
