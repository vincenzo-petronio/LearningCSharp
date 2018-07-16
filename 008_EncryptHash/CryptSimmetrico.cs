using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace _008_EncryptHash
{
    class CryptSimmetrico
    {
        public CryptSimmetrico()
        {
            Encrypt();
        }


        private void Encrypt()
        {
            Console.WriteLine("Digita una password:");
            string password = Console.ReadLine();

            Console.WriteLine("Encrypt START");
            // chiavi da usare nel metodo di crypt
            byte[] salt = new UnicodeEncoding().GetBytes("SALT");
            Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, salt);
            //byte[] rgbKey = new UnicodeEncoding().GetBytes(password);
            //byte[] rgbIV = new UnicodeEncoding().GetBytes("HARDCODED_IV");

            // MANAGED algoritmo implementato in .NET nella forma Managed
            SymmetricAlgorithm crypthAlgo = new RijndaelManaged();
            crypthAlgo.Key = rfc2898DeriveBytes.GetBytes(crypthAlgo.KeySize / 8);
            crypthAlgo.IV = rfc2898DeriveBytes.GetBytes(crypthAlgo.BlockSize / 8);

            // CryptoStream
            ICryptoTransform cryptoTransform = crypthAlgo.CreateEncryptor();


            // File Output
            var filePathOutput = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                "CRYPT_SIMM"
            );

            // N.B. in questo modo posso dichiarare nested using
            using (FileStream fileStreamOutput = new FileStream(filePathOutput, FileMode.OpenOrCreate))
            using (CryptoStream cryptoStream = new CryptoStream(fileStreamOutput, cryptoTransform, CryptoStreamMode.Write))
            using (FileStream fileStreamInput = new FileStream("LoremIpsum.txt", FileMode.Open))
            {
                int data;
                while ((data = fileStreamInput.ReadByte()) != -1)
                {
                    cryptoStream.WriteByte((byte)data);
                }
            }

            Console.WriteLine("Encrypt END");
        }

        private void Decrypt()
        {

        }
    }
}
