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
            //string html = File.ReadAllText("Views/Home/Home.html");

            //byte[] bodyResponseBytes = Encoding.UTF8.GetBytes(html);

            //HttpResponse httpResponse = new HttpResponse("text/html", bodyResponseBytes);

            return this.View("Views/Home/Home.html");
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
