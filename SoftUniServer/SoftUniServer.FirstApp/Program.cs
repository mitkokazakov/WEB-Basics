
using SoftUniServer.HTTP;
using System;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniServer.FirstApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            IHttpServer server = new HttpServer();

            server.AddRoute("/", HomePage);
            server.AddRoute("/about", AboutPage);
            server.AddRoute("/users/login", LoginPage);
            server.AddRoute("/users/register", LoginPage);

            await server.Start(80);

        }

        

        

        static HttpResponse LoginPage(HttpRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
