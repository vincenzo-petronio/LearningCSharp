using System;

namespace _002_ConsoleAppNetCore
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = string.Empty;
            DateTime date = DateTime.Now;

            do
            {
                Console.WriteLine("Digita il tuo nome...");
                name = Console.ReadLine();
                date = DateTime.Now;
            } while (!UtilsLibraries.StringUtils.IsFirstCharUpper(name));

            /// String interpolation
            /// <see cref="https://docs.microsoft.com/it-it/dotnet/csharp/language-reference/tokens/interpolated"/>
            /// @since C# 6
            Console.WriteLine($"Ciao {name}, la data è: {date:d} , {date:t}");

            Console.Write("Press any key to continue...");
            Console.ReadKey(true);
        }
    }
}
