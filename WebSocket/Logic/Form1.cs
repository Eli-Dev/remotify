using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MouseControl
{
    public class Form1 : Form
    {
        [DllImport("user32.dll", EntryPoint = "SetCursorPos")]
        private static extern bool SetCursorPos(double xDiff, double yDiff, double xVelocity, double yVelocity);

        

        public void Move(double xDiff, double yDiff, double xVelocity, double yVelocity)
        {
            SetCursorPos(xDiff, yDiff, xVelocity, yVelocity);
        }
    }
}
