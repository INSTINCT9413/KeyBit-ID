using KeyBit_ID.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KeyBit_ID.Classes
{
    class ThreadStarter
    {
        public void TSThread(Action methodName)
        {
            Thread thread = new Thread(new ThreadStart(methodName));
            thread.Start();
        }
    }
}
