using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.IO;


namespace Rijndael
{
    public class RijndaelAlg
    {
        public static string Encrypt(string yourText, string password, string saltValue,
            string hashAlgorithm, int passwordIteration, string initializationVector, int keySize)
        {
            byte[] initializationVectorBytes = Encoding.ASCII.GetBytes(initializationVector); // Transformation strings in byte massive
            byte[] saltValueBytes = Encoding.ASCII.GetBytes(saltValue);

            byte[] yourTextBytes = Encoding.UTF8.GetBytes(yourText); // Transformation open text to byte massive

            PasswordDeriveBytes password1 = new PasswordDeriveBytes(password, saltValueBytes,
                hashAlgorithm, passwordIteration); // Creation password with passPhrase and SaltValue, creation with hasg alg (SHA256 or MD5)

            byte[] keyBytes = password1.GetBytes(keySize / 8); // Key size

            RijndaelManaged symmetricKey = new RijndaelManaged(); // Create not initialize object of Rijndael cipher
            symmetricKey.Mode = CipherMode.CBC;

            ICryptoTransform encryptor = symmetricKey.CreateEncryptor(keyBytes, initializationVectorBytes); // Creation ecryptor from byte key and initVector

            MemoryStream memoryStream = new MemoryStream();

            CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);

            cryptoStream.Write(yourTextBytes, 0, yourTextBytes.Length); // Start of cipher 

            cryptoStream.FlushFinalBlock(); // Cipher last part 

            byte[] cipherTextBytes = memoryStream.ToArray(); // Transformation encrypted data from MemoryStream to byte massive

            memoryStream.Close();
            cryptoStream.Close();

            string cipherText = Convert.ToBase64String(cipherTextBytes); // Transformation encrypted data to string (encoding base64)

            return cipherText;
        }

        public static string Decrypt(string cipherText, string passPhrase, string saltValue, string hashAlgorithm,
        int passwordIterations, string initVector, int keySize)
        {
            byte[] initializationVectorBytes = Encoding.ASCII.GetBytes(initVector); // Transformation strings in byte massive
            byte[] saltValueBytes = Encoding.ASCII.GetBytes(saltValue);

            byte[] cipherTextBytes = Convert.FromBase64String(cipherText); // Transformation open text to byte massive

            PasswordDeriveBytes password1 = new PasswordDeriveBytes(passPhrase, saltValueBytes,
                hashAlgorithm, passwordIterations); // Creation password with passPhrase and SaltValue, creation with hasg alg (SHA256 or MD5)

            byte[] keyBytes = password1.GetBytes(keySize / 8); // Key size

            RijndaelManaged symmetricKey = new RijndaelManaged(); // Create not initialize object of Rijndael cipher
            symmetricKey.Mode = CipherMode.CBC;

            ICryptoTransform decryptor = symmetricKey.CreateDecryptor(keyBytes, initializationVectorBytes); // Creation ecryptor from byte key and initVector

            MemoryStream memoryStream = new MemoryStream(cipherTextBytes);

            CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read); // Spot Cryptographic stream

            byte[] plainTextbytes = new byte[cipherTextBytes.Length];

            int decryptedBytes = cryptoStream.Read(plainTextbytes, 0, plainTextbytes.Length); // Start of decryption

            memoryStream.Close();
            cryptoStream.Close();

            string plainText = Encoding.UTF8.GetString(plainTextbytes, 0, decryptedBytes); // Transformation encrypted data to string

            return plainText;
        }
    }
}


