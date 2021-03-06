using MouseControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using WebApplication;

namespace Logic
{
    public class Controller
    {
        Mouse mouse = new Mouse();
        Keyboard keyboard = new Keyboard();
        ResponseEvent<MouseParameter> mouseResponse = new ResponseEvent<MouseParameter>();
        ResponseEvent<KeyboardParameter> keyboardResponse = new ResponseEvent<KeyboardParameter>();

        public Controller()
        {
            Startup.MessageReceived += Startup_MessageReceived;
        }

        private void Startup_MessageReceived(object sender, MessageReceivedEventArgs e)
        {
            Console.WriteLine(e.Message);
            if (e.Message.Contains("mouse"))
            {
                mouseResponse = JsonSerializer.Deserialize<ResponseEvent<MouseParameter>>(e.Message);

                if (mouseResponse.parameters.click == "left")
                {
                    mouse.LeftClick();
                } 
                else if (mouseResponse.parameters.click == "right")
                {
                    mouse.RightClick();
                }
                else if (mouseResponse.parameters.click.Contains("release left"))
                {
                    mouse.LeftRelease();
                    
                }
                else if (mouseResponse.parameters.click.Contains("release right"))
                {
                    mouse.RightRelease();
                }
                mouse.MoveCursor(mouseResponse.parameters);
            }
            if (e.Message.Contains("keyboard"))
            {
                keyboardResponse = JsonSerializer.Deserialize<ResponseEvent<KeyboardParameter>>(e.Message);

                if (keyboardResponse.parameters == null)
                {
                    keyboard.KeyboardInput(" ");
                }
                else
                {
                    keyboard.KeyboardInput(keyboardResponse.parameters.keyInput);
                }
            }
        }
    }
}
