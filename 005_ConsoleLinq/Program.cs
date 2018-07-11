using System;
using System.Collections.Generic;
using System.Linq;
using static _005_ConsoleLinq.Utils;

namespace _005_ConsoleLinq
{
    class Program
    {
        private static IEnumerable<Seme> Semi() => Enum.GetValues(typeof(Seme)) as IEnumerable<Seme>;
        private static IEnumerable<Valore> Valori() => Enum.GetValues(typeof(Valore)) as IEnumerable<Valore>;


        static void Main(string[] args)
        {
            var mazzoDiCarteOrdinate = (from s in Semi()
                                        from v in Valori()
                                        select new Carta(s, v)
                               ).ToArray();

            foreach (Carta c in mazzoDiCarteOrdinate)
            {
                Console.WriteLine(c.ToString());
            };


            var superiore = mazzoDiCarteOrdinate.Take(26).LogData("Metà superiore presa");
            var inferiore = mazzoDiCarteOrdinate.TakeLast(26).LogData("Metà inferiore presa");

            //superiore = from c in superiore orderby c.Valore descending select c;

            //var mazzoDiCarteMescolate = (from c in superiore.ElementAt(new Random().Next(superiore.Count())) 
            //                            from inf
            //                            )

            var mazzoDiCarteMescolate = superiore.Mescola(inferiore).LogData("Mescolata....");

            Console.Write(Environment.NewLine);
            Console.Write("Press any key to continue...");
            Console.ReadKey(true);
        }
    }
}
