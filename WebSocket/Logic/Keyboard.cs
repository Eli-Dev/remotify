using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using WindowsInput.Native;
using WindowsInput;

namespace Logic
{
    public class Keyboard
    {
        static void Main(string[] args)
        {
            KeyboardInput();
        }

        public static void KeyboardInput()
        {
            while (true)
            {
                InputSimulator sim = new InputSimulator();
                VirtualKeyCode vCode = (VirtualKeyCode)0x52;
                sim.Keyboard.KeyPress(vCode);
                Thread.Sleep(200);
            }
        }
    }
}
