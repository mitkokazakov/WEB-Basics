
using SoftUniServer.HTTP;
using System.Net;

namespace SoftUniServer.FirstApp
{
    class Program
    {
        static void Main(string[] args)
        {
            IHttpServer server = new HttpServer();

            server.AddRoute("/", HomePage);
            server.AddRoute("/about", AboutPage);
            server.AddRoute("/users/login", LoginPage);

            server.Start();

        }

        static HttpResponse HomePage(HttpRequest request)
        { 

        }

        static HttpResponse AboutPage(HttpRequest request)
        {

        }

        static HttpResponse LoginPage(HttpRequest request)
        {

        }
    }
}
