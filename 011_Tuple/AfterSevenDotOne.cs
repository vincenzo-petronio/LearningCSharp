using System;

namespace _011_Tuple
{
    class AfterSevenDotOne
    {
        internal void Start()
        {
            // TUPLE LITERALS WITH INFERRED
            // Rispetto a C# 7 usando delle variabili con nome, 
            // è possibile omettere il nome del parametro nella definizione della Tupla.
            var Name = "Luca Bianchi";
            var Id = 123456;
            var user1 = (Name, Id); // Inferred tuple names (la variabile definisce anche il nome)
            var user2 = ("Luca Bianchi", 654321); // Inferred tuple names
            Console.WriteLine($"[TUPLE LITERALS WITH INFERRED]{Environment.NewLine}" +
                $"{user1.Name} is equal to {user2.Item1}? => {user1.CompareTo(user2)}")
                ;
        }
    }
}
