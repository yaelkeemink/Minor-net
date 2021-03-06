﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace Minor.Dag52.Encryption
{
    public class Encryptor
    {
        public static void Main(string[] args)
        {
            //byte[] key = { 0x01, 0x23, 0x45, 0x67, 0x89, 0x23, 0x45, 0x67, 0x89, 0xAB, 0xAB, 0xCD, 0xEF, 0x01, 0xCD, 0xEF };
            //byte[] IV = { 0x67, 0x89, 0xAB, 0xAB, 0xCD, 0x01, 0x23, 0x45, 0x67, 0x89, 0x23, 0x45, 0xEF, 0x01, 0xCD, 0xEF };

            if (args.Length != 2)
            {
                Console.WriteLine("usage: dotnet Encrypt <<file name>> <<password>>");
            }

            byte[] IV = new byte[16];
            byte[] salt = new byte[16];
            RandomNumberGenerator rng = RandomNumberGenerator.Create();
            rng.GetBytes(IV);
            rng.GetBytes(salt);
            string password = "geheim";
            Rfc2898DeriveBytes hasher = new Rfc2898DeriveBytes(password, salt);
            byte[] key = hasher.GetBytes(16);

            using (FileStream inputStream = File.OpenRead(@"Encryptor.cs"))
            using (StreamReader reader = new StreamReader(inputStream))
            {
                using (Aes algorithm = Aes.Create())
                using (FileStream outputStream = File.Create(@"..\Encryptor.bin"))
                using (CryptoStream encryptedStream = new CryptoStream(
                    outputStream,
                    algorithm.CreateEncryptor(key, IV),
                    CryptoStreamMode.Write))
                using (StreamWriter writer = new StreamWriter(encryptedStream))
                {
                    writer.Write(reader.ReadToEnd());
                }
            }
            Console.WriteLine("You have been encrypted.");
        }
    }
}
