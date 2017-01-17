using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace Minor.Dag52.Decryptography
{
    public class Decryptor
    {
        public static void Main(string[] args)
        {
            Decrypt(args[0], args[1]);
        }
        public static void Decrypt(string path, string password)
        {
            byte[] IV = new byte[16];
            byte[] salt = new byte[16];
            byte[] key = new byte[16];

            using (FileStream inputStream = File.OpenRead(path))
            using (BinaryReader reader = new BinaryReader(inputStream))
            {
                IV = reader.ReadBytes(16);
                salt = reader.ReadBytes(16);
                    
                var hasher = new Rfc2898DeriveBytes(password, salt);
                key = hasher.GetBytes(16);

                using (Aes algorithm = Aes.Create())
                using (FileStream outputStream = File.Create(path))
                using (CryptoStream encryptedStream = new CryptoStream(
                    outputStream,
                    algorithm.CreateDecryptor(key, IV),
                    CryptoStreamMode.Write))
                using (StreamWriter writer = new StreamWriter(encryptedStream))
                {
                    writer.WriteLine(IV);
                    writer.WriteLine(salt);

                    int pos = 0;
                    int length = (int)encryptedStream.Length;

                    while (pos < length)
                    {
                        writer.WriteLine(reader.ReadBytes(16));
                        pos += 16;
                    }
                }
            }
            Console.WriteLine("You have been decrypted.");
        }
    }
}
