using SoftUniServer.HTTP;
using SoftUniServer.MVC;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniServer.FirstApp.Controllers
{
    class HomeController : Controller
    {
        public HttpResponse HomePage(HttpRequest request)
        {
            string html = "<h1>Welcome in our SoftUni Server</h1>";

            byte[] bodyResponseBytes = Encoding.UTF8.GetBytes(html);

            HttpResponse httpResponse = new HttpResponse("text/html", bodyResponseBytes);

            return httpResponse;
        }

        public HttpResponse AboutPage(HttpRequest request)
        {
            string html = "<h1>About Us</h1>";

            byte[] bodyResponseBytes = Encoding.UTF8.GetBytes(html);

            HttpResponse httpResponse = new HttpResponse("text/html", bodyResponseBytes);

            return httpResponse;
        }
    }
}
