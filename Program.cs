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
//  This file is the main entry point of the entire program
//  In the Main() class, the program will create either a
//  new Legal or new MainWindow form depending on a saved
//  setting. First time running the program, Legal form
//  will always be displayed, then after the MainWindow
//
#endregion
using KeyBit_ID.Forms;
using KeyBit_ID.Properties;
using System;
using System.Windows.Forms;

namespace KeyBit_ID
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // if statement, checks if a setting is set to true
            // if it is set to true then show MainWindow
            if (Settings.Default.RunFirstTime == true)
            {
                // setting is true so create a new MainWindow
                Application.Run(new MainWindow());
            }
            else
            {
                // setting is false so create a new Legal
                Application.Run(new Legal());
            }
        }
    }
}
