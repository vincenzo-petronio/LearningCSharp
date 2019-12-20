using System;

namespace _011_Tuple
{
    class AfterSevenDotThree
    {
        internal void Start()
        {
            // EQUALITY AND TUPLES
            var name = "Luca Bianchi";
            var id = 123456;
            var user1 = (Name: name, Id: id);
            var user2 = (Name: "Luca Bianchi", Id: 654321);
            // Da C# 7.3 è possibile usare == e != per comparare due Tuple.
            // La comparazione viene fatta confrontando uno ad uno i membri delle Tuple.
            Console.WriteLine($"[EQUALITY AND TUPLES]{Environment.NewLine}" +
                $"{user1.Name} is equal to {user2.Name}? => {user1 == user2}")
                ;
        }
    }
}
