using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using NetFwTypeLib;
using System;

namespace WebApplication
{
    public class Websocket
    {
        public static void Main(string[] args)
        {
            Start();
        }

        public static void Start()
        {
            

            CreateHostBuilder(new string[0]).Build().Run();
        }

        private static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    webBuilder.UseUrls($"http://{Utility.GetLocalIPAddress()}:5000");
                });
    }
}
