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
//  This file is a basic struct that has a property and
//  a single method. The main purpose of this file is
//  to pass a string (URL) and open it via Process.Start()
//
#endregion

namespace KeyBit_ID.Structs
{
    struct OpenLink
    {
        // property that gets and sets the string of URI
        public string URI { get; set; }

        // Method that can be called
        public void OpenURL()
        {
            // decalare a string and make it equal to URI property
            string URL = URI;
            // execute the string, since it will be a URL
            // this should open in the users default browser
            System.Diagnostics.Process.Start(URL);
        }
    }
}
