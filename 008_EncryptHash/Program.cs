using StandardSharedCode;
using System;

namespace _008_EncryptHash
{
    class Program
    {
        static void Main(string[] args)
        {
            // NON supportata su Win10
            //Console.WriteLine("EX: File.Encrypt and File.Decrypt");
            //FileEnc fileEnc = new FileEnc();
            //fileEnc.TryToEncrypt();
            //fileEnc.TryToDecrypt();


            // Symmetric Encryption
            //CryptSimmetrico crypt = new CryptSimmetrico();


            // Asymmetric Encryption
            CryptAsimmetrico crypt = new CryptAsimmetrico();


            Utils.BloccaConsole();
        }
    }
}
