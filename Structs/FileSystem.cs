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
//  This file is a struct has basic filesystem methods in it
//  Contains two methods, one to check if a director is empty
//  the other method returns the file name of the account
//
#endregion
using System.IO;
using System.Linq;

namespace KeyBit_ID.Structs
{
    struct FileSystem
    {
        // Method that accepts a string and returns a bool
        public bool IsDirectoryEmpty(string path)
        {
            // return if there is not any file system entries
            return !Directory.EnumerateFileSystemEntries(path).Any();
        }
        // Method that accepts a string
        public string Account(string file)
        {
            // return that string
            return Account(file);
        }

    }
}
