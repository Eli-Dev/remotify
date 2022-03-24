using Logic;
using System;
using System.Threading;
using WebApplication;

namespace Testing
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread t = new Thread(Websocket.Start);
            t.Start();
            new Controller();
            Console.WriteLine("Alo");
            Console.ReadKey();
        }
    }
}
