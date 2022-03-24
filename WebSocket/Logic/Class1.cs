using System;
using System.Windows.Forms;
using System.Threading;

namespace MouseControl
{
    public class Class1
    {
        public void MoveCursor(int x, int y)
        {
            Form1 cursor = new Form1();

            while (true)
            {
                cursor.Move(x, y);
                x++;
                y++;
                Thread.Sleep(100);
            }
        }
    }
}
