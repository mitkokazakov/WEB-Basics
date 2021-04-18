
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

            await server.Start(80);

        }

        static HttpResponse HomePage(HttpRequest request)
        {
            string html = "<h1>Welcome in our SoftUni Server</h1>";

            byte[] bodyResponseBytes = Encoding.UTF8.GetBytes(html);

            HttpResponse httpResponse = new HttpResponse("text/html", bodyResponseBytes);

            return httpResponse;
        }

        static HttpResponse AboutPage(HttpRequest request)
        {
            throw new NotImplementedException();
        }

        static HttpResponse LoginPage(HttpRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
