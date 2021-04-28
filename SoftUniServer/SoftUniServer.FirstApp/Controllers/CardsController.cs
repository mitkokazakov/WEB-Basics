using SoftUniServer.HTTP;
using SoftUniServer.MVC;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniServer.FirstApp.Controllers
{
    class CardsController : Controller
    {
        public HttpResponse Add(HttpRequest httpRequest)
        {
            return this.View();
        }

        public HttpResponse All(HttpRequest httpRequest)
        {
            return this.View();
        }

        public HttpResponse Collection(HttpRequest httpRequest)
        {
            return this.View();
        }


    }
}
