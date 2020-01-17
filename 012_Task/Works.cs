using System;
using System.Threading;
using System.Threading.Tasks;

namespace _012_Task
{
    static class Works
    {
        /// <summary>
        /// Esegue le operazioni in modo sequenziale su un singolo thread
        /// </summary>
        internal static void RunSequencial()
        {
            Console.WriteLine("RunSequencial");
            double result = 0d;

            result += DoIOBound();
            result += DoCPUBound();

            Console.WriteLine($"The result is {result.ToString()} !");
        }

        /// <summary>
        /// Esegue l'operazione I/O su un thread secondario e procede
        /// con l'esecuzione dell'operazione CPU Bound.
        /// </summary>
        internal static void RunWithThreads()
        {
            Console.WriteLine("RunWithThreads");
            double result = 0d;

            var threadForIoOperation = new Thread(() => { result += DoIOBound(); });
            threadForIoOperation.Start();

            // Avendo più cpu/core/vCPU l'operazione CPU Bound viene eseguita mentre
            // l'operazione I/O Bound è in esecuzione su un altro thread.
            var resultFromCpuOperation = DoCPUBound();

            threadForIoOperation.Join();
            result += resultFromCpuOperation;

            Console.WriteLine($"The result is {result.ToString()} !");
        }

        /// <summary>
        /// Esegue l'operazione IO su un thread fornito dal ThreadPool.
        /// </summary>
        internal static void RunWithPoolThreads()
        {
            Console.WriteLine("RunWithPoolThreads");
            double result = 0d;

            ThreadPool.QueueUserWorkItem((x) =>
            {
                result += DoIOBound();
            });

            var resultFromCpuOperation = DoCPUBound();

            // FIXME nel ThreadPool non c'è un modo per aspettare il risultato,
            // ma in questo caso l'operazione IO dura meno della successiva quindi
            // il flusso di esecuzione garantisce il risultato corretto.

            result += resultFromCpuOperation;

            Console.WriteLine($"The result is {result.ToString()} !");
        }

        /// <summary>
        /// Esegue le due operazioni su due task separati.
        /// </summary>
        internal static void RunTasks()
        {
            Console.WriteLine("RunTasks");
            // C# 4 
            // Task.Factory.StartNew

            // C# 4.5
            // Task.Run 


            double result = 0d;
            Task<double>[] tasks = new Task<double>[2];
            tasks[0] = Task.Run(() => DoCPUBound());
            tasks[1] = Task.Run(() => DoIOBound());

            // Ridondante, perché il Result successivo già blocca l'esecuzione
            // in attesa del risultato, quindi nel foreach garantisce l'attesa 
            // di tutti i Task.
            //Task.WaitAll(tasks);

            foreach (Task<double> t in tasks)
            {
                // N.B. Result è bloccante!
                result += t.Result;
            }

            Console.WriteLine($"The result is {result.ToString()} !");
        }

        internal static Task RunTasksAsync()
        {
            Console.WriteLine("RunTasksAsync");
            double result = 0d;

            Task<double>[] tasks = new Task<double>[2];
            tasks[0] = DoIOBoundAsync();
            tasks[1] = DoCPUBoundAsync();

            Task.WaitAll(tasks);

            foreach (Task<double> t in tasks)
            {
                result += t.Result;
            }

            Console.WriteLine($"The result is {result.ToString()} !");

            return Task.CompletedTask;
        }

        static double DoIOBound()
        {
            Console.WriteLine($"IO thread: {Thread.CurrentThread.ManagedThreadId.ToString()}");
            Thread.Sleep(2000); // simula una operazione I/O
            return 100d;
        }

        static double DoCPUBound()
        {
            Console.WriteLine($"CPU thread: {Thread.CurrentThread.ManagedThreadId.ToString()}");
            int maxInt = Int32.MaxValue;
            double result = 100000d;
            for (int i = 1; i < maxInt; i++)
            {
                result /= i;
            }
            return result;
        }

        async static Task<double> DoIOBoundAsync()
        {
            Console.WriteLine($"IO thread: {Thread.CurrentThread.ManagedThreadId.ToString()}");
            await Task.Delay(2000); // simula una operazione I/O
            return 100d;
        }

        static Task<double> DoCPUBoundAsync()
        {
            Console.WriteLine($"CPU thread: {Thread.CurrentThread.ManagedThreadId.ToString()}");
            int maxInt = Int32.MaxValue;
            double result = 100000d;
            for (int i = 1; i < maxInt; i++)
            {
                result /= i;
            }
            return Task.FromResult(result);
        }
    }
}
