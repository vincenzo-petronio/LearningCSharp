using System;

namespace _011_Tuple
{
    class AfterSeven
    {
        internal void Start()
        {
            // TUPLE LITERALS
            var name = "Luca Bianchi";
            var id = 123456;
            var user1 = (Name: name, Id: id);
            var user2 = (Name: "Luca Bianchi", Id: 654321);
            Console.WriteLine($"[TUPLE LITERALS]{Environment.NewLine}" +
                $"{user1.Name} is equal to {user2.Name}? => {user1.CompareTo(user2)}")
                ;


            Console.WriteLine($"[TUPLE RETURN TYPE]{Environment.NewLine}" +
                $"{CreateUser().Name} " +       // named tupla
                $"{CreateUser().Id} " +         // named tupla
                $"{CreateUser().Item3.ToShortDateString()}")    // unnamed tupla
                ;


            Console.WriteLine($"[TUPLE WITHOUT SYNTACTIC SUGAR]{Environment.NewLine}" +
                $"{CreateUserWithoutSugar().Item1} " +       // unnamed tupla
                $"{CreateUserWithoutSugar().Item2} " +         // unnamed tupla
                $"{CreateUserWithoutSugar().Item3.ToShortDateString()}")    // unnamed tupla
                ;


            var fakeUser = new FakeUser();
            var (username, identity) = fakeUser;
            Console.WriteLine($"[DECONSTRUCT TUPLE]{Environment.NewLine}" +
                $"{username} " +
                $"{identity} ")
                ;
        }

        // TUPLE RETURN TYPE
        // E' possibile associare un nome al tipo (named Tuple)
        // oppure utilizzare la versione unnamed ed utilizzare il dato con Item1, Item2, etc
        (string Name, int Id, DateTime) CreateUser()
        {
            return ("Mario Rossi", 456789, DateTime.Now);
        }

        // TUPLE WITHOUT SYNTACTIC SUGAR
        // Tutti gli elementi named o unnamed sono una rappresentazione comoda, ma a runtime 
        // quello che resta è ValueTuple, infatti il metodo può essere riscritto senza zucchero!
        ValueTuple<string, int, DateTime> CreateUserWithoutSugar()
        {
            return new ValueTuple<string, int, DateTime>("Alberto Rossi", 123789, DateTime.Now);
        }

        // DECONSTRUCT TUPLE
        private class FakeUser
        {
            private string Name => "Salvatore Esposito";
            private int Id => 55566;

            public void Deconstruct(out string name, out int id)
            {
                name = Name;
                id = Id;
            }
        }
    }
}
