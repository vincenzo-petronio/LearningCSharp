using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace _003_ConsoleReadQuotes
{
    class Program
    {
        static void Main(string[] args)
        {
            // nel Main non potendo usare il modificatore async come firma del metodo 
            // devo utilizzare Wait(). Da C# 7.1 è possibile invece utilizzare async/await.
            RunPrompt().Wait();
        }

        private static async Task RunPrompt()
        {
            var config = new PromptConfig();

            var showTask = ShowPrompt(config);
            var quotesTask = GetSpeed(config);

            await Task.WhenAll(showTask, quotesTask);
        }

        private static async Task ShowPrompt(PromptConfig config)
        {
            var words = ReadFrom("quotes.txt");
            foreach (string w in words)
            {
                Console.Write(w);
                if (!String.IsNullOrWhiteSpace(w))
                {
                    await Task.Delay(config.DelayInMs);
                }
            }
        }

        private static async Task GetSpeed(PromptConfig config)
        {
            Action work = () =>
            {
                do
                {
                    var key = Console.ReadKey(true);
                    if (key.KeyChar == '+')
                        config.UpdateDelay(-50);
                    else if (key.KeyChar == '-')
                        config.UpdateDelay(50);
                } while (!config.GetDone());
            };
            await Task.Run(work);
        }

        private static IEnumerable<string> ReadFrom(string fileName)
        {
            string line;
            using (var reader = File.OpenText(fileName))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    //yield return line;
                    var words = line.Split(' ');
                    foreach (string word in words)
                    {
                        yield return word + " ";
                    }

                    // Usare questo invece di \n !!!
                    yield return Environment.NewLine;
                }
            }
        }
    }
}
