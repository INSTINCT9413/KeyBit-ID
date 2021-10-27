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
// This file is a basic struct that has one method
// The purpose of this file is to pause the thread
// but not hang the UI. 
//
#endregion

using System.Windows.Forms;

namespace KeyBit_ID.Structs
{
    struct Wait
    {
        // Time method that takes an int 
        public void Time(int Seconds)
        {
            // For loop
            // set i = 0, make a condition of i <= Seconds * 100
            // increase i until it reaches <= Seconds
            for (int i = 0; i <= Seconds * 100; i++)
            {
                // timeout the thread by 10 milliseconds
                System.Threading.Thread.Sleep(10);
                // then allow program to continue
                Application.DoEvents();
            }
        }
    }
}
