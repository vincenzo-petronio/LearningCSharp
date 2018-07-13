using StandardSharedCode;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace _007_Validation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Digita il tuo numero di telefono:");

            bool ritenta = true;

            do
            {
                //ritenta = ValidaInput(Console.ReadLine());

                ritenta = ValidaInputWithAggregateException(Console.ReadLine());

            } while (ritenta);



            Utils.BloccaConsole();
        }

        private static bool ValidaInput(string input)
        {
            string stringNumber = string.Empty;
            int telephoneNumber;
            bool error = false;

            try
            {
                stringNumber = input;

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
                    if (stringNumber.Any(c => (Char.IsLetter(c) || Char.IsWhiteSpace(c))))
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
                //bool conversionSuccessfull = int.TryParse(stringNumber,
                //               NumberStyles.Number,
                //               CultureInfo.CurrentCulture,
                //               out telephoneNumber);
                telephoneNumber = int.Parse(stringNumber,
                          NumberStyles.Number,
                          CultureInfo.CurrentCulture);

                // Validazioni Contract  ... 
                // D'OHHHH!!! i Contract lanciano un'eccezione non catturabile...  
                //Contract.Requires<OperationException>(!conversionSuccessfull, "Conversione fallita!");
                //Contract.EndContractBlock();


                error = false;
            }
            catch (OperationException oe)
            {
                Console.WriteLine(oe.Message);
                error = true;
            }
            catch (ArgumentNullException ane)
            {
                Console.WriteLine(ane.Message);
                error = true;
            }
            catch (ArgumentOutOfRangeException aoure)
            {
                Console.WriteLine(aoure.Message);
                error = true;
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
                error = true;
            }
            catch (FormatException fe)
            {
                Console.WriteLine(fe.Message);
                error = true;
            }
            // @since C# 6
            catch (Exception e) when (e is IOException || e is OutOfMemoryException)
            {
                // catch per catturare le eccezioni sul ReadLine()
                Console.WriteLine(e.Message);
                error = true;
            }

            return error;
        }

        /// <summary>
        /// AggregateException tutta la vita!!!
        /// </summary>
        /// <returns></returns>
        /// <exception cref="AggregateException">AggregateException</exception>
        /// <see cref="https://stackoverflow.com/questions/16921984/stop-visual-studio-from-breaking-on-exception-in-tasks"/>
        private static bool ValidaInputWithAggregateException(string input)
        {
            bool error = false;
            List<Task> taskList = new List<Task>();
            taskList.Add(Task.Factory.StartNew(() =>
            {
                Console.WriteLine($"Task {Thread.CurrentThread.Name} with ID #{Thread.CurrentThread.ManagedThreadId}");
                ValidateInputAsTask(input);
            }));
            taskList.Add(Task.Factory.StartNew(() =>
            {
                Console.WriteLine($"Task {Thread.CurrentThread.Name} with ID #{Thread.CurrentThread.ManagedThreadId}");
                ConvertInputAsTask(input);
            }));
            taskList.Add(Task.Factory.StartNew(() =>
            {
                Console.WriteLine($"Task {Thread.CurrentThread.Name} with ID #{Thread.CurrentThread.ManagedThreadId}");
                ValidateWithRegex(input);
            }));


            try
            {
                Task.WaitAll(taskList.ToArray());

                error = false;
            }
            catch (AggregateException ae)
            {
                Console.WriteLine("AggregateException catched!");
                error = true;

                //foreach (Exception e in ae.Flatten().InnerExceptions)
                //{
                //    // @see Flatten https://exceptionalcode.wordpress.com/2010/05/31/introducing-the-aggregateexception/
                //    Console.WriteLine(e.Message);
                //}

                ae.Handle(e =>
                {
                    Console.WriteLine("AggregateException handled: " + e.Message);
                    return true;
                });
            }

            return error;
        }

        private static void ValidateInputAsTask(string input)
        {
            string stringNumber = string.Empty;

            stringNumber = input;

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
                if (stringNumber.Any(c => (Char.IsLetter(c) || Char.IsWhiteSpace(c))))
                {
                    throw new ArgumentException("caratteri non ammessi!");
                }
            }
            catch (ArgumentException ae)
            {
                throw ae;
            }
        }

        private static void ConvertInputAsTask(string input)
        {
            string stringNumber = string.Empty;
            stringNumber = input;

            try
            {
                int telephoneNumber = int.Parse(stringNumber,
                              NumberStyles.Number,
                              CultureInfo.CurrentCulture);
            }
            catch
            {
                throw;
            }
        }

        private static void ValidateWithRegex(string input)
        {

            // Ammessi solo digit
            if (Regex.IsMatch(input, "^\\D*$"))
            {
                throw new ArgumentException("caratteri non ammessi dalla regex!");
            }

            try
            {
                // Più di 4 digit uguali consecutivi non ammessi
                Match match = Regex.Match(input, "([0-9])\\1{4}");
                if(match.Success)
                {
                    throw new OperationException("caratteri ripetuti non ammessi dalla regex!");
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
