namespace _015_OOP
{
    internal interface IPay : IPayBase // an interface can inherit from one or more base interfaces
    {

        /// <summary>
        /// Saldo
        /// </summary>
        /// <returns>decimal</returns>
        decimal GetBalance();
    }
}
