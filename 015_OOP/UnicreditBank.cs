namespace _015_OOP
{
    /// <summary>
    /// Derived class.
    /// </summary>
    internal class UnicreditBank : Bank, IPay // a class can inherit a base class and also implment one or more interfaces
    {
        public decimal GetBalance()
        {
            return decimal.MaxValue;
        }

        public override void Hello() // implementation is provided by a method override
        {
            pin = "123456789";
            Console.WriteLine($"Hello Unicredit! Your pin: {pin}");
        }

    }
}
