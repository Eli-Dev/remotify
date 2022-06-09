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
        VirtualKeyCode vCode = new VirtualKeyCode();

        bool isCapital = false;

        public void KeyboardInput(string parameters)
        {
            if (parameters == " ") 
            {
                sim.Keyboard.KeyPress(VirtualKeyCode.SPACE);
            }
            else if (parameters.Length == 1)
            {
                if (char.IsUpper(parameters[0]))
                {
                    sim.Keyboard.KeyPress(VirtualKeyCode.CAPITAL);
                    isCapital = true;
                }

                vCode = Enum.Parse<VirtualKeyCode>("VK_" + parameters, true);
                sim.Keyboard.KeyPress(vCode);

                if (isCapital)
                {
                    isCapital = false;
                    sim.Keyboard.KeyPress(VirtualKeyCode.CAPITAL);
                }
            }
            else
            {
                vCode = Enum.Parse<VirtualKeyCode>(parameters, true);
                sim.Keyboard.KeyPress(vCode);
            }
        }
    }
}
