using System;
using System.IO;
using System.Text;

namespace _008_EncryptHash
{
    /// <summary>
    /// Utilizza il metodo in System.IO.File per fare Encrypt e Decrypt basati sull'account.<para/>
    /// Il Decrypt funziona solo se si utilizza lo stesso account utilizzato per l'Encrypt.
    /// </summary>
    class FileEnc
    {
        private const string DATA = "You can do anything, but not everything";
        private const string FILENAME = "data_encrypted";
        private string FilePath { get; set; }

        public FileEnc()
        {
            FilePath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                FILENAME
            );
            File.WriteAllText(FilePath, DATA);
        }

        public void TryToEncrypt()
        {

            File.Encrypt(FilePath);

            using (var reader = File.OpenText(FilePath))
            {
                while (!string.IsNullOrEmpty(reader.ReadLine()))
                {
                    Console.WriteLine(reader.ReadLine());
                }
            }
        }


        public void TryToDecrypt()
        {
            File.Decrypt(FilePath);

            using (var reader = File.OpenText(FilePath))
            {
                while (!string.IsNullOrEmpty(reader.ReadLine()))
                {
                    Console.WriteLine(reader.ReadLine());
                }
            }
        }
    }
}
