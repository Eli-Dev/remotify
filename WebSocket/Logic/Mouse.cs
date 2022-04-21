using System;
using System.Windows.Forms;
using System.Threading;
using Logic;

namespace MouseControl
{
    public class Mouse
    {
        private readonly Form1 cursor = new Form1();

        public void MoveCursor(MouseParameter parameters)
        {
            Console.WriteLine(Cursor.Position.X + " " + parameters.xDiff + " " + cursor.ScreenWidth);
            double xDiff = parameters.xDiff /* * cursor.ScreenWidth*/;
            double yDiff = parameters.yDiff /* * cursor.ScreenHeight*/;

            Cursor.Position = new System.Drawing.Point((int) (Cursor.Position.X + xDiff), (int) (Cursor.Position.Y + yDiff));

            //Thread.Sleep(1);
        }
    }
}
