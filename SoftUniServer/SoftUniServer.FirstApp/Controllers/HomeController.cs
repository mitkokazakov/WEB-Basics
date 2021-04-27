using SoftUniServer.HTTP;
using SoftUniServer.MVC;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SoftUniServer.FirstApp.Controllers
{
    class HomeController : Controller
    {
        public HttpResponse Home(HttpRequest request)
        {
           
            return this.View("Home");
        }

        public HttpResponse About(HttpRequest request)
        {
            string html = "<h1>About Us</h1>";

            byte[] bodyResponseBytes = Encoding.UTF8.GetBytes(html);

            HttpResponse httpResponse = new HttpResponse("text/html", bodyResponseBytes);

            return httpResponse;
        }
    }
}
