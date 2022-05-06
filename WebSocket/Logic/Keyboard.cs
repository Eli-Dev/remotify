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

        InputSimulator sim = new InputSimulator();
        KeysConverter converter = new KeysConverter();
        VirtualKeyCode vCode = new VirtualKeyCode();

        public void KeyboardInput(KeyboardParameter parameters)
        {   
            vCode = (VirtualKeyCode) converter.ConvertFromString(parameters.KeyInput);
            sim.Keyboard.KeyPress(vCode);
        }
    }
}
