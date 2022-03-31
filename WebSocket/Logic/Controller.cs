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
        public Controller()
        {
            Startup.MessageReceived += Startup_MessageReceived;
        }

        private void Startup_MessageReceived(object sender, MessageReceivedEventArgs e)
        {
            if (e.Message.Contains("mouse"))
            {
                ResponseEvent<MouseParameter> response = JsonSerializer.Deserialize<ResponseEvent<MouseParameter>>(e.Message);
                Console.WriteLine("XDIFF: " + response.parameters.xDiff);
                /*MouseParameter mouseParams = JsonSerializer.Deserialize<MouseParameter>(e.Message);
                Console.WriteLine("XDIFF: " + mouseParams.XDiff);*/
            }

            /*switch(e.Message)
            {
                case "mouse":
                    Console.WriteLine("Test");
                    ResponseEvent<MouseParameter> response = JsonSerializer.Deserialize<ResponseEvent<MouseParameter>>(e.Message);
                    Console.WriteLine("XDIFF: " + response.Param.XDiff);
                    break;

            }*/
        }

    }
}
