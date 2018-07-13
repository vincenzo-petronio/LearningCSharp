using StandardSharedCode;
using System;
using System.Diagnostics.Contracts;
using System.Globalization;
using System.IO;
using System.Linq;

namespace _007_Validation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Digita il tuo numero di telefono:");
            int telephoneNumber;
            bool ritenta = true;

            do
            {
                string stringNumber = string.Empty;

                try
                {
                    stringNumber = Console.ReadLine();

                    // Validazioni
                    if (string.IsNullOrWhiteSpace(stringNumber))
                    {
                        throw new ArgumentNullException("numero non inserito!");
                    }
                    if (stringNumber.Length > 10)
                    {
                        throw new ArgumentOutOfRangeException("numero troppo lungo!");
                    }

                    // Qui catturo due eccezioni, una lanciata da Any e l'altra generata a mano
                    // quando l'if non è valido.
                    try
                    {
                        if (stringNumber.Any(c => Char.IsLetter(c)))
                        {
                            throw new ArgumentException("caratteri non ammessi!");
                        }
                    }
                    catch (ArgumentException ae)
                    {
                        throw new ArgumentException(ae.Message);
                    }
                    //if (stringNumber.Any(c => Char.IsLetter(c)))
                    //{
                    //    throw new ArgumentException("caratteri non ammessi!");
                    //}


                    // Conversione
                    bool conversionSuccessfull = int.TryParse(stringNumber,
                                NumberStyles.Number,
                                CultureInfo.CurrentCulture,
                                out telephoneNumber);

                    // Validazioni Contract
                    //Contract.Requires<OperationException>(!conversionSuccessfull, "Conversione fallita!");
                    //Contract.EndContractBlock();

                    // Regex


                    ritenta = false;
                }
                catch (OperationException oe)
                {
                    Console.WriteLine(oe.Message);
                }
                catch (ArgumentNullException ane)
                {
                    Console.WriteLine(ane.Message);
                }
                catch (ArgumentOutOfRangeException aoure)
                {
                    Console.WriteLine(aoure.Message);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
                // @since C# 6
                catch (Exception e) when (e is IOException || e is OutOfMemoryException)
                {
                    // catch per catturare le eccezioni sul ReadLine()
                    Console.WriteLine(e.Message);
                }
            } while (ritenta);



            Utils.BloccaConsole();
        }
    }
}
