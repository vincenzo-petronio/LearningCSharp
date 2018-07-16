using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace _008_EncryptHash
{
    /// <summary>
    /// Crea un algoritmo simmetrico di crittografia, e utilizzando la password fornita
    /// dall'utente sulla console esegue un crypt e descrypt di un file di testo.
    /// Non sono gestite, per semplicità, Exception e Task.
    /// </summary>
    class CryptSimmetrico
    {
        public CryptSimmetrico()
        {
            Encrypt();
            Decrypt();
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
            using (StreamWriter fileStreamWriterOutput = new StreamWriter(cryptoStream))
            using (FileStream fileStreamInput = new FileStream("LoremIpsum.txt", FileMode.Open))
            using (StreamReader fileStreamReaderInput = new StreamReader(fileStreamInput))
            {
                // A )
                //int data;
                //while ((data = fileStreamInput.ReadByte()) != -1)
                //{
                //    cryptoStream.WriteByte((byte)data);
                //}


                // B ) utilizzo StreamReader/StreamWriter
                fileStreamWriterOutput.Write(fileStreamReaderInput.ReadToEnd());

            }

            Console.WriteLine("Encrypt END");
        }

        private void Decrypt()
        {
            Console.WriteLine("Digita la password utilizzata per cifrare il testo:");
            string password = Console.ReadLine();

            Console.WriteLine("Decrypt START");

            byte[] salt = new UnicodeEncoding().GetBytes("SALT");
            Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, salt);

            SymmetricAlgorithm crypthAlgo = new RijndaelManaged();
            crypthAlgo.Key = rfc2898DeriveBytes.GetBytes(crypthAlgo.KeySize / 8);
            crypthAlgo.IV = rfc2898DeriveBytes.GetBytes(crypthAlgo.BlockSize / 8);

            ICryptoTransform cryptoTransform = crypthAlgo.CreateDecryptor();

            // File Input / CipherText
            var filePathInput = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                "CRYPT_SIMM"
            );
            // File Output / PlainText
            var filePathOutput = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                "DECRYPT_SIMM"
            );

            using (FileStream fileStreamInput = new FileStream(filePathInput, FileMode.Open))
            using (CryptoStream cryptoStream = new CryptoStream(fileStreamInput, cryptoTransform, CryptoStreamMode.Read))
            using (StreamReader fileStreamReaderInput = new StreamReader(cryptoStream))
            using (FileStream fileStreamOutput = new FileStream(filePathOutput, FileMode.Create))
            using (StreamWriter fileStreamWriterOutput = new StreamWriter(fileStreamOutput))
            {
                fileStreamWriterOutput.Write(fileStreamReaderInput.ReadToEnd());
            }

            Console.WriteLine("Decrypt END");
        }
    }
}
