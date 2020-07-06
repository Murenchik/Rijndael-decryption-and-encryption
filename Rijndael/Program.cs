using System;

namespace Rijndael
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the text: ");
            string plainText = Console.ReadLine();

            string passPhrase = "TestPass"; // Can be any string
            string saltValue = "TestSalt"; // Can be any stribg
            string hashAlgorithm = "SHA256"; // Can be "MD5" and "SHA256"
            int passwordIterations = 2; // Can be any number
            string initVector = "!2A4zadsw@3469AM"; // Must be 16 bytes
            int keySize = 256;  // Can be 128 or 192

            Console.WriteLine(String.Format("Not cipher test: {0}", plainText));

            string cipherText = RijndaelAlg.Encrypt
            (
                plainText, passPhrase, saltValue, hashAlgorithm,
                passwordIterations, initVector, keySize
            );

            Console.WriteLine(String.Format("Cipher text: {0}", cipherText));

            plainText = RijndaelAlg.Decrypt
            (
                cipherText, passPhrase, saltValue, hashAlgorithm,
                passwordIterations, initVector, keySize
            );

            Console.WriteLine(String.Format("Decryption text: {0}", plainText));
            Console.ReadKey();
        }
    }
}

