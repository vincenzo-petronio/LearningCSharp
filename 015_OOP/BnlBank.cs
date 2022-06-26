namespace _015_OOP
{
    internal class BnlBank : Bank
    {
        public virtual string Plan { get; set; }

        public BnlBank()
        {
            Plan = "Base";
        }


        public override void Hello()
        {
            pin = "123123123";
            Console.WriteLine($"Hello Bnl! Your pin: {pin}");
        }
    }
}
