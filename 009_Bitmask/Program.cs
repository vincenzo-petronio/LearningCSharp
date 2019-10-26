using StandardSharedCode;
using System;

namespace _009_Bitmask
{
    class Program
    {

        static void Main(string[] args)
        {
            const int Alignment = 16;

            Console.WriteLine("Bitmask & Enum with Flags!");

            // 0b_0000_0100 OR
            // 0b_0000_1000 =
            // 0b_0000_1100 = 12
            ColorEnum colorArancione = ColorEnum.Yellow | ColorEnum.Red;


            // 0b_0000_0100 OR 
            // 0b_0001_0000 OR 
            // 0b_0000_0010 = 
            // 0b_0001_0110 = 22
            ColorEnum colorVerdeChiaro = ColorEnum.Yellow | ColorEnum.Blue | ColorEnum.White;


            // 0b_0001_0111
            ColorEnum colorUnknown = (ColorEnum)23;


            // C# 6 
            // String interpolation https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/tokens/interpolated

            Console.WriteLine($"Valori nella variabile colorArancione: [{string.Join(", ", Enum.GetNames(colorArancione.GetType())),Alignment}]");
            Console.WriteLine(Environment.NewLine);

            Console.WriteLine(
                $"Colore creato: {EnumExtension.GetName(colorArancione),Alignment}" + Environment.NewLine +
                $"Il colore secondario è formato da due primari: {colorArancione,Alignment} | {(int)colorArancione,Alignment}" + Environment.NewLine +
                $"Contiene il verde? {colorArancione.HasFlag(ColorEnum.Blue | ColorEnum.Yellow),Alignment}" + Environment.NewLine +
                //$"Contiene il giallo? {,Alignment}" + Environment.NewLine +
                $"Contiene il giallo? {(colorArancione & ColorEnum.Yellow) == ColorEnum.Yellow}"
            );
            Console.WriteLine(Environment.NewLine);


            Console.WriteLine(
                $"Colore creato: {EnumExtension.GetName(colorVerdeChiaro),Alignment}" + Environment.NewLine +
                $"Contiene il verde? {colorVerdeChiaro.HasFlag(ColorEnum.Blue | ColorEnum.Yellow),Alignment}"
            );
            Console.WriteLine(Environment.NewLine);


            Console.WriteLine(
                $"Colore creato: {EnumExtension.GetName(colorUnknown),Alignment}" + Environment.NewLine +
                $"Il colore creato contiene i seguenti primari: {colorUnknown,Alignment}" + Environment.NewLine +
                $"Contiene il verde? {colorUnknown.HasFlag(ColorEnum.Blue | ColorEnum.Yellow),Alignment}" + Environment.NewLine +
                $"Contiene il rosso? {colorUnknown.HasFlag(ColorEnum.Red),Alignment}"
            );
            Console.WriteLine(Environment.NewLine);


            Utils.BloccaConsole();
        }
    }
}
