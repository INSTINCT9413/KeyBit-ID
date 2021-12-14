#region Header Block
//  About this Program
//  
//  Programmer:     Jacob Brookhouse
//  Class:          CITP 280 - 70591
//  Application:    KeyBit ID - Password Manager
//  Description:    KeyBit ID is a password manager that allows a user to save sensitive
//                  information, such as passwords and account information.
//
#endregion
#region About this file
//
// This class contains the logic to encrypt and decrypt files, specifically the account file
// This class has many methods.
//
#endregion
using System;
using System.IO;
using System.Management;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace KeyBit_ID.Classes
{
    // inherits UserID
    internal class UserIDEncrypt : UserID
    {

        // this is the encryption key which will never change
        // right now its just something simple but should be 
        // a jumble of numbers
        public const string KEY = "89898989";
        public static string Key { get; set; }

        // instantiate a new ManagementObjectSearcher and set it to search for the motherboard
        readonly ManagementObjectSearcher HWID = new ManagementObjectSearcher("Select * From Win32_BaseBoard");

        // a string to store where the accounts path is located
        public static string DataLocation = Application.StartupPath + @"\data\accounts\";
        // enumeration that selects between encryption and decryption operations
        public enum CryptoOperation
        {
            ENCRYPT,
            DECRYPT
        };
        public UserIDEncrypt()
        {

        }
        // Method for getting the motherboard serial number
        public string GetHWID()
        {
            // foreach  ManagementObject in HWID
            foreach (ManagementObject getID in HWID.Get())
            {
                // set Key to the serial number, since we selected Win32_BaseBoard
                // it will only return one serial number which should be the motherboards
                Key = getID["SerialNumber"].ToString();
            }
            // return Key
            return Key;
        }
        // method to choose the tpye of crypto operation
        public byte[] DESCrypto(CryptoOperation cryptoOperation, byte[] IV, byte[] key, byte[] message)
        {
            // create new crypto provider and while using it
            using (var DES = new DESCryptoServiceProvider())
            {
                // assign the crypto provider with the required info to encrypt/decrypt
                DES.IV = IV; // assign initialization vector
                DES.Key = key; // assign key
                DES.Mode = CipherMode.CBC; // assign the cipher type
                DES.Padding = PaddingMode.PKCS7; // assign the padding type

                // create new MemoryStream and while using it
                using (var memStream = new MemoryStream())
                {
                    // create a cryptostream
                    CryptoStream cryptoStream = null;
                    // if the enum is Encrypt then encrypt
                    if (cryptoOperation == CryptoOperation.ENCRYPT)
                        // assign the crypto stream to a new cryptostream with the data to encrypt
                        cryptoStream = new CryptoStream(memStream, DES.CreateEncryptor(), CryptoStreamMode.Write);
                    // else if the enum is Decrypt then decrypt
                    else if (cryptoOperation == CryptoOperation.DECRYPT)
                        // assign the crypto stream to a new cryptostream with the data to decrypt
                        cryptoStream = new CryptoStream(memStream, DES.CreateDecryptor(), CryptoStreamMode.Write);
                    // if the stream is null
                    if (cryptoStream == null)
                        // return null
                        return null;
                    // write the block of bytes 
                    cryptoStream.Write(message, 0, message.Length);
                    // end stream and clear buffer 
                    cryptoStream.FlushFinalBlock();
                    //return the MemoryStream as an array
                    return memStream.ToArray();
                }
            }
        }

        // Encrypt method
        public void EncryptFile(string filePath, string key)
        {
            // create new byte array and set it to a files bytes
            byte[] plainContent = File.ReadAllBytes(filePath);
            // create a new crypto provider and while using it
            using (var DES = new DESCryptoServiceProvider())
            {
                // set the crypto provider with the necessary info to encrypt the file
                DES.IV = Encoding.UTF8.GetBytes(key);
                DES.Key = Encoding.UTF8.GetBytes(key);
                DES.Mode = CipherMode.CBC;
                DES.Padding = PaddingMode.PKCS7;

                // create a new MemoryStream and while using it
                using (var memStream = new MemoryStream())
                {
                    // create new CryptoStream, set it with the required info, then write
                    CryptoStream cryptoStream = new CryptoStream(memStream, DES.CreateEncryptor(),
                        CryptoStreamMode.Write);
                    // write the block of bytes
                    cryptoStream.Write(plainContent, 0, plainContent.Length);
                    // end stream and clear buffer
                    cryptoStream.FlushFinalBlock();
                    // write to the file 
                    File.WriteAllBytes(filePath, memStream.ToArray());

                }
            }
        }
        // Decrypt method
        public void DecryptFile(string filePath, string key)
        {
            // create new byte array and set it to a files bytes
            byte[] encrypted = File.ReadAllBytes(filePath);
            // create a new crypto provider and while using it
            using (var DES = new DESCryptoServiceProvider())
            {
                // set the crypto provider with the necessary info to decrypt the file
                DES.IV = Encoding.UTF8.GetBytes(key);
                DES.Key = Encoding.UTF8.GetBytes(key);
                DES.Mode = CipherMode.CBC;
                DES.Padding = PaddingMode.PKCS7;

                // create a new MemoryStream and while using it
                using (var memStream = new MemoryStream())
                {
                    // create new CryptoStream, set it with the required info, then write
                    CryptoStream cryptoStream = new CryptoStream(memStream, DES.CreateDecryptor(),
                        CryptoStreamMode.Write);
                    // write the block of bytes
                    cryptoStream.Write(encrypted, 0, encrypted.Length);
                    // end of stream and clear buffer
                    cryptoStream.FlushFinalBlock();
                    // write  to the file
                    File.WriteAllBytes(filePath, memStream.ToArray());

                }
            }
        }

        // Method to create random byte array
        public byte[] GenerateRandomByteArray(int size)
        {
            // make new random
            var random = new Random();
            // create new byte array that takes a size as int
            byte[] byteArray = new byte[size];
            // fill the array with random bytes
            random.NextBytes(byteArray);
            // return the array
            return byteArray;
        }
        // method to create the initialization vector
        public byte[] GenerateIv()
        {
            // create new byte array and call the method GenerateRandomByteArray with the size set to 8
            byte[] IV = GenerateRandomByteArray(8);
            // return the initialization vector
            return IV;
        }
        // method to generate the key
        public byte[] GenerateKey()
        {
            // create new byte array and call the method GenerateRandomByteArray with the size set to 8
            byte[] key = GenerateRandomByteArray(8);
            // return the key
            return key;
        }

    }
}
