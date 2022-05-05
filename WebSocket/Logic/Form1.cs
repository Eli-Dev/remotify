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
        private readonly Rectangle dimensions;

        public int ScreenWidth 
        { 
            get
            {
                return dimensions.Width;
            }
        }

        public int ScreenHeight
        {
            get
            {
                return dimensions.Height;
            }
        }

        public Form1()
        {
            dimensions = Screen.FromControl(this).Bounds;
        }

        [DllImport("user32.dll", EntryPoint = "SetCursorPos")]

        private static extern bool SetCursorPos(double xDiff, double yDiff);

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);


        public void Move(double xDiff, double yDiff)
        {
            SetCursorPos(xDiff, yDiff);
        }

        public const int MOUSEEVENTF_LEFTDOWN = 0x02;
        public const int MOUSEEVENTF_LEFTUP = 0x04;

        public const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        public const int MOUSEEVENTF_RIGHTUP = 0x10;

        public void LeftMouseClick(int xCurrentPos, int yCurrentPos)
        {
            mouse_event(MOUSEEVENTF_LEFTDOWN, xCurrentPos, yCurrentPos, 0, 0);
        }

        public void RightMouseClick(int xCurrentPos, int yCurrentPos)
        {
            mouse_event(MOUSEEVENTF_RIGHTDOWN, xCurrentPos, yCurrentPos, 0, 0);
            
        }

        public void LeftMouseRelease(int xCurrentPos, int yCurrentPos)
        {
            mouse_event(MOUSEEVENTF_LEFTUP, xCurrentPos, yCurrentPos, 0, 0);
        }

        public void RightMouseRelease(int xCurrentPos, int yCurrentPos)
        {
            mouse_event(MOUSEEVENTF_RIGHTUP, xCurrentPos, yCurrentPos, 0, 0);
        }

        
    }
}
