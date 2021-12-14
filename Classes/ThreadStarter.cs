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
// This class contains the logic to create new instances of a thread,
// provide any method name to run it as a new thread
//
#endregion
using System;
using System.Threading;

namespace KeyBit_ID.Classes
{
    class ThreadStarter
    {
        public ThreadStarter()
        {

        }
        public void TSThread(Action methodName)
        {
            // Create a new instance of a thread with the methods name (methodName)
            Thread thread = new Thread(new ThreadStart(methodName));
            // Start the new thread
            thread.Start();
        }
    }
}
