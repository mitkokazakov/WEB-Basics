using SoftUniServer.HTTP;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniServer.MVC
{
    public static class Host
    {
        public static async Task RunAsync(List<Route> routeTable)
        {
            IHttpServer server = new HttpServer(routeTable);

            await server.Start(80);
        }
    }
}
