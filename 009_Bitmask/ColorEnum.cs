using System;

namespace _009_Bitmask
{
    /// <summary>
    /// Rappresenta i colori primari.
    /// </summary>
    [Flags]
    public enum ColorEnum
    {
        // C# 7
        // Binary literals  https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/proposals/csharp-7.0/binary-literals 
        // Digit separators https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/proposals/csharp-7.0/digit-separators

        // C# 7.2 
        // Leading digit separator https://docs.microsoft.com/it-it/dotnet/csharp/language-reference/proposals/csharp-7.2/leading-separator
                
                    // BIN          // DEC      // HEX      // BIT-SHIFT
        None    =   0b_0000_0000,   // 0        // 0x_00    // 0
        Black   =   0b_0000_0001,   // 1        // 0x_01    // 1 << 0 
        White   =   0b_0000_0010,   // 2        // 0x_02    // 1 << 1
        Yellow  =   0b_0000_0100,   // 4        // 0x_04    // 1 << 2
        Red     =   0b_0000_1000,   // 8        // 0x_08    // 1 << 3
        Blue    =   0b_0001_0000    // 16       // 0x_10    // 1 << 4
    }
}
