using StandardSharedCode;
using System;

namespace _011_Tuple
{
    class Program
    {
        static void Main(string[] args)
        {
            BeforeSeven beforeSeven = new BeforeSeven();
            beforeSeven.Start();

            SetSpaces();

            AfterSeven afterSeven = new AfterSeven();
            afterSeven.Start();

            SetSpaces();

            AfterSevenDotOne afterSevenDotOne = new AfterSevenDotOne();
            afterSevenDotOne.Start();

            SetSpaces();

            AfterSevenDotThree afterSevenDotThree = new AfterSevenDotThree();
            afterSevenDotThree.Start();

            Utils.BloccaConsole();

            // LOCAL FUNCTIONS
            void SetSpaces()
            {
                for (int i = 1; i < 3; i++)
                {
                    Console.WriteLine(Environment.NewLine);
                }
            }
        }
    }
}
