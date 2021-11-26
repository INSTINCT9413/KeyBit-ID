using System;
using System.Threading;

namespace KeyBit_ID.Classes
{
    class ThreadStarter
    {
        public void TSThread(Action methodName)
        {
            // Create a new instance of a thread with the methods name (methodName)
            Thread thread = new Thread(new ThreadStart(methodName));
            // Start the new thread
            thread.Start();
        }
    }
}
