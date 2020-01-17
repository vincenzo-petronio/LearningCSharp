using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace _013_Task
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_Clear(object sender, RoutedEventArgs e)
        {
            this.UI_Log.Items.Clear();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            // Sono operazioni sequenziali di tipo IO e CPU Bound che 
            // bloccano la UI perché in esecuzione sullo stesso thread!!!
            DoCPUBound();
            DoIOBound(500);
            DoIOBound(1000);
            DoCPUBound();
            DoIOBound(1500);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            // Lo stesso codice viene ora eseguito in un thread differente,
            // preso dal thread-pool. La UI è responsiva ed è possibile 
            // eseguire N volte il click, eseguendo di fatto i task in parallelo!
            Task.Run(() => DoCPUBound());
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            // Anche in questo caso la UI è bloccata, perché vengono eseguiti
            // tutti nello stesso Thread.
            var t1 = DoCPUBoundAsync();
            var t2 = DoIOBoundAsync(1500);
            var t3 = DoIOBoundAsync(500);
        }

        private async void Button_Click_4(object sender, RoutedEventArgs e)
        {
            // Il task viene eseguito su un thread del thread-pool, ma l'esecuzione continua!
            Task.Run(() => DoCPUBoundAsync());

            // I 4 task iniziano in parallelo e in modo asincrono vengono risolti
            // a seconda dei tempi che impiegano. L'esecuzione termina quando il task
            // più "lento" viene eseguito, quindi 6 secondi!
            var t1 = DoIOBoundAsync(4500);
            var t2 = DoIOBoundAsync(2500);
            var t3 = DoIOBoundAsync(6000);
            var t4 = DoIOBoundAsync(1800);

            Task[] tasks = new Task[] { t1, t2, t3, t4 };
            await Task.WhenAll(tasks);
            UI_Log.Items.Add($"All IO threads awaited");
        }

        private async void Button_Click_5(object sender, RoutedEventArgs e)
        {
            // Il task viene eseguito su un thread del thread-pool, ma l'esecuzione continua!
            Task.Run(() => DoCPUBoundAsync());

            // Come il caso precedente, ma mettendo await prima di fatto vengono eseguiti
            // in cascata uno alla volta, perdendo il parallelismo.
            await DoIOBoundAsync(4500);
            await DoIOBoundAsync(2500);
            await DoIOBoundAsync(6000);
            await DoIOBoundAsync(1800);
            UI_Log.Items.Add($"All IO threads awaited");
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            //Viene eseguito tutto in sequenza in modo bloccante.

            var message1 = DoIOBoundBlockingAsync(1500).Result;
            UI_Log.Items.Add(message1);

            var message2 = DoIOBoundBlockingAsync(2800).GetAwaiter().GetResult();
            UI_Log.Items.Add(message2);
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            // ################## DEADLOCK! ##################
            // I Metodi Wait(), GetResult() e Result sono attese bloccanti
            // perché l'esecuzione avviene in modo sincrono.
            // Inoltre è una attesa sincrona che avviene nel thread della UI
            // mentre nel metodo il Dispatcher tenta di accedere anch'esso alla UI, quindi
            // avviene un deadlock e la UI è bloccata.
            DoIOBoundDeadlockAsync(1500).Wait();
            DoIOBoundDeadlockAsync(2800).GetAwaiter().GetResult();
        }


        private void DoIOBound(int delayTimeMs)
        {
            var currentThread = Thread.CurrentThread.ManagedThreadId.ToString();
            Stopwatch sw = Stopwatch.StartNew();

            // Dispatcher.InvokeAsync serve per ritornare sul thread della UI!
            Dispatcher.InvokeAsync(() =>
                UI_Log.Items.Add($"Start IO thread: {currentThread}")
            );
            Thread.Sleep(delayTimeMs);
            sw.Stop();
            Dispatcher.InvokeAsync(() =>
                UI_Log.Items.Add($"End IO thread: {currentThread} in {sw.ElapsedMilliseconds.ToString()} ms")
            );
        }

        private void DoCPUBound()
        {
            var currentThread = Thread.CurrentThread.ManagedThreadId.ToString();
            Stopwatch sw = Stopwatch.StartNew();

            Dispatcher.InvokeAsync(() =>
                UI_Log.Items.Add($"Start CPU thread: {currentThread}")
            );
            int maxInt = Int32.MaxValue;
            double result = 10000d;
            for (int i = 1; i < maxInt; i++)
            {
                result /= i;
            }
            sw.Stop();
            Dispatcher.InvokeAsync(() =>
                UI_Log.Items.Add($"End CPU thread: {currentThread} in {sw.ElapsedMilliseconds.ToString()} ms")
            );
        }

        private Task DoCPUBoundAsync()
        {
            // If you CAN write it without await, then you SHOULD write it without await, 
            // and remove the async keyword from the method. 
            // A non-async method returning Task.FromResult is more efficient than an 
            // async method returning a value!

            var currentThread = Thread.CurrentThread.ManagedThreadId.ToString();
            Stopwatch sw = Stopwatch.StartNew();

            Dispatcher.InvokeAsync(() =>
                UI_Log.Items.Add($"Start CPU thread: {currentThread}")
            );
            int maxInt = Int32.MaxValue;
            double result = 10000d;
            for (int i = 1; i < maxInt; i++)
            {
                result /= i;
            }
            sw.Stop();
            Dispatcher.InvokeAsync(() =>
                UI_Log.Items.Add($"End CPU thread: {currentThread} in {sw.ElapsedMilliseconds.ToString()} ms")
            );

            return Task.CompletedTask;
        }

        private async Task DoIOBoundAsync(int delayTimeMs)
        {
            var currentThread = Thread.CurrentThread.ManagedThreadId.ToString();
            Stopwatch sw = Stopwatch.StartNew();

            await Dispatcher.InvokeAsync(() =>
                UI_Log.Items.Add($"Start IO thread: {currentThread}")
            );
            await Task.Delay(delayTimeMs);
            sw.Stop();
            await Dispatcher.InvokeAsync(() =>
                UI_Log.Items.Add($"End IO thread: {currentThread} in {sw.ElapsedMilliseconds.ToString()} ms")
            );
        }

        private async Task DoIOBoundDeadlockAsync(int delayTimeMs)
        {
            var currentThread = Thread.CurrentThread.ManagedThreadId.ToString();
            Stopwatch sw = Stopwatch.StartNew();

            await Dispatcher.InvokeAsync(() =>
                // DEADLOCK
                UI_Log.Items.Add($"Start IO thread: {currentThread}")
            );
            await Task.Delay(delayTimeMs);
            sw.Stop();
            await Dispatcher.InvokeAsync(() =>
               UI_Log.Items.Add($"End IO thread: {currentThread} in {sw.ElapsedMilliseconds.ToString()} ms")
            );

            //return Task.CompletedTask;
        }

        private Task<string> DoIOBoundBlockingAsync(int delayTimeMs)
        {
            var currentThread = Thread.CurrentThread.ManagedThreadId.ToString();
            Stopwatch sw = Stopwatch.StartNew();
            Task.Delay(delayTimeMs).Wait();
            sw.Stop();

            return Task.FromResult($"End IO thread: {currentThread} in {sw.ElapsedMilliseconds.ToString()} ms");
        }


    }
}
