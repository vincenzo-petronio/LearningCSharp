using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Xml;

namespace _008_EncryptHash
{
    class CryptAsimmetrico
    {
        private byte[] cipherText;

        public CryptAsimmetrico()
        {
            Encrypt();

            Decrypt();
        }

        private void Encrypt()
        {
            Console.WriteLine("Encrypt START");

            // PlainText
            byte[] plainTextInputBytes;
            using (FileStream fileStreamInput = new FileStream("LoremIpsum.txt", FileMode.Open))
            using (StreamReader fileStreamReaderInput = new StreamReader(fileStreamInput))
            {
                var plainTextInput = fileStreamInput.ToString();
                plainTextInputBytes = new UnicodeEncoding().GetBytes(plainTextInput);
            }

            // RSA Algo
            using (var crypthAlgo = new RSACryptoServiceProvider(2048))
            {
                RSAParameters publicKeyParameter = crypthAlgo.ExportParameters(false);
                var publicKeyString = GetStringFromRSAParameter(publicKeyParameter);
                Console.WriteLine($"publicKeyString=[{publicKeyString}]");

                // Le chiavi in RSA possono essere definite in 3 formati, tra cui l'XML.
                //crypthAlgo.FromXmlString(publicKeyString.ToString());
                FromXmlString(crypthAlgo, publicKeyString.ToString());
                var cryptData = crypthAlgo.Encrypt(plainTextInputBytes, true);
                var cryptDataBase64 = Convert.ToBase64String(cryptData);
                crypthAlgo.PersistKeyInCsp = false;

                cipherText = cryptData;

                Console.WriteLine(Environment.NewLine);
                Console.WriteLine($"Encrypted data in base64 format=[{cryptDataBase64}]");
            }

            Console.WriteLine("Encrypt END");
        }

        private void Decrypt()
        {
            Console.WriteLine("Decrypt START");

            var cryptData = cipherText;
                //Convert.FromBase64String(cipherText);

            // RSA Algo
            using (var crypthAlgo = new RSACryptoServiceProvider(2048))
            {
                RSAParameters privateKeyParameter = crypthAlgo.ExportParameters(true);
                var privateKeyString = GetStringFromRSAParameter(privateKeyParameter);
                Console.WriteLine($"privateKeyString=[{privateKeyString}]");

                FromXmlString(crypthAlgo, privateKeyString.ToString());
                var decryptData = crypthAlgo.Decrypt(cryptData, true);
                var decryptDataString = UnicodeEncoding.UTF8.GetString(cryptData);
                crypthAlgo.PersistKeyInCsp = false;

                Console.WriteLine(Environment.NewLine);
                Console.WriteLine($"Decrypted data=[{decryptDataString.ToString()}]");
            }

            Console.WriteLine("Decrypt END");
        }

        private string GetStringFromRSAParameter(RSAParameters param)
        {
            using (var stringWriter = new StringWriter())
            {
                var xmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(RSAParameters));
                xmlSerializer.Serialize(stringWriter, param);
                Console.WriteLine($"RSAParameter=[{stringWriter.ToString()}]");
                return stringWriter.ToString();
            }
        }

        /// <summary>
        /// In .net Core 2 il metodo RSA.FromXmlString non esiste, quindi è necessario crearlo a mano.
        /// </summary>
        /// <param name="rsa"></param>
        /// <param name="xmlString"></param>
        private void FromXmlString(RSA rsa, string xmlString)
        {
            RSAParameters parameters = new RSAParameters();

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xmlString);

            if (xmlDoc.DocumentElement.Name.Equals("RSAParameters"))
            {
                foreach (XmlNode node in xmlDoc.DocumentElement.ChildNodes)
                {
                    switch (node.Name)
                    {
                        case "Modulus": parameters.Modulus = (string.IsNullOrEmpty(node.InnerText) ? null : Convert.FromBase64String(node.InnerText)); break;
                        case "Exponent": parameters.Exponent = (string.IsNullOrEmpty(node.InnerText) ? null : Convert.FromBase64String(node.InnerText)); break;
                        case "P": parameters.P = (string.IsNullOrEmpty(node.InnerText) ? null : Convert.FromBase64String(node.InnerText)); break;
                        case "Q": parameters.Q = (string.IsNullOrEmpty(node.InnerText) ? null : Convert.FromBase64String(node.InnerText)); break;
                        case "DP": parameters.DP = (string.IsNullOrEmpty(node.InnerText) ? null : Convert.FromBase64String(node.InnerText)); break;
                        case "DQ": parameters.DQ = (string.IsNullOrEmpty(node.InnerText) ? null : Convert.FromBase64String(node.InnerText)); break;
                        case "InverseQ": parameters.InverseQ = (string.IsNullOrEmpty(node.InnerText) ? null : Convert.FromBase64String(node.InnerText)); break;
                        case "D": parameters.D = (string.IsNullOrEmpty(node.InnerText) ? null : Convert.FromBase64String(node.InnerText)); break;
                    }
                }
            }
            else
            {
                throw new Exception("Invalid XML RSA key.");
            }

            rsa.ImportParameters(parameters);
        }

    }
}
