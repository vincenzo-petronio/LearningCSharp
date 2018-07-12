using System;
using System.Linq;
using System.Numerics;
using System.Reflection;

namespace _006_Reflection
{
    class Program
    {
        static void Main(string[] args)
        {
            // Un po' di info sui tipi:

            BigInteger bigInteger = new BigInteger();

            // Tipo a compile-time
            Type type1 = typeof(BigInteger);

            // Tipo a run-time
            Type type2 = bigInteger.GetType();
            Console.WriteLine($"type1={type1}");
            Console.WriteLine($"type2={type2.Name},{type2.Assembly}");

            // Creare istanze di un oggetto, presente in un assembly diverso. Ci sono diversi modi:
            // A)
            Assembly assembly = Assembly.Load(type2.Assembly.FullName);
            Type[] assemblyTypes = assembly.GetTypes();
            Type assemblyType = assemblyTypes.Single(t => t.Name.Equals(type1.Name));
            var bigInteger1 = Activator.CreateInstance(assemblyType);
            Console.WriteLine($"bigInteger1={bigInteger1}");
            // B)
            BigInteger bigInteger2 = Activator.CreateInstance<BigInteger>();
            Console.WriteLine($"bigInteger2={bigInteger2}");
            // C) Prendo il costruttore che accetta Int32 come parametro, poi creo l'istanza
            var costruttoreBigInteger3 = assemblyType.GetConstructor(new Type[] { typeof(Int32) });
            var bigInteger3 = costruttoreBigInteger3.Invoke(new object[] { 45 });
            var methodIsZero = assemblyType.GetMethod("get_IsZero");
            Console.WriteLine($"bigInteger3={bigInteger3}");

            // Verifico il return di un metodo per tutti e 3 gli oggetti BigInteger.
            // Solo l'ultimo 
            var valueMethodIsZero1 = methodIsZero.Invoke(bigInteger1, null);
            Console.WriteLine($"bigInteger1.IsZero={valueMethodIsZero1}");
            var valueMethodIsZero2 = methodIsZero.Invoke(bigInteger2, null);
            Console.WriteLine($"bigInteger2.IsZero={valueMethodIsZero2}");
            var valueMethodIsZero3 = methodIsZero.Invoke(bigInteger3, null);
            Console.WriteLine($"bigInteger3.IsZero={valueMethodIsZero3}");


            BloccaConsole();
        }

        private static void BloccaConsole()
        {
            Console.Write("Press any key to continue...");
            Console.ReadKey(true);
        }
    }
}
