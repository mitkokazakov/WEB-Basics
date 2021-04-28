
using SoftUniServer.FirstApp.Controllers;
using SoftUniServer.HTTP;
using System;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using SoftUniServer.MVC;

namespace SoftUniServer.FirstApp
{
    public class Program
    {
        public static async Task Main(string[] args)
        {

            await Host.RunAsync(new Startup());

        }

        
    }
}
