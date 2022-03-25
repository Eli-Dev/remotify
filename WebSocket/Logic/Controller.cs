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
            //ResponseEvent<MouseParameter>? response = JsonSerializer.Deserialize<ResponseEvent<MouseParameter>>(txt);
            Console.WriteLine(e.Message);
        }

    }
}
