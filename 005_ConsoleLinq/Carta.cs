namespace _005_ConsoleLinq
{
    class Carta
    {
        public Utils.Seme Seme { get; set; }
        public Utils.Valore Valore { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="seme">enum</param>
        /// <param name="valore">enum</param>
        public Carta(Utils.Seme seme, Utils.Valore valore)
        {
            this.Seme = seme;
            this.Valore = valore;
        }


        /// <summary>
        /// Da C# 6 è possible usare i membri con corpo di espressione
        /// </summary>
        /// <see cref="https://docs.microsoft.com/it-it/dotnet/csharp/programming-guide/statements-expressions-operators/expression-bodied-members"/>
        /// <returns></returns>
        public override string ToString() => $"Carta {Valore} di {Seme}";

        //public override string ToString()
        //{
        //    return $"Carta {Valore} di {Seme}";
        //}
    }
}
