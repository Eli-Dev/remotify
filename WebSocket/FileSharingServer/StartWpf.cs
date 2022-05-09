using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebApplication;

namespace FileSharingServer
{
    public static class StartWpf
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            //Thread t = new Thread(Websocket.Start);
            //t.Start();
            //Thread t1 = new Thread(() => new Controller());
            //t1.Start();
            Start();
        }
        public static void Start()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
