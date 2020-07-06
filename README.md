# Rijndael-decryption-and-encryption

This programm writed on C# using OOP pricipals for decryption and encryption data through symetric key.

Key paramets:
 - keySize (lenght of key ciphered in bits, valid values is 128, 192 and 256);
 - passPhrase (phrase which will be outputed pseudo-random password and this phrase will be using for 
 creation of key cipher, phrase can be any string);
 - initVector (this parametr needed to cipher of first data block, for RijndaelManaged class IV 
 lenght must be 16 ASCII symbols);
 - saltValue (value of salt using together with passPhrase for creation of password, 
 salt can be any string);
 - hashAlgorithm (hashing algorithm , using for generate a password, admissiblе "SHA256", "MD5").
 
More information about Rijndael decryption algorithm: 
https://blog.finjan.com/rijndael-encryption-algorithm/#:~:text=Mechanics%20of%20the%20Rijndael%20Encryption,those%20of%20their%20respective%20keys.
https://docs.microsoft.com/en-us/dotnet/api/system.security.cryptography.rijndael?view=netcore-3.1

GitHub:
https://github.com/Murenchik
