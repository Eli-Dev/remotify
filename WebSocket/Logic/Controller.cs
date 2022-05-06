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

        public Controller()
        {
            Startup.MessageReceived += Startup_MessageReceived;
        }

        private void Startup_MessageReceived(object sender, MessageReceivedEventArgs e)
        {
            if (e.Message.Contains("mouse"))
            {
                ResponseEvent<MouseParameter> response = JsonSerializer.Deserialize<ResponseEvent<MouseParameter>>(e.Message);

                if (response.parameters.click == "left")
                {
                    mouse.LeftClick();
                } else if (response.parameters.click == "right")
                {
                    mouse.RightClick();
                }
                mouse.MoveCursor(response.parameters);
            }
            


        }

    }
}
