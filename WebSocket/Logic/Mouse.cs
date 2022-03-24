using System;
using System.Windows.Forms;
using System.Threading;
using Logic;

namespace MouseControl
{
    public class Mouse
    {
        public void MoveCursor(MouseParameter parameters)
        {
            Form1 cursor = new Form1();

            while (true)
            {
                cursor.Move(parameters.xDiff, parameters.yDiff);
                Thread.Sleep(100);
            }
        }
    }
}
