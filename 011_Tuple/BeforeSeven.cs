using StandardSharedCode;
using System;

namespace _011_Tuple
{
    /// <summary>
    /// Tuple in C# 4
    /// </summary>
    class BeforeSeven
    {
        internal void Start()
        {
            // E' possibile creare Tuple con un numero max di 8 elementi 
            var person = new Tuple<string, int>("Mario", 23);

            // Tupla definita con la classe Factory
            var anotherPerson = Tuple.Create<string, int>("Luca", 18);

            // Le proprietà Item1, Item2 etc non forniscono nessuna informazione
            // circa il contenuto o il tipo!!!
            Console.WriteLine($"person=[{person.Item1},{person.Item2}]");
            Console.WriteLine($"anotherPerson=[{anotherPerson.Item1},{anotherPerson.Item2}]");

            Utils.BloccaConsole();
        }
    }
}
