using System;

namespace _001_ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Out.WriteLineAsync("Hello World!");
            Console.Write("Press any key to continue...");
            Console.ReadKey(true);
        }
    }
}
