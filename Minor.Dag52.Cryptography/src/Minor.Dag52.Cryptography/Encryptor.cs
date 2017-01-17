using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Minor.Dag52.Cryptography
{
    public class Encryptor
    {
        public static void Main(string[] args)
        {
            Encrypt(args[0], args[1]);
        }
        public static void Encrypt(string path, string password)
        {
            byte[] IV = new byte[16];
            byte[] salt = new byte[16];
            byte[] key = new byte[16];
            var rng = RandomNumberGenerator.Create();           
            rng.GetBytes(IV);
            rng.GetBytes(salt);

            var hasher = new Rfc2898DeriveBytes(password, salt);
            key = hasher.GetBytes(16);

            using (FileStream inputStream = File.OpenRead(path))
            using (BinaryReader reader = new BinaryReader(inputStream))
            {
                using (FileStream outputStream = File.Create(path))
                {
                    using (StreamWriter writer = new StreamWriter(outputStream, Encoding.UTF8, 32, true))
                    {
                        writer.WriteLine(IV);
                        writer.WriteLine(salt);
                    }

                    using (Aes algorithm = Aes.Create())
                    using (CryptoStream encryptedStream = new CryptoStream(
                        outputStream,
                        algorithm.CreateEncryptor(key, IV),
                        CryptoStreamMode.Write))
                    using (StreamWriter writer = new StreamWriter(encryptedStream))
                    {
                        int pos = 0;
                        int length = (int)encryptedStream.Length;

                        while (pos < length)
                        {
                            writer.WriteLine(reader.ReadBytes(16));
                            pos += 16;
                        }
                    }
                }
            }
            Console.WriteLine("You have been encrypted.");
        }
    }
}
