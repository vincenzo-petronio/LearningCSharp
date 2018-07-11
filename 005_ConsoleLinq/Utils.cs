using System;
using System.Collections.Generic;

namespace _005_ConsoleLinq
{
    static class Utils
    {

        public enum Seme { Cuori, Quadri, Fiori, Picche }

        public enum Valore { Due = 2, Tre, Quattro, Cinque, Sei, Sette, Otto, Nove, Dieci, Fante, Regina, Re, Asso }

        public static IEnumerable<T> LogData<T>(this IEnumerable<T> sequence, string data)
        {
            Console.WriteLine($"LogData: {data}");
            foreach (var c in sequence)
            {
                Console.WriteLine(c.ToString());
            };
            return sequence;
        }

        public static IEnumerable<T> Mescola<T>(this IEnumerable<T> sup, IEnumerable<T> inf)
        {
            var supIter = sup.GetEnumerator();
            var infIter = inf.GetEnumerator();

            while (supIter.MoveNext() && infIter.MoveNext())
            {
                yield return supIter.Current;
                yield return infIter.Current;
            }
        }

    }
}
